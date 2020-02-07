
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PE2A_WF_Lecturer
{
    public partial class EnrollForm : Form
    {
        public EnrollForm()
        {
            InitializeComponent();
        }
        string studentID;
        Thread sendingThread;
        Thread listeningThread;
        private void btnEnroll_Click(object sender, EventArgs e)
        {
            studentID = txtStudentID.Text.ToUpper().Trim();

            if (studentID.Trim().ToLower().Equals("admin"))
            {
                LecturerForm lecturerForm = new LecturerForm();
                lecturerForm.Show();
            }       
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
