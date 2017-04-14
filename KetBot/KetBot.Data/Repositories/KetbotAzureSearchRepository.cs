using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KetBot.Data.Model;
using System.Configuration;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;

namespace KetBot.Data.Repositories
{
    public class KetbotAzureSearchRepository : IKetbotRepository
    {
        string searchServiceName = ConfigurationManager.AppSettings["SearchServiceName"];
        string queryApiKey = ConfigurationManager.AppSettings["SearchServiceQueryApiKey"];
        SearchIndexClient indexClient;

        public KetbotAzureSearchRepository()
        {
            indexClient = new SearchIndexClient(searchServiceName, "ketbotindex", new SearchCredentials(queryApiKey));
        }

        public async Task<IEnumerable<KetBotDocument>> GetAllByIntentAsync(string intent)
        {
            SearchParameters parameters = new SearchParameters()
            {
                Filter = "intent eq '" + intent + "'",
            };
            DocumentSearchResult<DocumentDBModel> results = await indexClient.Documents.SearchAsync<DocumentDBModel>("*", parameters);

            return results.Results.ToList().Select(x => new KetBotDocument
            {
                Answer = x.Document.answer,
                ID = x.Document.id,
                Intent = x.Document.intent,
                Keywords = x.Document.keywords,
                Title = x.Document.title,
            }).ToList();
        }

        public async Task<IEnumerable<KetBotDocument>> GetByKeywordWithinIntentAsync(string intent, List<string> keywords)
        {
            SearchParameters parameters = new SearchParameters()
            {
                Filter = "intent eq '" + intent + "'",
            };
            var searchkeyword = String.Join("|", keywords);
            DocumentSearchResult<DocumentDBModel> results = await indexClient.Documents.SearchAsync<DocumentDBModel>(searchkeyword, parameters);

            return results.Results.ToList().Select(x => new KetBotDocument
            {
                Answer = x.Document.answer,
                ID = x.Document.id,
                Intent = x.Document.intent,
                Keywords = x.Document.keywords,
                Title = x.Document.title,
            }).ToList();
        }
    }
}
