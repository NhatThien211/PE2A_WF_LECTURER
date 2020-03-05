namespace PE2A_WF_Lecturer
{
    partial class PointDetailMsgBox
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
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("No:");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Student code:");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Student name:");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Exam code:");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("List questions:");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Result:");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Coding convention:");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Total point:");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Submitted time:");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Evaluated time:");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Message:");
            this.panel1 = new System.Windows.Forms.Panel();
            this.tvPointDetail = new System.Windows.Forms.TreeView();
            this.btnReEvaluate = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnReEvaluate);
            this.panel1.Controls.Add(this.tvPointDetail);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10, 20, 10, 10);
            this.panel1.Size = new System.Drawing.Size(584, 501);
            this.panel1.TabIndex = 0;
            // 
            // tvPointDetail
            // 
            this.tvPointDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvPointDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.tvPointDetail.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvPointDetail.Location = new System.Drawing.Point(10, 20);
            this.tvPointDetail.Name = "tvPointDetail";
            treeNode12.Name = "nNo";
            treeNode12.Text = "No:";
            treeNode13.Name = "nStudentCode";
            treeNode13.Text = "Student code:";
            treeNode14.Name = "nStudentName";
            treeNode14.Text = "Student name:";
            treeNode15.Name = "nExamCode";
            treeNode15.Text = "Exam code:";
            treeNode16.Name = "nListQuestions";
            treeNode16.Text = "List questions:";
            treeNode17.Name = "nResult";
            treeNode17.Text = "Result:";
            treeNode18.Name = "nCodingConvention";
            treeNode18.Text = "Coding convention:";
            treeNode19.Name = "nTotalPoint";
            treeNode19.Text = "Total point:";
            treeNode20.Name = "nSubmittedTime";
            treeNode20.Text = "Submitted time:";
            treeNode21.Name = "nEvaluatedTime";
            treeNode21.Text = "Evaluated time:";
            treeNode22.Name = "nMessage";
            treeNode22.Text = "Message:";
            this.tvPointDetail.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22});
            this.tvPointDetail.ShowLines = false;
            this.tvPointDetail.Size = new System.Drawing.Size(564, 397);
            this.tvPointDetail.TabIndex = 0;
            // 
            // btnReEvaluate
            // 
            this.btnReEvaluate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReEvaluate.Location = new System.Drawing.Point(200, 435);
            this.btnReEvaluate.Name = "btnReEvaluate";
            this.btnReEvaluate.Size = new System.Drawing.Size(200, 45);
            this.btnReEvaluate.TabIndex = 1;
            this.btnReEvaluate.Text = "Re-evaluate";
            this.btnReEvaluate.UseVisualStyleBackColor = true;
            // 
            // PointDetailMsgBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 501);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PointDetailMsgBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Point Detail";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView tvPointDetail;
        private System.Windows.Forms.Button btnReEvaluate;
    }
}