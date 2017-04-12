using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KetBot.Data.Model;

namespace KetBot.Data.Repositories
{
    public class KetbotAzureSearchRepository : IKetbotRepository
    {
        public Task<IEnumerable<KetBotDocument>> GetAllByIntentAsync(string intent)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<KetBotDocument>> GetByKeywordWithinIntentAsync(string intent, List<string> keywords)
        {
            throw new NotImplementedException();
        }
    }
}
