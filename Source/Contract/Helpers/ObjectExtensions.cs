using System;

namespace Routindo.Contract.Helpers
{
    public static class ObjectExtensions
    {
        public static bool IsNullable<T>(this object obj)
        {
            if (obj == null) return true; // obvious
            Type type = typeof(T);
            if (!type.IsValueType) return true; // ref-type
            if (Nullable.GetUnderlyingType(type) != null) return true; // Nullable<T>
            return false; // value-type
        }
    }
}
