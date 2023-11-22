namespace CustomDataGridView.Lib.Forms
{
    partial class ColumnSelectionForm
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
            this.columnsAvailable = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bRemove = new System.Windows.Forms.Button();
            this.bAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.columnsUsing = new System.Windows.Forms.CheckedListBox();
            this.pTop = new System.Windows.Forms.Panel();
            this.pBottom = new System.Windows.Forms.Panel();
            this.bExit = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.pBody = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bDown = new System.Windows.Forms.Button();
            this.bUp = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pTop.SuspendLayout();
            this.pBottom.SuspendLayout();
            this.pBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // columnsAvailable
            // 
            this.columnsAvailable.AllowDrop = true;
            this.columnsAvailable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.columnsAvailable.FormattingEnabled = true;
            this.columnsAvailable.Location = new System.Drawing.Point(2, 15);
            this.columnsAvailable.Margin = new System.Windows.Forms.Padding(2);
            this.columnsAvailable.Name = "columnsAvailable";
            this.columnsAvailable.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.columnsAvailable.Size = new System.Drawing.Size(270, 312);
            this.columnsAvailable.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(618, 329);
            this.splitContainer1.SplitterDistance = 321;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.columnsAvailable);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(274, 329);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Campos Disponíveis";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bRemove);
            this.panel1.Controls.Add(this.bAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(274, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(47, 329);
            this.panel1.TabIndex = 1;
            // 
            // bRemove
            // 
            this.bRemove.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bRemove.Location = new System.Drawing.Point(11, 44);
            this.bRemove.Margin = new System.Windows.Forms.Padding(2);
            this.bRemove.Name = "bRemove";
            this.bRemove.Size = new System.Drawing.Size(28, 23);
            this.bRemove.TabIndex = 3;
            this.bRemove.Text = "<";
            this.bRemove.UseVisualStyleBackColor = true;
            this.bRemove.Click += new System.EventHandler(this.bRemove_Click);
            // 
            // bAdd
            // 
            this.bAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bAdd.Location = new System.Drawing.Point(11, 15);
            this.bAdd.Margin = new System.Windows.Forms.Padding(2);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(28, 24);
            this.bAdd.TabIndex = 2;
            this.bAdd.Text = ">";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.columnsUsing);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(247, 329);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Campos a Utilizar";
            // 
            // columnsUsing
            // 
            this.columnsUsing.AllowDrop = true;
            this.columnsUsing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.columnsUsing.FormattingEnabled = true;
            this.columnsUsing.Location = new System.Drawing.Point(2, 15);
            this.columnsUsing.Margin = new System.Windows.Forms.Padding(2);
            this.columnsUsing.Name = "columnsUsing";
            this.columnsUsing.Size = new System.Drawing.Size(243, 312);
            this.columnsUsing.TabIndex = 0;
            this.columnsUsing.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.columnsUsing_ItemCheck);
            this.columnsUsing.DragDrop += new System.Windows.Forms.DragEventHandler(this.columnsUsing_DragDrop);
            this.columnsUsing.DragOver += new System.Windows.Forms.DragEventHandler(this.columnsUsing_DragOver);
            this.columnsUsing.MouseDown += new System.Windows.Forms.MouseEventHandler(this.columnsUsing_MouseDown);
            // 
            // pTop
            // 
            this.pTop.Controls.Add(this.splitContainer1);
            this.pTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pTop.Location = new System.Drawing.Point(0, 0);
            this.pTop.Margin = new System.Windows.Forms.Padding(2);
            this.pTop.Name = "pTop";
            this.pTop.Size = new System.Drawing.Size(618, 329);
            this.pTop.TabIndex = 4;
            // 
            // pBottom
            // 
            this.pBottom.Controls.Add(this.bExit);
            this.pBottom.Controls.Add(this.bSave);
            this.pBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pBottom.Location = new System.Drawing.Point(0, 378);
            this.pBottom.Margin = new System.Windows.Forms.Padding(2);
            this.pBottom.Name = "pBottom";
            this.pBottom.Size = new System.Drawing.Size(618, 49);
            this.pBottom.TabIndex = 5;
            // 
            // bExit
            // 
            this.bExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bExit.BackColor = System.Drawing.SystemColors.Control;
            this.bExit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bExit.ForeColor = System.Drawing.Color.Black;
            this.bExit.Location = new System.Drawing.Point(417, 13);
            this.bExit.Margin = new System.Windows.Forms.Padding(2);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(94, 24);
            this.bExit.TabIndex = 5;
            this.bExit.Text = "Sair";
            this.bExit.UseVisualStyleBackColor = false;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // bSave
            // 
            this.bSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(85)))), ((int)(((byte)(172)))));
            this.bSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bSave.ForeColor = System.Drawing.Color.White;
            this.bSave.Location = new System.Drawing.Point(515, 13);
            this.bSave.Margin = new System.Windows.Forms.Padding(2);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(94, 24);
            this.bSave.TabIndex = 3;
            this.bSave.Text = "Gravar";
            this.bSave.UseVisualStyleBackColor = false;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // pBody
            // 
            this.pBody.Controls.Add(this.dataGridView1);
            this.pBody.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pBody.Location = new System.Drawing.Point(0, 329);
            this.pBody.Margin = new System.Windows.Forms.Padding(2);
            this.pBody.Name = "pBody";
            this.pBody.Size = new System.Drawing.Size(618, 49);
            this.pBody.TabIndex = 6;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(618, 49);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.bDown);
            this.panel2.Controls.Add(this.bUp);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(247, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(47, 329);
            this.panel2.TabIndex = 2;
            // 
            // bDown
            // 
            this.bDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bDown.Location = new System.Drawing.Point(11, 44);
            this.bDown.Margin = new System.Windows.Forms.Padding(2);
            this.bDown.Name = "bDown";
            this.bDown.Size = new System.Drawing.Size(28, 23);
            this.bDown.TabIndex = 3;
            this.bDown.Text = "↓";
            this.bDown.UseVisualStyleBackColor = true;
            this.bDown.Click += new System.EventHandler(this.bDown_Click);
            // 
            // bUp
            // 
            this.bUp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bUp.Location = new System.Drawing.Point(11, 15);
            this.bUp.Margin = new System.Windows.Forms.Padding(2);
            this.bUp.Name = "bUp";
            this.bUp.Size = new System.Drawing.Size(28, 24);
            this.bUp.TabIndex = 2;
            this.bUp.Text = "↑";
            this.bUp.UseVisualStyleBackColor = true;
            this.bUp.Click += new System.EventHandler(this.bUp_Click);
            // 
            // ColumnSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 427);
            this.Controls.Add(this.pTop);
            this.Controls.Add(this.pBody);
            this.Controls.Add(this.pBottom);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ColumnSelectionForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.pTop.ResumeLayout(false);
            this.pBottom.ResumeLayout(false);
            this.pBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox columnsAvailable;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox columnsUsing;
        private System.Windows.Forms.Panel pTop;
        private System.Windows.Forms.Panel pBottom;
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Panel pBody;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button bRemove;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button bDown;
        private System.Windows.Forms.Button bUp;
    }
}