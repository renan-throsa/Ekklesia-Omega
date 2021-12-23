namespace Ekklesia.Entities.Entities
{
    public abstract class BaseModel : IEntity<int>
    {
        public int Id { get; set; }
    }
}
