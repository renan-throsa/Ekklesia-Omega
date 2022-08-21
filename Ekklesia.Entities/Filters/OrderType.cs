using System.Runtime.Serialization;

namespace Ekklesia.Entities.Filters
{
    public enum OrderType
    {
        [EnumMember(Value = "0")]
        Ascending,

        [EnumMember(Value = "1")]
        Descending,
    }
}
