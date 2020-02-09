using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PE2A_WF_Lecturer
{
    class StudentDTO
    {
        public int NO { get; set; }
        public string StudentCode { get; set; }
        public IPAddress IpAddress { get; set; }
        public int Port { get; set; }
        public Dictionary<string, string> ListQuestions { get; set; }
        public string Time { get; set; }
        public string Result { get; set; }
        public string TotalPoint { get; set; }
        public string Status { get; set; }

        public Image Close{get;set;}
        public StudentDTO(string studentCode, IPAddress ipAddress, int port)
        {
            StudentCode = studentCode;
            IpAddress = ipAddress;
            Port = port;
        }

        public StudentDTO(int no, string studentCode, IPAddress ipAddress, int port, string status,Image close)
        {
            this.NO = no;
            StudentCode = studentCode;
            IpAddress = ipAddress;
            Port = port;
            this.Status = status;
            this.Close = close;
        }

        public StudentDTO()
        {
        }

    }
}
