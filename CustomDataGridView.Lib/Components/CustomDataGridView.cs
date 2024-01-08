using CustomDataGridView.Lib.Forms;
using CustomDataGridView.Lib.Helpers;
using CustomDataGridView.Lib.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CustomDataGridView.Lib.Components
{
    public partial class CustomDataGridView : DataGridView
    {
        #region "Constants"

        /// <summary>
        /// Default width of top left button
        /// </summary>
        private const int _topLeftButtonWidth = 25;

        #endregion

        #region "Members"

        /// <summary>
        /// Default visibility of top left button
        /// </summary>
        private bool topLeftButtonVisible = true;

        #endregion

        #region "Events"

        /// <summary>
        /// Represents the method signature for the UserSelectedColumns event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public delegate void UserSelectedColumnsEventHandler(object sender, EventArgs e);
        /// <summary>
        /// Event that is raised when the user selects columns.
        /// </summary>
        public event UserSelectedColumnsEventHandler UserSelectedColumns;
        /// <summary>
        /// Represents the method signature for the UserResetColumns event.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public delegate void UserResetColumnsEventHandler(object sender, EventArgs e);
        /// <summary>
        /// Event that is raised when the user reset columns.
        /// </summary>
        public event UserResetColumnsEventHandler UserResetColumns;

        #endregion

        #region "Properties"

        /// <summary>
        /// Create a list to store the available column names
        /// </summary>
        public List<string> ColumnsAvailable { get; private set; } = new List<string>();
        /// <summary>
        /// Create a list to store the selected column names
        /// </summary>
        public List<string> ColumnsSelected { get; private set; } = new List<string>();
        /// <summary>
        /// Return the wigth of the top left button
        /// </summary>
        public int TopLeftButtonWidth
        {
            get { return topLeftButton.Width; }
            set { topLeftButton.Width = value; }
        }
        /// <summary>
        /// Gets or sets the visibility of the top left button
        /// </summary>
        public bool TopLeftButtonVisible
        {
            get { return topLeftButton.Visible; }
            set { topLeftButtonVisible = value; topLeftButton.Visible = topLeftButtonVisible; }
        }
        /// <summary>
        /// Sets the visibility of the context menu 'SelectColumns'
        /// </summary>
        public bool ContextMenuSelectColumnsVisible
        {
            set { SetContextMenuItemVisibility(tsmSelectColumns.Name, value); }
        }
        /// <summary>
        /// Sets the visibility of the context menu 'ExportToExcel'
        /// </summary>
        public bool ContextMenuExportToExcelVisible
        {
            set { SetContextMenuItemVisibility(tsmExportToExcel.Name, value); }
        }
        /// <summary>
        /// Sets the visibility of the context menu 'DataGridViewOptions'
        /// </summary>
        public bool ContextMenuDataGridViewOptionsVisible
        {
            set { SetContextMenuItemVisibility(tsmDataGridViewOptions.Name, value); }
        }

        #endregion

        #region "Constructor"

        /// <summary>
        /// Constructor for the CustomDataGridView class
        /// </summary>
        public CustomDataGridView()
        {
            InitializeComponent();

            ConfigureButton();
            ConfigureToolStripenus();
            ConfigureLocalization();
        }

        #endregion

        #region "Private"

        /// <summary>
        /// Configure the button on the top corner of the DataGridView
        /// </summary>
        private void ConfigureButton()
        {
            // Create a button for the TopLeftHeaderCell
            topLeftButton.Height = ColumnHeadersHeight;
            topLeftButton.Width = _topLeftButtonWidth;

            // Add the button to the DataGridView's TopLeftHeaderCell
            Controls.Add(topLeftButton);
        }

        /// <summary>
        /// Configure the ToolStripMenus for the DataGridView options
        /// </summary>
        private void ConfigureToolStripenus()
        {
            foreach (var property in CustomDataGridViewHelper.GetPropertiesWithEnums(this))
            {
                var toolStripItemParent = new ToolStripMenuItem
                {
                    Name = $"{tsmDataGridViewOptions}_{property.Name}",
                    Text = property.Name,
                    Tag = property.Name
                };
                foreach (var enumValue in Enum.GetValues(property.PropertyType))
                {
                    var toolStripItemChild = new ToolStripMenuItem
                    {
                        Name = $"{tsmDataGridViewOptions}_{property.Name}_{enumValue}",
                        Text = enumValue.ToString(),
                        Tag = $"{property.Name}_{enumValue}"
                    };
                    toolStripItemChild.Click += ToolStripItemChild_Click;
                    toolStripItemParent.DropDownItems.Add(toolStripItemChild);
                }

                tsmDataGridViewOptions.DropDownItems.Add(toolStripItemParent);
            }
        }

        /// <summary>
        /// Set components text based on culture
        /// </summary>
        private void ConfigureLocalization()
        {
            tsmSelectColumns.Text = Localization.Global.labelSelectColumns;
            tsmExportToExcel.Text = Localization.Global.labelExportToExcel;
            tsmDataGridViewOptions.Text = Localization.Global.labelTable;
            tsmResetPreferences.Text = Localization.Global.labelResetPreferences;
        }

        /// <summary>
        /// Refresh the DataGridView to display selected columns
        /// </summary>
        private void RefreshColumns()
        {
            foreach (DataGridViewColumn column in Columns)
            {
                if (!ColumnsSelected.Contains(column.Name))
                {
                    column.Visible = false;
                }
                else
                {
                    // Set the display order based on the index in your list
                    column.Visible = true;
                    column.DisplayIndex = ColumnsSelected.IndexOf(column.Name);
                }
            }
            Refresh();
        }

        /// <summary>
        /// Refresh the DataGridView available columns
        /// </summary>
        public void RefreshColumnsAvailable()
        {
            ColumnsAvailable = Columns.Cast<DataGridViewColumn>().Select(s => s.Name).ToList();

            topLeftButton.Visible = topLeftButton.Visible && ColumnsAvailable.Count > 0;
        }

        /// <summary>
        /// Reposition the TopLeftButton to center it in the TopLeftHeaderCell
        /// </summary>
        private void RepositionTopLeftButton()
        {
            // Calculate the button's position to center it
            int x = (TopLeftHeaderCell.Size.Width - topLeftButton.Width) / 2;
            int y = (TopLeftHeaderCell.Size.Height - topLeftButton.Height) / 2;

            // Set the button's position
            topLeftButton.Location = new System.Drawing.Point(x, y);
            topLeftButton.Visible = topLeftButtonVisible;
        }

        /// <summary>
        /// Sets the visibility of a context menu item based on its name.
        /// </summary>
        /// <param name="contextMenuItemName">The name of the context menu item.</param>
        /// <param name="visible">A boolean value indicating whether the context menu item should be visible.</param>
        private void SetContextMenuItemVisibility(string contextMenuItemName, bool visible)
        {
            var toolStripMenuItem = contextMenuStrip1.Items.Cast<ToolStripMenuItem>().FirstOrDefault(fod => fod.Name == contextMenuItemName);

            if (toolStripMenuItem != null)
                toolStripMenuItem.Visible = visible;
        }

        /// <summary>
        /// Moves the focus to the next cell based on the current cell position.
        /// </summary>
        /// <param name="currentRowIndex">The index of the current row.</param>
        /// <param name="currentColumnIndex">The index of the current column.</param>
        private void MoveToNextCell(int currentRowIndex, int currentColumnIndex)
        {
            try
            {
                int nextRowIndex = currentRowIndex;
                int nextColumnIndex = currentColumnIndex + 1;

                // Check if the next column exists
                if (nextColumnIndex >= Columns.Count)
                {
                    // Move to the first column of the next row
                    nextColumnIndex = 0;
                    nextRowIndex++;
                }

                // Check if the next row exists
                if (nextRowIndex < Rows.Count)
                {
                    // Move to the next cell
                    CurrentCell = this[nextColumnIndex, nextRowIndex];
                }
                else
                {
                    // No next cell, end editing
                    EndEdit();
                }
            }
            catch(Exception) { }
        }

        #endregion

        #region "Public"

        /// <summary>
        /// Method to display a dialog for column selection
        /// </summary>
        public void ShowColumnSelectionDialog()
        {
            using (var columnSelectionForm = new ColumnSelectionForm(ColumnsAvailable,
                Columns.Cast<DataGridViewColumn>().Where(w => w.Visible).OrderBy(ob => ob.DisplayIndex).Select(s => s.Name).ToList()))
            {
                if (columnSelectionForm.ShowDialog() == DialogResult.OK)
                {
                    ColumnsSelected = columnSelectionForm.SelectedColumns;
                    RefreshColumns();
                    OnUserSelectedColumns(new EventArgs());
                }
            }
        }

        /// <summary>
        /// Method to get DataGridView settings as a configuration object
        /// </summary>
        public DataGridViewConfiguration GetDataGridViewSettings()
        {
            var dataGridViewConfiguration = new DataGridViewConfiguration();

            Columns.Cast<DataGridViewColumn>().Where(w => w.Visible).ToList().ForEach(fe =>
            {
                var columnFound = Columns.Cast<DataGridViewColumn>().FirstOrDefault(fod => fod.Name == fe.Name);

                dataGridViewConfiguration.Columns.Add(new DataGridViewConfigurationColumn
                {
                    ColumnName = fe.Name,
                    Width = columnFound.Width,
                    DisplayIndex = columnFound.DisplayIndex
                });
            });

            CustomDataGridViewHelper.GetPropertiesWithEnums(this).ToList().ForEach(fe =>
            {
                dataGridViewConfiguration.ExtraProperties.Add(new DataGridViewConfigurationExtraProperty
                {
                    Name = fe.Name,
                    Value = fe.GetValue(this)
                });
            });

            return dataGridViewConfiguration;
        }

        /// <summary>
        /// Method to set DataGridView settings from a configuration object
        /// </summary>
        public void SetDataGridViewSettings(DataGridViewConfiguration dataGridViewConfiguration)
        {
            Columns.Cast<DataGridViewColumn>().ToList().ForEach(fe =>
            {
                var columnFound = dataGridViewConfiguration.Columns.FirstOrDefault(fod => fod.ColumnName == fe.Name);

                if (columnFound != null)
                {
                    fe.Width = columnFound.Width;
                    fe.Visible = true;
                    fe.DisplayIndex = columnFound.DisplayIndex;
                }
                else
                    fe.Visible = false;
            });
            dataGridViewConfiguration.Columns.ForEach(fe =>
            {
                var columnFound = Columns.Cast<DataGridViewColumn>().FirstOrDefault(fod => fod.Name == fe.ColumnName);

                if (columnFound != null)
                {
                    columnFound.Width = fe.Width;
                    columnFound.DisplayIndex = fe.DisplayIndex;
                }
            });

            dataGridViewConfiguration.ExtraProperties.ForEach(fe =>
            {
                CustomDataGridViewHelper.ChangeProperty(this, fe.Name,
                    Enum.Parse(GetType().GetProperty(fe.Name).PropertyType, fe.Value.ToString()));
            });
        }

        /// <summary>
        /// Sets the current culture for the application.
        /// </summary>
        /// <param name="name">The name of the culture to set.</param>
        /// <param name="useUserOverride">A flag indicating whether to use user overrides for the culture.</param>
        public void SetCurrentCulture(string name, bool useUserOverride = false)
        {
            try
            {
                CultureInfo cultureInfo = new CultureInfo(name, useUserOverride);
                Thread.CurrentThread.CurrentCulture = cultureInfo;
                Thread.CurrentThread.CurrentUICulture = cultureInfo;

                ConfigureLocalization();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion

        #region "Protected"

        /// <summary>
        /// Raises the UserSelectedColumns event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnUserSelectedColumns(EventArgs e)
        {
            // Check if any subscribers have been attached to the event
            if (UserSelectedColumns != null)
            {
                // Invoke the event
                UserSelectedColumns(this, e);
            }
        }

        /// <summary>
        /// Raises the UserResetColumns event.
        /// </summary>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected virtual void OnUserResetColumns(EventArgs e)
        {
            // Check if any subscribers have been attached to the event
            if (UserResetColumns != null)
            {
                // Invoke the event
                UserResetColumns(this, e);
            }
        }

        /// <summary>
        /// Overrides the ProcessCmdKey method to handle specific key presses.
        /// </summary>
        /// <param name="msg">A <see cref="Message"/>, passed by reference, that represents the window message to process.</param>
        /// <param name="keyData">One of the <see cref="Keys"/> values that represents the key to process.</param>
        /// <returns>true if the key was processed by the control; otherwise, false.</returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter || keyData == Keys.Tab)
            {
                // Handle the key press here
                int currentRowIndex = CurrentCell.RowIndex;
                int currentColumnIndex = CurrentCell.ColumnIndex;

                MoveToNextCell(currentRowIndex, currentColumnIndex);

                // Indicate that the key press has been handled
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region "Events"

        /// <summary>
        /// Event handler for ToolStripItemChild click
        /// </summary>
        private void ToolStripItemChild_Click(object sender, EventArgs e)
        {
            var toolStripMenuItem = (ToolStripMenuItem)sender;
            var toolStripMenuItemSplitted = toolStripMenuItem.Tag.ToString().Split(new char[] { '_' });

            CustomDataGridViewHelper.ChangeProperty(this, toolStripMenuItemSplitted[0],
                Enum.Parse(GetType().GetProperty(toolStripMenuItemSplitted[0]).PropertyType, toolStripMenuItemSplitted[1]));

            Refresh();
        }

        /// <summary>
        /// Event handler for TopLeftButton click
        /// </summary>
        private void TopLeftButton_Click(object sender, EventArgs e) => contextMenuStrip1.Show(topLeftButton, 0, topLeftButton.Height);

        /// <summary>
        /// Event handler for tsmSelectColumns click
        /// </summary>
        private void tsmSelectColumns_Click(object sender, EventArgs e) => ShowColumnSelectionDialog();

        /// <summary>
        /// Event handler for tsmResetPreferences click. Resets datagridiview
        /// </summary>
        private void tsmResetPreferences_Click(object sender, EventArgs e)
        {
            var dataTable = DataSource;

            DataSource = null;
            DataSource = dataTable;

            OnUserResetColumns(new EventArgs());
        }

        /// <summary>
        /// Event handler for CustomDataGridView Paint
        /// </summary>
        private void CustomDataGridView_Paint(object sender, PaintEventArgs e) => RepositionTopLeftButton();

        /// <summary>
        /// Event handler for CustomDataGridView DataBindingComplete
        /// </summary>
        private void CustomDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            RefreshColumnsAvailable();
        }

        /// <summary>
        /// Event handler for CustomDataGridView for ColumnAdded or ColumnRemoved
        /// </summary>
        private void CustomDataGridView_Changed(object sender, DataGridViewColumnEventArgs e)
        {
            RefreshColumnsAvailable();
        }

        #endregion
    }
}
