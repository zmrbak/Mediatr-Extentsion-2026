using Mediatr_Extentsion_2026.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mediatr_Extentsion_2026.Extensions
{
    public static class Enums
    {
        public static IEnumerable<NameValue<T>> ToNameValues<T>() where T : Enum
        {
            return typeof(T)
                .GetFields(BindingFlags.Static | BindingFlags.Public)
                .Select(x => new NameValue<T>
                {
                    Name = x.Name,
                    Value = (T)x.GetValue(null)
                });
        }
    }
}
