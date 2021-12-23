namespace Ekklesia.Entities.Entities
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
