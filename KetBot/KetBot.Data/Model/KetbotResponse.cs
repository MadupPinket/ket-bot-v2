using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetBot.Data.Model
{

    public class KetBotResponse
    {
        public string message { get; set; }
        public Attachment[] attachments { get; set; }
    }

    public class Attachment
    {
        public string contentType { get; set; }
        public string contentUrl { get; set; }
        public string name { get; set; }
    }

}
