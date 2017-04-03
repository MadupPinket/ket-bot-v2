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
        Task<IEnumerable<KetBotDocument>> GetAllByIntentAsync(string intent);

        Task<IEnumerable<KetBotDocument>> GetByKeywordWithinIntentAsync(string intent, List<string> keywords);
    }
}
