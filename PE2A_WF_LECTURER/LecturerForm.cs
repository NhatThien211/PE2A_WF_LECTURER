﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PE2A_WF_Lecturer
{
    public partial class LecturerForm : Form
    {
        private int count = 0;
        public TcpClient client;
        public List<StudentDTO> ListStudent { get; set; }
        public string PracticalExamStatus { get; set; }
        public string PracticalExamCode { get; set; }
        public List<StudentDTO> ListStudentBackUp { get; set; }

        private Dictionary<string, byte[]> ExamScriptList = new Dictionary<string, byte[]>();


        Image CloseImage = PE2A_WF_Lecturer.Properties.Resources.close;

        static Socket udpSocket;
        static Byte[] buffer;
        private bool isPublishedPoint = false;
        string submissionURL;
        public LecturerForm()
        {
            InitializeComponent();
        }

        // for dummy data
        string[] listStudetnCode = { "SE63146", "SE63155", "SE62847", "SE62882" };

        private void dummyDataConnect()
        {
            //foreach (StudentDTO dto in ListStudent)
            //{
            //    if (!listStudetnCode.Contains(dto.StudentCode))
            //    {
            //        dto.Status = Constant.STATUSLIST[0];
            //        ResetDataGridViewDataSourceWithDto(dto);
            //        //ResetDataGridViewDataSource();
            //    }
            //}
        }

        private void dummyDataSubmission()
        {
            //foreach (StudentDTO dto in ListStudent)
            //{
            //    if (!listStudetnCode.Contains(dto.StudentCode))
            //    {
            //        string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //        dto.SubmitTime = time;
            //        dto.Status = Constant.STATUSLIST[1];
            //        ResetDataGridViewDataSourceWithDto(dto);

            //        //ResetDataGridViewDataSource();
            //    }
            //}
        }

        private void dummyDataGetPoint()
        {
            //Random ran = new Random();

            //foreach (StudentDTO dto in ListStudent)
            //{
            //    if (!listStudetnCode.Contains(dto.StudentCode))
            //    {
            //        string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //        dto.EvaluateTime = time;
            //        int correctQuesiton = ran.Next(0, 4);
            //        switch (correctQuesiton)
            //        {
            //            case 0:
            //                dto.TotalPoint = 0 + "";
            //                dto.Result = "0/4";
            //                break;
            //            case 1:
            //                dto.TotalPoint = 3 + "";
            //                dto.Result = "1/4";
            //                break;
            //            case 2:
            //                dto.TotalPoint = 6 + "";
            //                dto.Result = "2/4";
            //                break;
            //            case 3:
            //                dto.TotalPoint = 8 + "";
            //                dto.Result = "3/4";
            //                break;
            //            case 4:
            //                dto.TotalPoint = 10 + "";
            //                dto.Result = "4/4";
            //                break;
            //        }
            //        dto.Status = Constant.STATUSLIST[2];
            //        ResetDataGridViewDataSourceWithDto(dto);

            //        //ResetDataGridViewDataSource();
            //    }
            //}
        }

        private void ListeningToBroadcastUDPConnection(int listeningPort)
        {
            udpSocket = new Socket(AddressFamily.InterNetwork,
                          SocketType.Dgram,
                                ProtocolType.Udp);

            IPEndPoint senders = new IPEndPoint(IPAddress.Any, listeningPort);
            EndPoint tempRemoteEP = (EndPoint)senders;
            udpSocket.Bind(senders);
            buffer = new byte[1024];
            udpSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref tempRemoteEP,
                                            new AsyncCallback(DoReceiveFrom), buffer);
        }

        private void DoReceiveFrom(IAsyncResult iar)
        {
            EndPoint clientEP = new IPEndPoint(IPAddress.Any, 5656);
            int size = udpSocket.EndReceiveFrom(iar, ref clientEP);
            if (size > 0)
            {
                byte[] receivedData = new byte[size];
                receivedData = (byte[])iar.AsyncState;
                ASCIIEncoding encoding = new ASCIIEncoding();

                // Receive IP & Port from student
                string receivedMessage = encoding.GetString(receivedData);
                receivedMessage = receivedMessage.Substring(0, size);

                string[] data = receivedMessage.Split('-');
                Thread t = new Thread(() => ReturnWebserviceURL(data[0], int.Parse(data[1]), data[2]));
                t.Start();
            }
            udpSocket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None,
                ref clientEP, new AsyncCallback(DoReceiveFrom), buffer);
        }

        // Return submission API - document questions - expired time to student
        private void ReturnWebserviceURL(string ipAddress, int port, string studentCode)
        {
            // Student's TCP information
            TcpClient tcpClient = new System.Net.Sockets.TcpClient(ipAddress, port);

            string scriptCode = "";
            string message;

            if (IsConnected(ipAddress))
            {
                message = Constant.EXISTED_IP_MESSAGE;
                Util.sendMessage(System.Text.Encoding.Unicode.GetBytes(message), tcpClient);
            }
            else
            {
                count++;
                bool isSent = false;
                StudentDTO student = ListStudent.Where(t => t.StudentCode == studentCode).FirstOrDefault();
                StudentDTO studentDisconnected = ListStudentBackUp.Where(t => t.StudentCode == studentCode).FirstOrDefault();
                if (student != null)
                {
                    student.TcpClient = tcpClient;
                    student.Status = Constant.STATUSLIST[0];

                    // Exam code
                    scriptCode = student.ScriptCode;
                    ResetDataGridViewDataSourceWithDto(student, Constant.ACTION_UPDATE);
                }
                else if (studentDisconnected != null)
                {
                    StudentDTO studentDTO = (StudentDTO)studentDisconnected.Shallowcopy();
                    studentDTO.TcpClient = tcpClient;
                    studentDTO.Status = Constant.STATUSLIST[0];
                    studentDTO.NO = ListStudent.Count + 1;
                    ListStudent.Add(studentDTO);
                    scriptCode = studentDTO.ScriptCode;
                    ResetDataGridViewDataSourceWithDto(studentDTO, Constant.ACTION_ADD);
                }
                else
                {
                    MessageBox.Show("Student not in class is connecting");
                    return;
                }


                //ResetDataGridViewDataSource();
                while (!isSent)
                {
                    try
                    {
                        // Cập nhật giao diện ở đây
                        message = "=" + submissionURL + "=" + scriptCode + "=" + PracticalExamCode;
                        //SendMessage(ipAddress, port, message);
                        var messageEncode = Util.Encode(message, "SE1267");
                        messageEncode = Constant.RETURN_URL_CODE + messageEncode;
                        Util.sendMessage(System.Text.Encoding.Unicode.GetBytes(messageEncode), tcpClient);
                        //byte[] bytes = File.ReadAllBytes(@"D:\Capstone_WF_Lecturer\PE2A_WF_LECTURER\submission\PracticalExams\Practical_Java_SE1269_05022020\TestScripts\Java_SE1269_05_02_2020_De1.java");
                        //Util.sendMessage(bytes, tcpClient);
                        isSent = true;
                    }
                    catch (Exception e)
                    {
                        // resent message
                    }
                }
            }
        }

        private void InitDataSource()
        {
            dgvStudent.Rows.Clear();
            foreach (var item in ListStudent)
            {
                count++;
                item.NO = count;
                item.Close = CloseImage;
                AddRowDataGridView(item);
            }
            FitDataGridViewCollumn();
        }
        string scriptCode;
        private void AddRowDataGridView(StudentDTO dto)
        {
            scriptCode = dto.ScriptCode.Substring(dto.ScriptCode.IndexOf(Constant.SCRIPT_PREFIX));
            dgvStudent.Rows.Add(dto.NO.ToString(), dto.StudentCode, dto.StudentName, scriptCode, dto.Status, dto.TotalPoint, dto.SubmitTime, dto.EvaluateTime, dto.Result, dto.ErrorMsg, dto.Close);
        }

        private void ResetDataGridViewDataSource()
        {
            //this.InvokeEx(f => this.dgvStudent.Rows.Clear());
            //foreach (StudentDTO dto in ListStudent)
            //{
            //    this.InvokeEx(f => AddRowDataGridView(dto));
            //}

        }

        private void ResetDataGridViewDataSourceWithDto(StudentDTO dto, string action)
        {
            switch (action)
            {
                case Constant.ACTION_ADD:
                    this.InvokeEx(f => AddRecord(dto));
                    break;
                case Constant.ACTION_REMOVE:
                    this.InvokeEx(f => RemoveRecord(dto));
                    break;
                case Constant.ACTION_UPDATE:
                    this.InvokeEx(f => UpdateRecord(dto));
                    break;
            }
        }

        private bool IsConnected(string ipAddress)
        {
            foreach (var student in ListStudent)
            {
                try
                {
                    IPAddress connectingIP = ((IPEndPoint)student.TcpClient.Client.RemoteEndPoint).Address;
                    if (connectingIP.ToString().Equals(ipAddress))
                    {
                        return true;
                    }
                }
                catch (Exception e)
                {

                }
            }
            return false;
        }

        private void ReceiveStudentPointFromTCP(int serverPort)
        {
            while (!isPublishedPoint)
            {
                Console.WriteLine("ReceiveStudentPointFromTCP");
                string receivedMessage = Util.GetMessageFromTCPConnection(serverPort, Constant.MAXIMUM_REQUEST);
                Console.WriteLine(receivedMessage);
                StudentPointDTO studentPoint = JsonConvert.DeserializeObject<StudentPointDTO>(receivedMessage);

                foreach (var student in ListStudent)
                {
                    if (student.StudentCode.Equals(studentPoint.StudentCode))
                    {
                        if (studentPoint.ErrorMsg == null)
                        {
                            // Update student result
                            student.ListQuestions = studentPoint.ListQuestions;
                            // change tested time to submisstime   student.TimeSubmitted = studentPoint.Time;
                            student.Result = studentPoint.Result;
                            student.TotalPoint = studentPoint.TotalPoint;
                            student.Status = Constant.STATUSLIST[2];
                            student.EvaluateTime = studentPoint.EvaluateTime;
                            ReadFile(student);
                            ResetDataGridViewDataSourceWithDto(student, Constant.ACTION_UPDATE);
                            //ResetDataGridViewDataSource();
                            // For test
                            Console.WriteLine("Student code: " + studentPoint.StudentCode);
                            Dictionary<string, string> listQuestions = studentPoint.ListQuestions;
                            foreach (var ques in listQuestions)
                            {
                                Console.WriteLine(ques.Key + ": " + ques.Value);
                            }
                            Console.WriteLine("Total point: " + studentPoint.TotalPoint);
                            Console.WriteLine("Result: " + studentPoint.Result);
                            Console.WriteLine("Evaluate time: " + studentPoint.EvaluateTime);
                        }
                        else
                        {
                            // Update status of the student when cannot evaluate the submission
                            student.Status = Constant.STATUSLIST[3];
                            ResetDataGridViewDataSourceWithDto(student, Constant.ACTION_UPDATE);
                            //ResetDataGridViewDataSource();
                        }
                        break;
                    }
                }
            }
        }
        private void ReadFile(StudentDTO dto)

        {
            string practicalExam = PracticalExamCode;
            var appDomainDir = Util.ExecutablePath();
            var destinationPath = Path.Combine(appDomainDir + Constant.SCRIPT_FILE_PATH);
            string listStudentPath = destinationPath + "\\" + practicalExam + "\\" + Constant.STUDENT_LIST_FILE_NAME;
            string newCSV = "";
            string[] readAllText = File.ReadAllLines(listStudentPath);
            foreach (var item in readAllText)
            {
                if (item.Contains(dto.StudentCode))
                {
                    newCSV += dto.NO + "," + dto.StudentCode + "," + dto.StudentName + "," + dto.ScriptCode + "," + dto.SubmitTime + "," + dto.EvaluateTime + "," + "0" + "," + dto.Result + "(correct)," + dto.TotalPoint + "," + dto.ErrorMsg;
                    foreach (KeyValuePair<string, string> items in dto.ListQuestions)
                    {
                        newCSV += "," + items.Key + ":" + items.Value;
                    }
                    newCSV += "\r\n";
                }
                else
                {
                    newCSV += item + "\r\n";
                }
            }
            File.WriteAllText(listStudentPath, newCSV);
        }
        private void UpdateStudentPointTable()
        {
            Task.Run(() => ReceiveStudentPointFromTCP(Constant.SOCKET_STUDENT_POINT_LISTENING_PORT));
        }

        private void ReceiveStudentSubmissionFromTCP(int serverPort)
        {
            while (true)
            {
                Console.WriteLine("ReceiveStudentSubmissionFromTCP");
                string receivedMessage = Util.GetMessageFromTCPConnections(serverPort, Constant.MAXIMUM_REQUEST);
                Console.WriteLine(receivedMessage);
                if (receivedMessage != null && !receivedMessage.Equals("") && receivedMessage.Contains('T'))
                {
                    string[] messages = receivedMessage.Split('T');
                    string studentCode = messages[0];
                    string submissionTime = messages[1];
                    foreach (var student in ListStudent)
                    {
                        if (student.StudentCode.Equals(studentCode))
                        {
                            // Update student submissiontime and status
                            student.SubmitTime = submissionTime;
                            student.Status = Constant.STATUSLIST[1];
                            ResetDataGridViewDataSourceWithDto(student, Constant.ACTION_UPDATE);
                            //ResetDataGridViewDataSource();
                            break;
                        }
                    }
                }

            }
        }



        private void UpdateStudentSubmissionTable()
        {
            Task.Run(() => ReceiveStudentSubmissionFromTCP(Constant.SOCKET_STUDENT_SUBMISSION_LISTENING_PORT));
        }

        private void FitDataGridViewCollumn()
        {
            int baseWidth = Constant.COLUMN_WIDTH_A_LETTER;
            dgvStudent.Columns[nameof(StudentDTO.NO)].Width = Constant.COLUMN_NO_LETTER * baseWidth;
            dgvStudent.Columns[nameof(StudentDTO.TotalPoint)].Width = Constant.COLUMN_POINT_LETTER * baseWidth;
            dgvStudent.Columns[nameof(StudentDTO.Result)].Width = Constant.COLUMN_RESULT_LETTER * baseWidth;
            dgvStudent.Columns[nameof(StudentDTO.StudentCode)].Width = Constant.COLUMN_STUDENTCODE_LETTER * baseWidth;
            dgvStudent.Columns[Constant.COLUMN_SCRIPTCODE_NAME].Width = Constant.COLUMN_SCRIPTCODE_LETTER * baseWidth;
            dgvStudent.Columns[nameof(StudentDTO.Close)].Width = Constant.COLUMN_CLOSE_LETTER * baseWidth;
        }

        private void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnClicked = e.ColumnIndex;
            int rowClicked = e.RowIndex;
            if (ListStudent.Count == 0 || rowClicked < 0 || rowClicked > ListStudent.Count - 1) return;
            if (columnClicked == dgvStudent.Columns[nameof(StudentDTO.Close)].Index && rowClicked >= 0)
            {

                string studentCode = dgvStudent.Rows[rowClicked].Cells[dgvStudent.Columns[nameof(StudentDTO.StudentCode)].Index].Value.ToString();
                DialogResult result = MessageBox.Show(Constant.REMOVE_STUDENT_MESSAGE + studentCode, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    StudentDTO removeStudent = ListStudent.Where(f => f.StudentCode == studentCode).FirstOrDefault();
                    ListStudent.Remove(removeStudent);
                    ResetDataGridViewDataSourceWithDto(removeStudent, Constant.ACTION_REMOVE);
                    //ResetDataGridViewDataSource();
                }
            }
            else if (Constant.PRACTICAL_STATUS[2].Equals(PracticalExamStatus))
            {
                StudentDTO dto = ListStudent[rowClicked];
                DialogResult result = MessageBox.Show(Constant.REEVALUATE_STUDENT_MESSAGE + dto.StudentCode, "RE-Evaluate", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    var appDomainDir = Util.ExecutablePath();
                    var destinationPath = Path.Combine(appDomainDir + Constant.SCRIPT_FILE_PATH);
                    string listStudentPath = destinationPath + "\\" + PracticalExamCode + "\\" + Constant.SUMISSION_FOLDER_NAME;
                    listStudentPath = listStudentPath + "\\" + dto.StudentCode + Constant.ZIP_EXTENSION;
                    Task.Run(async delegate
                    {
                        string message = await sendFile(listStudentPath, dto.StudentCode, dto.ScriptCode);
                        Console.WriteLine(message);
                    }
                    );
                }
            }
        }

        private void LecturerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void LecturerForm_LoadAsync(object sender, EventArgs e)
        {
            InitDataSource();
            submissionURL = Constant.PROTOCOL + Util.GetLocalIPAddress() + Constant.ENDPOINT;
            if (Constant.PRACTICAL_STATUS[0].Equals(PracticalExamStatus))
            {
                ShowMenuAction(false);
            }
            else if (Constant.PRACTICAL_STATUS[1].Equals(PracticalExamStatus))
            {
                //listen to student
                ListeningToBroadcastUDPConnection(Constant.LECTURER_LISTENING_PORT);
                // listening to webservice for return student's submission
                // UpdateStudentSubmissionTable();
                // listening to webservice for return student's point
                GetAllPracticalDocFile();
                UpdateStudentSubmissionTable();
                UpdateStudentPointTable();
                // Task.Run(() => { dummyDataConnect(); });
            }
            else
            {
                ShowMenuAction(false);
                UpdateStudentPointTable();
            }

        }

        private async Task<string> sendFile(string fileName, string studentID, string scriptCode)
        {
            //var client = new WebClient();
            string submissionURL = Constant.PROTOCOL + Util.GetLocalIPAddress() + Constant.ENDPOINT;
            var uri = new Uri(submissionURL);
            string fileExtension = fileName.Substring(fileName.IndexOf('.'));
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var stream = File.ReadAllBytes(fileName);
                    MultipartFormDataContent form = new MultipartFormDataContent();
                    //form.Add(new ByteArrayContent(stream,0,stream.Length), "file");
                    //file => byte[]
                    //multipartFile => stream
                    HttpContent content = new StreamContent(new FileStream(fileName, FileMode.Open));
                    content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    {
                        Name = "file",
                        FileName = studentID + fileExtension
                    };
                    form.Add(content, "file");
                    form.Add(new StringContent(studentID), "studentCode");
                    form.Add(new StringContent(scriptCode), "scriptCode");
                    using (var message = await client.PostAsync(uri, form))
                    {
                        var result = await message.Content.ReadAsStringAsync();
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return "Error !";

        }

        private void ShowMenuAction(bool isShowing)
        {
            menuAction.Visible = isShowing;
        }

        private void publishPointMenu_Click(object sender, EventArgs e)
        {
            //send point to client
            foreach (var item in ListStudent)
            {
                try
                {
                    string point = Constant.RETURN_POINT + item.TotalPoint;
                    Util.sendMessage(System.Text.Encoding.Unicode.GetBytes(point), item.TcpClient);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("PUBLISH POINT: " + item.StudentCode + " has disconnected");
                }
            }

        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string time = txtTime.Text;
            Regex regex = new Regex(Constant.REGEX_NUMBER);
            if ("".Equals(time) || !regex.IsMatch(time) || !isDoneReadExamDocument)
            {
                MessageBox.Show("Reading Exam document");
                return;
            }
            foreach (var item in ListStudent)
            {
                try
                {
                    Util.sendMessage(System.Text.Encoding.Unicode.GetBytes(Constant.RETURN_EXAM_SCIPT + time), item.TcpClient);
                    var temp = ExamScriptList.Where(x => item.ScriptCode.Contains(x.Key)).FirstOrDefault();
                    if (temp.Key != null)
                    {
                        Util.sendMessage(ExamScriptList[temp.Key], item.TcpClient);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("PUBLISH POINT: " + item.StudentCode + " has disconnected");
                }
            }

            dummyDataSubmission();
            dummyDataGetPoint();
        }

        bool isDoneReadExamDocument = false;
        private void GetAllPracticalDocFile()
        {
            var appDomainDir = Util.ExecutablePath();
            var destinationPath = Path.Combine(appDomainDir + Constant.SCRIPT_FILE_PATH);
            string examScriptFolderPath = destinationPath + "\\" + PracticalExamCode + "\\" + Constant.EXAM_SCIPT_FOLDER_NAME;
            string[] fileEntries = Directory.GetFiles(examScriptFolderPath);
            string fileNameWithExtension;
            string fileName;
            int readedFile = 0;
            foreach (string file in fileEntries)
            {

                fileNameWithExtension = Path.GetFileName(file);
                if (fileNameWithExtension.Contains(Constant.WORD_FILE_EXTENSION))
                {
                    fileName = fileNameWithExtension.Replace(Constant.WORD_FILE_EXTENSION, "");
                    byte[] bytes = File.ReadAllBytes(file);
                    //  loadPracticalDoc(fileName, file);
                    ExamScriptList.Add(fileName, bytes);
                    readedFile++;
                    if (readedFile == fileEntries.Length)
                    {
                        isDoneReadExamDocument = true;
                        MessageBox.Show("Done Reading exam document");
                    }


                }
            }
        }

        private void dgvStudent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = dgvStudent.CurrentCell.RowIndex;
            string number = dgvStudent.Rows[selectedRow].Cells[0].Value.ToString();
            string studentCode = dgvStudent.Rows[selectedRow].Cells[1].Value.ToString();
            StudentDTO studentDto = ListStudent.Where(student => student.StudentCode == studentCode).FirstOrDefault();
            PointDetailMsgBox msgBox = new PointDetailMsgBox(studentDto);
            msgBox.SubmitAPIUrl = submissionURL;
            msgBox.PracticalExamCode = PracticalExamCode;
            msgBox.Show();
            //Dictionary<string, string> listQuestion = new Dictionary<string, string>();
            //listQuestion.Add("question1", "success:1/1");
            //listQuestion.Add("question2", "fail:0/1");
            //listQuestion.Add("question3", "success:1/1");
            //listQuestion.Add("question4", "success:1/1");
            //studentDto.ListQuestions = listQuestion;
            //ReadFile(studentDto);
        }

        private void printReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string projectDirectory = Util.GetProjectDirectory();

            // Get student result report folder
            string reportDirectory = Path.Combine(projectDirectory + Constant.SCRIPT_FILE_PATH, this.PracticalExamCode);
            string destinationDirectory;
            FolderBrowserDialog browserDialog = new FolderBrowserDialog();
            if (browserDialog.ShowDialog() == DialogResult.OK)
            {
                destinationDirectory = browserDialog.SelectedPath;
                string reportFile = Path.Combine(reportDirectory, Constant.STUDENT_LIST_FILE_NAME);
                string destinationFile = Path.Combine(destinationDirectory, Constant.STUDENT_LIST_FILE_NAME);

                // Check if the report file existed
                if (File.Exists(reportFile))
                {
                    File.Copy(reportFile, destinationFile, true);
                    MessageBox.Show("Report file saved.");
                }
                else
                {
                    MessageBox.Show("Cannot export report!", "Error occured");
                }
            }
        }


        private void UpdateRecord(StudentDTO dto)
        {
            for (int i = 0; i < this.dgvStudent.RowCount; i++)
            {
                var getStudentId = this.dgvStudent[1, i].Value.ToString();
                if (getStudentId.Equals(dto.StudentCode))
                {
                    this.dgvStudent[4, i].Value = dto.Status;
                    this.dgvStudent[5, i].Value = dto.TotalPoint;
                    this.dgvStudent[6, i].Value = dto.SubmitTime;
                    this.dgvStudent[7, i].Value = dto.EvaluateTime;
                    this.dgvStudent[8, i].Value = dto.Result;
                    this.dgvStudent[9, i].Value = dto.ErrorMsg;
                    break;
                }
            }
        }

        private void RemoveRecord(StudentDTO dto)
        {
            int rowIndex = 1;
            StudentDTO currentStudent;
            for (int i = 0; i < this.dgvStudent.RowCount; i++)
            {
                var getStudentId = this.dgvStudent[1, i].Value.ToString();
                if (getStudentId.Equals(dto.StudentCode))
                {
                    dgvStudent.Rows.Remove(dgvStudent.Rows[i]);
                }
                if (i < dgvStudent.RowCount)
                {
                    this.dgvStudent[0, i].Value = rowIndex;
                    string currentStudentCode = dgvStudent[1, i].Value.ToString();
                    currentStudent = ListStudent.Where(t => t.StudentCode.Equals(currentStudentCode)).FirstOrDefault();
                    if (currentStudent != null)
                    {
                        currentStudent.NO = rowIndex;
                    }
                    rowIndex++;
                }
            }
        }
        private void AddRecord(StudentDTO dto)
        {
            int index = dgvStudent.Rows.Count;
            dto.NO = index;
            dto.Close = CloseImage;
            AddRowDataGridView(dto);
        }
    }
}
