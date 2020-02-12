using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
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
        private void ReturnWebserviceURL(string ipAddress, int port, string studentCode)
        {
            string scriptCode = "";
            string message;
            if (IsConnected(ipAddress))
            {
                message = Constant.EXISTED_IP_MESSAGE;
                SendMessage(ipAddress, port, message);
            }
            else
            {
                count++;
                bool isSent = false;
                string submissionURL = Constant.PROTOCOL + Util.GetLocalIPAddress() + Constant.ENDPOINT;
                StudentDTO student = ListStudent.Where(t => t.StudentCode == studentCode).FirstOrDefault();
                StudentDTO studentDisconnected = ListStudentBackUp.Where(t => t.StudentCode == studentCode).FirstOrDefault();
                if(student != null)
                {
                    student.IpAddress = IPAddress.Parse(ipAddress);
                    student.Port = port;
                    student.Status = Constant.STATUSLIST[0];
                    scriptCode = student.ScriptCode;
                }
                else if(studentDisconnected != null)
                {
                    StudentDTO studentDTO =(StudentDTO) studentDisconnected.Shallowcopy();
                    studentDTO.IpAddress = IPAddress.Parse(ipAddress);
                    studentDTO.Port = port;
                    studentDTO.Status = Constant.STATUSLIST[0];
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
                    try
                    {
                        // Cập nhật giao diện ở đây
                        message = "here is your submission url =" + submissionURL + "=" + ScriptCodePrefix + scriptCode;
                        SendMessage(ipAddress, port, message);
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
            splitContainer1.Panel2Collapsed = true;
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
                    if (student.IpAddress.ToString().Equals(ipAddress))
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

        private void SendMessage(string ipAddress, int port, string message)
        {
            try
            {
                IPEndPoint iPEnd = new IPEndPoint(IPAddress.Parse(ipAddress), port);

                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    socket.Connect(iPEnd);
                    socket.Send(Encoding.UTF8.GetBytes(message));
                    socket.Dispose();
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(Constant.CLIENT_SOCKET_CLOSED_MESSAGE);
            }
        }


        //private void GetResultFromFile()
        //{
        //    String directory = AppDomain.CurrentDomain.BaseDirectory + @"Results.txt";
        //    var getFile = File.ReadAllText(directory).Replace("\n", "").Replace("\r", "");
        //    for (int i = 0; i < getFile.Length; i++)
        //    {
        //        int startIndex = getFile.IndexOf("//" + i);
        //        int endIndex = getFile.IndexOf("//end" + i) - startIndex;

        //        if (startIndex != -1 && endIndex != -1)
        //        {
        //            String startString = getFile.Substring(startIndex, endIndex);
        //            int startIndexCode = startString.IndexOf("SE");
        //            int endIndexCode = startString.IndexOf("(StudentCode)") - startIndexCode;
        //            String studentCode = startString.Substring(startIndexCode, endIndexCode);
        //            int startIndexResult = startString.IndexOf("Result") + 8; // skip word result 
        //            int endIndexResult = startString.IndexOf("(Point)") - startIndexResult;
        //            String studentPoint = startString.Substring(startIndexResult, endIndexResult);
        //            String splitPassed = studentPoint.Split('/')[0];
        //            String splitTotal = studentPoint.Split('/')[1];
        //            Double totalPoint = (Double.Parse(splitPassed) / Double.Parse(splitTotal)) * 10;
        //            foreach (var item in ListStudent)
        //            {
        //                if (studentCode.ToUpper().Trim().Equals(item.StudentCode.ToUpper()))
        //                {
        //                    item.Point = totalPoint + "";
        //                }
        //            }

        //        }
        //    };
        //}

        private void ReceiveStudentPointFromTCP(int serverPort)
        {
            while (true)
            {
                string receivedMessage = Util.GetMessageFromTCPConnection(serverPort, Constant.MAXIMUM_REQUEST);
                StudentPointDTO studentPoint = JsonConvert.DeserializeObject<StudentPointDTO>(receivedMessage);
                foreach (var student in ListStudent)
                {
                    if (student.StudentCode.Equals(studentPoint.StudentCode))
                    {
                        // Update student result
                        student.ListQuestions = studentPoint.ListQuestions;
                        student.TimeSubmitted = studentPoint.Time;
                        student.Result = studentPoint.Result;
                        student.Point = studentPoint.TotalPoint;
                        student.Status = Constant.STATUSLIST[2];
                        ResetDataGridViewDataSource();
                        // For test
                        Console.WriteLine(studentPoint.StudentCode);
                        Dictionary<string, string> listQuestions = studentPoint.ListQuestions;
                        foreach (var ques in listQuestions)
                        {
                            Console.WriteLine(ques.Key + ": " + ques.Value);
                        }
                        Console.WriteLine(studentPoint.TotalPoint);
                        Console.WriteLine(studentPoint.Result);
                        Console.WriteLine(studentPoint.Time);
                        break;
                    }
                }
            }
        }

        private void UpdateStudentPointTable()
        {
            Task.Run(() => ReceiveStudentPointFromTCP(Constant.SOCKET_STUDENT_POINT_LISTENING_PORT)); // 6969
        }


        private void FitDataGridViewCollumn()
        {
            int baseWidth = Constant.COLUMN_WIDTH_A_LETTER;
            dgvStudent.Columns[nameof(StudentDTO.NO)].Width = Constant.COLUMN_NO_LETTER * baseWidth;
            dgvStudent.Columns[nameof(StudentDTO.Point)].Width = Constant.COLUMN_POINT_LETTER * baseWidth;
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
                    SendMessage(item.IpAddress.ToString(), item.Port, item.Point);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("PUBLISH POINT: " + item.StudentCode + " has disconnected");
                }
            }

        }
    }
}
