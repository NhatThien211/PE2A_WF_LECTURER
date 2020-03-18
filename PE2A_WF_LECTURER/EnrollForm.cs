
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PE2A_WF_Lecturer
{
    public partial class LecturerEnroll : Form
    {
        public LecturerEnroll()
        {
            InitializeComponent();
            ShowControls(true);
        }

        private void ShowControls(bool isVisble)
        {
            labelRollNumber.Visible = isVisble;
            txtEnrollKey.Visible = isVisble;
            btnEnroll.Visible = isVisble;
            loadingBox.Visible = !isVisble;
        }


        //private async Task GetListStudentssAsync()
        //{
        //    listStudent = await GetClassStudentListAsync();
        //    if (listStudent == null)
        //    {
        //    }
        //    else if (listStudent.Count == 0)
        //    {
        //        MessageBox.Show(Constant.CLASS_EMPTY_MESSAGE);
        //    }
        //    else
        //    {
        //        this.InvokeEx(f => ShowControls(true));
        //    }
        //}
        //List<StudentDTO> listStudent = new List<StudentDTO>();
        List<PracticalDTO> listPractical;
        private void btnEnroll_Click(object sender, EventArgs e)
        {
            string enrollKey = txtEnrollKey.Text.ToUpper().Trim();
            if (!CheckInput(enrollKey)) return;
            ShowControls(false);
            GetPracticalList(enrollKey);
            ImportScriptForm importScriptForm = new ImportScriptForm(this);
            //importScriptForm.PracticalList = listPractical;
            //importScriptForm.Show();
            //if (studentID.Equals("ADMIN"))
            //{
            //    LecturerForm lecturerForm = new LecturerForm();
            //    AddData();
            //    lecturerForm.ListStudent = listStudent;
            //    List<StudentDTO> listTemp = new List<StudentDTO>();
            //    listTemp.AddRange(listStudent);
            //    lecturerForm.ListStudentBackUp = listTemp;
            //    string scriptCode = listStudent[0].ScriptCode;
            //    string practicalPrefix = scriptCode.Substring(0, scriptCode.IndexOf(Constant.SCRIPT_PREFIX));
            //    lecturerForm.ScriptCodePrefix = practicalPrefix;
            //    //lecturerForm.Show();
            //    ImportScriptForm importScriptForm = new ImportScriptForm(this, lecturerForm);
            //    importScriptForm.Show();
            //    this.Hide();
            //}
        }

        //for dummy data
        //private void AddData()
        //{
        //    int count = 10;
        //    StudentDTO dto = null;
        //    for (int i = 0; i < listStudent.Count; i++)
        //    {
        //        if (listStudent[i].StudentCode.ToUpper() == "SE63155")
        //        {
        //            dto = listStudent[i];
        //        }
        //    }
        //    while (count < 40)
        //    {
        //        Console.WriteLine("AddData");
        //        count++;
        //        StudentDTO temp = (StudentDTO)dto.Shallowcopy();
        //        temp.StudentCode = "SE632" + count;
        //        temp.StudentName = "Nguyen Van " + count;

        //        listStudent.Add(temp);
        //    }
        //}

        private bool CheckInput(string enrollKey)
        {
            if (enrollKey == null || enrollKey.Equals(""))
            {
                MessageBox.Show(Constant.ENROLL_NAME_NOT_NULL_MESSAGE);
                return false;
            }
            return true;
        }

        //private async Task<List<StudentDTO>> GetClassStudentListAsync()
        //{
        //    List<StudentDTO> students = null;
        //    string apiUrl = Constant.ONLINE_API_URL;
        //    int startIndex = apiUrl.IndexOf('{');
        //    int endIndex = apiUrl.IndexOf('}');
        //    string id = apiUrl.Substring(startIndex, endIndex - startIndex + 1);
        //    apiUrl = apiUrl.Replace(id, "1");
        //    using (HttpClient client = new HttpClient())
        //    {
        //        client.DefaultRequestHeaders.Accept.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        try
        //        {
        //            string result = await GetStudentListFromAPI(client, apiUrl);
        //            students = JsonConvert.DeserializeObject<List<StudentDTO>>(result);
        //        }
        //        catch (Exception e)
        //        {
        //            MessageBox.Show(Constant.CANNOT_CONNECT_API_MESSAGE);
        //            return null;
        //        }
        //    }
        //    return students;
        //}
        //private async Task<string> GetStudentListFromAPI(HttpClient client, String uri)
        //{
        //    string message = "";
        //    uri = "http://" + uri;
        //    HttpResponseMessage response = await client.GetAsync(new Uri(uri));
        //    if (response.IsSuccessStatusCode)
        //    {
        //        message = await response.Content.ReadAsStringAsync();
        //    }

        //    return message;
        //}
        private async Task<string> GetPracticalListFromAPI(HttpClient client, string uri, string enrollKey)
        {
            string message = "";
            try
            {
                uri = "http://" + uri;
                var values = new Dictionary<string, string>{
                { "code", enrollKey }
                };
                HttpContent content = new FormUrlEncodedContent(values);
                HttpResponseMessage response = await client.PostAsync(new Uri(uri), content);
                if (response.IsSuccessStatusCode)
                {
                    message = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception e)
            {

            }
            return message;
        }

        private async void GetPracticalList(string enrollKey)
        {
            string apiUrl = Constant.ONLINE_API_URL;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    string result = await GetPracticalListFromAPI(client, apiUrl, enrollKey);
                    listPractical = JsonConvert.DeserializeObject<List<PracticalDTO>>(result);
                    ImportScriptForm importScript = new ImportScriptForm(this);
                    importScript.PracticalList = listPractical;
                    importScript.Show();
                    this.InvokeEx(f => ShowControls(true));
                    this.InvokeEx(f => this.Hide());
                }
                catch (Exception e)
                {
                    MessageBox.Show(Constant.CANNOT_CONNECT_API_MESSAGE);
                }
            }
        }
    }
}
