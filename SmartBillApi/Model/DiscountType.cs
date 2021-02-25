using System;
using System.Runtime.Serialization;

namespace SmartBillApi.Model
{
    [Serializable]
    public enum DiscountType
    {
        [EnumMember(Value = "1")] Valoric = 1,
        [EnumMember(Value = "2")] Procentual = 2,
    }
}