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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbSubmitedFiles = new System.Windows.Forms.GroupBox();
            this.dgvStudent = new System.Windows.Forms.DataGridView();
            this.btnPublishMark = new System.Windows.Forms.Button();
            this.btnCSV = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbSubmitedFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbSubmitedFiles);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(7, 25, 7, 6);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCSV);
            this.splitContainer1.Panel2.Controls.Add(this.btnPublishMark);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(40, 37, 40, 492);
            this.splitContainer1.Size = new System.Drawing.Size(1484, 599);
            this.splitContainer1.SplitterDistance = 1112;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // gbSubmitedFiles
            // 
            this.gbSubmitedFiles.Controls.Add(this.dgvStudent);
            this.gbSubmitedFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSubmitedFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSubmitedFiles.Location = new System.Drawing.Point(7, 25);
            this.gbSubmitedFiles.Margin = new System.Windows.Forms.Padding(0);
            this.gbSubmitedFiles.Name = "gbSubmitedFiles";
            this.gbSubmitedFiles.Padding = new System.Windows.Forms.Padding(7, 25, 4, 4);
            this.gbSubmitedFiles.Size = new System.Drawing.Size(1098, 568);
            this.gbSubmitedFiles.TabIndex = 0;
            this.gbSubmitedFiles.TabStop = false;
            this.gbSubmitedFiles.Text = "Submited Files";
            // 
            // dgvStudent
            // 
            this.dgvStudent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudent.BackgroundColor = System.Drawing.Color.White;
            this.dgvStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStudent.Location = new System.Drawing.Point(7, 46);
            this.dgvStudent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvStudent.Name = "dgvStudent";
            this.dgvStudent.RowHeadersWidth = 62;
            this.dgvStudent.RowTemplate.Height = 28;
            this.dgvStudent.Size = new System.Drawing.Size(1087, 518);
            this.dgvStudent.TabIndex = 0;
            this.dgvStudent.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudent_CellContentClick);
            // 
            // btnPublishMark
            // 
            this.btnPublishMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPublishMark.Location = new System.Drawing.Point(78, 230);
            this.btnPublishMark.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPublishMark.MinimumSize = new System.Drawing.Size(67, 62);
            this.btnPublishMark.Name = "btnPublishMark";
            this.btnPublishMark.Size = new System.Drawing.Size(169, 62);
            this.btnPublishMark.TabIndex = 0;
            this.btnPublishMark.Text = "Publish Mark";
            this.btnPublishMark.UseVisualStyleBackColor = true;
            this.btnPublishMark.Click += new System.EventHandler(this.btnEstimate_Click);
            // 
            // btnCSV
            // 
            this.btnCSV.Location = new System.Drawing.Point(78, 359);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(169, 61);
            this.btnCSV.TabIndex = 1;
            this.btnCSV.Text = "Export CSV";
            this.btnCSV.UseVisualStyleBackColor = true;
            this.btnCSV.Click += new System.EventHandler(this.btnCSV_Click);
            // 
            // LecturerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 599);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LecturerForm";
            this.Text = "LECTURER FORM";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LecturerForm_FormClosing);
            this.Load += new System.EventHandler(this.LecturerForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbSubmitedFiles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gbSubmitedFiles;
        private System.Windows.Forms.Button btnPublishMark;
        private System.Windows.Forms.DataGridView dgvStudent;
        private System.Windows.Forms.Button btnCSV;
    }
}