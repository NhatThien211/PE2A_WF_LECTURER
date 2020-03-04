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
            this.publishPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.dgvStudent.Size = new System.Drawing.Size(1658, 655);
            this.dgvStudent.TabIndex = 0;
            this.dgvStudent.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudent_CellContentClick);
            // 
            // gbSubmitedFiles
            // 
            this.gbSubmitedFiles.Controls.Add(this.dgvStudent);
            this.gbSubmitedFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSubmitedFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSubmitedFiles.Location = new System.Drawing.Point(0, 33);
            this.gbSubmitedFiles.Margin = new System.Windows.Forms.Padding(0);
            this.gbSubmitedFiles.Name = "gbSubmitedFiles";
            this.gbSubmitedFiles.Padding = new System.Windows.Forms.Padding(8, 31, 4, 5);
            this.gbSubmitedFiles.Size = new System.Drawing.Size(1670, 716);
            this.gbSubmitedFiles.TabIndex = 2;
            this.gbSubmitedFiles.TabStop = false;
            // 
            // menuAction
            // 
            this.menuAction.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuAction.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuAction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.publishPointToolStripMenuItem,
            this.printReportToolStripMenuItem,
            this.startToolStripMenuItem});
            this.menuAction.Location = new System.Drawing.Point(0, 0);
            this.menuAction.Name = "menuAction";
            this.menuAction.Size = new System.Drawing.Size(1670, 33);
            this.menuAction.TabIndex = 3;
            this.menuAction.Text = "menuStrip1";
            // 
            // publishPointToolStripMenuItem
            // 
            this.publishPointToolStripMenuItem.Image = global::PE2A_WF_Lecturer.Properties.Resources.icShare;
            this.publishPointToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.publishPointToolStripMenuItem.Name = "publishPointToolStripMenuItem";
            this.publishPointToolStripMenuItem.Size = new System.Drawing.Size(144, 29);
            this.publishPointToolStripMenuItem.Text = "Publish Point";
            this.publishPointToolStripMenuItem.Click += new System.EventHandler(this.publishPointMenu_Click);
            // 
            // printReportToolStripMenuItem
            // 
            this.printReportToolStripMenuItem.Image = global::PE2A_WF_Lecturer.Properties.Resources.icPrint;
            this.printReportToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.printReportToolStripMenuItem.Name = "printReportToolStripMenuItem";
            this.printReportToolStripMenuItem.Size = new System.Drawing.Size(134, 29);
            this.printReportToolStripMenuItem.Text = "Print Report";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(64, 29);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(379, 6);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(211, 26);
            this.txtTime.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(607, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Minutes";
            // 
            // LecturerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1670, 749);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.gbSubmitedFiles);
            this.Controls.Add(this.menuAction);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LecturerForm";
            this.Text = "LECTURER FORM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LecturerForm_FormClosing);
            this.Load += new System.EventHandler(this.LecturerForm_LoadAsync);
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
        private System.Windows.Forms.ToolStripMenuItem publishPointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label label1;
    }
}