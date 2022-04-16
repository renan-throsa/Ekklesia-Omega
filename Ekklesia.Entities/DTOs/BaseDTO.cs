namespace Ekklesia.Entities.DTOs
{
    public abstract class BaseDto<T>
    {
        public string Id { get; set; } = string.Empty;
        public abstract T ToEntity(params string[] props);
    }

}
