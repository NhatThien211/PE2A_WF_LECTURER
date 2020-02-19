
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PE2A_WF_Lecturer
{
    public partial class LecturerEnroll : Form
    {
        public LecturerEnroll()
        {
            InitializeComponent();
            ShowControls(false);
            Task.Run(async () => await GetListStudentssAsync());
        }

        private void ShowControls(bool isVisble)
        {
            labelRollNumber.Visible = isVisble;
            txtStudentID.Visible = isVisble;
            btnEnroll.Visible = isVisble;
            loadingBox.Visible = !isVisble;
        }
        private async Task GetListStudentssAsync() {
            listStudent = await GetClassStudentListAsync();
            if(listStudent == null)
            {
            }else if(listStudent.Count == 0)
            {
                MessageBox.Show(Constant.CLASS_EMPTY_MESSAGE);
            }
            else
            {
                this.InvokeEx(f => ShowControls(true));
            }
        }
        string studentID;
        List<StudentDTO> listStudent = new List<StudentDTO>();
        private void btnEnroll_Click(object sender, EventArgs e)
        {
            
            studentID = txtStudentID.Text.ToUpper().Trim();
            if (!CheckInput()) return;
            if (studentID.Equals("ADMIN"))
            {
                LecturerForm lecturerForm = new LecturerForm();
                AddData();
                lecturerForm.ListStudent = listStudent;
                List<StudentDTO> listTemp = new List<StudentDTO>();
                listTemp.AddRange(listStudent);
                lecturerForm.ListStudentBackUp = listTemp;
                string scriptCode = listStudent[0].ScriptCode;
                string practicalPrefix = scriptCode.Substring(0, scriptCode.IndexOf(Constant.SCRIPT_PREFIX));
                lecturerForm.ScriptCodePrefix = practicalPrefix;
                //lecturerForm.Show();
                ImportScriptForm importScriptForm = new ImportScriptForm(this, lecturerForm);
                importScriptForm.Show();
                this.Hide();
            }       
        }

        //for dummy data
        private void AddData()
        {
            int count = 10;
            StudentDTO dto = null;
          for(int i = 0; i< listStudent.Count; i++)
            {
                if (listStudent[i].StudentCode.ToUpper() == "SE63155")
                {
                    dto = listStudent[i];
                }
            }
            while (count < 40)
            {
                count++;
                StudentDTO temp = (StudentDTO)dto.Shallowcopy();
                temp.StudentCode = "SE632" + count;
                temp.StudentName = "Nguyen Van " + count;

                listStudent.Add(temp);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private bool CheckInput()
        {
            if(studentID.Equals("")|| studentID == null)
            {
                MessageBox.Show(Constant.ENROLL_NAME_NOT_NULL_MESSAGE);
                return false;
            }
            return true;
        }

        private async Task<List<StudentDTO>> GetClassStudentListAsync()
        {
            List<StudentDTO> students = null;
            string apiUrl = Constant.ONLINE_API_URL;
            int startIndex = apiUrl.IndexOf('{');
            int endIndex = apiUrl.IndexOf('}');
            string id = apiUrl.Substring(startIndex, endIndex - startIndex + 1);
            apiUrl = apiUrl.Replace(id,"1");
            using(HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string result = await GetStudentListFromAPI(client,apiUrl);
                    students = JsonConvert.DeserializeObject<List<StudentDTO>>(result);
                }
                catch(Exception e)
                {
                    MessageBox.Show(Constant.CANNOT_CONNECT_API_MESSAGE);
                    return null;
                }
            }
            return students;
        }
        private async Task<string> GetStudentListFromAPI(HttpClient client,String uri)
        {
            string message = "";
            uri = "http://" + uri;
            HttpResponseMessage response = await client.GetAsync(new Uri(uri));
            if (response.IsSuccessStatusCode)
            {
                message = await response.Content.ReadAsStringAsync();
            }
           
            return message;
        }

    }
}
