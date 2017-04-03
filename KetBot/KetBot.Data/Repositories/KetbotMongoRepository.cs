using KetBot.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetBot.Data.Repositories
{
    public class KetbotMongoRepository : IKetbotMongoRepository
    {
        public KetbotMongoRepository()
        {

        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KetBotDocument> GetAll(int page = 1, int pageSize = 10)
        {
            //using (var session = new SessionT())
            //{
            //    return session.All<KetBotDocument>().OrderByDescending(r => r.UpdatedDate).Skip(pageSize * (page - 1)).Take(pageSize).ToList();
            //}
            throw new NotImplementedException();
        }
    }
}
