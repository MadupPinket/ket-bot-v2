using KetBot.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetBot.Data.Repositories
{
    public interface IKetbotMongoRepository
    {
        IEnumerable<KetBotDocument> GetAll(int page = 1, int pageSize = 10);

        int Count();

    }
}
