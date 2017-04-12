using KetBot.Data.Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetBot.Data.Repositories
{
    [Serializable]
    public class KetbotMongoRepository : IKetbotRepository
    {
        private IMongoCollection<KetBotDocument> answers;

        public KetbotMongoRepository()
        {
            string connString = ConfigurationManager.AppSettings["MongoDBConnectionString"];
            var client = new MongoClient(connString);
            var ketbotdb = client.GetDatabase(ConfigurationManager.AppSettings["MongoDBDatabase"]);
            answers = ketbotdb.GetCollection<KetBotDocument>(ConfigurationManager.AppSettings["MongoDBCollection"]);
        }

        public async Task<IEnumerable<KetBotDocument>> GetAllByIntentAsync(string intent)
        {
            var filter = Builders<KetBotDocument>.Filter.Eq("Intent", intent);
            var docs = await answers.Find(filter).ToListAsync();
            return docs;
        }

        public async Task<IEnumerable<KetBotDocument>> GetByKeywordWithinIntentAsync(string intent, List<string> searchwords)
        {
            var intentFilter = Builders<KetBotDocument>.Filter.Eq("Intent", intent);
            var keywordFilter = Builders<KetBotDocument>.Filter.AnyIn(x => x.Keywords, searchwords);
            var filter = intentFilter | keywordFilter;
            var docs = await answers.Find(filter).ToListAsync();
            return docs;
        }
    }
}
