﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE2A_WF_Lecturer
{
    public class Constant
    {
        public static int LECTURER_LISTENING_PORT = 5656;
        public static int STUDENT_LISTENING_PORT = 4000;
        public static int MAXIMUM_REQUEST = 100;
        public static string EXISTED_IP_MESSAGE = "You Have Connected To Server";
        public static string[] STATUSLIST = { "connected","submitted","checked","returned"};
        public static string CLIENT_SOCKET_CLOSED_MESSAGE = "Clients closed their connection!!!";
        public static string PROTOCOL = "http://";
        public static string ENDPOINT = ":2020/api/submission";
    }
}
