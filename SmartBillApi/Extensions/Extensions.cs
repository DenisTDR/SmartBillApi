using System;
using RestSharp;

namespace SmartBillApi.Extensions
{
    internal static class Extensions
    {
        internal static string ToSmartBillString(this DateTime dateTime) => dateTime.ToString("yyyy-MM-dd");

        internal static string ToSmartBillString(this DateTime? dateTime) => dateTime?.ToSmartBillString();

        internal static IRestRequest AddOptionalQueryParameter(this IRestRequest request, string name, string value)
        {
            return value == null ? request : request.AddQueryParameter(name, value);
        }
    }
}