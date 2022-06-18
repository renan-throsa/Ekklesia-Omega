using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekklesia.Entities.DTOs
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }        

        public UserDTO()
        {
            Name = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;            
        }

        public UserDTO(string name, string email, string phoneNumber)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;           
        }
    }
}
