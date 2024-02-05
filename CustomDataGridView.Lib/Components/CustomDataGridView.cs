using CustomDataGridView.Lib.CustomColumns;
using CustomDataGridView.Lib.Forms;
using CustomDataGridView.Lib.Helpers;
using CustomDataGridView.Lib.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
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
        private const int _rowDefaultHeight = 22;
        private const int _rowExpandedHeight = 200;
        private const int _rowDefaultDivider = 0;
        private const int _rowExpandedDivider = 300 - 22;
        private const int _columnHeadersHeight = 40;

        #endregion

        #region "Members"

        /// <summary>
        /// Default visibility of top left button
        /// </summary>
        private bool topLeftButtonVisible = true;
        /// <summary>
        /// Indicates whether the row should be collapsed.
        /// </summary>
        private bool doCollapseRow;
        /// <summary>
        /// List of rows that are currently expanded.
        /// </summary>
        private List<int> lstCurrentRows = new List<int>();
        /// <summary>
        /// Row header icon list.
        /// </summary>
        private ImageList rowHeaderIconList = new ImageList();
        /// <summary>
        /// Detail tab control.
        /// </summary>
        private CustomDataGridViewDetail detailTabControl = new CustomDataGridViewDetail { Height = 278 /*rowExpandedDivider*/ - 5/*rowDividerMargin*/ * 2, Visible = false };
        /// <summary>
        /// Flag indicating whether the row details are enabled.
        /// </summary>
        private bool enableRowDetails = false;

        #endregion

        #region "Enums"

        public enum RowHeaderIcons
        {
            Expand = 1,
            Collapse = 0
        }

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
        /// <summary>
        /// Default DataGridViewConfiguration
        /// </summary>
        public DataGridViewConfiguration DefaultDataGridViewConfiguration { get; set; }
        /// <summary>
        /// Default for ChangeColumnTypesToCustom
        /// </summary>
        public bool ChangeColumnTypesToCustom { get; set; } = true;
        /// <summary>
        /// Sets the image of the top left button
        /// </summary>
        public Image TopLeftButtonImage { get { return topLeftButton.Image; } set { topLeftButton.Image = value; } }
        /// <summary>
        /// Sets the FlatStyle of the top left button
        /// </summary>
        public FlatStyle TopLeftButtonFlatStyle { get { return topLeftButton.FlatStyle; } set { topLeftButton.FlatStyle = value; } }
        /// <summary>
        /// Sets the BackColor of the top left button
        /// </summary>
        public Color TopLeftButtonBackColor { get { return topLeftButton.BackColor; } set { topLeftButton.BackColor = value; } }
        /// <summary>
        /// Enable or disable the row details
        /// </summary>
        public bool EnableRowDetails { get { return enableRowDetails; } set { enableRowDetails = value; } }
        /// <summary>
        /// Gets or sets the DataGridViewColumnButtonEvents
        /// </summary>
        public List<DataGridViewColumnButtonEvent> DataGridViewColumnButtonEvents { get; set; }

        #endregion

        #region "Constructor"

        /// <summary>
        /// Constructor for the CustomDataGridView class
        /// </summary>
        public CustomDataGridView()
        {
            InitializeComponent();

            ConfigureDataGridViewDetails();
            ConfigureButton();
            ConfigureToolStripMenus();
            ConfigureLocalization();
        }

        /// <summary>
        /// Configure the DataGridView details
        /// </summary>
        private void ConfigureDataGridViewDetails()
        {
            rowHeaderIconList.Images.Add(Properties.Resources.minus16x16);
            rowHeaderIconList.Images.Add(Properties.Resources.add16x16);

            RowPostPaint += CustomDataGridView_RowPostPaint;
            RowHeadersDefaultCellStyle.Padding = new Padding(RowHeadersWidth);
            RowHeaderMouseClick += CustomDataGridView_RowHeaderMouseClick;
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

            topLeftButton.FlatStyle = FlatStyle.Flat;
            topLeftButton.FlatAppearance.BorderSize = 0;
            topLeftButton.BackColor = Color.White;
            topLeftButton.Image = Properties.Resources.settings16x16;

            // Add the button to the DataGridView's TopLeftHeaderCell
            Controls.Add(topLeftButton);
        }

        /// <summary>
        /// Configure the ToolStripMenus for the DataGridView options
        /// </summary>
        private void ConfigureToolStripMenus()
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

            //AdjustButtonSizeAndPosition();
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
                int nextColumnIndex = currentColumnIndex;

                do
                {
                    nextColumnIndex++;

                    // Check if the next column exists
                    if (nextColumnIndex >= Columns.Count)
                    {
                        // Move to the first column of the next row
                        nextColumnIndex = 0;
                        nextRowIndex++;
                    }

                    // Check if the next row exists
                    if (nextRowIndex >= Rows.Count)
                    {
                        // No next cell, end editing
                        EndEdit();
                        return;
                    }
                }
                while (this.Columns[nextColumnIndex].ReadOnly || !this.Columns[nextColumnIndex].Visible);

                // Move to the next cell
                CurrentCell = this[nextColumnIndex, nextRowIndex];
            }
            catch (Exception)
            {
                // Handle exception
                // ...
            }
        }

        /// <summary>
        /// Hides the row header selector.
        /// </summary>
        private void HideRowHeaderSelector(DataGridViewRowPostPaintEventArgs e)
        {
            object o = Rows[e.RowIndex].HeaderCell.Value;

            e.Graphics.DrawString(
                o != null ? o.ToString() : "",
                Font,
                Brushes.Black,
                new PointF((float)e.RowBounds.Left + 2, (float)e.RowBounds.Top + 4));
        }

        /// <summary>
        /// Opens or closes the detail of a row.
        /// </summary>
        private void OpenDetail(int rowIndex)
        {
            if (lstCurrentRows.Contains(rowIndex))
            {
                lstCurrentRows.Clear();
                Rows[rowIndex].Height = _rowDefaultHeight;
                Rows[rowIndex].DividerHeight = _rowDefaultDivider;
            }
            else
            {
                if (lstCurrentRows.Count != 0)
                {
                    int eRow = lstCurrentRows[0];
                    lstCurrentRows.Clear();
                    Rows[eRow].Height = _rowDefaultHeight;
                    Rows[eRow].DividerHeight = _rowDefaultDivider;
                    ClearSelection();
                    doCollapseRow = true;
                    Rows[eRow].Selected = true;
                }

                lstCurrentRows.Add(rowIndex);

                object parentObject = Rows[rowIndex].DataBoundItem;

                detailTabControl.TabPages.Clear();

                if (parentObject != null)
                {
                    parentObject.GetType().GetProperties().Where(p => typeof(IList).IsAssignableFrom(p.PropertyType)).ToList().ForEach(fe =>
                    {
                        IList listOfDetail = (IList)fe.GetValue(parentObject);

                        detailTabControl.AddChildgrid(listOfDetail, fe.Name, DataGridViewColumnButtonEvents);
                    });
                }

                if (detailTabControl.HasChildren)
                {
                    Rows[rowIndex].Height = _rowExpandedHeight;
                    Rows[rowIndex].DividerHeight = _rowExpandedDivider;
                }
                else
                {
                    detailTabControl.Visible = false;
                }
            }
            ClearSelection();
            doCollapseRow = true;
            Rows[rowIndex].Selected = true;
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
                    HeaderText = fe.HeaderText,
                    Width = columnFound.Width,
                    DisplayIndex = columnFound.DisplayIndex,
                    Visible = fe.Visible,
                    ReadOnly = fe.ReadOnly,
                    Type = fe.CellType,
                    Aligment = fe.DefaultCellStyle.Alignment,
                    Format = fe.DefaultCellStyle.Format,
                    FontStyle = fe.DefaultCellStyle.Font.Style,
                    BackColor = fe.DefaultCellStyle.BackColor,
                    ForeColor = fe.DefaultCellStyle.ForeColor
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
        public void SetDataGridViewSettings(DataGridViewConfiguration dataGridViewConfiguration, bool setColumnsNotFoundVisible = true)
        {
            Columns.Cast<DataGridViewColumn>().ToList().ForEach(fe =>
            {
                var columnFound = dataGridViewConfiguration.Columns.FirstOrDefault(fod => fod.ColumnName == fe.Name);
                var fontToSet = fe.DefaultCellStyle.Font == null ? Font : fe.DefaultCellStyle.Font;
                var backColorToSet = fe.DefaultCellStyle.BackColor == null ? BackColor : fe.DefaultCellStyle.BackColor;
                var foreColorToSet = fe.DefaultCellStyle.ForeColor == null ? ForeColor : fe.DefaultCellStyle.ForeColor;

                if (columnFound != null)
                {
                    fe.Name = columnFound.ColumnName;
                    fe.HeaderText = columnFound.HeaderText;
                    fe.Visible = columnFound.Visible;
                    fe.ReadOnly = columnFound.ReadOnly;
                    fe.DefaultCellStyle.Alignment = columnFound.Aligment;
                    fe.DefaultCellStyle.Format = columnFound.Format;
                    fe.DefaultCellStyle.FormatProvider = CultureInfo.CurrentCulture.NumberFormat;
                    fe.DefaultCellStyle.Font = new System.Drawing.Font(fontToSet.FontFamily, fontToSet.Size, columnFound.FontStyle);
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
            dataGridViewConfiguration.Columns.ForEach(fe =>
            {
                var columnFound = Columns.Cast<DataGridViewColumn>().FirstOrDefault(fod => fod.Name == fe.ColumnName);

                if (columnFound != null)
                {
                    var fontToSet = columnFound.DefaultCellStyle.Font == null ? Font : columnFound.DefaultCellStyle.Font;
                    var backColorToSet = columnFound.DefaultCellStyle.BackColor == null ? BackColor : columnFound.DefaultCellStyle.BackColor;
                    var foreColorToSet = columnFound.DefaultCellStyle.ForeColor == null ? ForeColor : columnFound.DefaultCellStyle.ForeColor;

                    columnFound.Name = fe.ColumnName;
                    columnFound.HeaderText = fe.HeaderText;
                    columnFound.Visible = fe.Visible;
                    columnFound.ReadOnly = fe.ReadOnly;
                    columnFound.DefaultCellStyle.Alignment = fe.Aligment;
                    columnFound.DefaultCellStyle.Format = fe.Format;
                    columnFound.DefaultCellStyle.FormatProvider = CultureInfo.CurrentCulture.NumberFormat;
                    columnFound.DefaultCellStyle.Font = new System.Drawing.Font(fontToSet.FontFamily, fontToSet.Size, fe.FontStyle);
                    columnFound.DefaultCellStyle.BackColor = fe.BackColor;
                    columnFound.DefaultCellStyle.ForeColor = fe.ForeColor;
                    if (fe.Width.HasValue)
                        columnFound.Width = fe.Width.Value;
                    if (fe.DisplayIndex.HasValue)
                        columnFound.DisplayIndex = fe.DisplayIndex.Value;
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

        /// <summary>
        /// Initialize the DataGridView
        /// </summary>
        public void InitializeDataGridView()
        {
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            ColumnHeadersHeight = _columnHeadersHeight;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            if (Parent == null)
                throw new Exception(Localization.Global.labelControlShouldBeInContainer);

            Parent.Controls.Add(detailTabControl);
            detailTabControl.BringToFront();
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
            SetDataGridViewSettings(DefaultDataGridViewConfiguration);

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
            if (ChangeColumnTypesToCustom)
            {
                // Create a list to store the columns to modify
                var columnsToModify = Columns.Cast<DataGridViewColumn>()
                    .Where(w => w.ValueType == typeof(DateTime))
                    .ToList();

                // Iterate over the list and modify the columns
                foreach (DataGridViewColumn column in columnsToModify)
                {
                    // Specify the target column type (in this case, DataGridViewTextBoxColumn)
                    CustomDataGridViewHelper.ChangeColumnType<DateTimePickerColumn>(this, column.Name);
                }
            }
        }

        /// <summary>
        /// Event handler for CustomDataGridView for RowHeaderMouseClick
        /// </summary>
        private void CustomDataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (enableRowDetails)
            {
                if (Rows[e.RowIndex].DataBoundItem == null)
                    return;
                Rectangle rect = new Rectangle(_rowDefaultHeight / 2, (_rowDefaultHeight - 16) / 2, 16, 16);
                if (rect.Contains(e.Location))
                    OpenDetail(e.RowIndex);
                else
                    doCollapseRow = false;
            }
        }

        /// <summary>
        /// Event handler for CustomDataGridView for RowPostPaint
        /// </summary>
        private void CustomDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (enableRowDetails)
            {
                HideRowHeaderSelector(e);

                //// Calculate the button's position to center it
                Rectangle rect = new Rectangle(e.RowBounds.X + (_rowDefaultHeight / 2), e.RowBounds.Y + ((_rowDefaultHeight - 16) / 2), 16, 16);

                if (doCollapseRow)
                {
                    if (lstCurrentRows.Contains(e.RowIndex))
                    {
                        Rows[e.RowIndex].DividerHeight = Rows[e.RowIndex].Height - _rowDefaultHeight;

                        e.Graphics.DrawImage(rowHeaderIconList.Images[(int)RowHeaderIcons.Collapse], rect);

                        detailTabControl.Location = new Point(e.RowBounds.Left + RowHeadersWidth, e.RowBounds.Top + _rowDefaultHeight + 20);
                        detailTabControl.Width = e.RowBounds.Right - RowHeadersWidth;
                        detailTabControl.Height = Rows[e.RowIndex].DividerHeight - 10;
                        detailTabControl.Visible = true;
                    }
                    else
                    {
                        detailTabControl.Visible = false;
                        e.Graphics.DrawImage(rowHeaderIconList.Images[(int)RowHeaderIcons.Expand], rect);
                    }
                    doCollapseRow = false;
                }
                else
                {
                    if (lstCurrentRows.Contains(e.RowIndex))
                    {
                        Rows[e.RowIndex].DividerHeight = Rows[e.RowIndex].Height - _rowDefaultHeight;
                        e.Graphics.DrawImage(rowHeaderIconList.Images[(int)RowHeaderIcons.Collapse], rect);
                        detailTabControl.Location = new Point(e.RowBounds.Left + RowHeadersWidth, e.RowBounds.Top + _rowDefaultHeight + 20);
                        detailTabControl.Width = e.RowBounds.Right - RowHeadersWidth;
                        detailTabControl.Height = Rows[e.RowIndex].DividerHeight - 10;
                        detailTabControl.Visible = true;
                    }
                    else
                    {
                        e.Graphics.DrawImage(rowHeaderIconList.Images[(int)RowHeaderIcons.Expand], rect);
                    }
                }
            }
        }

        #endregion
    }
}
