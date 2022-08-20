using MongoDB.Bson;

namespace Ekklesia.Entities.Entities
{
    public interface IEntity
    {
        ObjectId Id { get; set; }        
    }
}
