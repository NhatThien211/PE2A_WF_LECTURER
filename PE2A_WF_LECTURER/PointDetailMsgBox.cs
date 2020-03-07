using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PE2A_WF_Lecturer
{
    public partial class PointDetailMsgBox : Form
    {
        private StudentDTO studentDTO;

        public PointDetailMsgBox(StudentDTO studentDTO)
        {
            InitializeComponent();
            this.studentDTO = studentDTO;
            DisplayResultMessage();
        }

        private void DisplayResultMessage()
        {
            if (studentDTO != null)
            {
                // Set form title to student name
                Text = studentDTO.StudentName;

                // Update result to tree view
                tvPointDetail.Nodes[0].Text = "No                   : " + studentDTO.NO;
                tvPointDetail.Nodes[1].Text = "Student code         : " + studentDTO.StudentCode;
                tvPointDetail.Nodes[2].Text = "Student name         : " + studentDTO.StudentName;
                tvPointDetail.Nodes[3].Text = "Exam code            : " + studentDTO.ScriptCode;
                tvPointDetail.Nodes[4].Text = "List questions       : ";
                if (studentDTO.ListQuestions != null)
                {
                    foreach (var item in studentDTO.ListQuestions)
                    {
                        tvPointDetail.Nodes[4].Nodes.Add(item.Key + " : " + item.Value);
                    }
                }
                tvPointDetail.Nodes[5].Text = "Result               : " + studentDTO.Result;
                tvPointDetail.Nodes[6].Text = "Coding convention    : " + studentDTO.CodingConvention;
                tvPointDetail.Nodes[7].Text = "Total point          : " + studentDTO.TotalPoint;
                tvPointDetail.Nodes[8].Text = "Submitted time       : " + studentDTO.SubmitTime;
                tvPointDetail.Nodes[9].Text = "Evaluated time       : " + studentDTO.EvaluateTime;
                tvPointDetail.Nodes[10].Text = "Message              : " + studentDTO.ErrorMsg;
            }
        }
    }
}
