using Ekklesia.Entities.Enums;

namespace Ekklesia.Entities.DTOs
{
    public class Response
    {
        public ResponseStatus status { get; set; }
        public object? payload { get; set; }
    }
}
