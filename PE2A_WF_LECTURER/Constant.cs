
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
        public static string ZIP_EXTENSION = ".zip";
        public static string RAR_EXTENSION = ".rar";
    }
}
