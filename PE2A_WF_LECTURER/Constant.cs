﻿
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
        public static string[] STATUSLIST = { "Connected", "Submitted", "Evaluated", "Cannot Evaluate"};
        public static string CLIENT_SOCKET_CLOSED_MESSAGE = "Clients closed their connection!!!";
        public static string PROTOCOL = "http://";
        public static string ENDPOINT = ":2020/api/submission";
        public static string REMOVE_STUDENT_MESSAGE = "Do you want to remove ";
        public static string ENROLL_NAME_NOT_NULL_MESSAGE = "EnrollName is must NOT empty please";
        public static string PASSWORD_NOT_NULL_MESSAGE = "Password is must NOT empty please";
        public static string CANNOT_CONNECT_API_MESSAGE = "Can not connect to online webservice";
        public static string ONLINE_API_URL = "localhost:8080/api/practical-exam/lecturer/enroll";
        public static List<string> HIDDEN_COLUMN = new List<string> { "TcpClient", "ListQuestions", "Id", "SubmitPath", "CodingConvention", "ErrorMsg"};
        public static string CLASS_EMPTY_MESSAGE = "Your class have no student please check again";
        public static string SCRIPT_PREFIX = "De";
        public static string HEADER_COLUMN_STUDENTNAME = "Name";
        public static string HEADER_COLUMN_STUDENTCODE = "Code";
        public static string HEADER_COLUMN_SCRIPTCODE = "Script";
        public static int MAXIMUM_SEND_TIME = 3;

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
        public const string SUBMISSION_FOLDER_PATH = @"\submission";
        public const string PRACTICAL_INFO = "practical-info.json";

        // read student list from csv
        public static string STUDENT_LIST_FILE_NAME = "Student_List.csv";
        public static int STUDENT_CODE_INDEX = 1;
        public static int STUDENT_NAME_INDEX = 2;
        public static int SCRIPT_CODE_INDEX = 3;
        public static int SUBMITTED_TIME_INDEX = 4;
        public static int EVALUATED_TIME_INDEX = 5;
        public static int CODING_CONVENTION_INDEX = 6;
        public static int RESULT_INDEX= 7;
        public static int TOTAL_POINT_INDEX= 8;
        public static int ERROR_INDEX= 9;

        public static string[] PRACTICAL_STATUS = {"DONE","NOT_EVALUATE","ERROR" };
        public static string SUMISSION_FOLDER_NAME = "Submissions";
    }
}
