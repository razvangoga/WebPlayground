using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace AngularJSTests.Infrastructure
{
    public static class EnumExtensions
    {
        public const int ENUM_DEFAULT_VALUE = 0;

        public static string GetDescription<TEnum>(this TEnum e) where TEnum : struct, IConvertible
        {
            if (!typeof(TEnum).IsEnum)
                throw new ArgumentException("Extension is only available for enums");

            FieldInfo fieldInfo = e.GetType().GetField(e.ToString());

            if (fieldInfo == null)
                return "n/a";

            DescriptionAttribute[] atributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            string value = string.Empty;

            if (atributes == null || atributes.Length == 0)
                value = e.ToString().Replace("_", " ");
            else
                value = atributes[0].Description;

            return value;
        }

        public static int GetOrder<TEnum>(this TEnum e) where TEnum : struct, IConvertible
        {
            if (!typeof(TEnum).IsEnum)
                throw new ArgumentException("Extension is only available for enums");

            FieldInfo fieldInfo = e.GetType().GetField(e.ToString());

            int value = 0;

            if (fieldInfo == null)
                return value;

            DisplayAttribute[] atributes = fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];

            if (atributes != null && atributes.Length > 0)
                value = atributes[0].Order;

            return value;
        }

        public static List<TEnum> GetAll<TEnum>()
            where TEnum : struct, IConvertible
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>()
                .OrderBy(e => e.GetOrder())
                .ToList();
        }

        private static List<KeyValuePair<int, string>> GetEnumValuesListInt<TEnum>(Func<TEnum, bool> where, string nameForUndefined)
            where TEnum : struct, IConvertible
        {
            IEnumerable<TEnum> items = GetAll<TEnum>();

            if (where != null)
                items = items.Where(where);

            List<KeyValuePair<int, string>> result = new List<KeyValuePair<int, string>>();

            foreach (TEnum item in items)
            {
                int itemValue = Convert.ToInt32(item);

                int key = itemValue;
                string value = itemValue == ENUM_DEFAULT_VALUE && !string.IsNullOrWhiteSpace(nameForUndefined)
                        ? nameForUndefined.Trim()
                        : item.GetDescription();

                result.Add(new KeyValuePair<int, string>(key, value));
            }

            return result;
        }
        public static List<KeyValuePair<int, string>> GetAllValuesListInt<TEnum>(string nameForUndefined = null)
             where TEnum : struct, IConvertible
        {
            return GetEnumValuesListInt<TEnum>(null, nameForUndefined);
        }
        public static List<KeyValuePair<int, string>> GetAllExceptUndefinedInt<TEnum>(string nameForUndefined = null)
            where TEnum : struct, IConvertible
        {
            return GetEnumValuesListInt<TEnum>(e => Convert.ToInt32(e) != ENUM_DEFAULT_VALUE, nameForUndefined);
        }

        private static List<KeyValuePair<string, string>> GetEnumValuesListString<TEnum>(Func<TEnum, bool> where, string nameForUndefined)
             where TEnum : struct, IConvertible
        {
            IEnumerable<TEnum> items = GetAll<TEnum>();

            if (where != null)
                items = items.Where(where);

            List<KeyValuePair<string, string>> result = new List<KeyValuePair<string, string>>();

            foreach (TEnum item in items)
            {
                string key = item.ToString();
                string value = Convert.ToInt32(item) == ENUM_DEFAULT_VALUE && !string.IsNullOrWhiteSpace(nameForUndefined)
                        ? nameForUndefined.Trim()
                        : item.GetDescription();

                result.Add(new KeyValuePair<string, string>(key, value));
            }

            return result;
        }
        public static List<KeyValuePair<string, string>> GetAllValuesListString<TEnum>(string nameForUndefined = null)
             where TEnum : struct, IConvertible
        {
            return GetEnumValuesListString<TEnum>(null, nameForUndefined);
        }
        public static List<KeyValuePair<string, string>> GetAllExceptUndefinedString<TEnum>(string nameForUndefined = null)
            where TEnum : struct, IConvertible
        {
            return GetEnumValuesListString<TEnum>(e => Convert.ToInt32(e) != ENUM_DEFAULT_VALUE, nameForUndefined);
        }
    }
}