namespace CustomDataGridView.Win.Forms
{
    partial class FormTest
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbContextMenuDataGridViewOptionsVisible = new System.Windows.Forms.CheckBox();
            this.cbContextMenuExportToExcelVisible = new System.Windows.Forms.CheckBox();
            this.cbContextMenuSelectColumnsVisible = new System.Windows.Forms.CheckBox();
            this.bSetCurrentCulture = new System.Windows.Forms.Button();
            this.tbCurrentCulture = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cbTopLeftButtonVisible = new System.Windows.Forms.CheckBox();
            this.customDataGridView1 = new CustomDataGridView.Lib.Components.CustomDataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 185);
            this.panel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(554, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(246, 185);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(4, 19);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(238, 162);
            this.textBox1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbTopLeftButtonVisible);
            this.panel2.Controls.Add(this.cbContextMenuDataGridViewOptionsVisible);
            this.panel2.Controls.Add(this.cbContextMenuExportToExcelVisible);
            this.panel2.Controls.Add(this.cbContextMenuSelectColumnsVisible);
            this.panel2.Controls.Add(this.bSetCurrentCulture);
            this.panel2.Controls.Add(this.tbCurrentCulture);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(554, 185);
            this.panel2.TabIndex = 3;
            // 
            // cbContextMenuDataGridViewOptionsVisible
            // 
            this.cbContextMenuDataGridViewOptionsVisible.AutoSize = true;
            this.cbContextMenuDataGridViewOptionsVisible.Checked = true;
            this.cbContextMenuDataGridViewOptionsVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbContextMenuDataGridViewOptionsVisible.Location = new System.Drawing.Point(271, 88);
            this.cbContextMenuDataGridViewOptionsVisible.Name = "cbContextMenuDataGridViewOptionsVisible";
            this.cbContextMenuDataGridViewOptionsVisible.Size = new System.Drawing.Size(276, 20);
            this.cbContextMenuDataGridViewOptionsVisible.TabIndex = 6;
            this.cbContextMenuDataGridViewOptionsVisible.Tag = "ContextMenuDataGridViewOptionsVisible";
            this.cbContextMenuDataGridViewOptionsVisible.Text = "ContextMenuDataGridViewOptionsVisible";
            this.cbContextMenuDataGridViewOptionsVisible.UseVisualStyleBackColor = true;
            this.cbContextMenuDataGridViewOptionsVisible.CheckedChanged += new System.EventHandler(this.cbContextMenuDataGridViewOptionsVisible_CheckedChanged);
            // 
            // cbContextMenuExportToExcelVisible
            // 
            this.cbContextMenuExportToExcelVisible.AutoSize = true;
            this.cbContextMenuExportToExcelVisible.Location = new System.Drawing.Point(271, 56);
            this.cbContextMenuExportToExcelVisible.Name = "cbContextMenuExportToExcelVisible";
            this.cbContextMenuExportToExcelVisible.Size = new System.Drawing.Size(235, 20);
            this.cbContextMenuExportToExcelVisible.TabIndex = 5;
            this.cbContextMenuExportToExcelVisible.Tag = "ContextMenuExportToExcelVisible";
            this.cbContextMenuExportToExcelVisible.Text = "ContextMenuExportToExcelVisible";
            this.cbContextMenuExportToExcelVisible.UseVisualStyleBackColor = true;
            this.cbContextMenuExportToExcelVisible.CheckedChanged += new System.EventHandler(this.cbContextMenuDataGridViewOptionsVisible_CheckedChanged);
            // 
            // cbContextMenuSelectColumnsVisible
            // 
            this.cbContextMenuSelectColumnsVisible.AutoSize = true;
            this.cbContextMenuSelectColumnsVisible.Checked = true;
            this.cbContextMenuSelectColumnsVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbContextMenuSelectColumnsVisible.Location = new System.Drawing.Point(271, 20);
            this.cbContextMenuSelectColumnsVisible.Name = "cbContextMenuSelectColumnsVisible";
            this.cbContextMenuSelectColumnsVisible.Size = new System.Drawing.Size(237, 20);
            this.cbContextMenuSelectColumnsVisible.TabIndex = 4;
            this.cbContextMenuSelectColumnsVisible.Tag = "ContextMenuSelectColumnsVisible";
            this.cbContextMenuSelectColumnsVisible.Text = "ContextMenuSelectColumnsVisible";
            this.cbContextMenuSelectColumnsVisible.UseVisualStyleBackColor = true;
            this.cbContextMenuSelectColumnsVisible.CheckedChanged += new System.EventHandler(this.cbContextMenuDataGridViewOptionsVisible_CheckedChanged);
            // 
            // bSetCurrentCulture
            // 
            this.bSetCurrentCulture.Location = new System.Drawing.Point(16, 51);
            this.bSetCurrentCulture.Margin = new System.Windows.Forms.Padding(4);
            this.bSetCurrentCulture.Name = "bSetCurrentCulture";
            this.bSetCurrentCulture.Size = new System.Drawing.Size(208, 28);
            this.bSetCurrentCulture.TabIndex = 3;
            this.bSetCurrentCulture.Text = "Set Current Culture";
            this.bSetCurrentCulture.UseVisualStyleBackColor = true;
            this.bSetCurrentCulture.Click += new System.EventHandler(this.bSetCurrentCulture_Click);
            // 
            // tbCurrentCulture
            // 
            this.tbCurrentCulture.Location = new System.Drawing.Point(16, 86);
            this.tbCurrentCulture.Name = "tbCurrentCulture";
            this.tbCurrentCulture.Size = new System.Drawing.Size(208, 22);
            this.tbCurrentCulture.TabIndex = 1;
            this.tbCurrentCulture.Text = "en-GB";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(124, 15);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 2;
            this.button2.Text = "Set Settings";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Get Settings";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbTopLeftButtonVisible
            // 
            this.cbTopLeftButtonVisible.AutoSize = true;
            this.cbTopLeftButtonVisible.Checked = true;
            this.cbTopLeftButtonVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTopLeftButtonVisible.Location = new System.Drawing.Point(271, 114);
            this.cbTopLeftButtonVisible.Name = "cbTopLeftButtonVisible";
            this.cbTopLeftButtonVisible.Size = new System.Drawing.Size(153, 20);
            this.cbTopLeftButtonVisible.TabIndex = 7;
            this.cbTopLeftButtonVisible.Tag = "TopLeftButtonVisible";
            this.cbTopLeftButtonVisible.Text = "TopLeftButtonVisible";
            this.cbTopLeftButtonVisible.UseVisualStyleBackColor = true;
            this.cbTopLeftButtonVisible.CheckedChanged += new System.EventHandler(this.cbTopLeftButtonVisible_CheckedChanged);
            // 
            // customDataGridView1
            // 
            this.customDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.customDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customDataGridView1.Location = new System.Drawing.Point(0, 185);
            this.customDataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.customDataGridView1.Name = "customDataGridView1";
            this.customDataGridView1.RowHeadersWidth = 51;
            this.customDataGridView1.RowTemplate.Height = 24;
            this.customDataGridView1.Size = new System.Drawing.Size(800, 265);
            this.customDataGridView1.TabIndex = 0;
            this.customDataGridView1.TopLeftButtonVisible = false;
            this.customDataGridView1.TopLeftButtonWidth = 33;
            this.customDataGridView1.UserSelectedColumns += new CustomDataGridView.Lib.Components.CustomDataGridView.UserSelectedColumnsEventHandler(this.customDataGridView1_UserSelectedColumns);
            this.customDataGridView1.UserResetColumns += new CustomDataGridView.Lib.Components.CustomDataGridView.UserResetColumnsEventHandler(this.customDataGridView1_UserResetColumns);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.customDataGridView1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormTest";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CustomDataGridView.Lib.Components.CustomDataGridView customDataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bSetCurrentCulture;
        private System.Windows.Forms.TextBox tbCurrentCulture;
        private System.Windows.Forms.CheckBox cbContextMenuSelectColumnsVisible;
        private System.Windows.Forms.CheckBox cbContextMenuExportToExcelVisible;
        private System.Windows.Forms.CheckBox cbContextMenuDataGridViewOptionsVisible;
        private System.Windows.Forms.CheckBox cbTopLeftButtonVisible;
    }
}

