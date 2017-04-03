using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KetBot.Data.Model
{
    [Serializable]
    public class KetBotDocument
    {
        [BsonId]
        public BsonObjectId _id { get; set; }
        public string ID { get; set; }
        public string Intent { get; set; }
        public string Title { get; set; }
        public string Answer { get; set; }
        public string[] Keywords { get; set; }
        public DocumentAttachment[] attachments { get; set; }
    }

    [Serializable]
    public class DocumentAttachment
    {
        public string contentType { get; set; }
        public string contentUrl { get; set; }
        public string name { get; set; }
    }

}
