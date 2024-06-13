using Ekklesia.Entities.Enums;

namespace Ekklesia.Entities.DTOs
{
    public class Response
    {
        public ResponseStatus Status { get; set; }
        public object? Payload { get; set; }
    }
}
