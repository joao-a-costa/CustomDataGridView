﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
        public string HeaderText { get; set; }
        public int? Width { get; set; }
        public int? DisplayIndex { get; set; }
        public bool Visible { get; set; }
        public bool AvailableToSelect { get; set; } = true;
        public bool ReadOnly { get; set; } = false;
        public string Format { get; set; }
        public Type Type { get; set; } = typeof(string);
        public DataGridViewContentAlignment Aligment { get; set; } = DataGridViewContentAlignment.MiddleLeft;
        public System.Drawing.FontStyle FontStyle { get; set; } = System.Drawing.FontStyle.Regular;
        public System.Drawing.Color BackColor { get; set; }
        public System.Drawing.Color ForeColor { get; set; }
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
