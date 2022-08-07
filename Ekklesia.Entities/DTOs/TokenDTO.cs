using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekklesia.Entities.DTOs
{
    public class TokenDTO
    {
        public string Token { get; set; } = string.Empty;
        public double ExpiresIn { get; set; }
        public UserDTO User { get; set; } = new UserDTO();
    }
}
