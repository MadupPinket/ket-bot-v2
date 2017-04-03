using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KetBot.Bot.Luis
{
    public class KetbotLUIS
    {
        public string query { get; set; }
        public lIntent[] intents { get; set; }
        public lEntity[] entities { get; set; }
    }
}