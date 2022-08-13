using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekklesia.Entities.Filters
{
    public class OccasionFilter
    {
        public DateTime? Before { get; set; }
        public DateTime? After { get; set; }
    }
}
