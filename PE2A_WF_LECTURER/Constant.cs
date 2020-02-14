
using System.Collections.Generic;

namespace PE2A_WF_Lecturer
{
    public static class Constant
    {
        public static int LECTURER_LISTENING_PORT = 9999;
        public static int STUDENT_LISTENING_PORT = 9998;
        public static int SOCKET_STUDENT_POINT_LISTENING_PORT = 9997;
        public static int SOCKET_STUDENT_SUBMISSION_LISTENING_PORT = 9996;
        public static int MAXIMUM_REQUEST = 100;
        public static string EXISTED_IP_MESSAGE = "You Have Connected To Server";
        public static string[] STATUSLIST = { "Connected", "Submitted", "Evaluated" };
        public static string CLIENT_SOCKET_CLOSED_MESSAGE = "Clients closed their connection!!!";
        public static string PROTOCOL = "http://";
        public static string ENDPOINT = ":2020/api/submission";
        public static string REMOVE_STUDENT_MESSAGE = "Do you want to remove ";
        public static string ENROLL_NAME_NOT_NULL_MESSAGE = "EnrollName is must NOT empty please";
        public static string CANNOT_CONNECT_API_MESSAGE = "Can not connect to online webservice";
        public static string ONLINE_API_URL = "localhost:8080/api/practical-exam/{id}/students";
        public static List<string> HIDDEN_COLUMN = new List<string> { "IpAddress", "Port", "ListQuestions", "Id", "SubmitPath" };
        public static string CLASS_EMPTY_MESSAGE = "Your class have no student please check again";
        public static string SCRIPT_PREFIX = "De";
        public static string HEADER_COLUMN_STUDENTNAME = "Name";
        public static string HEADER_COLUMN_STUDENTCODE = "Code";
        public static string HEADER_COLUMN_SCRIPTCODE = "Script";

        public static int COLUMN_WIDTH_A_LETTER = 20;
        public static int COLUMN_NO_LETTER = 2;
        public static int COLUMN_POINT_LETTER = 4;
        public static int COLUMN_RESULT_LETTER = 4;
        public static int COLUMN_STUDENTCODE_LETTER = 8;
        public static int COLUMN_SCRIPTCODE_LETTER = 3;
        public static int COLUMN_CLOSE_LETTER = 3;

        public static string ZIP_EXTENSION = ".zip";
        public static string RAR_EXTENSION = ".rar";
        public const string SCRIPT_FILE_PATH = @"\submission\PracticalExams";
    }
}
