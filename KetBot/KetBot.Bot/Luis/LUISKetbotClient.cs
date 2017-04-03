using Microsoft.Bot.Builder.Luis.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace KetBot.Bot.Luis
{
    public class LUISKetbotClient
    {
        public static async Task<LuisResult> ParseUserInput(string strInput)
        {
            string strRet = string.Empty;
            string strEscaped = Uri.EscapeDataString(strInput);

            using (var client = new HttpClient())
            {
                string uri = "https://api.projectoxford.ai/luis/v1/application?id=2eafd60f-83ec-465a-bf57-634b725c266d&subscription-key=50def8ad402f452697bf75a2ec2c8a7a&q=" + strEscaped;
                HttpResponseMessage msg = await client.GetAsync(uri);

                if (msg.IsSuccessStatusCode)
                {
                    var jsonResponse = await msg.Content.ReadAsStringAsync();
                    var _Data = JsonConvert.DeserializeObject<LuisResult>(jsonResponse);
                    return _Data;
                }
            }
            return null;
        }
    }
}