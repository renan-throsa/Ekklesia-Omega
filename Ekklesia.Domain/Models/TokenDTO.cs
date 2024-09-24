using System;

namespace Ekklesia.Domain.DTOs
{
    public class TokenDTO
    {
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public UserDTO User { get; set; } = new UserDTO();
    }
}
