using CustomDataGridView.Lib.Models;
using CustomDataGridView.Win.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CustomDataGridView.Win.Forms
{
    /// <summary>
    /// Represents the main form of the test application.
    /// </summary>
    public partial class FormTest : Form
    {
        private const string _labelColumnsSelected = "Columns were selected";
        private const string _labelColumnsReset = "Columns were reset";

        /// <summary>
        /// Gets the list of selected columns.
        /// </summary>
        public List<string> SelectedColumns { get; private set; }

        // Sample data source
        List<Person> persons = new List<Person>
        {
            new Person { ID = 1, FirstName = "John", LastName = "Doe", Age = 30, Email = "john@example.com" },
            new Person { ID = 2, FirstName = "Jane", LastName = "Smith", Age = 25, Email = "jane@example.com" },
            new Person { ID = 3, FirstName = "Bob", LastName = "Johnson", Age = 35, Email = "bob@example.com" },
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="FormTest"/> class.
        /// </summary>
        public FormTest()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // Set the data source for the CustomDataGridView
            customDataGridView1.DataSource = persons;
        }

        /// <summary>
        /// Handles the Click event of the button1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = JsonConvert.SerializeObject(customDataGridView1.GetDataGridViewSettings(), Formatting.Indented);
        }

        /// <summary>
        /// Handles the Click event of the button2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button2_Click(object sender, EventArgs e)
        {
            customDataGridView1.SetDataGridViewSettings(JsonConvert.DeserializeObject<DataGridViewConfiguration>(textBox1.Text));
        }

        /// <summary>
        /// Handles the Click event of the bSetCurrentCulture control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void bSetCurrentCulture_Click(object sender, EventArgs e)
        {
            customDataGridView1.SetCurrentCulture(tbCurrentCulture.Text);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the cbContextMenuDataGridViewOptionsVisible control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cbContextMenuDataGridViewOptionsVisible_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = (CheckBox)sender;

            customDataGridView1.GetType()?.GetProperty(checkBox.Tag.ToString())?.SetValue(customDataGridView1, checkBox.Checked);
        }

        /// <summary>
        /// Handles the UserSelectedColumns event of the customDataGridView1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void customDataGridView1_UserSelectedColumns(object sender, EventArgs e)
        {
            MessageBox.Show(_labelColumnsSelected);
        }

        /// <summary>
        /// Handles the UserResetColumns event of the customDataGridView1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void customDataGridView1_UserResetColumns(object sender, EventArgs e)
        {
            MessageBox.Show(_labelColumnsReset);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the cbTopLeftButtonVisible control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cbTopLeftButtonVisible_CheckedChanged(object sender, EventArgs e)
        {
            customDataGridView1.TopLeftButtonVisible = cbTopLeftButtonVisible.Checked;
        }
    }
}