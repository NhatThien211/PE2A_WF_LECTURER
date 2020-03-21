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
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StudentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ScriptCodes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubmitTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EvaluateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Error = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Close = new System.Windows.Forms.DataGridViewImageColumn();
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
            this.dgvStudent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.StudentCode,
            this.StudentName,
            this.ScriptCodes,
            this.Status,
            this.TotalPoint,
            this.SubmitTime,
            this.EvaluateTime,
            this.Result,
            this.Error,
            this.Close});
            this.dgvStudent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStudent.Location = new System.Drawing.Point(5, 37);
            this.dgvStudent.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.dgvStudent.Name = "dgvStudent";
            this.dgvStudent.RowHeadersWidth = 62;
            this.dgvStudent.RowTemplate.Height = 28;
            this.dgvStudent.Size = new System.Drawing.Size(905, 423);
            this.dgvStudent.TabIndex = 0;
            this.dgvStudent.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudent_CellContentClick);
            this.dgvStudent.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudent_CellDoubleClick);
            // 
            // No
            // 
            this.No.HeaderText = "NO";
            this.No.MinimumWidth = 8;
            this.No.Name = "No";
            // 
            // StudentCode
            // 
            this.StudentCode.HeaderText = "Student Code";
            this.StudentCode.MinimumWidth = 8;
            this.StudentCode.Name = "StudentCode";
            // 
            // StudentName
            // 
            this.StudentName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.StudentName.HeaderText = "Student Name";
            this.StudentName.MinimumWidth = 8;
            this.StudentName.Name = "StudentName";
            this.StudentName.Width = 127;
            // 
            // ScriptCodes
            // 
            this.ScriptCodes.HeaderText = "Script Code";
            this.ScriptCodes.MinimumWidth = 8;
            this.ScriptCodes.Name = "ScriptCodes";
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.MinimumWidth = 8;
            this.Status.Name = "Status";
            // 
            // TotalPoint
            // 
            this.TotalPoint.HeaderText = "Total Point";
            this.TotalPoint.MinimumWidth = 8;
            this.TotalPoint.Name = "TotalPoint";
            // 
            // SubmitTime
            // 
            this.SubmitTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SubmitTime.HeaderText = "Submit Time";
            this.SubmitTime.MinimumWidth = 8;
            this.SubmitTime.Name = "SubmitTime";
            this.SubmitTime.Width = 116;
            // 
            // EvaluateTime
            // 
            this.EvaluateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.EvaluateTime.HeaderText = "Evaluate Time";
            this.EvaluateTime.MinimumWidth = 8;
            this.EvaluateTime.Name = "EvaluateTime";
            this.EvaluateTime.Width = 127;
            // 
            // Result
            // 
            this.Result.HeaderText = "Result";
            this.Result.MinimumWidth = 8;
            this.Result.Name = "Result";
            // 
            // Error
            // 
            this.Error.HeaderText = "Error";
            this.Error.MinimumWidth = 8;
            this.Error.Name = "Error";
            // 
            // Close
            // 
            this.Close.HeaderText = "Action";
            this.Close.MinimumWidth = 8;
            this.Close.Name = "Close";
            this.Close.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Close.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gbSubmitedFiles
            // 
            this.gbSubmitedFiles.Controls.Add(this.dgvStudent);
            this.gbSubmitedFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSubmitedFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSubmitedFiles.Location = new System.Drawing.Point(0, 24);
            this.gbSubmitedFiles.Margin = new System.Windows.Forms.Padding(0);
            this.gbSubmitedFiles.Name = "gbSubmitedFiles";
            this.gbSubmitedFiles.Padding = new System.Windows.Forms.Padding(5, 20, 3, 3);
            this.gbSubmitedFiles.Size = new System.Drawing.Size(913, 463);
            this.gbSubmitedFiles.TabIndex = 2;
            this.gbSubmitedFiles.TabStop = false;
            // 
            // menuAction
            // 
            this.menuAction.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuAction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.publishPointToolStripMenuItem,
            this.printReportToolStripMenuItem,
            this.startToolStripMenuItem});
            this.menuAction.Location = new System.Drawing.Point(0, 0);
            this.menuAction.Name = "menuAction";
            this.menuAction.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuAction.Size = new System.Drawing.Size(913, 24);
            this.menuAction.TabIndex = 3;
            this.menuAction.Text = "menuStrip1";
            // 
            // publishPointToolStripMenuItem
            // 
            this.publishPointToolStripMenuItem.Image = global::PE2A_WF_Lecturer.Properties.Resources.icShare;
            this.publishPointToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.publishPointToolStripMenuItem.Name = "publishPointToolStripMenuItem";
            this.publishPointToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.publishPointToolStripMenuItem.Text = "Publish Point";
            this.publishPointToolStripMenuItem.Click += new System.EventHandler(this.publishPointMenu_Click);
            // 
            // printReportToolStripMenuItem
            // 
            this.printReportToolStripMenuItem.Image = global::PE2A_WF_Lecturer.Properties.Resources.icPrint;
            this.printReportToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.printReportToolStripMenuItem.Name = "printReportToolStripMenuItem";
            this.printReportToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.printReportToolStripMenuItem.Text = "Print Report";
            this.printReportToolStripMenuItem.Click += new System.EventHandler(this.printReportToolStripMenuItem_Click);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(43, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(253, 4);
            this.txtTime.Margin = new System.Windows.Forms.Padding(2);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(142, 20);
            this.txtTime.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(405, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Minutes";
            // 
            // LecturerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(913, 487);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.gbSubmitedFiles);
            this.Controls.Add(this.menuAction);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScriptCodes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubmitTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn EvaluateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Result;
        private System.Windows.Forms.DataGridViewTextBoxColumn Error;
        private System.Windows.Forms.DataGridViewImageColumn Close;
    }
}