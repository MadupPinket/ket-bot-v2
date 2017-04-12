using KetBot.Tools.Mongo2DocDB.Data;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetBot.Tools.Mongo2DocDB
{
    class Program
    {
        // ADD THIS PART TO YOUR CODE
        private const string EndpointUrl = "https://ketbot.documents.azure.com:443/";
        private const string PrimaryKey = "MLAhQHjeeLaoQ9n1ZzKCMQCc5UDciPll7TIStFVaFv61FI2uPoP9La5Cm1bsHFYnjk6vs6zqXVzkcDwXTdd9GQ==";

        static void Main(string[] args)
        {
            // ADD THIS PART TO YOUR CODE
            try
            {
                MongoClient mongoclient = new MongoClient(ConfigurationManager.AppSettings["MongoDBConnectionString"]);
                IMongoDatabase ketbotdb = mongoclient.GetDatabase(ConfigurationManager.AppSettings["MongoDBDatabase"]);
                IMongoCollection<MongoDBModel> answers = ketbotdb.GetCollection<MongoDBModel>(ConfigurationManager.AppSettings["MongoDBCollection"]);

                DocumentClient client = new DocumentClient(new Uri(EndpointUrl), PrimaryKey);


                var documents = answers.Find(_ => true).ToList();

                foreach(var doc in documents)
                {
                    var newdoc = new Data.DocumentDBModel
                    {
                        answer = doc.Answer,
                        attachments = doc.attachments,
                        id = doc.ID,
                        intent = doc.Intent,
                        keywords = doc.Keywords,
                        title = doc.Title
                    };

                    Task.Run(async () =>
                    {
                        await client.UpsertDocumentAsync(UriFactory.CreateDocumentCollectionUri("KetbotDB", "KetbotAnswer"), newdoc);
                    }).GetAwaiter().GetResult();
                    
                }
                Console.WriteLine("done");
            }
            catch (DocumentClientException de)
            {
                Exception baseException = de.GetBaseException();
                Console.WriteLine("{0} error occurred: {1}, Message: {2}", de.StatusCode, de.Message, baseException.Message);
            }
            catch (Exception e)
            {
                Exception baseException = e.GetBaseException();
                Console.WriteLine("Error: {0}, Message: {1}", e.Message, baseException.Message);
            }
            finally
            {
                Console.WriteLine("End of demo, press any key to exit.");
                Console.ReadKey();
            }
        }

       
    }
}
