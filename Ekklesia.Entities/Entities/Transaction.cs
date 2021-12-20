using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekklesia.Entities.Entities
{
    public abstract class Transaction : BaseModel
    {
        public DateTime Date { get; set; }
        public float Value { get; set; }
    }
}
