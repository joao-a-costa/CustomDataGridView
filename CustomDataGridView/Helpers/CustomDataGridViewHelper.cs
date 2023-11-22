using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CustomDataGridView.Lib.Helpers
{
    static internal class CustomDataGridViewHelper
    {
        /// <summary>
        /// Get only enum properties of an object 
        /// </summary>
        public static IEnumerable<PropertyInfo> GetPropertiesWithEnums(this object control)
        {
            return control.GetType().GetProperties()
                .Where(property => property.PropertyType.IsEnum);
        }

        /// <summary>
        /// Set value of a property
        /// </summary>
        public static void ChangeProperty(object objectInstance, string propertyName, object newValue)
        {
            // Use reflection to get the property information
            var property = objectInstance.GetType().GetProperty(propertyName);

            if (property != null && property.CanWrite)
            {
                // Set the new value for the property
                property.SetValue(objectInstance, newValue, null);

            }
        }
    }
}
