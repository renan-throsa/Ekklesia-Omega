using System;
using System.Runtime.Serialization;

namespace Ekklesia.Entities.Filters
{
    [Serializable]
    [DataContract(Name = "FilterType")]
    public enum FilterType
    {
        [EnumMember(Value = "0")]
        Equal,
        [EnumMember(Value = "1")]
        Like,
        [EnumMember(Value = "2")]
        GreaterThan,
        [EnumMember(Value = "3")]
        GreaterThanOrEqual,
        [EnumMember(Value = "4")]
        LessThan,
        [EnumMember(Value = "5")]
        LessThanOrEqual,
        [EnumMember(Value = "6")]
        IsNull,
        [EnumMember(Value = "7")]
        FromDate,
        [EnumMember(Value = "8")]
        ToDate,
        [EnumMember(Value = "9")]
        NotEqual
    }
}
