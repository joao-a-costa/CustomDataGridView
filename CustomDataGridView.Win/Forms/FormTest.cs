using CustomDataGridView.Lib.Models;
using CustomDataGridView.Win.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CustomDataGridView.Win.Forms
{
    public partial class FormTest : Form
    {
        private CheckedListBox checkedListBox;
        private Button okButton;
        private Button cancelButton;

        public List<string> SelectedColumns { get; private set; }

        // Sample data source
        List<Person> persons = new List<Person>
            {
                new Person { ID = 1, FirstName = "John", LastName = "Doe", Age = 30, Email = "john@example.com" },
                new Person { ID = 2, FirstName = "Jane", LastName = "Smith", Age = 25, Email = "jane@example.com" },
                new Person { ID = 3, FirstName = "Bob", LastName = "Johnson", Age = 35, Email = "bob@example.com" },
                // Add more sample data here
            };

        public FormTest()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set the data source for the CustomDataGridView
            customDataGridView1.DataSource = persons;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = Newtonsoft.Json.JsonConvert.SerializeObject(customDataGridView1.GetDataGridViewSettings(), Formatting.Indented);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //customDataGridView1.Columns[0].Width
            customDataGridView1.SetDataGridViewSettings(JsonConvert.DeserializeObject<DataGridViewConfiguration>(textBox1.Text));
        }

        private void bSetCurrentCulture_Click(object sender, EventArgs e)
        {
            customDataGridView1.SetCurrentCulture(tbCurrentCulture.Text);
        }

        private void cbContextMenuDataGridViewOptionsVisible_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = (CheckBox)sender;

            customDataGridView1.GetType()?.GetProperty(checkBox.Tag.ToString())?.SetValue(customDataGridView1, checkBox.Checked);
        }
    }
}
