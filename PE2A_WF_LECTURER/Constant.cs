using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE2A_WF_Lecturer
{
    public class Constant
    {
        public static int LECTURER_LISTENING_PORT = 9999;
        public static int STUDENT_LISTENING_PORT = 9998;
        public static int SOCKET_STUDENT_POINT_LISTENING_PORT = 9997;
        public static int MAXIMUM_REQUEST = 100;
        public static string EXISTED_IP_MESSAGE = "You Have Connected To Server";
        public static string[] STATUSLIST = { "Connected", "Submitted", "Evaluated" };
        public static string CLIENT_SOCKET_CLOSED_MESSAGE = "Clients closed their connection!!!";
        public static string PROTOCOL = "http://";
        public static string ENDPOINT = ":2020/api/submission";
        public static string REMOVE_STUDENT_MESSAGE = "Do you want to remove ";
        public static string ENROLL_NAME_NOT_NULL_MESSAGE = "EnrollName is must NOT empty please";
        public static string CANNOT_CONNECT_API_MESSAGE = "EnrollName is must NOT empty please";
        public static string ONLINE_API_URL = "localhost:8080/api/practical-exam/{id}/students";
        public static List<String> HIDDEN_COLUMN = new List<string> { "IpAddress", "Port", "ListQuestions", "Id", "SubmitPath" };
        public static string CLASS_EMPTY_MESSAGE = "Your class have no student please check again";
        public static string SCRIPT_PREFIX = "De";
    }
}
