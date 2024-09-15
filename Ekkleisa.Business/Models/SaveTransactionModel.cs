using Microsoft.AspNetCore.Http;
using MongoDB.Bson.Serialization.Attributes;

namespace Ekkleisa.Business.Models
{
    public class SaveTransactionModel
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public string Description { get; set; }        

        [BsonIgnore]
        public string Receipt { get; set; }

        [BsonIgnore]
        public IFormFile? FormFile { get; set; }

        public string ResponsableName { get; set; }
        public string ResponsableId { get; set; }       

        public int Type { get; set; }
    }
}
