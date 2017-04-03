using KetBot.Data.Model;
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
    public class KetbotMongoRepository : IKetbotMongoRepository
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
            var list = await answers.Find(x => x.intent == intent).ToListAsync();
            return list;
        }

        public async Task<IEnumerable<KetBotDocument>> GetByKeywordWithinIntentAsync(string intent, List<string> searchwords)
        {
            //var filter = Builders<KetBotDocument>.Filter.AnyIn("keywords", searchwords);
            var filter = Builders<KetBotDocument>.Filter.AnyIn(p => p.keywords, searchwords);
            
            // TODO : 쿼리 다시 만들어야 함. 
            var list = await answers.Find(filter).ToListAsync();
            return list.Where(x => x.intent == intent).ToList();
        }
    }
}
