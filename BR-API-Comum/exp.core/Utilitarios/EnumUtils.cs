using System;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;

namespace exp.core.Utilitarios
{
    public static class EnumUtils
    {
        public static string GetDescription(Enum value)
        {
            if (value != null)
            {
                var fi = value.GetType().GetField(value.ToString());

                var attributes =
                    (DescriptionAttribute[])fi.GetCustomAttributes(
                        typeof(DescriptionAttribute),
                        false);

                if (attributes != null &&
                    attributes.Length > 0)
                    return attributes[0].Description;
                return value.ToString();
            }

            return null;
        }

        public static SelectList ToSelectList(Type enumType)
        {
            if (enumType.BaseType != typeof(Enum)) throw new InvalidCastException();
            var values = from Enum e in Enum.GetValues(enumType)
                select new { Id = Convert.ToInt32(e), Name = GetDescription(e) };
            return new SelectList(values, "Id", "Name");
        }

        public static SelectList ToSelectList<T>(T[] enums)
        {
            if (!typeof(T).IsEnum) throw new InvalidCastException();
            var values = from Enum e in enums
                select new { Id = Convert.ToInt32(e), Name = GetDescription(e) };
            return new SelectList(values, "Id", "Name");
        }

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}