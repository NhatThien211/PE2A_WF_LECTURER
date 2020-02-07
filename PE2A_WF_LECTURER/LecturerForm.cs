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
        DataTable dataTable = new DataTable();
        List<StudentDTO> listStudent = new List<StudentDTO>();
        private List<StudentPointDTO> listStudentPoints = new List<StudentPointDTO>();
        public LecturerForm()
        {
            InitializeComponent();

            //dataTable.Columns.Add("No.");
            //dataTable.Columns.Add("Student_Code");
            //dataTable.Columns.Add("Total Point");
            //dataTable.Columns.Add("Time");
            //dataTable.Columns.Add("Status");

            //dataTable.Columns.Add("Close", typeof(Image));
            //dataTable.Columns.Add("Close", typeof(Image));
            InitDataSource();
            //listen to student
            ListeningToBroadcastUDPConnection(Constant.LECTURER_LISTENING_PORT);

            // listening to webservice for return student's point
            UpdateStudentPointTable();
        }


        private void btnEstimate_Click(object sender, EventArgs e)
        {
            //get point from file
         //   GetResultFromFile();
            //send point to client
            foreach (var item in listStudent)
            {
                SendMessage(item.IpAddress.ToString(), item.Port, item.TotalPoint);
            }

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
                StudentDTO newStudent = new StudentDTO(count,studentCode, IPAddress.Parse(ipAddress), port,Constant.STATUSLIST[0]);
                listStudent.Remove(listStudent.Where(x => x.NO == 0).FirstOrDefault());
                listStudent.Add(newStudent);
                Console.WriteLine(newStudent.IpAddress);
                Console.WriteLine(ipAddress);
                ResetDataGridViewDataSource();
                while (!isSent)
                {
                    try
                    {
                        // Cập nhật giao diện ở đây
                        message = "here is your submission url =" + submissionURL;
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
            this.InvokeEx(f => dgvStudent.DataSource = null);
            StudentDTO dto = new StudentDTO()
            {
                NO = 0,
                StudentCode = "",
            };
            listStudent.Add(dto);
            dgvStudent.DataSource = listStudent;
            this.InvokeEx(f => dgvStudent.DataSource = listStudent);
            this.InvokeEx(f => this.dgvStudent.Columns["IpAddress"].Visible = false);
            this.InvokeEx(f => this.dgvStudent.Columns["Port"].Visible = false);
            this.InvokeEx(f => this.dgvStudent.Columns["ListQuestions"].Visible = false);
           
        }
        private void ResetDataGridViewDataSource()
        {           
            this.InvokeEx(f => dgvStudent.DataSource = null);          
            this.InvokeEx(f => dgvStudent.DataSource = listStudent);
            this.InvokeEx(f => this.dgvStudent.Columns["IpAddress"].Visible = false);
            this.InvokeEx(f => this.dgvStudent.Columns["Port"].Visible = false);
            this.InvokeEx(f => this.dgvStudent.Columns["ListQuestions"].Visible = false);

        }
        private bool IsConnected(string ipAddress)
        {
            try
            {
                foreach (var student in listStudent)
                {
                    if (student.IpAddress.ToString().Equals(ipAddress))
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("IsConnected : "+ex.Message);
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


        private void GetResultFromFile()
        {
            String directory = AppDomain.CurrentDomain.BaseDirectory + @"Results.txt";
            var getFile = File.ReadAllText(directory).Replace("\n", "").Replace("\r", "");
            for (int i = 0; i < getFile.Length; i++)
            {
                int startIndex = getFile.IndexOf("//" + i);
                int endIndex = getFile.IndexOf("//end" + i) - startIndex;

                if (startIndex != -1 && endIndex != -1)
                {
                    String startString = getFile.Substring(startIndex, endIndex);
                    int startIndexCode = startString.IndexOf("SE");
                    int endIndexCode = startString.IndexOf("(StudentCode)") - startIndexCode;
                    String studentCode = startString.Substring(startIndexCode, endIndexCode);
                    int startIndexResult = startString.IndexOf("Result") + 8; // skip word result 
                    int endIndexResult = startString.IndexOf("(Point)") - startIndexResult;
                    String studentPoint = startString.Substring(startIndexResult, endIndexResult);
                    String splitPassed = studentPoint.Split('/')[0];
                    String splitTotal = studentPoint.Split('/')[1];
                    Double totalPoint = (Double.Parse(splitPassed) / Double.Parse(splitTotal)) * 10;
                    foreach (var item in listStudent)
                    {
                        if (studentCode.ToUpper().Trim().Equals(item.StudentCode.ToUpper()))
                        {
                            item.TotalPoint = totalPoint + "";
                        }
                    }

                }
            };
        }

        private void ReceiveStudentPointFromTCP(int serverPort)
        {
            while (true)
            {
                string receivedMessage = Util.GetMessageFromTCPConnection(serverPort, Constant.MAXIMUM_REQUEST);
                StudentPointDTO studentPoint = JsonConvert.DeserializeObject<StudentPointDTO>(receivedMessage);
                foreach (var student in listStudent)
                {
                    if (student.StudentCode.Equals(studentPoint.StudentCode))
                    {
                        // Update student result
                        student.ListQuestions = studentPoint.ListQuestions;
                        student.Time = studentPoint.Time;
                        student.Result = studentPoint.Result;
                        student.TotalPoint = studentPoint.TotalPoint;
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
                      

                        //string colName = "Student_Code='" + student.StudentCode + "'";
                        //DataRow dr = dataTable.Select(colName).FirstOrDefault();
                        //if (dr != null)
                        //{
                        //    dr["Total Point"] = student.TotalPoint;
                        //    dr["Time"] = student.Time;
                        //    dr["Status"] = Constant.STATUSLIST[2];
                        //    this.InvokeEx(f => dgvStudent.Refresh());
                        //}
                        break;
                    }
                }
            }
        }

        private void UpdateStudentPointTable()
        {
            Task.Run(() => ReceiveStudentPointFromTCP(Constant.SOCKET_STUDENT_POINT_LISTENING_PORT)); // 6969
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
