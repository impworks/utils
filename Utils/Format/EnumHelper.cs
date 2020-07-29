using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Impworks.Utils.Format
{
    /// <summary>
    /// Various extension / helper methods for enum values.
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Cached description values for all values of known enums.
        /// </summary>
        private static readonly ConcurrentDictionary<Type, object> DescriptionCache = new ConcurrentDictionary<Type, object>();

        /// <summary>
        /// Cached description values for all values of known enums.
        /// </summary>
        private static readonly ConcurrentDictionary<Type, object> DynamicDescriptionCache = new ConcurrentDictionary<Type, object>();

        #region Strongly typed

        /// <summary>
        /// Returns the lookup of enum values and readable descriptions (from [Description] attribute or the label).
        /// </summary>
        public static IReadOnlyDictionary<T, string> GetEnumDescriptions<T>()
            where T : struct
        {
            var type = typeof(T);
            var lookup = DescriptionCache.GetOrAdd(type, t =>
            {
                var flags = BindingFlags.DeclaredOnly
                            | BindingFlags.Static
                            | BindingFlags.Public
                            | BindingFlags.GetField;

                return type.GetFields(flags)
                           .ToDictionary(
                               x => (T)x.GetRawConstantValue(),
                               x => x.GetCustomAttribute<DescriptionAttribute>()?.Description
                                    ?? Enum.GetName(type, x.GetRawConstantValue())
                           );
            });

            return (IReadOnlyDictionary<T, string>)lookup;
        }

        /// <summary>
        /// Returns a readable description of a single enum value.
        /// </summary>
        public static string GetEnumDescription<T>(this T enumValue)
            where T : struct
        {
            return GetEnumDescriptions<T>()[enumValue];
        }

        /// <summary>
        /// Returns the list of enum values.
        /// </summary>
        public static IReadOnlyList<T> GetEnumValues<T>()
            where T : struct
        {
            return Enum.GetValues(typeof(T))
                       .Cast<T>()
                       .ToList();
        }

        /// <summary>
        /// Checks if the element is defined, possibly ignoring the case.
        /// </summary>
        public static bool IsDefined<T>(string name, bool ignoreCase = false)
        {
            return ignoreCase
                ? Enum.GetNames(typeof(T)).Any(x => string.Compare(x, name, StringComparison.InvariantCultureIgnoreCase) == 0)
                : Enum.IsDefined(typeof(T), name);
        }

        #endregion

        #region Weakly typed

        /// <summary>
        /// Returns the lookup of enum values and readable descriptions (from [Description] attribute or the label).
        /// </summary>
        public static IReadOnlyDictionary<object, string> GetEnumDescriptions(Type type)
        {
            if(!type.IsEnum)
                throw new ArgumentException($"Type {type.Name} is not an Enum.", nameof(type));

            var lookup = DynamicDescriptionCache.GetOrAdd(type, t =>
            {
                var flags = BindingFlags.DeclaredOnly
                            | BindingFlags.Static
                            | BindingFlags.Public
                            | BindingFlags.GetField;

                return type.GetFields(flags)
                           .ToDictionary(
                               x => Enum.ToObject(type, x.GetRawConstantValue()),
                               x => x.GetCustomAttribute<DescriptionAttribute>()?.Description
                                    ?? Enum.GetName(type, x.GetRawConstantValue())
                           );
            });

            return (IReadOnlyDictionary<object, string>) lookup;
        }

        #endregion
    }
}