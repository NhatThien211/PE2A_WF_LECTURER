namespace PE2A_WF_Lecturer
{
    partial class LecturerEnroll
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
            this.btnEnroll = new System.Windows.Forms.Button();
            this.labelRollNumber = new System.Windows.Forms.Label();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.loadingBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.loadingBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEnroll
            // 
            this.btnEnroll.Location = new System.Drawing.Point(201, 213);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(128, 42);
            this.btnEnroll.TabIndex = 8;
            this.btnEnroll.Text = "Enroll";
            this.btnEnroll.UseVisualStyleBackColor = true;
            this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);
            // 
            // labelRollNumber
            // 
            this.labelRollNumber.AutoSize = true;
            this.labelRollNumber.Location = new System.Drawing.Point(111, 108);
            this.labelRollNumber.Name = "labelRollNumber";
            this.labelRollNumber.Size = new System.Drawing.Size(95, 20);
            this.labelRollNumber.TabIndex = 7;
            this.labelRollNumber.Text = "Enroll Name";
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(115, 151);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(319, 26);
            this.txtStudentID.TabIndex = 6;
            // 
            // loadingBox
            // 
            this.loadingBox.Image = global::PE2A_WF_Lecturer.Properties.Resources.loading;
            this.loadingBox.Location = new System.Drawing.Point(115, 50);
            this.loadingBox.Name = "loadingBox";
            this.loadingBox.Size = new System.Drawing.Size(242, 215);
            this.loadingBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loadingBox.TabIndex = 9;
            this.loadingBox.TabStop = false;
            // 
            // LecturerEnroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(544, 298);
            this.Controls.Add(this.loadingBox);
            this.Controls.Add(this.btnEnroll);
            this.Controls.Add(this.labelRollNumber);
            this.Controls.Add(this.txtStudentID);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "LecturerEnroll";
            this.Text = "LECUTER ENROLL FORM";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.loadingBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnroll;
        private System.Windows.Forms.Label labelRollNumber;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.PictureBox loadingBox;
    }
}

