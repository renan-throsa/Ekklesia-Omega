using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekklesia.Domain.Settings
{
    public class SecutitySettings
    {
        public string Secret { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int ExpirationInHours { get; set; }
        public int MaxFailedAccessAttempts { get; set; }
        public int DefaultLockoutTime { get; set; }


    }
}
