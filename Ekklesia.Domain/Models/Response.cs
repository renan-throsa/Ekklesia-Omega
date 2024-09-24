using System.Net;

namespace Ekklesia.Domain.DTOs
{
    public class Response
    {
        public bool IsValid => Status == HttpStatusCode.OK || Status == HttpStatusCode.Created || Status == HttpStatusCode.Found;
        public HttpStatusCode Status { get; set; }
        public object? Payload { get; set; }
    }
}
