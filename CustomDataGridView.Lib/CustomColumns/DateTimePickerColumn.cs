using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace CustomDataGridView.Lib.CustomColumns
{
    public class DateTimePickerColumn : DataGridViewColumn
    {
        private const string _InvalidCastExceptionMessage = "Must be a DateTimePickerCell";

        public DateTimePickerColumn() : base(new DateTimePickerCell())
        {
        }

        public override DataGridViewCell CellTemplate
        {
            get { return base.CellTemplate; }
            set
            {
                // Ensure that the cell used for the template is a DateTimePickerCell.
                if (value != null && !value.GetType().IsAssignableFrom(typeof(DateTimePickerCell)))
                {
                    throw new InvalidCastException(_InvalidCastExceptionMessage);
                }
                base.CellTemplate = value;
            }
        }
    }

    public class DateTimePickerCell : DataGridViewTextBoxCell
    {
        public const string _dateFormat = "yyyy-MM-dd";

        public DateTimePickerCell()
        {
            // Use a DateTimePicker control as the default editor.
            this.Style.Format = _dateFormat;
        }

        public override Type EditType
        {
            get { return typeof(DateTimePickerEditingControl); }
        }

        public override Type ValueType
        {
            get { return typeof(DateTime); }
        }

        public override object DefaultNewRowValue
        {
            get { return DateTime.Now; }
        }

        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            if (value != null && value is DateTime)
            {
                // Format the DateTime value as needed.
                return ((DateTime)value).ToString(_dateFormat);
            }

            return base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
        }
    }

    public class DateTimePickerEditingControl : DateTimePicker, IDataGridViewEditingControl
    {
        private DataGridView dataGridView;
        private bool valueChanged = false;
        private int rowIndex;
        private string columnName; // New property to store the column name
        public event EventHandler<CellValueChangedEventArgs> CellValueChanged;

        public DateTimePickerEditingControl()
        {
            this.Format = DateTimePickerFormat.Custom;
            this.CustomFormat = DateTimePickerCell._dateFormat;
            this.ShowUpDown = true;
        }

        public object EditingControlFormattedValue
        {
            get { return this.Value.ToString(DateTimePickerCell._dateFormat); }
            set
            {
                if (value is DateTime)
                {
                    DateTime dateValue = (DateTime)value;
                    this.Value = dateValue;
                }
            }
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return this.Value.ToString(DateTimePickerCell._dateFormat);
        }


        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
            this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
            // Set the column name when preparing for edit
            columnName = EditingControlDataGridView.Columns[EditingControlDataGridView.CurrentCell.ColumnIndex].Name;

            // No other preparation needs to be done.
        }

        // New property to get and set the column name
        public string ColumnName
        {
            get { return columnName; }
            set { columnName = value; }
        }

        public int EditingControlRowIndex
        {
            get { return rowIndex; }
            set { rowIndex = value; }
        }

        public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
        {
            // Let the DateTimePicker handle the keys listed.
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        public bool RepositionEditingControlOnValueChange
        {
            get { return false; }
        }

        public DataGridView EditingControlDataGridView
        {
            get { return dataGridView; }
            set { dataGridView = value; }
        }

        public bool EditingControlValueChanged
        {
            get { return valueChanged; }
            set { valueChanged = value; }
        }

        public Cursor EditingPanelCursor
        {
            get { return base.Cursor; }
        }

        public void CommitEdit()
        {
            // Commit the changes to the DataGridView
            valueChanged = true;
            EditingControlDataGridView.EndEdit();
            EditingControlDataGridView.NotifyCurrentCellDirty(true);

            // Update the data source with the new value
            if (rowIndex != -1)
            {
                // Raise the custom event
                OnCellValueChanged(new CellValueChangedEventArgs(rowIndex, columnName, this.Value));
            }
        }

        protected virtual void OnCellValueChanged(CellValueChangedEventArgs e)
        {
            CellValueChanged?.Invoke(this, e);
        }

        protected override void OnValueChanged(EventArgs eventargs)
        {
            PrepareEditingControlForEdit(false);
            CommitEdit();
            base.OnValueChanged(eventargs);
        }
    }

    // Define a custom event arguments class
    public class CellValueChangedEventArgs : EventArgs
    {
        public int RowIndex { get; }
        public string ColumnName { get; }
        public object NewValue { get; }

        public CellValueChangedEventArgs(int rowIndex, string columnName, object newValue)
        {
            RowIndex = rowIndex;
            ColumnName = columnName;
            NewValue = newValue;
        }
    }
}
