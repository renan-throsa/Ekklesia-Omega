using Ekklesia.Entities.Entities;

namespace Ekklesia.Entities.DTOs
{
    public abstract class BaseDto<TEntity> : IObject<TEntity> where TEntity : IEntity
    {
        public string Id { get; set; } = string.Empty;
        public abstract TEntity ToEntity(params string[] props);
    }

}
