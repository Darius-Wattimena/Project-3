using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ProjectData.Util
{
    public class EnumUtil
    {
        /// <summary>
        /// Find the index number of the given enum.
        /// </summary>
        /// <param name="value">The enum you want to receive the Index from.</param>
        /// <returns>An int value with the index number of the enum.</returns>
        public static int GetIndex(Enum value)
        {
            return Array.IndexOf(Enum.GetValues(value.GetType()), value);
        }

        public static IEnumerable<T> GetValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        public static string GetEnumDescription(Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            var attributes = (DescriptionAttribute[]) fi.GetCustomAttributes(
                    typeof(DescriptionAttribute),
                    false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static T GetEnumFormDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            return default(T);
        }
    }
}
