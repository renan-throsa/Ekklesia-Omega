using MongoDB.Bson;

namespace Ekklesia.Entities.Entities
{
    public abstract class BaseEntity : IEntity
    {
        public ObjectId Id { get; set; }
        
    }
}
