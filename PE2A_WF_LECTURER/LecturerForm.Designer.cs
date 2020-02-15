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
            this.dgvStudent = new System.Windows.Forms.DataGridView();
            this.gbSubmitedFiles = new System.Windows.Forms.GroupBox();
            this.menuAction = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importScriptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.publishPointMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.printReportMenu = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).BeginInit();
            this.gbSubmitedFiles.SuspendLayout();
            this.menuAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvStudent
            // 
            this.dgvStudent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudent.BackgroundColor = System.Drawing.Color.White;
            this.dgvStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStudent.Location = new System.Drawing.Point(8, 56);
            this.dgvStudent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvStudent.Name = "dgvStudent";
            this.dgvStudent.RowHeadersWidth = 62;
            this.dgvStudent.RowTemplate.Height = 28;
            this.dgvStudent.Size = new System.Drawing.Size(1658, 652);
            this.dgvStudent.TabIndex = 0;
            this.dgvStudent.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudent_CellContentClick);
            // 
            // gbSubmitedFiles
            // 
            this.gbSubmitedFiles.Controls.Add(this.dgvStudent);
            this.gbSubmitedFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSubmitedFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSubmitedFiles.Location = new System.Drawing.Point(0, 36);
            this.gbSubmitedFiles.Margin = new System.Windows.Forms.Padding(0);
            this.gbSubmitedFiles.Name = "gbSubmitedFiles";
            this.gbSubmitedFiles.Padding = new System.Windows.Forms.Padding(8, 31, 4, 5);
            this.gbSubmitedFiles.Size = new System.Drawing.Size(1670, 713);
            this.gbSubmitedFiles.TabIndex = 2;
            this.gbSubmitedFiles.TabStop = false;
            // 
            // menuAction
            // 
            this.menuAction.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuAction.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuAction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.actionToolStripMenuItem});
            this.menuAction.Location = new System.Drawing.Point(0, 0);
            this.menuAction.Name = "menuAction";
            this.menuAction.Size = new System.Drawing.Size(1670, 36);
            this.menuAction.TabIndex = 3;
            this.menuAction.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importScriptToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(73, 32);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // importScriptToolStripMenuItem
            // 
            this.importScriptToolStripMenuItem.Name = "importScriptToolStripMenuItem";
            this.importScriptToolStripMenuItem.Size = new System.Drawing.Size(219, 34);
            this.importScriptToolStripMenuItem.Text = "Import Script";
            this.importScriptToolStripMenuItem.Click += new System.EventHandler(this.ImportScriptToolStripMenuItem_Click);
            // 
            // actionToolStripMenuItem
            // 
            this.actionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.publishPointMenu,
            this.printReportMenu});
            this.actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            this.actionToolStripMenuItem.Size = new System.Drawing.Size(79, 32);
            this.actionToolStripMenuItem.Text = "Action";
            // 
            // publishPointMenu
            // 
            this.publishPointMenu.BackColor = System.Drawing.Color.White;
            this.publishPointMenu.Image = global::PE2A_WF_Lecturer.Properties.Resources.icShare;
            this.publishPointMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.publishPointMenu.Name = "publishPointMenu";
            this.publishPointMenu.Size = new System.Drawing.Size(216, 34);
            this.publishPointMenu.Text = "Publish Point";
            // 
            // printReportMenu
            // 
            this.printReportMenu.BackColor = System.Drawing.Color.White;
            this.printReportMenu.Image = global::PE2A_WF_Lecturer.Properties.Resources.icPrint;
            this.printReportMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.printReportMenu.Name = "printReportMenu";
            this.printReportMenu.Size = new System.Drawing.Size(216, 34);
            this.printReportMenu.Text = "Print Report";
            // 
            // LecturerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1670, 749);
            this.Controls.Add(this.gbSubmitedFiles);
            this.Controls.Add(this.menuAction);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LecturerForm";
            this.Text = "LECTURER FORM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LecturerForm_FormClosing);
            this.Load += new System.EventHandler(this.LecturerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).EndInit();
            this.gbSubmitedFiles.ResumeLayout(false);
            this.menuAction.ResumeLayout(false);
            this.menuAction.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStudent;
        private System.Windows.Forms.GroupBox gbSubmitedFiles;
        private System.Windows.Forms.MenuStrip menuAction;
        private System.Windows.Forms.ToolStripMenuItem actionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem publishPointMenu;
        private System.Windows.Forms.ToolStripMenuItem printReportMenu;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importScriptToolStripMenuItem;
    }
}