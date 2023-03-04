using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WaifuImAPI_NET.Utilities
{
    public static class Extensions
    {
        // Credit to: https://stackoverflow.com/a/46519166
        public static string GetEnumMemberValue<T>(this T value)
        where T : struct, IConvertible
        {
            return typeof(T)
                .GetTypeInfo()
                .DeclaredMembers
                .SingleOrDefault(x => x.Name == value.ToString())
                ?.GetCustomAttribute<EnumMemberAttribute>(false)
                ?.Value;
        }

        public static string GetLowerString(this bool value)
        {
            return value.ToString().ToLowerInvariant();
        }
    }
}
