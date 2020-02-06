using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PE2A_WF_Lecturer
{
    class StudentDTO
    {
        public string StudentCode { get; set; }
        public IPAddress IpAddress { get; set; }
        public int Port { get; set; }
        public Dictionary<string, string> ListQuestions { get; set; }
        public string Time { get; set; }
        public string Result { get; set; }
        public string TotalPoint { get; set; }
        public StudentDTO(string studentCode, IPAddress ipAddress, int port)
        {
            StudentCode = studentCode;
            IpAddress = ipAddress;
            Port = port;
        }
    }
}
