using CustomDataGridView.Lib.Forms;
using CustomDataGridView.Lib.Helpers;
using CustomDataGridView.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        #region "Properties"

        /// <summary>
        /// Create a list to store the selected column names
        /// </summary>
        public List<string> ColumnsAvailable { get; private set; } = new List<string>();
        public List<string> ColumnsSelected { get; private set; } = new List<string>();
        /// <summary>
        /// Return the wigth of the top left button
        /// </summary>
        public int TopLeftButtonWidth
        {
            get { return topLeftButton.Width; }
            set { topLeftButton.Width = value; }
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
        /// Refresh the DataGridView to display selected columns
        /// </summary>
        private void RefreshColumns()
        {
            foreach (DataGridViewColumn column in Columns)
            {
                column.Visible = ColumnsSelected.Contains(column.Name);
            }
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
        }

        #endregion

        #region "Public"

        /// <summary>
        /// Method to display a dialog for column selection
        /// </summary>
        public void ShowColumnSelectionDialog()
        {
            using (var columnSelectionForm = new ColumnSelectionForm(ColumnsAvailable,
                Columns.Cast<DataGridViewColumn>().Where(w => w.Visible).Select(s => s.Name).ToList()))
            {
                if (columnSelectionForm.ShowDialog() == DialogResult.OK)
                {
                    ColumnsSelected = columnSelectionForm.SelectedColumns;
                    RefreshColumns();
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
                    Width = columnFound.Width
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
                }
                else
                    fe.Visible = false;
            });
            dataGridViewConfiguration.Columns.ForEach(fe =>
            {
                var columnFound = Columns.Cast<DataGridViewColumn>().FirstOrDefault(fod => fod.Name == fe.ColumnName);

                if (columnFound != null)
                    columnFound.Width = fe.Width;
            });

            dataGridViewConfiguration.ExtraProperties.ForEach(fe =>
            {
                CustomDataGridViewHelper.ChangeProperty(this, fe.Name,
                    Enum.Parse(GetType().GetProperty(fe.Name).PropertyType, fe.Value.ToString()));
            });
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
        /// Event handler for CustomDataGridView Paint
        /// </summary>
        private void CustomDataGridView_Paint(object sender, PaintEventArgs e) => RepositionTopLeftButton();

        /// <summary>
        /// Event handler for CustomDataGridView DataBindingComplete
        /// </summary>
        private void CustomDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) => ColumnsAvailable = Columns.Cast<DataGridViewColumn>().Select(s => s.Name).ToList();

        #endregion
    }
}
