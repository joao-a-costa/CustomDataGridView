using System.Collections;
using System.Windows.Forms;

namespace CustomDataGridView.Lib.Components
{
    public class CustomDataGridViewDetail : TabControl
    {
        internal void AddChildgrid(IList listOfDetail, string name)
        {
            DataGridView grid = new DataGridView();

            grid.DataSource = listOfDetail;
            grid.Dock = DockStyle.Fill;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            TabPage tabpage = new TabPage { Text = name };

            tabpage.Controls.Add(grid);

            TabPages.Add(tabpage);
        }
    }
}
