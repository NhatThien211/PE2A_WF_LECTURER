using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE2A_WF_Lecturer
{
    class StudentPointDTO
    {
        public string StudentCode { get; set; }
        public Dictionary<string, string> ListQuestions { get; set; }
        public string Time { get; set; }
        public string Result { get; set; }
        public string TotalPoint { get; set; }

        public StudentPointDTO(string studentCode, Dictionary<string, string> listQuestions, string totalPoint, string time, string result)
        {
            StudentCode = studentCode;
            ListQuestions = listQuestions;
            TotalPoint = totalPoint;
            Time = time;
            Result = result;
        }

       
    }
}
