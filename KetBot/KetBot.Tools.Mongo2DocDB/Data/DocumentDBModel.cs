using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetBot.Tools.Mongo2DocDB.Data
{
    [Serializable]
    public class DocumentDBModel
    {

        public string answer { get; set; }
        public string[] keywords { get; set; }
        public string intent { get; set; }
        public string id { get; set; }
        public string title { get; set; }
        public Attachment[] attachments { get; set; }
    }

    [Serializable]
    public class Attachment
    {
        public string contentType { get; set; }
        public string contentUrl { get; set; }
        public string name { get; set; }
    }

}
