using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Newtonsoft.Json;
using System.Configuration;
using System.Net;

namespace KetBot.Data.InsertTool
{
    public class DocumentDbManager
    {
        private readonly string endpointUrl = ConfigurationManager.AppSettings["EndPointUrl"];
        private readonly string authorizationKey = ConfigurationManager.AppSettings["AuthorizationKey"];
        private readonly string databaseId = ConfigurationManager.AppSettings["DatabaseId"];
        private readonly string collectionId = ConfigurationManager.AppSettings["CollectionId"];

        private DocumentClient client;
        private Uri collectionLink;

        public DocumentDbManager()
        {
            client = new DocumentClient(new Uri(endpointUrl), authorizationKey);
            //ensure the database & collection exist before running samples
            Init();
            collectionLink = UriFactory.CreateDocumentCollectionUri(databaseId, collectionId);
        }

        private void Init()
        {
            GetOrCreateDatabaseAsync(databaseId).Wait();
            GetOrCreateCollectionAsync(databaseId, collectionId).Wait();
        }

        public async Task<HttpStatusCode> Upsert(KetBotDocument item)
        {
            var response = await client.UpsertDocumentAsync(collectionLink, item);
            return response.StatusCode;
        }

        private async Task<DocumentCollection> GetOrCreateCollectionAsync(string databaseId, string collectionId)
        {
            var databaseUri = UriFactory.CreateDatabaseUri(databaseId);

            DocumentCollection collection = client.CreateDocumentCollectionQuery(databaseUri)
                .Where(c => c.Id == collectionId)
                .AsEnumerable()
                .FirstOrDefault();

            if (collection == null)
            {
                collection = await client.CreateDocumentCollectionAsync(databaseUri, new DocumentCollection { Id = collectionId });
            }

            return collection;
        }

        private async Task<Database> GetOrCreateDatabaseAsync(string databaseId)
        {
            var databaseUri = UriFactory.CreateDatabaseUri(databaseId);

            Database database = client.CreateDatabaseQuery()
                .Where(db => db.Id == databaseId)
                .ToArray()
                .FirstOrDefault();

            if (database == null)
            {
                database = await client.CreateDatabaseAsync(new Database { Id = databaseId });
            }

            return database;
        }
    }
}
