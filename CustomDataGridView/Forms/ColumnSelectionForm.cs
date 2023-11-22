using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CustomDataGridView.Lib.Forms
{
    /// <summary>
    /// Represents a form for selecting columns in a DataGridView.
    /// </summary>
    public partial class ColumnSelectionForm : Form
    {
        #region "Properties"
        /// <summary>
        /// Public properties for available and selected columns
        /// </summary>
        public List<string> AvailableColumns { get; private set; } = new List<string>();
        public List<string> SelectedColumns { get; private set; } = new List<string>();

        #endregion

        /// <summary>
        /// Default constructor for ColumnSelectionForm.
        /// </summary>
        public ColumnSelectionForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Parameterized constructor to initialize with available and selected columns.
        /// </summary>
        /// <param name="availableColumns">List of available columns.</param>
        /// <param name="selectedColumns">List of selected columns.</param>
        public ColumnSelectionForm(List<string> availableColumns, List<string> selectedColumns)
            : this()
        {

            AvailableColumns = availableColumns;
            SelectedColumns = selectedColumns;

            InitializeColumns();
        }

        #region "Private"

        /// <summary>
        /// Load data table based on checked items in the "Using" column.
        /// </summary>
        private void LoadDataTable()
        {
            DataTable dt = new DataTable();

            foreach (string item in columnsUsing.CheckedItems)
            {
                dt.Columns.Add(item.ToString());
            }

            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
        }

        /// <summary>
        /// Initialize columns in the form.
        /// </summary>
        private void InitializeColumns()
        {
            AvailableColumns.ForEach(item => columnsAvailable.Items.Add(item));
            SelectedColumns.ForEach(item => columnsUsing.Items.Add(item, true));
            SelectedColumns.ForEach(item =>
            {
                if (columnsAvailable.Items.Contains(item))
                    columnsAvailable.Items.Remove(item);
            });

            LoadDataTable();
        }

        /// <summary>
        /// Move the selected item up or down in the "Using" column.
        /// </summary>
        /// <param name="direction">Direction of movement (-1 for up, 1 for down).</param>
        private void MoveItem(int direction)
        {
            if (columnsUsing.SelectedItem == null)
                return; // No item selected

            int selectedIndex = columnsUsing.SelectedIndex;

            if ((direction == -1 && selectedIndex == 0) || (direction == 1 && selectedIndex == columnsUsing.Items.Count - 1))
                return; // Already at the top or bottom

            object selectedItem = columnsUsing.SelectedItem;
            var itemCheckState = columnsUsing.GetItemCheckState(selectedIndex);

            // Remove the item at the selected index
            columnsUsing.Items.RemoveAt(selectedIndex);

            // Insert the item at the new index (up or down)
            columnsUsing.Items.Insert(selectedIndex + direction, selectedItem);

            columnsUsing.SetItemCheckState(selectedIndex + direction, itemCheckState);

            // Update the selection to the moved item
            columnsUsing.SelectedIndex = selectedIndex + direction;
        }

        #endregion

        #region "Events"

        /// <summary>
        /// Handles the click event of the "OK" button.
        /// </summary>
        private void okButton_Click(object sender, EventArgs e)
        {
            SelectedColumns.Clear();
            foreach (string item in columnsAvailable.Items)
            {
                SelectedColumns.Add(item.ToString());
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Handles the click event of the "Cancel" button.
        /// </summary>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Handles the click event of the "Add" button.
        /// </summary>
        private void bAdd_Click(object sender, EventArgs e)
        {
            var columnsAvailableList = columnsAvailable.SelectedItems.Cast<string>().ToList();

            columnsAvailableList.ForEach(item => columnsUsing.Items.Add(item));
            columnsAvailableList.ForEach(item => columnsAvailable.Items.Remove(item));

            LoadDataTable();
        }

        /// <summary>
        /// Handles the click event of the "Remove" button.
        /// </summary>
        private void bRemove_Click(object sender, EventArgs e)
        {
            var columnsAvailableList = columnsUsing.SelectedItems.Cast<string>().ToList();

            columnsAvailableList.ForEach(item => columnsAvailable.Items.Add(item));
            columnsAvailableList.ForEach(item => columnsUsing.Items.Remove(item));

            LoadDataTable();
        }

        /// <summary>
        /// Handles the item check event of the CheckedListBox
        /// </summary>
        private void columnsUsing_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            columnsUsing.ItemCheck -= new ItemCheckEventHandler(columnsUsing_ItemCheck);
            columnsUsing.SetItemCheckState(e.Index, e.NewValue);
            columnsUsing.ItemCheck += new ItemCheckEventHandler(columnsUsing_ItemCheck);
            LoadDataTable();
        }

        /// <summary>
        /// Handles the mouse down event of the CheckedListBox
        /// </summary>
        private void columnsUsing_MouseDown(object sender, MouseEventArgs e)
        {
            if (columnsUsing.SelectedItem != null)
            {
                // Check if the mouse button is the left buttonIDIDIDID
                if (e.Button == MouseButtons.Left)
                {
                    // Check if the click is not on the checkbox portion of the item
                    int index = columnsUsing.IndexFromPoint(e.Location);
                    if (index >= 0 && e.X <= 10)
                        return;

                    // Start drag-and-drop operation
                    columnsUsing.DoDragDrop(columnsUsing.SelectedItem, DragDropEffects.Move);
                }
            }
        }

        /// <summary>
        /// Handles the drag over event of the CheckedListBox
        /// </summary>
        private void columnsUsing_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        /// <summary>
        /// Handles the drag drop event of the CheckedListBox
        /// </summary>
        private void columnsUsing_DragDrop(object sender, DragEventArgs e)
        {
            Point point = columnsUsing.PointToClient(new Point(e.X, e.Y));
            int index = columnsUsing.IndexFromPoint(point);
            if (index < 0) index = columnsUsing.Items.Count - 1;
            string data = e.Data.GetData(typeof(string)).ToString();
            var itemCheckState = columnsUsing.GetItemCheckState(columnsUsing.Items.IndexOf(data));
            columnsUsing.Items.Remove(data);
            columnsUsing.Items.Insert(index, data);
            columnsUsing.SetItemCheckState(index, itemCheckState);

            LoadDataTable();
        }

        /// <summary>
        /// Handles the click event of the "Save" button.
        /// </summary>
        private void bSave_Click(object sender, EventArgs e)
        {
            SelectedColumns = columnsUsing.CheckedItems.Cast<string>().ToList();
            DialogResult = DialogResult.OK;

            Close();
        }

        /// <summary>
        /// Handles the click event of the "Exit" button.
        /// </summary>
        private void bExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Handles the click event of the "Move Up" button.
        /// </summary>
        private void bUp_Click(object sender, EventArgs e)
        {
            MoveItem(-1);
        }

        /// <summary>
        /// Handles the click event of the "Move Down" button.
        /// </summary>
        private void bDown_Click(object sender, EventArgs e)
        {
            MoveItem(+1);
        }

        #endregion
    }
}
