using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AttribChanger
{
    public partial class FileAttributeChanger : Form
    {
        //Initializing new instance of DataTable
        DataTable dt = new DataTable();
        DataRow dr;
        string filename = "";

        public FileAttributeChanger()
        {
            InitializeComponent();
            //Adding a new column name that will show file names
            dt.Columns.Add(new DataColumn("Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Type", typeof(string)));              
            dt.Columns.Add(new DataColumn("Path", typeof(string)));          
        }

        //Code to run on clicking ChangeAttributes 
        private void btn_ChangeAttribs_Click(object sender, EventArgs e)
        {
            string type ="";
            foreach (DataGridViewRow dgvr in dgv_filescollection.Rows)
            {
                try
                {
                    //Get Current file name in the datagridview
                    filename = dgvr.Cells[2].Value.ToString();
                    type = dgvr.Cells[1].Value.ToString();

                    //Reset File Attributes so that new attributes can be set
                    //This is required because file attributes cannot be changed if it is read-only
                    File.SetAttributes(filename, FileAttributes.Normal);

                    if (type == "File")
                    {

                        //change file dates if date time picker for creation date is enabled
                        if (dtp_creationdate.Enabled)
                            File.SetCreationTime(filename, dtp_creationdate.Value);

                        //change modified time if date time picker for modified time is enabled
                        if (dtp_modifieddate.Enabled)
                            File.SetLastWriteTime(filename, dtp_modifieddate.Value);

                        //change last accessed date if datetime picker for last accessed date is enabled
                        if (dtp_accesseddate.Enabled)
                            File.SetLastAccessTime(filename, dtp_accesseddate.Value);

                        ChangeFileAttributes(filename);//pass filename as parameter to change its attributes
                    }

                        //if Changes to all is enabled and type is directory then all the 
                    //files and folders in the directory will have the same attributes
                    else if (rbtn_changestoall.Checked == true && type == "Directory")
                    {
                        //create an instance of DirectoryInfo to
                        //get information about the directory
                        DirectoryInfo di = new DirectoryInfo(filename);

                        //get all the files in the directory with searchoption as search all subdirectories within
                        foreach (FileInfo files in di.GetFiles("*.*", SearchOption.AllDirectories))
                        {
                            File.SetAttributes(files.FullName, FileAttributes.Normal);

                            //change file dates if date time picker for creation date is enabled
                            if (dtp_creationdate.Enabled)
                                File.SetCreationTime(files.FullName, dtp_creationdate.Value);

                            if (dtp_modifieddate.Enabled)
                                File.SetLastWriteTime(files.FullName, dtp_modifieddate.Value);

                            if (dtp_accesseddate.Enabled)
                                File.SetLastAccessTime(files.FullName, dtp_accesseddate.Value);

                            //pass the full path of file as a parameter to change its attributes
                            ChangeFileAttributes(files.FullName);
                        }

                        //get all the directories in the current directory as search all directories inside
                        foreach (DirectoryInfo dinfo in di.GetDirectories("*.*", SearchOption.AllDirectories))
                        {
                            File.SetAttributes(dinfo.FullName, FileAttributes.Normal);
                            //change creation date of directory if creation date is to be changed
                            if (dtp_creationdate.Enabled)
                                Directory.SetCreationTime(dinfo.FullName, dtp_creationdate.Value);

                            if (dtp_modifieddate.Enabled)
                                Directory.SetLastWriteTime(dinfo.FullName, dtp_modifieddate.Value);

                            if (dtp_accesseddate.Enabled)
                                Directory.SetLastAccessTime(dinfo.FullName, dtp_accesseddate.Value);

                            ChangeFileAttributes(dinfo.FullName);
                        }

                        //change attribute of the directory also
                        if (dtp_creationdate.Enabled)
                            Directory.SetCreationTime(di.FullName, dtp_creationdate.Value);

                        if (dtp_modifieddate.Enabled)
                            Directory.SetLastWriteTime(di.FullName, dtp_modifieddate.Value);

                        if (dtp_accesseddate.Enabled)
                            Directory.SetLastAccessTime(di.FullName, dtp_accesseddate.Value);

                        ChangeFileAttributes(di.FullName);
                    }

                        //if only the attributes of the directory in the datagridview is to be changed
                    //and NOT its subdirectories and files
                    else if (rbtn_folderonly.Checked == true && type == "Directory")
                    {
                        if (dtp_creationdate.Enabled)
                            Directory.SetCreationTime(filename, dtp_creationdate.Value);

                        if (dtp_modifieddate.Enabled)
                            Directory.SetLastWriteTime(filename, dtp_modifieddate.Value);

                        if (dtp_accesseddate.Enabled)
                            Directory.SetLastAccessTime(filename, dtp_accesseddate.Value);
                        ChangeFileAttributes(filename);
                    }
                }
                catch (IOException fileloaderror)
                {
                    MessageBox.Show(fileloaderror.Message);
                }

                catch (Exception othererror)
                {
                    MessageBox.Show(othererror.Message);
                }
            }
        }

        //clear the checkboxes so that current file or folder will not show attributes of previous one
        private void clearCheckBox()
        {
            //since the groupbox contains only checkboxes, hence their checked status can be removed
            foreach (CheckBox cbx in gbx_attributes.Controls)
            {
                if (cbx.Checked == true)
                {
                    cbx.Checked = false;
                }
            }
            chk_ChangeCreatedDate.Checked = false;
            chk_ChangeModifiedDate.Checked = false;
            chk_ChangeAccessedDate.Checked = false;
        }

        //AddFiles To DatagridView
        private void btn_AddFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true; //Allow multiselection of files
            ofd.ShowDialog();
            //If many files are selected, then all of them will be added to datagridview
                foreach (string file in ofd.FileNames)
                {
                    dr = dt.NewRow();
                    FileInfo fi = new FileInfo(file);
                    dr[0] = fi.Name;
                    dr[1] = "File";
                    dr[2] = file;//Filename will be shown in the first column of all rows
                    dt.Rows.Add(dr);
                    dgv_filescollection.DataSource = dt;
                    dgv_filescollection.Focus();
                }            
        }

        //Remove all files from DataGridView
        private void btn_clear_Click(object sender, EventArgs e)
        {
            filename.Remove(0); //since string file is static, it will remove any character in file
            dt.Clear(); //clear the datatable
            dgv_filescollection.DataSource = null; //set the datagridview source to null
            clearCheckBox(); //remove checked status from all the checkboxes
        }        

        //Function to check file attributes
        private void checkattribs(string currentfile,string type)
        {
            try
            {
                String attributes = "";
                if (type == "File")
                {
                    //Get Dates of file
                    //Show File creation,modified,lastaccess date in datetimepicker 
                    dtp_creationdate.Value = File.GetCreationTime(currentfile);
                    dtp_modifieddate.Value = File.GetLastWriteTime(currentfile);
                    dtp_accesseddate.Value = File.GetLastAccessTime(currentfile);
                    attributes = File.GetAttributes(currentfile).ToString();
                }

                else if (type == "Directory")
                {
                    DirectoryInfo di = new DirectoryInfo(currentfile);
                    dtp_creationdate.Value = di.CreationTime;
                    dtp_modifieddate.Value = di.LastWriteTime;
                    dtp_accesseddate.Value = di.LastAccessTime;
                    attributes = di.Attributes.ToString();
                }

                //The File.GetAttributes method retrieves all the attributes of file
                if (attributes.Contains("Archive") == true)
                {
                    chk_archive.CheckState = CheckState.Checked;
                }
                if (attributes.Contains("Compressed"))
                {
                    chk_compressed.Checked = true;
                }
                if (attributes.Contains("Encrypted"))
                {
                    chk_encrypted.Checked = true;
                }
                if (attributes.Contains("Hidden"))
                {
                    chk_hidden.Checked = true;
                }
                if (attributes.Contains("ReadOnly"))
                {
                    chk_readonly.Checked = true;
                }
                if (attributes.Contains("System"))
                {
                    chk_system.Checked = true;
                }
            }
            catch (IOException fileloaderror)
            {
                MessageBox.Show(fileloaderror.Message);
            }
            catch (Exception othererrors)
            {
                MessageBox.Show(othererrors.Message);
            }
        }

        //if current row changes then the file name will be changed
        private void dgv_filescollection_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //The File name will be used to retrieve its attributes
            filename = dgv_filescollection.Rows[e.RowIndex].Cells[2].Value.ToString();
            string gettype = dgv_filescollection.Rows[e.RowIndex].Cells[1].Value.ToString();
            clearCheckBox(); //checkboxes are unchecked everytime row is changed
            checkattribs(filename,gettype); //name is passed on to check its attributes           
        }

        //On Clicking Checkbox related to Create date, datetimepicker will be enabled
        private void chk_ChangeCreatedDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_ChangeCreatedDate.Checked == true)
                dtp_creationdate.Enabled = true;
            else
                dtp_creationdate.Enabled = false;
        }

        //When checkbox corresponding to change modified date is checked, datetimepicker will be enabled
        private void chk_ChangeModifiedDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_ChangeModifiedDate.Checked)
                dtp_modifieddate.Enabled = true;
            else
                dtp_modifieddate.Enabled = false;
        }

        //When checkbox corresponding to change accessed date is checked, datetimepicker will be enabled        
        private void chk_ChangeAccessedDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_ChangeAccessedDate.Checked)
                dtp_accesseddate.Enabled = true;
            else
                dtp_accesseddate.Enabled = false;
        }

        //add a folder to datagridview
        private void btn_addfolder_Click(object sender, EventArgs e)
        {
            //show folder browser dialog
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;
            fbd.ShowDialog();

            //if folder browser dialog box path is not empty
            if (fbd.SelectedPath != "")
            {
                if (Directory.Exists(fbd.SelectedPath))
                {
                    DirectoryInfo di = new DirectoryInfo(fbd.SelectedPath);
                    dr = dt.NewRow();
                    dr[0] = di.Name;
                    dr[1] = "Directory";
                    dr[2] = di.FullName;
                    dt.Rows.Add(dr);
                    dgv_filescollection.DataSource = dt;
                    dgv_filescollection.Focus();//set focus to datagridview so that you can remove files/folders just by pressing "delete" 
                }
            }
        }

        private void FileAttributeChanger_DragOver(object sender, DragEventArgs e)
        {
            //on dragging a file or folder over form, show drageffects of copy operation
            e.Effect = DragDropEffects.Copy;
            this.AllowDrop = true;
        }

        private void FileAttributeChanger_DragDrop(object sender, DragEventArgs e)
        {                  
            //get all filenames and store them in string array
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string file in FileList)
            {
                    if (File.GetAttributes(file).ToString().Contains("Directory"))
                    {
                        DirectoryInfo di = new DirectoryInfo(file);
                        dr = dt.NewRow();
                        dr[0] = di.Name;
                        dr[1] = "Directory";
                        dr[2] = di.FullName;
                        dt.Rows.Add(dr);                        
                    }

                    else
                    {
                        dr = dt.NewRow();
                        FileInfo fi = new FileInfo(file);
                        dr[0] = fi.Name;
                        dr[1] = "File";
                        dr[2] = file;//Filename will be shown in the first column of all rows
                        dt.Rows.Add(dr);
                    }
            }
            dgv_filescollection.DataSource = dt;
            dgv_filescollection.Focus();
        }


        private void ChangeFileAttributes(string fname)
        {            
            //File class is also able to change attributes of Directory ;)
            //if Archive is checked, then its attribute will be set to archive
            if (chk_archive.Checked == true && File.GetAttributes(fname).ToString().Contains("Archive") == false)
                File.SetAttributes(fname, File.GetAttributes(fname) | FileAttributes.Archive);// Archive attribute will be added to its existing attributes

            //if unchecked, then Archive attribute will be removed
            //To remove attribute a tilde(~) is appended before the FileAttributes enum
            else if (chk_archive.Checked == false && File.GetAttributes(fname).ToString().Contains("Archive"))
                File.SetAttributes(fname, File.GetAttributes(fname) & ~FileAttributes.Archive);

            //set or unset attribute of file or folder to be hidden
            if (chk_hidden.Checked == true && File.GetAttributes(fname).ToString().Contains("Hidden") == false)
                File.SetAttributes(fname, File.GetAttributes(fname) | FileAttributes.Hidden);
            else if (chk_hidden.Checked == false && File.GetAttributes(fname).ToString().Contains("Hidden"))
                File.SetAttributes(fname, File.GetAttributes(fname) & ~FileAttributes.Hidden);

            //set or unset attribute as system
            if (chk_system.Checked == true && File.GetAttributes(fname).ToString().Contains("System") == false)
                File.SetAttributes(fname, File.GetAttributes(fname) | FileAttributes.System);
            else if (chk_system.Checked == false && File.GetAttributes(fname).ToString().Contains("System"))
                File.SetAttributes(fname, File.GetAttributes(fname) & ~FileAttributes.System);

            //set attribute to readonly
            if (chk_readonly.Checked == true && File.GetAttributes(fname).ToString().Contains("ReadOnly") == false)
                File.SetAttributes(fname, File.GetAttributes(fname) | FileAttributes.ReadOnly);
            else if (chk_readonly.Checked == false && File.GetAttributes(fname).ToString().Contains("ReadOnly"))
                File.SetAttributes(fname, File.GetAttributes(fname) & ~FileAttributes.ReadOnly);
        }
    }
}