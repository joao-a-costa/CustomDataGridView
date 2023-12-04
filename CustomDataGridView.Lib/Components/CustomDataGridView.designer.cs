namespace CustomDataGridView.Lib.Components
{
    partial class CustomDataGridView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        
        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmSelectColumns = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDataGridViewOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.topLeftButton = new System.Windows.Forms.Button();
            this.tsmResetPreferences = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSelectColumns,
            this.tsmExportToExcel,
            this.tsmDataGridViewOptions,
            this.tsmResetPreferences});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(195, 100);
            // 
            // tsmSelectColumns
            // 
            this.tsmSelectColumns.Name = "tsmSelectColumns";
            this.tsmSelectColumns.Size = new System.Drawing.Size(194, 24);
            this.tsmSelectColumns.Text = "Select Columns";
            this.tsmSelectColumns.Click += new System.EventHandler(this.tsmSelectColumns_Click);
            // 
            // tsmExportToExcel
            // 
            this.tsmExportToExcel.Name = "tsmExportToExcel";
            this.tsmExportToExcel.Size = new System.Drawing.Size(194, 24);
            this.tsmExportToExcel.Text = "Export to excel";
            this.tsmExportToExcel.Visible = false;
            // 
            // tsmDataGridViewOptions
            // 
            this.tsmDataGridViewOptions.Name = "tsmDataGridViewOptions";
            this.tsmDataGridViewOptions.Size = new System.Drawing.Size(194, 24);
            this.tsmDataGridViewOptions.Text = "Table";
            // 
            // topLeftButton
            // 
            this.topLeftButton.Location = new System.Drawing.Point(0, 0);
            this.topLeftButton.Name = "topLeftButton";
            this.topLeftButton.Size = new System.Drawing.Size(40, 23);
            this.topLeftButton.TabIndex = 0;
            this.topLeftButton.Text = "...";
            this.topLeftButton.UseVisualStyleBackColor = true;
            this.topLeftButton.Click += new System.EventHandler(this.TopLeftButton_Click);
            // 
            // tsmResetPreferences
            // 
            this.tsmResetPreferences.Name = "tsmResetPreferences";
            this.tsmResetPreferences.Size = new System.Drawing.Size(194, 24);
            this.tsmResetPreferences.Text = "Reset Preferences";
            this.tsmResetPreferences.Click += tsmResetPreferences_Click;
            // 
            // CustomDataGridView
            // 
            this.RowTemplate.Height = 24;
            this.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.CustomDataGridView_DataBindingComplete);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CustomDataGridView_Paint);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmSelectColumns;
        private System.Windows.Forms.Button topLeftButton;
        private System.Windows.Forms.ToolStripMenuItem tsmExportToExcel;
        private System.Windows.Forms.ToolStripMenuItem tsmDataGridViewOptions;
        private System.Windows.Forms.ToolStripMenuItem tsmResetPreferences;
    }
}
