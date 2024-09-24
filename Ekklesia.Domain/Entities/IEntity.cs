using MongoDB.Bson;

namespace Ekklesia.Domain.Entities
{
    public interface IEntity
    {
        ObjectId Id { get; set; }        
    }
}
