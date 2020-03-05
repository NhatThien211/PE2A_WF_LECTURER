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
            this.lbPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.loadingBox)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEnroll
            // 
            this.btnEnroll.Location = new System.Drawing.Point(134, 138);
            this.btnEnroll.Margin = new System.Windows.Forms.Padding(2);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(85, 27);
            this.btnEnroll.TabIndex = 8;
            this.btnEnroll.Text = "Enroll";
            this.btnEnroll.UseVisualStyleBackColor = true;
            this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);
            // 
            // labelRollNumber
            // 
            this.labelRollNumber.AutoSize = true;
            this.labelRollNumber.Location = new System.Drawing.Point(20, 63);
            this.labelRollNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRollNumber.Name = "labelRollNumber";
            this.labelRollNumber.Size = new System.Drawing.Size(64, 13);
            this.labelRollNumber.TabIndex = 7;
            this.labelRollNumber.Text = "Enroll Name";
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(98, 60);
            this.txtStudentID.Margin = new System.Windows.Forms.Padding(2);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(214, 20);
            this.txtStudentID.TabIndex = 6;
            // 
            // loadingBox
            // 
            this.loadingBox.Image = global::PE2A_WF_Lecturer.Properties.Resources.loading;
            this.loadingBox.Location = new System.Drawing.Point(98, 18);
            this.loadingBox.Margin = new System.Windows.Forms.Padding(2);
            this.loadingBox.Name = "loadingBox";
            this.loadingBox.Size = new System.Drawing.Size(161, 140);
            this.loadingBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loadingBox.TabIndex = 9;
            this.loadingBox.TabStop = false;
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(20, 103);
            this.lbPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(53, 13);
            this.lbPassword.TabIndex = 10;
            this.lbPassword.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(98, 100);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(214, 20);
            this.txtPassword.TabIndex = 11;
            // 
            // LecturerEnroll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(363, 194);
            this.Controls.Add(this.loadingBox);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.btnEnroll);
            this.Controls.Add(this.labelRollNumber);
            this.Controls.Add(this.txtStudentID);
            this.Controls.Add(this.txtPassword);
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
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.TextBox txtPassword;
    }
}

