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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("No:");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Student code:");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Student name:");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Exam code:");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("List questions:");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Result:");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Coding convention:");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Total point:");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Submitted time:");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Evaluated time:");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Message:");
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReEvaluate = new System.Windows.Forms.Button();
            this.tvPointDetail = new System.Windows.Forms.TreeView();
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
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(15, 31, 15, 15);
            this.panel1.Size = new System.Drawing.Size(876, 771);
            this.panel1.TabIndex = 0;
            // 
            // btnReEvaluate
            // 
            this.btnReEvaluate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReEvaluate.Location = new System.Drawing.Point(300, 669);
            this.btnReEvaluate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReEvaluate.Name = "btnReEvaluate";
            this.btnReEvaluate.Size = new System.Drawing.Size(300, 69);
            this.btnReEvaluate.TabIndex = 1;
            this.btnReEvaluate.Text = "Re-evaluate";
            this.btnReEvaluate.UseVisualStyleBackColor = true;
            this.btnReEvaluate.Click += new System.EventHandler(this.btnReEvaluate_Click);
            // 
            // tvPointDetail
            // 
            this.tvPointDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvPointDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.tvPointDetail.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvPointDetail.Location = new System.Drawing.Point(15, 31);
            this.tvPointDetail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tvPointDetail.Name = "tvPointDetail";
            treeNode1.Name = "nNo";
            treeNode1.Text = "No:";
            treeNode2.Name = "nStudentCode";
            treeNode2.Text = "Student code:";
            treeNode3.Name = "nStudentName";
            treeNode3.Text = "Student name:";
            treeNode4.Name = "nExamCode";
            treeNode4.Text = "Exam code:";
            treeNode5.Name = "nListQuestions";
            treeNode5.Text = "List questions:";
            treeNode6.Name = "nResult";
            treeNode6.Text = "Result:";
            treeNode7.Name = "nCodingConvention";
            treeNode7.Text = "Coding convention:";
            treeNode8.Name = "nTotalPoint";
            treeNode8.Text = "Total point:";
            treeNode9.Name = "nSubmittedTime";
            treeNode9.Text = "Submitted time:";
            treeNode10.Name = "nEvaluatedTime";
            treeNode10.Text = "Evaluated time:";
            treeNode11.Name = "nMessage";
            treeNode11.Text = "Message:";
            this.tvPointDetail.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11});
            this.tvPointDetail.ShowLines = false;
            this.tvPointDetail.Size = new System.Drawing.Size(846, 610);
            this.tvPointDetail.TabIndex = 0;
            // 
            // PointDetailMsgBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 771);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PointDetailMsgBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Point Detail";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.PointDetailMsgBox_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView tvPointDetail;
        private System.Windows.Forms.Button btnReEvaluate;
    }
}