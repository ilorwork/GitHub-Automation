using System;
using System.ComponentModel;
using System.Reflection;

namespace GitHub.helpers
{
    public static class ExtensionsMethods
    {
        public static string GetDescription(Enum value)
        {
            // Get the Description attribute value for the ENUM
            FieldInfo fi = value.GetType().GetField(value.ToString());//gets ENUM value
            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute), false);//gets the description annotations inside the ENUM 

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        public static int CreateRandomNumber()
        {
            var rand = new Random();
            return rand.Next(0, 99999999);
        }
    }
}
