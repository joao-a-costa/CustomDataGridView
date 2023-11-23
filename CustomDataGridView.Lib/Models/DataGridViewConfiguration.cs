using System.Collections.Generic;

namespace CustomDataGridView.Lib.Models
{
    /// <summary>
    /// Model for the datagridview configuration
    /// </summary>
    public class DataGridViewConfiguration
    {
        public List<DataGridViewConfigurationColumn> Columns = new List<DataGridViewConfigurationColumn>();
        public List<DataGridViewConfigurationExtraProperty> ExtraProperties = new List<DataGridViewConfigurationExtraProperty>();
    }

    /// <summary>
    /// Model of column configuration
    /// </summary>
    public class DataGridViewConfigurationColumn
    {
        public string ColumnName { get; set; }
        public int Width { get; set; }
    }

    /// <summary>
    /// Model of extra data 
    /// </summary>
    public class DataGridViewConfigurationExtraProperty
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }
}
