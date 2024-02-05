using System;
using System.Data;

namespace CustomDataGridView.Lib.Models
{
    public class DataGridViewColumnButtonEvent
    {
        public string ColumnName { get; set; }
        public string HeaderText { get; set; }
        public int DisplayIndex { get; set; }
        public Action<object> Action { get; set; }
    }
}