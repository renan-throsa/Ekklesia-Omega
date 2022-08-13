using System;
using System.Runtime.Serialization;

namespace Ekklesia.Entities.Filters
{
    [Serializable]
    [DataContract(Name = "FilterDto")]
    public class FilterDto
    {
        [DataMember(Name = "type")]
        public FilterType Type { get; set; }

        [DataMember(Name = "field")]
        public string Field { get; set; }

        [DataMember(Name = "arg")]
        public object Arg { get; set; }

        [DataMember(Name = "multipleArgs")]
        public object[] MultipleArgs { get; set; }

        public bool IsMultiple => MultipleArgs != null;

        public FilterDto()
        {
            this.Field = string.Empty;
            this.Arg = new object();
            this.MultipleArgs = new object[0];
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
