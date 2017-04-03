using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetBot.Data
{
    public class KetBotDocument
    {
        public string id { get; set; }
        public string intent { get; set; }
        public string title { get; set; }
        public string answer { get; set; }
        public string[] keywords { get; set; }
        public Attachment[] attachments { get; set; }
        public bool isdeleted { get; set; }
    }

    public class Attachment
    {
        public string contentType { get; set; }
        public string contentUrl { get; set; }
        public string name { get; set; }
    }

}
