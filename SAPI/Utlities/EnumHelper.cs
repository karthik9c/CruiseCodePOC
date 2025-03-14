﻿using System.ComponentModel;
using System.Reflection;

namespace Utlities
{
    public static class EnumHelper
    {
        public static string GetDescription(Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = field.GetCustomAttribute<DescriptionAttribute>();

            return attribute == null ? value.ToString() : attribute.Description;
        }

        public static string GetEnumKey(Enum value)
        {
            return value.ToString();
        }
    }
}
