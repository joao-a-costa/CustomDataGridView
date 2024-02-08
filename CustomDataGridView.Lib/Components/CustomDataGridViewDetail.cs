using CustomDataGridView.Lib.Helpers;
using CustomDataGridView.Lib.Models;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CustomDataGridView.Lib.Components
{
    public class CustomDataGridViewDetail : TabControl
    {
        #region "Properties"

        private List<DataGridViewColumnButtonEvent> DataGridViewColumnButtonEvents { get; set; }
        private CustomDataGridView CustomDataGridView { get; set; }

        #endregion

        #region "Private"

        private void AddColumnsToDataGridView()
        {
            DataGridViewColumnButtonEvents?.ForEach(fe =>
            {
                // Create the delete button column
                var column = new DataGridViewButtonColumn
                {
                    Name = fe.ColumnName,
                    Text = fe.ColumnName,
                    HeaderText = fe.HeaderText,
                    UseColumnTextForButtonValue = true
                };

                // Add the delete button column to the end of the DataGridView
                CustomDataGridView.Columns.Insert(CustomDataGridView.Columns.Count, column);
            });
        }

        /// <summary>
        /// Adds a child grid to the tab control
        /// </summary>
        internal void AddChildgrid(IList listOfDetail, string name, List<DataGridViewColumnButtonEvent> dataGridViewColumnButtonEvents, DataGridViewConfiguration defaultDataGridViewConfiguration)
        {
            DataGridViewColumnButtonEvents = dataGridViewColumnButtonEvents;
            CustomDataGridView = new CustomDataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                TopLeftButtonVisible = false
            };
            CustomDataGridView.DefaultDataGridViewConfiguration = defaultDataGridViewConfiguration;
            CustomDataGridView.DataSource = listOfDetail;
            CustomDataGridView.CellContentClick += Grid_CellContentClick;
            CustomDataGridView.DataBindingComplete += Grid_DataBindingComplete;

            TabPage tabpage = new TabPage { Text = name };

            tabpage.Controls.Add(CustomDataGridView);

            TabPages.Add(tabpage);
        }

        private void Grid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            CustomDataGridViewHelper.SetDataGridViewSettings(CustomDataGridView.DefaultDataGridViewConfiguration, CustomDataGridView, false);
            AddColumnsToDataGridView();
        }

        /// <summary>
        /// Event handler for the cell content click
        /// </summary>
        private void Grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridViewColumnButtonEvents != null && e.RowIndex >= 0)
            {
                var dataGridView = (DataGridView)sender;
                var columnName = dataGridView.Columns[e.ColumnIndex].Name;

                var action = DataGridViewColumnButtonEvents.FirstOrDefault(fod => fod.ColumnName == columnName);

                if (action?.Action != null)
                    action.Action(dataGridView.Rows[e.RowIndex].DataBoundItem);
            }
        }

        #endregion
    }
}
