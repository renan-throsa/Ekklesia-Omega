using Ekklesia.Entities.Entities;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson.Serialization.Attributes;


namespace Ekkleisa.Business.Models
{
    public class SaveMemberModel
    {
        public string Id { get; set; }

        public Role Role { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        [BsonIgnore]
        public string Photo { get; set; }

        [BsonIgnore]
        public IFormFile? FormFile { get; set; }

        public DateTime BirthDay { get; set; }
    }
}
