using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
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
        public List<StudentDTO> ListStudentBackUp { get; set; }
        public string ScriptCodePrefix { get; set; }

        Image CloseImage = PE2A_WF_Lecturer.Properties.Resources.close;

        public LecturerForm()
        {
            InitializeComponent();

        }

        static Socket s;
        static Byte[] buffer;
        private bool isPublishedPoint = false;

        private void ListeningToBroadcastUDPConnection(int listeningPort)
        {
            s = new Socket(AddressFamily.InterNetwork,
                          SocketType.Dgram,
                                ProtocolType.Udp);

            IPEndPoint senders = new IPEndPoint(IPAddress.Any, listeningPort);
            EndPoint tempRemoteEP = (EndPoint)senders;
            s.Bind(senders);
            buffer = new byte[1024];
            s.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref tempRemoteEP,
                                            new AsyncCallback(DoReceiveFrom), buffer);

        }

        private void DoReceiveFrom(IAsyncResult iar)
        {
            EndPoint clientEP = new IPEndPoint(IPAddress.Any, 5656);
            int size = s.EndReceiveFrom(iar, ref clientEP);
            if (size > 0)
            {
                byte[] receivedData = new Byte[size];
                receivedData = (byte[])iar.AsyncState;
                ASCIIEncoding eEncpding = new ASCIIEncoding();
                string receivedMessage = eEncpding.GetString(receivedData);
                receivedMessage = receivedMessage.Substring(0, size);
                Console.WriteLine("received message:" + receivedMessage);
                string[] data = receivedMessage.Split('-');
                Thread t = new Thread(() => ReturnWebserviceURL(data[0], int.Parse(data[1]), data[2]));
                t.Start();

            }
            s.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None,
                ref clientEP, new AsyncCallback(DoReceiveFrom), buffer);
        }

        private void StartTCPClient(TcpClient client)
        {
            Task.Run(() =>
            {
                while (!isPublishedPoint)
                {
                    Console.WriteLine("StartTCPClient");
                    WaitForServerRequest(client);
                }
            });
        }

        private void WaitForServerRequest(TcpClient client)
        {
            if (client != null)
            {
                //Get time submission when student submit
                var getDataTimeSubmission = GetTimeSubmission(client);
                if (getDataTimeSubmission != null)
                {
                    string studentCode = getDataTimeSubmission[0];
                    string timeSubmitted = getDataTimeSubmission[1];
                    if (studentCode != null && timeSubmitted != null)
                    {
                        StudentDTO dto = ListStudent.Where(t => t.StudentCode == studentCode).FirstOrDefault();
                        dto.SubmitTime = timeSubmitted;
                        dto.Status = Constant.STATUSLIST[1];
                        ResetDataGridViewDataSource();
                    }
                }
            }
        }

        private void ReturnWebserviceURL(string ipAddress, int port, string studentCode)
        {
            TcpClient tcpClient = new System.Net.Sockets.TcpClient(ipAddress, port);
            StartTCPClient(tcpClient);
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
                string submissionURL = Constant.PROTOCOL + Util.GetLocalIPAddress() + Constant.ENDPOINT;
                StudentDTO student = ListStudent.Where(t => t.StudentCode == studentCode).FirstOrDefault();
                StudentDTO studentDisconnected = ListStudentBackUp.Where(t => t.StudentCode == studentCode).FirstOrDefault();
                if (student != null)
                {
                    student.TcpClient = tcpClient;
                    student.Status = Constant.STATUSLIST[0];
                    scriptCode = student.ScriptCode;
                }
                else if (studentDisconnected != null)
                {
                    StudentDTO studentDTO = (StudentDTO)studentDisconnected.Shallowcopy();
                    studentDTO.TcpClient = tcpClient;
                    studentDTO.Status = Constant.STATUSLIST[0];
                    studentDTO.NO = ListStudent.Count + 1;
                    ListStudent.Add(studentDTO);
                    scriptCode = studentDTO.ScriptCode;
                }
                else
                {
                    MessageBox.Show("Student not in class is connecting");
                    return;
                }

                Console.WriteLine(ipAddress);
                ResetDataGridViewDataSource();
                while (!isSent)
                {
                    Console.WriteLine("!isSend");
                    try
                    {

                        // Cập nhật giao diện ở đây
                        message = "here is your submission url =" + submissionURL + "=" + ScriptCodePrefix + scriptCode;
                        //SendMessage(ipAddress, port, message);
                        Util.sendMessage(System.Text.Encoding.Unicode.GetBytes(message), tcpClient);
                        isSent = true;

                    }
                    catch (Exception e)
                    {
                        // resent message
                    }
                }
            }

        }


        private String[] GetTimeSubmission(TcpClient tcpClient)
        {
            var getStream = tcpClient.GetStream();
            var dataByte = new byte[1024 * 1024];
            var dataSize = tcpClient.ReceiveBufferSize;
            getStream.Read(dataByte, 0, dataSize);
            var dataConvert = Util.receiveMessage(dataByte);
            if (dataConvert.Split('-').Length > 0)
            {
                return dataConvert.Split('-');
            }
            return null;


        }
        private void InitDataSource()
        {
            foreach (var item in ListStudent)
            {
                count++;
                item.NO = count;
                item.Close = CloseImage;
                item.ScriptCode = item.ScriptCode.Replace(ScriptCodePrefix, "");
            }
            dgvStudent.DataSource = ListStudent;
            foreach (var item in Constant.HIDDEN_COLUMN)
            {
                this.dgvStudent.Columns[item].Visible = false;
            }
            FitDataGridViewCollumn();
        }

        private void ResetDataGridViewDataSource()
        {
            this.InvokeEx(f => dgvStudent.DataSource = null);
            this.InvokeEx(f => dgvStudent.DataSource = ListStudent);
            foreach (var item in Constant.HIDDEN_COLUMN)
            {
                this.InvokeEx(f => this.dgvStudent.Columns[item].Visible = false);
            }
            this.InvokeEx(f => FitDataGridViewCollumn());
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

        //private void SendMessage(string ipAddress, int port, string message)
        //{
        //    try
        //    {
        //        IPEndPoint iPEnd = new IPEndPoint(IPAddress.Parse(ipAddress), port);

        //        using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
        //        {
        //            socket.Connect(iPEnd);
        //            socket.Send(Encoding.UTF8.GetBytes(message));
        //            socket.Dispose();
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(Constant.CLIENT_SOCKET_CLOSED_MESSAGE);
        //    }
        //}


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
                            //dummy data
                            if (studentPoint.StudentCode.ToUpper().Equals("SE63155"))
                            {
                                int count = 10;
                                while (count < 40)
                                {
                                    count++;
                                    string code = "SE632" + count;
                                    StudentDTO dto = ListStudent.Where(t => t.StudentCode == code).FirstOrDefault();
                                    if (dto != null)
                                    {
                                        dto.ListQuestions = studentPoint.ListQuestions;
                                        // change tested time to submisstime   student.TimeSubmitted = studentPoint.Time;
                                        dto.Result = studentPoint.Result;
                                        dto.TotalPoint = studentPoint.TotalPoint;
                                        dto.Status = Constant.STATUSLIST[2];
                                    }
                                }
                            }
                            ResetDataGridViewDataSource();
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
                            ResetDataGridViewDataSource();
                        }
                        break;
                    }
                }
            }
        }

        private void UpdateStudentPointTable()
        {
            Task.Run(() => ReceiveStudentPointFromTCP(Constant.SOCKET_STUDENT_POINT_LISTENING_PORT));
        }

        //private void ReceiveStudentSubmissionFromTCP(int serverPort)
        //{
        //    while (true)
        //    {
        //        Console.WriteLine("ReceiveStudentSubmissionFromTCP");
        //        string receivedMessage = Util.GetMessageFromTCPConnection(serverPort, Constant.MAXIMUM_REQUEST);
        //        Console.WriteLine(receivedMessage);
        //        if (receivedMessage != null && !receivedMessage.Equals("") && receivedMessage.Contains('T'))
        //        {
        //            string[] messages = receivedMessage.Split('T');
        //            string studentCode = messages[0];
        //            string submissionTime = messages[1];
        //            foreach (var student in ListStudent)
        //            {
        //                if (student.StudentCode.Equals(studentCode))
        //                {
        //                    // Update student submissiontime and status
        //                    student.SubmitTime = submissionTime;
        //                    student.Status = Constant.STATUSLIST[1];
        //                    ResetDataGridViewDataSource();
        //                    break;
        //                }
        //            }
        //        }

        //    }
        //}

        //private void UpdateStudentSubmissionTable()
        //{
        //    Task.Run(() => ReceiveStudentSubmissionFromTCP(Constant.SOCKET_STUDENT_SUBMISSION_LISTENING_PORT));
        //}

        private void FitDataGridViewCollumn()
        {
            int baseWidth = Constant.COLUMN_WIDTH_A_LETTER;
            dgvStudent.Columns[nameof(StudentDTO.NO)].Width = Constant.COLUMN_NO_LETTER * baseWidth;
            dgvStudent.Columns[nameof(StudentDTO.TotalPoint)].Width = Constant.COLUMN_POINT_LETTER * baseWidth;
            dgvStudent.Columns[nameof(StudentDTO.Result)].Width = Constant.COLUMN_RESULT_LETTER * baseWidth;
            dgvStudent.Columns[nameof(StudentDTO.StudentCode)].Width = Constant.COLUMN_STUDENTCODE_LETTER * baseWidth;
            dgvStudent.Columns[nameof(StudentDTO.ScriptCode)].Width = Constant.COLUMN_SCRIPTCODE_LETTER * baseWidth;
            dgvStudent.Columns[nameof(StudentDTO.Close)].Width = Constant.COLUMN_CLOSE_LETTER * baseWidth;
            ChangeDataGridViewHeaderName();
        }

        private void ChangeDataGridViewHeaderName()
        {
            dgvStudent.Columns[nameof(StudentDTO.StudentName)].HeaderText = Constant.HEADER_COLUMN_STUDENTNAME;
            dgvStudent.Columns[nameof(StudentDTO.StudentCode)].HeaderText = Constant.HEADER_COLUMN_STUDENTCODE;
            dgvStudent.Columns[nameof(StudentDTO.ScriptCode)].HeaderText = Constant.HEADER_COLUMN_SCRIPTCODE;
        }

        private void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ListStudent.Count == 0) return;
            int columnClicked = e.ColumnIndex;
            int rowClicked = e.RowIndex;
            if (columnClicked == dgvStudent.Columns[nameof(StudentDTO.Close)].Index && rowClicked >= 0)
            {

                string studentCode = dgvStudent.Rows[rowClicked].Cells[dgvStudent.Columns[nameof(StudentDTO.StudentCode)].Index].Value.ToString();
                DialogResult result = MessageBox.Show(Constant.REMOVE_STUDENT_MESSAGE + studentCode, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ListStudent.Remove(ListStudent.Where(f => f.StudentCode == studentCode).FirstOrDefault());
                    count = 0;
                    foreach (var item in ListStudent)
                    {
                        count++;
                        item.NO = count;
                    }
                    ResetDataGridViewDataSource();
                }
            }
        }

        private void LecturerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void LecturerForm_Load(object sender, EventArgs e)
        {
            InitDataSource();
            //listen to student
            ListeningToBroadcastUDPConnection(Constant.LECTURER_LISTENING_PORT);
            // listening to webservice for return student's submission
            // UpdateStudentSubmissionTable();
            // listening to webservice for return student's point
            UpdateStudentPointTable();
        }

        private void publishPointMenu_Click(object sender, EventArgs e)
        {
            //send point to client
            foreach (var item in ListStudent)
            {
                try
                {
                    Util.sendMessage(System.Text.Encoding.Unicode.GetBytes(item.TotalPoint + ""), item.TcpClient);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("PUBLISH POINT: " + item.StudentCode + " has disconnected");
                }
            }

        }

        private void ImportScriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    using (var openFileDialog = new OpenFileDialog())
            //    {
            //        openFileDialog.Filter = "Supported file formats|*.zip;*.rar|ZIP files|*.zip|RAR files|*.rar";
            //        openFileDialog.Multiselect = false;
            //        openFileDialog.RestoreDirectory = true;
            //        if (openFileDialog.ShowDialog().Equals(DialogResult.OK))
            //        {
            //            var filePath = openFileDialog.FileName;
            //            if (File.Exists(filePath))
            //            {
            //                /*
            //                 * 
            //                 * This block is for local test (IDE test)
            //                 * 
            //                 */

            //                var appDomainDir = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            //                var projectNameDir = Path.GetFullPath(Path.Combine(appDomainDir, @"..\.."));
            //                var destinationPath = Path.Combine(projectNameDir + Constant.SCRIPT_FILE_PATH);

            //                /*
            //                 * 
            //                 * This block is for release app
            //                 * 
            //                 */

            //                //var projectNameDir = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            //                //var destinationPath = Path.Combine(projectNameDir + Constant.SCRIPT_FILE_PATH);

            //                if (Directory.Exists(destinationPath))
            //                {
            //                    Util.UnarchiveFile(filePath, destinationPath);
            //                    MessageBox.Show("Import success!", "Information");
            //                }
            //                else
            //                {
            //                    MessageBox.Show("Can not import script file!", "Error occurred");
            //                }
            //            }
            //            else
            //            {
            //                MessageBox.Show("The file does not exist!", "Error occurred");
            //            }
            //        }
            //    }
            //}
            //catch
            //{
            //    MessageBox.Show("Can not import script file!", "Error occurred");
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in ListStudent)
            {
                try
                {
                    Util.sendMessage(System.Text.Encoding.Unicode.GetBytes("chipu"), item.TcpClient);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("PUBLISH POINT: " + item.StudentCode + " has disconnected");
                }
            }
        }
    }
}
