using CustomDataGridView.Lib.CustomColumns;
using CustomDataGridView.Lib.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;

namespace CustomDataGridView.Lib.Helpers
{
    static internal class CustomDataGridViewHelper
    {
        /// <summary>
        /// Constant for the message of invalid column type
        /// </summary>
        private const string _messageInvalidColumnType = "Invalid column type";

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

        /// <summary>
        /// Change the type of a column to a new type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataGridView"></param>
        /// <param name="columnName"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void ChangeColumnType<T>(DataGridView dataGridView, string columnName)
            where T : DataGridViewColumn, new()
        {
            // Check if the column exists
            if (dataGridView.Columns.Contains(columnName))
            {
                // Get the index of the existing column
                int columnIndex = dataGridView.Columns[columnName].Index;
                var columnFound = dataGridView.Columns[columnName];

                // Create a new instance of T
                T newColumn = Activator.CreateInstance<T>();

                // Check if the column type is already the desired type
                if (columnFound is T)
                {
                    // The column is already of the desired type, no need to change it
                    return;
                }

                // Check if the new column is a valid DataGridViewColumn
                if (!(newColumn is DataGridViewColumn))
                {
                    throw new InvalidOperationException(_messageInvalidColumnType);
                }

                // Set the HeaderText for the new column
                if (newColumn is DataGridViewColumn dataGridViewColumn)
                {
                    //CopyIfDifferent(dataGridView.Columns[columnName], newColumn);

                    newColumn.HeaderText = columnFound.Name; // You can set the HeaderText as needed
                    newColumn.Name = columnFound.HeaderText; // You can set the HeaderText as needed
                }

                // Remove the old column
                dataGridView.Columns.Remove(columnName);

                // Add the new column to the DataGridView
                dataGridView.Columns.Insert(columnIndex, newColumn);
            }
        }

        /// <summary>
        /// Copy the values of the properties from one object to another
        /// </summary>
        /// <typeparam name="T1">The type origin</typeparam>
        /// <typeparam name="T2">The type destination</typeparam>
        /// <param name="source">The source type</param>
        /// <param name="destination">The destination type</param>
        /// <param name="propertiesToIgnore">The list of properties to ignore</param>
        public static void CopyIfDifferent<T1, T2>(T1 source, T2 destination, List<PropertiesToIgnore> propertiesToIgnore = null)
        {
            // Get all the properties of the source object
            var properties = source.GetType().GetProperties();

            // Loop through each property
            foreach (var property in properties)
            {
                // Check if the property can be read and written
                if (property.CanRead && property.CanWrite && source.HasProperties(property.Name))
                {
                    // Get the values of the property in the source and destination objects
                    var sourceValue = property.GetValue(source);
                    var destinationValue = property.GetValue(destination);

                    // Check if the source value is not null and is different from the destination value
                    if (sourceValue != null && !sourceValue.Equals(destinationValue))
                    {
                        // Check if the property should be ignored
                        var ignoreProperty = propertiesToIgnore?.FirstOrDefault(p => p.Name == property.Name && p.Type == property.PropertyType);
                        if
                        (
                            ignoreProperty != null &&
                            (
                                ignoreProperty.ValueToIgnore == null
                                ||
                                (
                                    ignoreProperty.ValueToIgnore != null &&
                                    sourceValue.Equals(Convert.ChangeType(ignoreProperty.ValueToIgnore, ignoreProperty.Type))
                                )
                            )
                        )
                        {
                            continue; // Ignore this property and move to the next
                        }

                        // Check if the property is a value type or a string
                        if
                        (
                            (property.PropertyType.IsValueType && !IsZeroValue(sourceValue)) ||
                            property.PropertyType == typeof(string) ||
                            typeof(System.Collections.IEnumerable).IsAssignableFrom(property.PropertyType)
                        )
                        {
                            // Set the value of the property in the destination object to the value of the property in the source object
                            property.SetValue(destination, sourceValue);
                        }
                        else
                        {
                            // Recursively call this method to copy the property values from the nested objects
                            CopyIfDifferent(sourceValue, destinationValue, propertiesToIgnore);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Check if the value of a property is zero
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool IsZeroValue(object value)
        {
            switch (Type.GetTypeCode(value.GetType()))
            {
                case TypeCode.Byte:
                    return (byte)value == default(byte);
                case TypeCode.SByte:
                    return (sbyte)value == default(sbyte);
                case TypeCode.Int16:
                    return (short)value == default(short);
                case TypeCode.Int32:
                    return (int)value == default(int);
                case TypeCode.Int64:
                    return (long)value == default(long);
                case TypeCode.UInt16:
                    return (ushort)value == default(ushort);
                case TypeCode.UInt32:
                    return (uint)value == default(uint);
                case TypeCode.UInt64:
                    return (ulong)value == default(ulong);
                case TypeCode.Single:
                    return (float)value == default(float);
                case TypeCode.Double:
                    return (double)value == default(double);
                case TypeCode.Decimal:
                    return (decimal)value == default(decimal);
                default:
                    return false;
            }
        }

        /// <summary>
        /// Check if an object has a property
        /// </summary>
        /// <param name="obj">The object</param>
        /// <param name="propertyName">The property name</param>
        /// <returns></returns>
        public static bool HasProperties(this object obj, string propertyName) => JObject.Parse(JsonConvert.SerializeObject(obj)).SelectToken(propertyName) != null;

        /// <summary>
        /// Method to set DataGridView settings from a configuration object
        /// </summary>
        public static void SetDataGridViewSettings(DataGridViewConfiguration dataGridViewConfiguration,
            Components.CustomDataGridView customDataGridView,
            bool setColumnsNotFoundVisible = true)
        {
            if (dataGridViewConfiguration != null)
            {
                customDataGridView.Columns.Cast<DataGridViewColumn>().ToList().ForEach(fe =>
                {
                    var columnFound = dataGridViewConfiguration.Columns.FirstOrDefault(fod => fod.ColumnName == fe.Name);
                    var fontToSet = fe.DefaultCellStyle.Font == null ? customDataGridView.Font : fe.DefaultCellStyle.Font;
                    var backColorToSet = fe.DefaultCellStyle.BackColor == null ? customDataGridView.BackColor : fe.DefaultCellStyle.BackColor;
                    var foreColorToSet = fe.DefaultCellStyle.ForeColor == null ? customDataGridView.ForeColor : fe.DefaultCellStyle.ForeColor;

                    if (columnFound != null)
                    {
                        fe.Name = columnFound.ColumnName;
                        fe.HeaderText = columnFound.HeaderText;
                        fe.Visible = columnFound.Visible;
                        fe.ReadOnly = columnFound.ReadOnly;
                        fe.DefaultCellStyle.Alignment = columnFound.Aligment;
                        fe.DefaultCellStyle.Format = columnFound.Format;
                        fe.DefaultCellStyle.FormatProvider = CultureInfo.CurrentCulture.NumberFormat;
                        fe.DefaultCellStyle.Font = new Font(fontToSet.FontFamily, fontToSet.Size, columnFound.FontStyle);
                        fe.DefaultCellStyle.BackColor = columnFound.BackColor;
                        fe.DefaultCellStyle.ForeColor = columnFound.ForeColor;
                        if (columnFound.Width.HasValue)
                            fe.Width = columnFound.Width.Value;
                        if (columnFound.DisplayIndex.HasValue)
                            fe.DisplayIndex = columnFound.DisplayIndex.Value;

                    }
                    else
                        fe.Visible = setColumnsNotFoundVisible;
                });
                dataGridViewConfiguration?.Columns.ForEach(fe =>
                {
                    var columnFound = customDataGridView.Columns.Cast<DataGridViewColumn>().FirstOrDefault(fod => fod.Name == fe.ColumnName);

                    if (columnFound != null)
                    {
                        var fontToSet = columnFound.DefaultCellStyle.Font == null ? customDataGridView.Font : columnFound.DefaultCellStyle.Font;
                        var backColorToSet = columnFound.DefaultCellStyle.BackColor == null ? customDataGridView.BackColor : columnFound.DefaultCellStyle.BackColor;
                        var foreColorToSet = columnFound.DefaultCellStyle.ForeColor == null ? customDataGridView.ForeColor : columnFound.DefaultCellStyle.ForeColor;

                        columnFound.Name = fe.ColumnName;
                        columnFound.HeaderText = fe.HeaderText;
                        columnFound.Visible = fe.Visible;
                        columnFound.ReadOnly = fe.ReadOnly;
                        columnFound.DefaultCellStyle.Alignment = fe.Aligment;
                        columnFound.DefaultCellStyle.Format = fe.Format;
                        columnFound.DefaultCellStyle.FormatProvider = CultureInfo.CurrentCulture.NumberFormat;
                        columnFound.DefaultCellStyle.Font = new Font(fontToSet.FontFamily, fontToSet.Size, fe.FontStyle);
                        columnFound.DefaultCellStyle.BackColor = fe.BackColor;
                        columnFound.DefaultCellStyle.ForeColor = fe.ForeColor;
                        if (fe.Width.HasValue)
                            columnFound.Width = fe.Width.Value;
                        if (fe.DisplayIndex.HasValue)
                            columnFound.DisplayIndex = fe.DisplayIndex.Value;
                    }
                });

                dataGridViewConfiguration?.ExtraProperties.ForEach(fe =>
                {
                    ChangeProperty(customDataGridView, fe.Name,
                        Enum.Parse(customDataGridView.GetType().GetProperty(fe.Name).PropertyType, fe.Value.ToString()));
                });
            }
        }
    }
}
