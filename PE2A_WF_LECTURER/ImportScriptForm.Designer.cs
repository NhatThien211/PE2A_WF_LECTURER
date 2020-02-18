namespace PE2A_WF_Lecturer
{
    partial class ImportScriptForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvScriptFiles = new System.Windows.Forms.DataGridView();
            this.dgvHeaderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvHeaderScriptName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScriptFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(518, 36);
            this.panel1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(518, 36);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ImportTemplateToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // ImportTemplateToolStripMenuItem
            // 
            this.ImportTemplateToolStripMenuItem.Name = "ImportTemplateToolStripMenuItem";
            this.ImportTemplateToolStripMenuItem.Size = new System.Drawing.Size(195, 26);
            this.ImportTemplateToolStripMenuItem.Text = "Import Template";
            this.ImportTemplateToolStripMenuItem.Click += new System.EventHandler(this.ImportTemplateToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.Controls.Add(this.dgvScriptFiles);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 36);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(15, 10, 15, 15);
            this.panel2.Size = new System.Drawing.Size(518, 581);
            this.panel2.TabIndex = 1;
            // 
            // dgvScriptFiles
            // 
            this.dgvScriptFiles.AllowUserToAddRows = false;
            this.dgvScriptFiles.AllowUserToDeleteRows = false;
            this.dgvScriptFiles.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvScriptFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScriptFiles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvHeaderNo,
            this.dgvHeaderScriptName});
            this.dgvScriptFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvScriptFiles.GridColor = System.Drawing.SystemColors.Control;
            this.dgvScriptFiles.Location = new System.Drawing.Point(15, 10);
            this.dgvScriptFiles.Name = "dgvScriptFiles";
            this.dgvScriptFiles.ReadOnly = true;
            this.dgvScriptFiles.RowTemplate.Height = 24;
            this.dgvScriptFiles.Size = new System.Drawing.Size(488, 556);
            this.dgvScriptFiles.TabIndex = 0;
            // 
            // dgvHeaderNo
            // 
            this.dgvHeaderNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgvHeaderNo.HeaderText = "No";
            this.dgvHeaderNo.MinimumWidth = 60;
            this.dgvHeaderNo.Name = "dgvHeaderNo";
            this.dgvHeaderNo.ReadOnly = true;
            this.dgvHeaderNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dgvHeaderNo.Width = 60;
            // 
            // dgvHeaderScriptName
            // 
            this.dgvHeaderScriptName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvHeaderScriptName.HeaderText = "Script Name";
            this.dgvHeaderScriptName.Name = "dgvHeaderScriptName";
            this.dgvHeaderScriptName.ReadOnly = true;
            this.dgvHeaderScriptName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ImportScriptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 617);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ImportScriptForm";
            this.Text = "Import Script";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImportScriptForm_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvScriptFiles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImportTemplateToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvScriptFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvHeaderNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvHeaderScriptName;
    }
}