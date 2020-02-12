namespace PE2A_WF_Lecturer
{
    partial class LecturerForm
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
            this.menuAction = new System.Windows.Forms.MenuStrip();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbSubmitedFiles = new System.Windows.Forms.GroupBox();
            this.dgvStudent = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.publishPointMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.printReportMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAction.SuspendLayout();
            this.gbSubmitedFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuAction
            // 
            this.menuAction.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuAction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionToolStripMenuItem});
            this.menuAction.Location = new System.Drawing.Point(8, 31);
            this.menuAction.Name = "menuAction";
            this.menuAction.Size = new System.Drawing.Size(1236, 33);
            this.menuAction.TabIndex = 1;
            this.menuAction.Text = "menuStrip1";
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.publishPointMenu,
            this.printReportMenu});
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(79, 30);
            this.actionToolStripMenuItem.Text = "Action";
            // 
            // gbSubmitedFiles
            // 
            this.gbSubmitedFiles.Controls.Add(this.dgvStudent);
            this.gbSubmitedFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSubmitedFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSubmitedFiles.Location = new System.Drawing.Point(8, 64);
            this.gbSubmitedFiles.Margin = new System.Windows.Forms.Padding(0);
            this.gbSubmitedFiles.Name = "gbSubmitedFiles";
            this.gbSubmitedFiles.Padding = new System.Windows.Forms.Padding(8, 31, 4, 5);
            this.gbSubmitedFiles.Size = new System.Drawing.Size(1236, 677);
            this.gbSubmitedFiles.TabIndex = 0;
            this.gbSubmitedFiles.TabStop = false;
            // 
            // dgvStudent
            // 
            this.dgvStudent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudent.BackgroundColor = System.Drawing.Color.White;
            this.dgvStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStudent.Location = new System.Drawing.Point(8, 56);
            this.dgvStudent.Name = "dgvStudent";
            this.dgvStudent.RowHeadersWidth = 62;
            this.dgvStudent.RowTemplate.Height = 28;
            this.dgvStudent.Size = new System.Drawing.Size(1224, 616);
            this.dgvStudent.TabIndex = 0;
            this.dgvStudent.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudent_CellContentClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbSubmitedFiles);
            this.splitContainer1.Panel1.Controls.Add(this.menuAction);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(8, 31, 8, 8);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(45, 46, 45, 615);
            this.splitContainer1.Size = new System.Drawing.Size(1670, 749);
            this.splitContainer1.SplitterDistance = 1252;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // publishPointMenu
            // 
            this.publishPointMenu.BackColor = System.Drawing.Color.White;
            this.publishPointMenu.Image = global::PE2A_WF_Lecturer.Properties.Resources.icShare;
            this.publishPointMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.publishPointMenu.Name = "publishPointMenu";
            this.publishPointMenu.Size = new System.Drawing.Size(270, 34);
            this.publishPointMenu.Text = "Publish Point";
            this.publishPointMenu.Click += new System.EventHandler(this.publishPointMenu_Click);
            // 
            // printReportMenu
            // 
            this.printReportMenu.BackColor = System.Drawing.Color.White;
            this.printReportMenu.Image = global::PE2A_WF_Lecturer.Properties.Resources.icPrint;
            this.printReportMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.printReportMenu.Name = "printReportMenu";
            this.printReportMenu.Size = new System.Drawing.Size(270, 34);
            this.printReportMenu.Text = "Print Report";
            // 
            // LecturerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1670, 749);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LecturerForm";
            this.Text = "LECTURER FORM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LecturerForm_FormClosing);
            this.Load += new System.EventHandler(this.LecturerForm_Load);
            this.menuAction.ResumeLayout(false);
            this.menuAction.PerformLayout();
            this.gbSubmitedFiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuAction;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem publishPointMenu;
        private System.Windows.Forms.ToolStripMenuItem printReportMenu;
        private System.Windows.Forms.GroupBox gbSubmitedFiles;
        private System.Windows.Forms.DataGridView dgvStudent;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}