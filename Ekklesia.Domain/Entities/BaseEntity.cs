using MongoDB.Bson;

namespace Ekklesia.Domain.Entities
{
    public abstract class BaseEntity : IEntity
    {
        public ObjectId Id { get; set; }
        
    }
}
