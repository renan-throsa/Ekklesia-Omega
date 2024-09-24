namespace Ekklesia.Domain.Entities
{
    public interface IObject<TEntity> where TEntity : IEntity
    {
        string Id { get; set; }
        public TEntity ToEntity(params string[] props);
    }
}
