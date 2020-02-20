﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PE2A_WF_Lecturer
{
    public partial class ImportScriptForm : Form
    {

        private LecturerEnroll enrollForm;
        private int scriptFileCounter;
        public List<PracticalDTO> PracticalList { get; set; }
        private List<StudentDTO> StudentList = new List<StudentDTO>();
        public ImportScriptForm(LecturerEnroll enrollForm)
        {
            InitializeComponent();
            this.enrollForm = enrollForm;


            scriptFileCounter = 0;

            InitDgvScriptFilesStyle();
            //  LoadTemplateHistory();

        }

        //private void LoadTemplateHistory()
        //{
        //    var submissionFolderPath = Path.Combine(GetProjectDirectory() + Constant.SCRIPT_FILE_PATH);
        //    DirectoryInfo directoryInfo = new DirectoryInfo(submissionFolderPath);
        //    DirectoryInfo[] directories = directoryInfo.GetDirectories();

        //    if (directories.Length > 0)
        //    {
        //        scriptFileCounter = 0;
        //        dgvScriptFiles.Rows.Clear();
        //        for (int i = 0; i < directories.Length; i++)
        //        {
        //            scriptFileCounter++;
        //            dgvScriptFiles.Rows.Add(new string[] { scriptFileCounter.ToString(), directories[i].ToString() });
        //        }
        //    }
        //}

        private void LoadPractical()
        {
            if (PracticalList.Count > 0)
            {
                scriptFileCounter = 0;
                dgvScriptFiles.Rows.Clear();
                for (int i = 0; i < PracticalList.Count; i++)
                {
                    scriptFileCounter++;
                    PracticalDTO dto = PracticalList[i];
                    dgvScriptFiles.Rows.Add(new string[] { scriptFileCounter.ToString(), dto.Code, dto.SubjectCode, dto.Date, dto.Status });
                }
            }
        }

        private void InitDgvScriptFilesStyle()
        {
            dgvScriptFiles.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvScriptFiles.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            dgvScriptFiles.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private string GetProjectDirectory()
        {
            /*
            * 
            * This block is for local test (IDE test)
            * 
            */

            var appDomainDir = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            var projectNameDir = Path.GetFullPath(Path.Combine(appDomainDir, @"..\.."));

            /*
             * 
             * This block is for release app
             * 
             */

            //var projectNameDir = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

            return projectNameDir;
        }

        private void ImportTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Supported file formats|*.zip;*.rar|ZIP files|*.zip|RAR files|*.rar";
                    openFileDialog.Multiselect = false;
                    openFileDialog.RestoreDirectory = true;
                    if (openFileDialog.ShowDialog().Equals(DialogResult.OK))
                    {
                        var filePath = openFileDialog.FileName;
                       
                        if (File.Exists(filePath))
                        {
                            var destinationPath = Path.Combine(GetProjectDirectory() + Constant.SCRIPT_FILE_PATH);

                            if (Directory.Exists(destinationPath))
                            {
                                Util.UnarchiveFile(filePath, destinationPath);
                                // LoadTemplateHistory();

                                var filename = Path.GetFileNameWithoutExtension(filePath);
                                var scriptFolder = Path.Combine(destinationPath, filename);

                                CopyPracticalInfoToSubmissionFolder(scriptFolder);
                                // MessageBox.Show("Import success!", "Information");
                             
                                var practicalExamCode = openFileDialog.SafeFileName.Split('.')[0];
                                GetListStudentFromCSV(practicalExamCode);
                                LecturerForm lecturerForm = new LecturerForm();
                                //AddData();
                                lecturerForm.ListStudent = StudentList;
                                List<StudentDTO> listTemp = new List<StudentDTO>();
                                listTemp.AddRange(StudentList);
                                lecturerForm.ListStudentBackUp = listTemp;
                                string scriptCode = StudentList[0].ScriptCode;
                                lecturerForm.Show();
                                Hide();
                            }
                            else
                            {
                                MessageBox.Show("Can not import script file!", "Error occurred");
                            }
                        }
                        else
                        {
                            MessageBox.Show("The file does not exist!", "Error occurred");
                        }
                    }
                }
            
            }
            catch
            {
                MessageBox.Show("Can not import script file!", "Error occurred");
            }
        }

        private void CopyPracticalInfoToSubmissionFolder(string scriptFolder)
        {
            if (Directory.Exists(scriptFolder))
            {
                // copy practical-info.json to submission folder
                string[] fileEntries = Directory.GetFiles(scriptFolder, "*.json");
                if (fileEntries.Length > 0
                    && Path.GetFileName(fileEntries[0]).Equals(Constant.PRACTICAL_INFO, StringComparison.OrdinalIgnoreCase))
                {
                    var sourceFile = fileEntries[0];
                    var destinationFile = Path.Combine(GetProjectDirectory() + Constant.SUBMISSION_FOLDER_PATH, Constant.PRACTICAL_INFO);
                    File.Copy(sourceFile, destinationFile, true);
                }
            }
        }

        private void ImportScriptForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            enrollForm.Show();
        }

        private void ImportScriptForm_Load(object sender, EventArgs e)
        {
            LoadPractical();
        }

        private void dgvScriptFiles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index < 0 || index > PracticalList.Count - 1) return;
            PracticalDTO dto = PracticalList[index];
            if (Constant.PRACTICAL_STATUS[1].Equals(dto.Status))
            {
                ImportTemplateToolStripMenuItem_Click(sender, e);
            }
        }

        private void GetListStudentFromCSV(string practicalExamCode)
        {
            string practicalExam = practicalExamCode;
            int count = 0;
            var appDomainDir = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            var projectNameDir = Path.GetFullPath(Path.Combine(appDomainDir, @"..\.."));
            var destinationPath = Path.Combine(projectNameDir + Constant.SCRIPT_FILE_PATH);
            string listStudentPath = destinationPath + "\\" + practicalExam + "\\" + Constant.STUDENT_LIST_FILE_NAME;
            using (var reader = new StreamReader(listStudentPath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (count != 0)
                    {
                        var values = line.Split(',');
                        StudentDTO dto = new StudentDTO();
                        dto.StudentCode = values[Constant.STUDENT_CODE_INDEX];
                        dto.StudentName = values[Constant.STUDENT_NAME_INDEX];
                        dto.ScriptCode = values[Constant.SCRIPT_CODE_INDEX];
                        StudentList.Add(dto);
                    }
                    count++;
                }
            }

            //                /*
            //                 * 
            //                 * This block is for release app
            //                 * 
            //                 */

            //                //var projectNameDir = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            //                //var destinationPath = Path.Combine(projectNameDir + Constant.SCRIPT_FILE_PATH);
            //foreach (StudentDTO dto in listStudent)
            //{
            //    Console.WriteLine(dto.StudentName);
            //}
        }
    }
}
