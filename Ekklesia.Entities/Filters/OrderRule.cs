using System;
using System.Runtime.Serialization;

namespace Ekklesia.Entities.Filters
{
    [Serializable]
    [DataContract(Name = "OrderRule")]
    public class OrderRule
    {
        [DataMember(Name = "field")]
        public string Field { get; set; }


        [DataMember(Name = "direction")]
        public string Direction { get; set; } = "DESC";


        public OrderRule()
        {
            this.Field = string.Empty;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
