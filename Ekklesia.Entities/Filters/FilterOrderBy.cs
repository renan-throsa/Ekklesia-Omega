using System;
using System.Runtime.Serialization;

namespace Ekklesia.Entities.Filters
{
    [Serializable]
    [DataContract(Name = "FilterDto")]
    public class FilterOrderBy
    {
        [DataMember(Name = "column")]
        public string Column { get; set; } = "Id";


        [DataMember(Name = "direction")]
        public string Direction { get; set; } = "DESC";


        [DataMember(Name = "type")]
        public string ColumnAndDirection => Column + " " + Direction;

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
