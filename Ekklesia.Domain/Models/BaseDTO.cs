using Ekklesia.Domain.Entities;

namespace Ekklesia.Domain.DTOs
{
    public abstract class BaseDto<TEntity> : IObject<TEntity> where TEntity : IEntity
    {
        public string Id { get; set; } = string.Empty;
        public abstract TEntity ToEntity(params string[] props);
    }

}
