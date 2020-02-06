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
        public string TotalPoint { get; set; }
        public string CreateDate { get; set; }

        public StudentPointDTO(string studentCode, Dictionary<string, string> listQuestions, string totalPoint, string createDate)
        {
            StudentCode = studentCode;
            ListQuestions = listQuestions;
            TotalPoint = totalPoint;
            CreateDate = createDate;
        }
    }
}
