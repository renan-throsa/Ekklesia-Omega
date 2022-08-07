using System;

namespace Ekklesia.Entities.DTOs
{
    public class TokenDTO
    {
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public UserDTO User { get; set; } = new UserDTO();
    }
}
