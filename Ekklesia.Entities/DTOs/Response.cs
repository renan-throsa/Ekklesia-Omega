using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekklesia.Entities.DTOs
{
    public class Response
    {
        public bool success { get; set; }
        public object? payload { get; set; }
    }
}
