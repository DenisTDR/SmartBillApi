using System;

namespace SmartBillApi
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class ResponseFieldPathAttribute : Attribute
    {
        public string FieldPath { get; set; }
        public bool IsFlat { get; set; }

        public ResponseFieldPathAttribute(string fieldPath)
        {
            FieldPath = fieldPath;
        }

        public ResponseFieldPathAttribute(bool isFlat)
        {
            IsFlat = isFlat;
        }

        public ResponseFieldPathAttribute()
        {
        }
    }
}