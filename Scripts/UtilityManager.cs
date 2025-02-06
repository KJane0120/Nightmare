using System.ComponentModel;
using System.Reflection;

namespace Nightmare
{
    internal class UtilityManager
    {
        static public string GetDescription(Enum e)
        {
            FieldInfo field = e.GetType().GetField(e.ToString());

            if (field != null)
            {
                var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute));
                if (attribute != null)
                {
                    return attribute.Description;
                }
            }

            return e.ToString();
        }
    }
}
