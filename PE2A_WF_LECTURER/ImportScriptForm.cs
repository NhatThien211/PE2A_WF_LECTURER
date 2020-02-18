using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PE2A_WF_Lecturer
{
    public partial class ImportScriptForm : Form
    {

        private LecturerEnroll enrollForm;
        private LecturerForm lecturerForm;
        private int scriptFileCounter;

        public ImportScriptForm(LecturerEnroll enrollForm, LecturerForm lecturerForm)
        {
            InitializeComponent();
            this.enrollForm = enrollForm;
            this.lecturerForm = lecturerForm;

            scriptFileCounter = 0;

            InitDgvScriptFilesStyle();
            LoadTemplateHistory();
        }

        private void LoadTemplateHistory()
        {
            var submissionFolderPath = Path.Combine(GetProjectDirectory() + Constant.SCRIPT_FILE_PATH);
            DirectoryInfo directoryInfo = new DirectoryInfo(submissionFolderPath);
            DirectoryInfo[] directories = directoryInfo.GetDirectories();

            if (directories.Length > 0)
            {
                scriptFileCounter = 0;
                dgvScriptFiles.Rows.Clear();
                for (int i = 0; i < directories.Length; i++)
                {
                    scriptFileCounter++;
                    dgvScriptFiles.Rows.Add(new string[] { scriptFileCounter.ToString(), directories[i].ToString() });
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
                                LoadTemplateHistory();

                                var filename = Path.GetFileNameWithoutExtension(filePath);
                                var scriptFolder = Path.Combine(destinationPath, filename);

                                CopyPracticalInfoToSubmissionFolder(scriptFolder);
                                // MessageBox.Show("Import success!", "Information");
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

            lecturerForm.Show();
            Hide();

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
    }
}
