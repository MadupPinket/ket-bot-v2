using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;
using System.Configuration;

namespace KetBot.Data.Repositories
{
    public class MongoSession : ISession
    {
        protected IMongoClient _client;
        protected IMongoDatabase _database;
        private string collectionName;

        public MongoSession()
        {
            //this looks for a connection string in your Web.config
            //<connectionStrings>
            //  <add name="db" connectionString="mongodb://localhost/testdb?strict=true"/>
            //</connectionStrings>
            _client = new MongoClient(ConfigurationManager.AppSettings["MongoDBConnectionString"]);
            _database = _client.GetDatabase(ConfigurationManager.AppSettings["KetbotDB"]);
            collectionName = ConfigurationManager.AppSettings["KetbotAnswer"];
        }

        public IQueryable<T> All<T>() where T : class, new()
        {
            return _database.GetCollection<T>(collectionName).AsQueryable();
        }

        public void Dispose()
        {
        }
    }
}
