using MongoDB.Bson;

namespace Ekklesia.Entities.Entities
{
    public abstract class BaseEntity : IEntity<ObjectId>
    {
        public ObjectId Id { get; set; }
    }
}
