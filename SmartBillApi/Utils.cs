using System;
using System.Linq;
using System.Reflection;

namespace SmartBillApi
{
    internal static class Utils
    {
        internal static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        internal static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        internal static ResponseFieldPathAttribute GetResponseFieldPathFromType<T>()
        {
            return GetResponseFieldPathFromType(typeof(T));
        }

        internal static ResponseFieldPathAttribute GetResponseFieldPathFromType(Type type)
        {
            var attr = type.GetCustomAttribute<ResponseFieldPathAttribute>();
            if (attr == null && type.IsGenericType)
            {
                attr = type.GetGenericArguments().First().GetCustomAttribute<ResponseFieldPathAttribute>();
            }

            if (attr == null)
            {
                throw new Exception($"Couldn't find response field name for '{type.Name}'.");
            }

            return attr;
        }
    }
}