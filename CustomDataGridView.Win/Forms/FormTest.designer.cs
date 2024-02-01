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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTest));
            this.PTop = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbTopLeftButtonVisible = new System.Windows.Forms.CheckBox();
            this.cbContextMenuDataGridViewOptionsVisible = new System.Windows.Forms.CheckBox();
            this.cbContextMenuExportToExcelVisible = new System.Windows.Forms.CheckBox();
            this.cbContextMenuSelectColumnsVisible = new System.Windows.Forms.CheckBox();
            this.bSetCurrentCulture = new System.Windows.Forms.Button();
            this.tbCurrentCulture = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.customDataGridView1 = new CustomDataGridView.Lib.Components.CustomDataGridView();
            this.PBody = new System.Windows.Forms.Panel();
            this.PTop.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customDataGridView1)).BeginInit();
            this.PBody.SuspendLayout();
            this.SuspendLayout();
            // 
            // PTop
            // 
            this.PTop.Controls.Add(this.groupBox1);
            this.PTop.Controls.Add(this.panel2);
            this.PTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PTop.Location = new System.Drawing.Point(0, 0);
            this.PTop.Name = "PTop";
            this.PTop.Size = new System.Drawing.Size(600, 129);
            this.PTop.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(433, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 129);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 16);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(161, 110);
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
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(433, 129);
            this.panel2.TabIndex = 3;
            // 
            // cbTopLeftButtonVisible
            // 
            this.cbTopLeftButtonVisible.AutoSize = true;
            this.cbTopLeftButtonVisible.Checked = true;
            this.cbTopLeftButtonVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTopLeftButtonVisible.Location = new System.Drawing.Point(203, 93);
            this.cbTopLeftButtonVisible.Margin = new System.Windows.Forms.Padding(2);
            this.cbTopLeftButtonVisible.Name = "cbTopLeftButtonVisible";
            this.cbTopLeftButtonVisible.Size = new System.Drawing.Size(124, 17);
            this.cbTopLeftButtonVisible.TabIndex = 7;
            this.cbTopLeftButtonVisible.Tag = "TopLeftButtonVisible";
            this.cbTopLeftButtonVisible.Text = "TopLeftButtonVisible";
            this.cbTopLeftButtonVisible.UseVisualStyleBackColor = true;
            this.cbTopLeftButtonVisible.CheckedChanged += new System.EventHandler(this.cbTopLeftButtonVisible_CheckedChanged);
            // 
            // cbContextMenuDataGridViewOptionsVisible
            // 
            this.cbContextMenuDataGridViewOptionsVisible.AutoSize = true;
            this.cbContextMenuDataGridViewOptionsVisible.Checked = true;
            this.cbContextMenuDataGridViewOptionsVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbContextMenuDataGridViewOptionsVisible.Location = new System.Drawing.Point(203, 72);
            this.cbContextMenuDataGridViewOptionsVisible.Margin = new System.Windows.Forms.Padding(2);
            this.cbContextMenuDataGridViewOptionsVisible.Name = "cbContextMenuDataGridViewOptionsVisible";
            this.cbContextMenuDataGridViewOptionsVisible.Size = new System.Drawing.Size(220, 17);
            this.cbContextMenuDataGridViewOptionsVisible.TabIndex = 6;
            this.cbContextMenuDataGridViewOptionsVisible.Tag = "ContextMenuDataGridViewOptionsVisible";
            this.cbContextMenuDataGridViewOptionsVisible.Text = "ContextMenuDataGridViewOptionsVisible";
            this.cbContextMenuDataGridViewOptionsVisible.UseVisualStyleBackColor = true;
            this.cbContextMenuDataGridViewOptionsVisible.CheckedChanged += new System.EventHandler(this.cbContextMenuDataGridViewOptionsVisible_CheckedChanged);
            // 
            // cbContextMenuExportToExcelVisible
            // 
            this.cbContextMenuExportToExcelVisible.AutoSize = true;
            this.cbContextMenuExportToExcelVisible.Location = new System.Drawing.Point(203, 46);
            this.cbContextMenuExportToExcelVisible.Margin = new System.Windows.Forms.Padding(2);
            this.cbContextMenuExportToExcelVisible.Name = "cbContextMenuExportToExcelVisible";
            this.cbContextMenuExportToExcelVisible.Size = new System.Drawing.Size(188, 17);
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
            this.cbContextMenuSelectColumnsVisible.Location = new System.Drawing.Point(203, 16);
            this.cbContextMenuSelectColumnsVisible.Margin = new System.Windows.Forms.Padding(2);
            this.cbContextMenuSelectColumnsVisible.Name = "cbContextMenuSelectColumnsVisible";
            this.cbContextMenuSelectColumnsVisible.Size = new System.Drawing.Size(189, 17);
            this.cbContextMenuSelectColumnsVisible.TabIndex = 4;
            this.cbContextMenuSelectColumnsVisible.Tag = "ContextMenuSelectColumnsVisible";
            this.cbContextMenuSelectColumnsVisible.Text = "ContextMenuSelectColumnsVisible";
            this.cbContextMenuSelectColumnsVisible.UseVisualStyleBackColor = true;
            this.cbContextMenuSelectColumnsVisible.CheckedChanged += new System.EventHandler(this.cbContextMenuDataGridViewOptionsVisible_CheckedChanged);
            // 
            // bSetCurrentCulture
            // 
            this.bSetCurrentCulture.Location = new System.Drawing.Point(12, 41);
            this.bSetCurrentCulture.Name = "bSetCurrentCulture";
            this.bSetCurrentCulture.Size = new System.Drawing.Size(156, 23);
            this.bSetCurrentCulture.TabIndex = 3;
            this.bSetCurrentCulture.Text = "Set Current Culture";
            this.bSetCurrentCulture.UseVisualStyleBackColor = true;
            this.bSetCurrentCulture.Click += new System.EventHandler(this.bSetCurrentCulture_Click);
            // 
            // tbCurrentCulture
            // 
            this.tbCurrentCulture.Location = new System.Drawing.Point(12, 70);
            this.tbCurrentCulture.Margin = new System.Windows.Forms.Padding(2);
            this.tbCurrentCulture.Name = "tbCurrentCulture";
            this.tbCurrentCulture.Size = new System.Drawing.Size(157, 20);
            this.tbCurrentCulture.TabIndex = 1;
            this.tbCurrentCulture.Text = "en-GB";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Set Settings";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Get Settings";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // customDataGridView1
            // 
            this.customDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.customDataGridView1.ChangeColumnTypesToCustom = true;
            this.customDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customDataGridView1.DefaultDataGridViewConfiguration = null;
            this.customDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customDataGridView1.EnableRowDetails = true;
            this.customDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.customDataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.customDataGridView1.Name = "customDataGridView1";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(41);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.customDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.customDataGridView1.RowHeadersWidth = 51;
            this.customDataGridView1.RowTemplate.Height = 24;
            this.customDataGridView1.Size = new System.Drawing.Size(600, 237);
            this.customDataGridView1.TabIndex = 0;
            this.customDataGridView1.TopLeftButtonBackColor = System.Drawing.Color.White;
            this.customDataGridView1.TopLeftButtonFlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.customDataGridView1.TopLeftButtonImage = ((System.Drawing.Image)(resources.GetObject("customDataGridView1.TopLeftButtonImage")));
            this.customDataGridView1.TopLeftButtonVisible = true;
            this.customDataGridView1.TopLeftButtonWidth = 25;
            this.customDataGridView1.UserSelectedColumns += new CustomDataGridView.Lib.Components.CustomDataGridView.UserSelectedColumnsEventHandler(this.customDataGridView1_UserSelectedColumns);
            this.customDataGridView1.UserResetColumns += new CustomDataGridView.Lib.Components.CustomDataGridView.UserResetColumnsEventHandler(this.customDataGridView1_UserResetColumns);
            // 
            // PBody
            // 
            this.PBody.Controls.Add(this.customDataGridView1);
            this.PBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PBody.Location = new System.Drawing.Point(0, 129);
            this.PBody.Name = "PBody";
            this.PBody.Size = new System.Drawing.Size(600, 237);
            this.PBody.TabIndex = 2;
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.PBody);
            this.Controls.Add(this.PTop);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormTest";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.PTop.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customDataGridView1)).EndInit();
            this.PBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CustomDataGridView.Lib.Components.CustomDataGridView customDataGridView1;
        private System.Windows.Forms.Panel PTop;
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
        private System.Windows.Forms.Panel PBody;
    }
}

