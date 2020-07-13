using System;
using System.ComponentModel;
using System.Data;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Xml;
using System.Diagnostics;
using System.Timers;
using System.Drawing;

namespace AttribChanger
{
    public partial class FileAttributeChanger : Form
    {
        //Initializing new instance of DataTable
        DataTable dt = new DataTable();
        DataRow dr;
        string filename = "";
        string message = "";
        bool updating = false;
        IniFile Auroraini = new IniFile(Environment.GetEnvironmentVariable("Windir") + "\\alamode.ini");


        public FileAttributeChanger()
        {
            SetStyle(ControlStyles.ResizeRedraw, true);
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));

            try
            {
                if (!Directory.Exists(Environment.GetEnvironmentVariable("ProgramData") + "\\alamode\\Common\\logs"))
                {

                    Directory.CreateDirectory(Environment.GetEnvironmentVariable("ProgramData") + "\\alamode\\Common\\logs");

                }
            }
            catch (IOException ioex)
            {
                Console.WriteLine(ioex.Message);
            }

            

            InitializeComponent();
            //Adding a new column name that will show file names
            dt.Columns.Add(new DataColumn("Description", typeof(string)));
            dt.Columns.Add(new DataColumn("Type", typeof(string)));              
            dt.Columns.Add(new DataColumn("Path", typeof(string)));
            dt.Columns.Add(new DataColumn("Owner", typeof(string)));
            dgv_filescollection.RowHeadersWidth = 28; //Setwidth of the RowHeaders Column (first column)

            try
            { //log start of application
                File.AppendAllText(Environment.GetEnvironmentVariable("ProgramData") + "\\alamode\\Common\\logs" + "\\Permissions.Check.log", DateTime.Now + " [I]: File Attribute Tool started " + Environment.NewLine);
            }
            catch (SystemException huh)
            {
                MessageBox.Show(huh.Message);
            }
            loadFolders();
            AddFiles();
            SetProgressText("Ready");
            myTimer.Start();
            
        }

        //Try to set Gradient background
        private Color _Color1 = Color.Silver;
        private Color _Color2 = Color.LightCyan;
        private float _ColorAngle = 45f;

        public Color Color1
        {
            get { return _Color1; }
            set
            {
                _Color1 = value;
                Invalidate(); // Tell the Form to repaint itself
            }
        }

        public Color Color2
        {
            get { return _Color2; }
            set
            {
                _Color2 = value;
                Invalidate(); // Tell the Form to repaint itself
            }
        }

        public float ColorAngle
        {
            get { return _ColorAngle; }
            set
            {
                _ColorAngle = value;
                Invalidate(); // Tell the Form to repaint itself
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // Getting the graphics object
            Graphics g = pevent.Graphics;

            // Creating the rectangle for the gradient
            Rectangle rBackground = new Rectangle(0, 0,
                                      Width, Height);

            // Creating the lineargradient
            System.Drawing.Drawing2D.LinearGradientBrush bBackground
                = new System.Drawing.Drawing2D.LinearGradientBrush(rBackground,
                                                  _Color1, _Color2, _ColorAngle);

            // Draw the gradient onto the form
            g.FillRectangle(bBackground, rBackground);

            // Disposing of the resources held by the brush
            bBackground.Dispose();
        }

        // End Gradient stuff


        public void DisplayTimeEvent(object source, ElapsedEventArgs e)
       {
            message += " .";
            SetProgressText(message); 
       }


    //Code to run on clicking ChangeAttributes 
    private void btn_ChangeAttribs_Click(object sender, EventArgs e)
        {
            // Cursor info from https://www.c-sharpcorner.com/UploadFile/mahesh/cursors-in-C-Sharp/
            Cursor cur = Cursors.WaitCursor; //Set wait cursor to indicat application is working
            Cursor = cur;
            if (updating == true)
            {
                MessageBox.Show("Please wait for current process to finish");
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            message = "Validating the files, Please Wait . . .";
            SetProgressText(message);
            try
            { //log start of application
                File.AppendAllText(Environment.GetEnvironmentVariable("ProgramData") + "\\alamode\\Common\\logs" + "\\Permissions.Check.log", DateTime.Now + " [I]: Beginning the File Verification and update process " + Environment.NewLine);
            }
            catch (SystemException huh)
            {
                Cursor = Cursors.Default; //Return Cursor to normal
                MessageBox.Show(huh.ToString()); //Display error if writing to the Common Logs folder fails
            }

            SetControlState(false);

            backgroundWorker1.RunWorkerAsync(); //Run the update process in a seperate thread
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        { }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {  
            update();
        }


        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetControlState(true);
            Cursor = Cursors.Default; //Return Cursor to normal
        }

		private void SetControlState(bool enabled)
		{
			foreach (Control control in Controls)
			{
				if (control.Name != groupBox1.Name)
					control.Enabled = enabled;

			}
		}

        public void update()
        {
            updating = true;
            Application.DoEvents();
            Application.EnableVisualStyles();
            string type ="";
            foreach (DataGridViewRow dgvr in dgv_filescollection.SelectedRows)
            {
                
                try
                {
                    //Get Current file name in the datagridview
                    filename = dgvr.Cells[2].Value.ToString();
                    type = dgvr.Cells[1].Value.ToString();
                    message = "Validating: " + filename; 
                    SetProgressText(message);
                    try
                    { //log start of application
                        File.AppendAllText(Environment.GetEnvironmentVariable("ProgramData") + "\\alamode\\Common\\logs" + "\\Permissions.Check.log", DateTime.Now + " [I]: Processing: " + filename + Environment.NewLine);
                    }
                    catch (SystemException huh)
                    {
                        MessageBox.Show(huh.ToString());
                    }


                    //Reset File Attributes so that new attributes can be set
                    //This is required because file attributes cannot be changed if it is read-only
                    File.SetAttributes(filename, FileAttributes.Normal);

                    if (type == "File")
                    {
                        message = "Validating: " + filename;
                        SetProgressText(message);
                        ChangeFileAttributes(filename);//pass filename as parameter to change its attributes
                        if (CuserFP.Checked == true)
                        {
                            message = "Validating \"User\" Permission on " + filename;
                            SetProgressText(message);
                            SetFullFilePermissions(filename, System.Security.Principal.WindowsIdentity.GetCurrent().Name);
                        }
                        if (AdminUserFP.Checked == true)
                        {
                            message = "Validating \"Administrator\" Permission on " + filename;
                            SetProgressText(message);
                            SetFullFilePermissions(filename, "Administrators");
                        }
                        if (AuthuserFP.Checked == true)
                        {
                            message = "Validating \"Authenticated User\" Permission on " + filename;
                            SetProgressText(message);
                            SetFullFilePermissions(filename, "Authenticated users");
                        }
                    }

                        
                    //if Changes to all is enabled and type is directory then all the 
                    //files and folders in the directory will have the same attributes
                    else if (rbtn_changestoall.Checked == true && type == "Directory")
                    {
                        //create an instance of DirectoryInfo to
                        //get information about the directory
                        DirectoryInfo di = new DirectoryInfo(filename);

                        //Update current selected Directory
                        try
                        { //log start of application
                            File.AppendAllText(Environment.GetEnvironmentVariable("ProgramData") + "\\alamode\\Common\\logs" + "\\Permissions.Check.log", DateTime.Now + " [I]: Processing: " + filename + Environment.NewLine);
                        }
                        catch (SystemException huh)
                        {
                            MessageBox.Show(huh.ToString());
                        }
                        message = "Validating: " + filename;
                        SetProgressText(message);
                        File.SetAttributes(filename, FileAttributes.Normal);
                        ChangeFileAttributes(filename);
                        if (CuserFP.Checked == true)
                        {
                            message = "Validating \"User\" Permission on " + filename;
                            SetProgressText(message);
                            SetFullAccessPermission(filename, System.Security.Principal.WindowsIdentity.GetCurrent().Name);
                        }
                        if (AdminUserFP.Checked == true)
                        {
                            message = "Validating \"Administrators\" Permission on " + filename;
                            SetProgressText(message);
                            SetFullAccessPermission(filename, "Administrators");
                        }
                        if (AuthuserFP.Checked == true)
                        {
                            message = "Validating \"Authenticated users\" Permission on " + filename;
                            SetProgressText(message);
                            SetFullAccessPermission(filename, "Authenticated users");
                        }


                        //get all the directories in the current directory as search all directories inside
                        foreach (DirectoryInfo dinfo in di.GetDirectories("*.*", SearchOption.AllDirectories))
                        {

                            try
                            { //log start of application
                                File.AppendAllText(Environment.GetEnvironmentVariable("ProgramData") + "\\alamode\\Common\\logs" + "\\Permissions.Check.log", DateTime.Now + " [I]: Processing: " + dinfo.FullName + Environment.NewLine);
                            }
                            catch (SystemException huh)
                            {
                                MessageBox.Show(huh.Message);
                            }
                            message = "Validating: " + dinfo.FullName;
                            SetProgressText(message);
                            File.SetAttributes(dinfo.FullName, FileAttributes.Normal);
                            ChangeFileAttributes(dinfo.FullName);
                            if (CuserFP.Checked == true)
                            {
                                message = "Validating \"User\" Permission on " + dinfo.FullName;
                                SetProgressText(message);
                                SetFullAccessPermission(dinfo.FullName, System.Security.Principal.WindowsIdentity.GetCurrent().Name);
                            }
                            if (AdminUserFP.Checked == true)
                            {
                                message = "Validating \"Administrators\" Permission on " + dinfo.FullName;
                                SetProgressText(message);
                                SetFullAccessPermission(dinfo.FullName, "Administrators");
                            }
                            if (AuthuserFP.Checked == true)
                            {
                                message = "Validating \"Authenticated users\" Permission on " + dinfo.FullName;
                                SetProgressText(message);
                                SetFullAccessPermission(dinfo.FullName, "Authenticated users");
                            }
                        }

                        //get all the files in the directory with search option as search all subdirectories within
                        foreach (FileInfo files in di.GetFiles("*.*", SearchOption.AllDirectories))
                        {

                            message = "Validating: " + files;
                            SetProgressText(message);
                            File.SetAttributes(files.FullName, FileAttributes.Normal);

                            //pass the full path of file as a parameter to change its attributes
                            ChangeFileAttributes(files.FullName);
                            if (CuserFP.Checked == true)
                                SetFullFilePermissions(files.FullName, System.Security.Principal.WindowsIdentity.GetCurrent().Name);
                            if (AdminUserFP.Checked == true)
                                SetFullFilePermissions(files.FullName, "Administrators");
                            if (AuthuserFP.Checked == true)
                                SetFullFilePermissions(files.FullName, "Authenticated users");
                        }

                        //change attribute of the directory also

                        message = "Validating: " + di.FullName;
                        SetProgressText(message);
                        ChangeFileAttributes(di.FullName);
                    }

                        //if only the attributes of the directory in the datagridview is to be changed
                    //and NOT its subdirectories and files
                    else if (rbtn_folderonly.Checked == true && type == "Directory")
                    {

                        message = "Validating: " + filename;
                        SetProgressText(message);
                        ChangeFileAttributes(filename);
                    }
                }
                catch (IOException fileloaderror)
                {
                    MessageBox.Show(fileloaderror.Message);
                    string excepType = fileloaderror.GetType().ToString();
                    string excepMessage = fileloaderror.Message;
                    LogError(" [E]: ", excepType, "occurred while attempting to set the permissions of", filename, excepMessage);
                }

                catch (Exception othererror)
                {
                    MessageBox.Show(othererror.Message);
                    string excepType = othererror.GetType().ToString();
                    string excepMessage = othererror.Message;
                    LogError(" [E]: ", excepType, "occurred while attempting to set the permissions of", filename, excepMessage);
                }
            }

            message = "Updating Settings Complete";
            SetProgressText(message);
            updating = false;
            

            try
            { //log start of application
                File.AppendAllText(Environment.GetEnvironmentVariable("ProgramData") + "\\alamode\\Common\\logs" + "\\Permissions.Check.log", DateTime.Now + " [I]: Processing Complete" + Environment.NewLine);
            }
            catch (SystemException huh)
            {
                MessageBox.Show(huh.ToString());
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
                cbx.Enabled = false;
            }
            CuserFP.Checked = false;
            AuthuserFP.Checked = false;
            AdminUserFP.Checked = false;
            CuserFP.Enabled = true;
            AuthuserFP.Enabled = true;
            AdminUserFP.Enabled = true;
            message = "Ready";
            SetProgressText(message);
        }

        //AddFiles To DatagridView
        private void AddFiles()
        {
            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Multiselect = true; //Allow multiselection of files
            //ofd.ShowDialog();
            //If many files are selected, then all of them will be added to datagridview
            string[] files = new string[5];
            files[0] = "Local settings" + "," + Environment.GetEnvironmentVariable("ProgramData") + "\\alamode\\alamode.xml";
            files[1] = "Aurora settings" + "," + Environment.GetEnvironmentVariable("Windir") + "\\alamode.ini";
            files[2] = "TOTAL Connect" + "," + Environment.GetEnvironmentVariable("ProgramData") + "\\alamode\\Mercury\\appsettings.xml";
            files[3] = "Delivery Plugins" + "," + Environment.GetEnvironmentVariable("ProgramData") + "\\alamode\\Mercury\\AvailablePlugins.xml";
            files[4] = "Dynamic Settings" + "," + Environment.GetEnvironmentVariable("Windir") + "\\alaredun.ini";

            foreach (string each in files)
            {
                string[] file = new string[2];
                file = each.Split(',');
                File.AppendAllText(Environment.GetEnvironmentVariable("ProgramData") + "\\alamode\\Common\\logs" + "\\Permissions.Check.log", DateTime.Now + " [I]: Loading " + file[0] + " " + file[1] + Environment.NewLine);

                //if this file exists, add it to the list
                if (File.Exists(file[1]))
                {

                    var fs = System.IO.File.GetAccessControl(file[1]);
                    var sid = fs.GetOwner(typeof(SecurityIdentifier));
                    var ntAccount = sid.Translate(typeof(NTAccount));

                    dr = dt.NewRow();
                    dr[0] = file[0];
                    dr[1] = "File";
                    dr[2] = file[1];//Filename will be shown in the first column of all rows
                    dr[3] = ntAccount;
                    dt.Rows.Add(dr);
                    dgv_filescollection.DataSource = dt;
                    dgv_filescollection.Focus();
                }
            }
                         
        }

        //Function to check file attributes
        private void checkattribs(string currentfile,string type)
        {
            try
            {
                string attributes = "";
                string permissions = "";
                string filtered = "";
                string curUser = Environment.GetEnvironmentVariable("USERNAME");
                string curUser2 = curUser.ToLower();

                DirectorySecurity folderSecurity = Directory.GetAccessControl(currentfile);
                foreach (FileSystemAccessRule fileSystemAccessRule in folderSecurity.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount)))
                {

                    string userName = fileSystemAccessRule.IdentityReference.Value;
                    string userRights = fileSystemAccessRule.FileSystemRights.ToString();
                    permissions += userName + ": " + userRights + ", ";
                    

                    if (type == "File")
                {
                    //Get Dates of file
                    //Show File creation,modified,lastaccess date in datetimepicker 

                    attributes = File.GetAttributes(currentfile).ToString();
                    //File.GetAccessControl;
                }

                else if (type == "Directory")
                {
                    DirectoryInfo di = new DirectoryInfo(currentfile);

                    attributes = di.Attributes.ToString();               
                    }

                    //MessageBox.Show(permissions);
                }

                //The File.GetAttributes method retrieves all the attributes of file
                var fs = System.IO.File.GetAccessControl(currentfile);
                var sid = fs.GetOwner(typeof(SecurityIdentifier));
                var ntAccount = sid.Translate(typeof(NTAccount));
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
                    chk_hidden.Enabled = true;
                }
                if (attributes.Contains("ReadOnly"))
                {
                    chk_readonly.Checked = true;
                    chk_readonly.Enabled = true;
                }
                if (attributes.Contains("System"))
                {
                    chk_system.Checked = true;
                    chk_system.Enabled = true;
                }
                if (permissions.Contains("Authenticated Users: FullControl") == true)
                {
                    AuthuserFP.Checked = true;
                    AuthuserFP.Enabled = false;
                }
                if (permissions.Contains("Administrators: FullControl") == true)
                {
                    AdminUserFP.Checked = true;
                    AdminUserFP.Enabled = false;
                }
                if (permissions.Contains(curUser +": FullControl") == true)
                {
                    CuserFP.Checked = true;
                    CuserFP.Enabled = false;
                }
                if (permissions.Contains(curUser2 + ": FullControl") == true)
                {
                    CuserFP.Checked = true;
                    CuserFP.Enabled = false;
                }
                //MessageBox.Show(permissions);
               filtered = permissions.Replace(",", Environment.NewLine +"      ");
                File.AppendAllText(Environment.GetEnvironmentVariable("ProgramData") + "\\alamode\\Common\\logs" + "\\Permissions.Check.log", DateTime.Now + " [I]: Loading Permissions for " + currentfile + ":" + Environment.NewLine + "     {" + Environment.NewLine + "    Current Owner:" + Environment.NewLine + "       " + ntAccount + Environment.NewLine + Environment.NewLine +  "    Current Permisions:" + Environment.NewLine + "       " + filtered + Environment.NewLine + Environment.NewLine + "    Currently Set Attributes:" + Environment.NewLine + "       " + attributes + Environment.NewLine + "     }" + Environment.NewLine + Environment.NewLine);

            }
            catch (IOException fileloaderror)
            {
                MessageBox.Show(fileloaderror.Message);
                string excepType = fileloaderror.GetType().ToString();
                string excepMessage = fileloaderror.Message;
                LogError(" [E]: ", excepType, "occurred while attempting to set the permissions of", currentfile, excepMessage);
            }
            catch (Exception othererrors)
            {
                MessageBox.Show(othererrors.Message);
                string excepType = othererrors.GetType().ToString();
                string excepMessage = othererrors.Message;
                LogError(" [E]: ", excepType, "occurred while attempting to set the permissions of", currentfile, excepMessage);
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

        string getpath(string name)
        {
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(Environment.GetEnvironmentVariable("ProgramData") + "\\alamode\\alamode.xml"); //Load alamode.xml
                XmlNode path = xml.SelectSingleNode(name);
                return path.InnerText;
            }
            catch
            {
                return null; //If a node does not exists, skip it and move on
             }
        }

        string getwt6datapath()
        {
            if (File.Exists(getpath("//SETTINGS/WINTOTAL/PROGRAMDIR") + "\\netsettings.xml")) //If Netsettings.xml exists
                try
                {

                    XmlDocument xml = new XmlDocument();
                    xml.Load(getpath("//SETTINGS/WINTOTAL/PROGRAMDIR") + "\\netsettings.xml"); //Load netsettings.xml
                    XmlNode Appsettings = xml.SelectSingleNode("//SETTINGS/WINTOTAL/GENERAL/DATAPATHS/BASEDIR"); //Load Data dir path
                    //MessageBox.Show("Appsettings.xml = " + Appsettings.InnerText.ToString());
                    //XmlDocument xml2 = new XmlDocument(); //create new memory location for appsettings.xml
                    //xml2.Load(Appsettings.InnerText + "\\AppSettings.xml"); //Load appsettings.xml 
                    //XmlNode path = xml2.SelectSingleNode(name); //Process node passed tostring name
                    return Appsettings.InnerText; // Return the resulting path
                }
                catch (System.Exception)
                {
                    //MessageBox.Show(othererrors.ToString());
                    return null; //If a node does not exists, skip it and move on
                }
            else
            {
               return null; //If a node does not exists, skip it and move on
            }
        }


        string getwt6paths(string name)
        {
            if (File.Exists(getpath("//SETTINGS/WINTOTAL/PROGRAMDIR") + "\\netsettings.xml")) //If Netsettings.xml exists
                try
            {

               XmlDocument xml = new XmlDocument();
               xml.Load(getpath("//SETTINGS/WINTOTAL/PROGRAMDIR") + "\\netsettings.xml"); //Load netsettings.xml
               XmlNode Appsettings = xml.SelectSingleNode("//SETTINGS/WINTOTAL/GENERAL/DATAPATHS/DATADIR"); //Load Data dir path
                    //MessageBox.Show("Appsettings.xml = " + Appsettings.InnerText.ToString());
                    XmlDocument xml2 = new XmlDocument(); //create new memory location for appsettings.xml
                    xml2.Load(Appsettings.InnerText + "\\AppSettings.xml"); //Load appsettings.xml 
                    XmlNode path = xml2.SelectSingleNode(name); //Process node passed tostring name
                    return path.InnerText; // Return the resulting path
            }
            catch (System.Exception)
               {
                    //MessageBox.Show(othererrors.ToString());
                    return null; //If a node does not exists, skip it and move on
            }
            else
            {
                try
                {
                    string Appsettings = Environment.GetEnvironmentVariable("ProgramData") + "\\alamode\\WINTOTAL";
                    XmlDocument xml2 = new XmlDocument(); //create new memory location for appsettings.xml
                    xml2.Load(Appsettings + "\\AppSettings.xml"); //Load appsettings.xml 
                    XmlNode path = xml2.SelectSingleNode(name); //Process node passed tostring name
                    return path.InnerText; // Return the resulting path
                }
                catch (System.Exception)
                {
                    //MessageBox.Show(othererrors.ToString());
                    return null; //If a node does not exists, skip it and move on
                }
            }
        }

        //add a folder to datagridview
        //Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) 
        private void loadFolders()
        {
            string[] pathes = new string[24];
            //pathes[0] = "Machine Settings" + "," + Environment.GetEnvironmentVariable("PROGRAMFILES") + "\\a la mode";
            //pathes[1] = "Program Files" + "," + Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\a la mode";

            //Local Settings is %userprofile%\appdata\local\alamode
            pathes[0] = "Local settings" + "," + Environment.GetEnvironmentVariable("LOCALAPPDATA") + "\\alamode";
            pathes[1] = "Local Data" + "," + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\a la mode";
            // Network settings is the path on a server install the TOTAL Data share is located
            pathes[2] = "Network settings" + "," + getwt6datapath();
            // Program Data is C:\proramdata\alamode
            pathes[3] = "Program Data" + "," + Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\alamode";
            // Program files is C:\program files\a la mode on an x86 machine and C:\program files (x86)\a la mode on an x64 machine
            // if (Directory.Exists(Environment.ExpandEnvironmentVariables("%HomeDrive%") + "\\Program files\\a la mode"))
            //    pathes[3] = "Program Files" + "," + Environment.ExpandEnvironmentVariables("%HomeDrive%") + "\\Program files\\a la mode";
            if (Directory.Exists(Environment.ExpandEnvironmentVariables("%HomeDrive%") + "\\Program files (x86)\\a la mode"))
                pathes[4] = "Program Files (x86)" + "," + Environment.ExpandEnvironmentVariables("%HomeDrive%") + "\\Program files (x86)\\a la mode";
            else
                pathes[4] = "Program Files" + "," + Environment.ExpandEnvironmentVariables("%Programfiles%") + "\\a la mode";
            // Get the TOTAL Connect Program Dir if TOTAL Connect is installed
            pathes[5] = "TOTAL Connect" + "," + getpath("//SETTINGS/MERCURY/PROGRAMDIR");
            // Get the TOTAL Sketch program dire if TOTAL Sketch is installed
            pathes[6] = "TOTAL Sketch" + "," + getpath("//SETTINGS/DAVINCI/PROGRAMDIR");
            // Get the Vault program directory if Vault is installed
            pathes[7] = "Vault" + "," + Auroraini.ReadSetting("a la mode File Vault", "ProgDir", 64, "");
            // Get the Esched (a la mode assistant) directory if installed 
            pathes[8] = "Assistant" + "," + Auroraini.ReadSetting("a la mode Scheduler", "ProgDir", 64, "");
            // Get the SureDocs program dir if installed 
            pathes[9] = "SureDocs" + "," + getpath("//SETTINGS/SUREDOCS/PROGRAMDIR");
            // get the Mileage Estimator dir if installed 
            pathes[10] = "Mileage Estimator" + "," + getpath("//SETTINGS/MILEAGEESTIMATOR/PROGRAMDIR");
            // Get UAD Reader path if installed 
            pathes[11] = "UAD Reader" + "," + getpath("//SETTINGS/UADREADER/PROGRAMDIR");
            // get Mobile Sync path if installed 
            pathes[12] = "Mobile Sync" + "," + getpath("//SETTINGS/TOTALMOBILESYNC/PROGRAMDIR");
            // Get the path to the customers current %temp% path 
            pathes[13] = "Temp" + "," + Environment.GetEnvironmentVariable("TEMP");
            // Get the last path used by the customer to export xml files 
            pathes[14] = "PDF\\XML" + "," + getpath("//SETTINGS/DATACOURIER/DEFAULTEXPORTPATH");
            // Get the path to the SQL folder (root not instance)  old method: pathes[22] = "SQL" + "," + Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Microsoft SQL Server";
            if (Directory.Exists(Environment.ExpandEnvironmentVariables("%HomeDrive%") + "\\Program files (x86)\\Microsoft SQL Server"))
                pathes[15] = "SQL" + "," + Environment.ExpandEnvironmentVariables("%HomeDrive%") + "\\Program files (x86)\\Microsoft SQL Server";
            else if (Directory.Exists(Environment.ExpandEnvironmentVariables("%HomeDrive%") + "\\Program files\\Microsoft SQL Server"))
                pathes[15] = "SQL" + "," + Environment.ExpandEnvironmentVariables("%HomeDrive%") + "\\Program files\\Microsoft SQL Server";
            else
                pathes[15] = "SQL" + "," + Environment.ExpandEnvironmentVariables("%Programfiles%") + "\\Microsoft SQL Server";
            // TOTAL Section
            pathes[16] = "TOTAL" + "," + getpath("//SETTINGS/WINTOTAL/PROGRAMDIR");
            // Process to handle both standalone and Server settings for TOTAL Images, Folders, Thumbs
            // Get My Reports Path
            pathes[17] = "My Reports" + "," + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\a la mode\\reports";
            // Get Shared Reports path
            if (Directory.Exists(getwt6paths("//SETTINGS/WINTOTAL/GENERAL/DATAPATHS/REPORTSPATH")))
                pathes[18] = "Shared Reports" + "," + getwt6paths("//SETTINGS/WINTOTAL/GENERAL/DATAPATHS/REPORTSPATH");
            else
                pathes[18] = "Shared Reports" + "," + Environment.GetEnvironmentVariable("PUBLIC") + "\\Documents\\a la mode\\Reports";
            // Get Images path
            if (Directory.Exists(getwt6paths("//SETTINGS/WINTOTAL/GENERAL/DATAPATHS/IMAGESPATH")))
                pathes[19] = "TOTAL Images" + "," + getwt6paths("//SETTINGS/WINTOTAL/GENERAL/DATAPATHS/IMAGESPATH");
            else if (Directory.Exists(getwt6datapath() + "\\Data\\WinTOTAL\\QuickPix\\Images"))
                pathes[19] = "TOTAL Images" + "," + getwt6datapath() + "\\Data\\WinTOTAL\\QuickPix\\Images";
            else
                pathes[19] = "TOTAL Images" + "," + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\a la mode\\Database\\Images";
            //Get thumbs path
            if (Directory.Exists(getwt6paths("//SETTINGS/WINTOTAL/GENERAL/DATAPATHS/THUMBSPATH")))
                pathes[20] = "TOTAL Thumbs" + "," + getwt6paths("//SETTINGS/WINTOTAL/GENERAL/DATAPATHS/THUMBSPATH");
            else if (Directory.Exists(getwt6datapath() + "\\Data\\WinTOTAL\\QuickPix\\Thumbs"))
                pathes[20] = "TOTAL Thumbs" + "," + getwt6datapath() + "\\Data\\WinTOTAL\\QuickPix\\Thumbs";
            else
                pathes[20] = "TOTAL Thumbs" + "," + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\a la mode\\Database\\Thumbs";
            //Aurora Section
            pathes[21] = "Aurora Dir" + "," + Auroraini.ReadSetting("WinTOTAL", "ProgramDir", 64, "");
            pathes[22] = "Aurora File Path" + "," + Auroraini.ReadSetting("WinTOTAL", "FilesPath", 64, "");
            pathes[23] = "Aurora Image Path" + "," + Auroraini.ReadSetting("WinTOTAL", "ImageDir", 64, "");
            

            //if folder browser dialog box path is not empty
            foreach (string s in pathes)
            {
                if (s != null)
                {
                    string[] dir = new string[2];
                    dir = s.Split(',');
                    File.AppendAllText(Environment.GetEnvironmentVariable("ProgramData") + "\\alamode\\Common\\logs" + "\\Permissions.Check.log", DateTime.Now + " [I]: Loading " + dir[0] + " " + dir[1] + Environment.NewLine);
                    if (Directory.Exists(dir[1]))
                    {
                        var fs = System.IO.File.GetAccessControl(dir[1]);
                        var sid = fs.GetOwner(typeof(SecurityIdentifier));
                        var ntAccount = sid.Translate(typeof(NTAccount));
                        DirectoryInfo di = new DirectoryInfo(dir[1]);
                        dr = dt.NewRow();
                        dr[0] = dir[0];
                        dr[1] = "Directory";
                        dr[2] = di.FullName;
                        dr[3] = ntAccount;
                        dt.Rows.Add(dr);
                        dgv_filescollection.DataSource = dt;
                        dgv_filescollection.Focus();//set focus to datagridview so that you can remove files/folders just by pressing "delete" 
                        
                    }
                    else
                    {
                        //string excepType = excep.GetType().ToString();
                        // string excepMessage = excep.Message;
                        //log start of application
                        //File.AppendAllText(Environment.GetEnvironmentVariable("ProgramData") + "\\alamode\\Common\\logs" + "\\Permissions.Check.log", DateTime.Now + " [I]: Remote Access Repair Tool started " + Environment.NewLine);
                        LogError(" [E]: ", "Directory not found", "Name: " + dir[0] , " Path: " + dir[1], dir[0]);
                        //MessageBox.Show("Name: " + dir[0] + "\n" + "Path: " + dir[1]);
                    }
                        
                }
            }
        }

        private void FileAttributeChanger_DragOver(object sender, DragEventArgs e)
        {
            //on dragging a file or folder over form, show drageffects of copy operation
            e.Effect = DragDropEffects.Copy;
            AllowDrop = true;
        }

        private void FileAttributeChanger_DragDrop(object sender, DragEventArgs e)
        {                  
            //get all filenames and store them in string array
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string file in FileList)
            {
                var fs = System.IO.File.GetAccessControl(file);
                var sid = fs.GetOwner(typeof(SecurityIdentifier));
                var ntAccount = sid.Translate(typeof(NTAccount));

                if (File.GetAttributes(file).ToString().Contains("Directory"))
                    {
                        DirectoryInfo di = new DirectoryInfo(file);
                        dr = dt.NewRow();
                        dr[0] = "Manually Added";
                        dr[1] = "Directory";
                        dr[2] = di.FullName;
                        dr[3] = ntAccount;
                        dt.Rows.Add(dr);
                    File.AppendAllText(Environment.GetEnvironmentVariable("ProgramData") + "\\alamode\\Common\\logs" + "\\Permissions.Check.log", DateTime.Now + " [I]: Loading " + "Manually Added directory " + file + Environment.NewLine);

                }

                    else
                    {
                        dr = dt.NewRow();
                        FileInfo fi = new FileInfo(file);
                        dr[0] = "Manually Added";
                        dr[1] = "File";
                        dr[2] = file;//Filename will be shown in the first column of all rows
                        dr[3] = ntAccount;
                        dt.Rows.Add(dr);
                    File.AppendAllText(Environment.GetEnvironmentVariable("ProgramData") + "\\alamode\\Common\\logs" + "\\Permissions.Check.log", DateTime.Now + " [I]: Loading " + "Manually Added file " + file + Environment.NewLine);
                }
            }
            dgv_filescollection.DataSource = dt;
            dgv_filescollection.Focus();
        }

        private void ChangeFileAttributes(string fname)
        {            
            //File class is also able to change attributes of Directory ;)

            //if unchecked, then Archive attribute will be removed
            //To remove attribute a tilde(~) is appended before the FileAttributes enum
            if (chk_archive.Checked == false && File.GetAttributes(fname).ToString().Contains("Archive"))
                File.SetAttributes(fname, File.GetAttributes(fname) & ~FileAttributes.Archive);

            //set or unset attribute of file or folder to be hidden
            //if (chk_hidden.Checked == true && File.GetAttributes(fname).ToString().Contains("Hidden") == false)
            //    File.SetAttributes(fname, File.GetAttributes(fname) | FileAttributes.Hidden);
            if (chk_hidden.Checked == false && File.GetAttributes(fname).ToString().Contains("Hidden"))
                File.SetAttributes(fname, File.GetAttributes(fname) & ~FileAttributes.Hidden);

            //unset attribute as system
             if (chk_system.Checked == false && File.GetAttributes(fname).ToString().Contains("System"))
                File.SetAttributes(fname, File.GetAttributes(fname) & ~FileAttributes.System);

            //unset attribute to readonly
            if (chk_readonly.Checked == false && File.GetAttributes(fname).ToString().Contains("ReadOnly"))
                File.SetAttributes(fname, File.GetAttributes(fname) & ~FileAttributes.ReadOnly);
        }

        public static void SetFullAccessPermission(string directoryPath, string username)
        {

            //MessageBox.Show(directoryPath + "\n" + username);
            DirectorySecurity dir_security = Directory.GetAccessControl(directoryPath);

            FileSystemAccessRule full_access_rule = new FileSystemAccessRule(username, FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow);

            dir_security.AddAccessRule(full_access_rule);

            try
            {
                Directory.SetAccessControl(directoryPath, dir_security);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                string excepType = excep.GetType().ToString();
                string excepMessage = excep.Message;
                LogError(" [E]: ", excepType, "occurred while attempting to change the permissions of", directoryPath, excepMessage);
            }
        }


        public static void SetFullFilePermissions(string fileName, string User)
        {
            //MessageBox.Show(fileName);
            // Read the current ACL details for the file
            var fileSecurity = File.GetAccessControl(fileName);


            // Create another new rule set, based on "Current User"
            var fileAccessRule = new FileSystemAccessRule(new NTAccount("", User),
                FileSystemRights.FullControl,
                AccessControlType.Allow);

            // Append the new rule sets to the file
            fileSecurity.AddAccessRule(fileAccessRule);


            // And persist it to the filesystem
            try
            {
                File.SetAccessControl(fileName, fileSecurity);
            }
            catch (System.Exception excep)
            {
                MessageBox.Show(excep.Message);
                string excepType = excep.GetType().ToString();
                string excepMessage = excep.Message;
                LogError(" [E]: ", excepType, "occurred while attempting to change the permissions of", fileName, excepMessage);
            }
        }

        private void rbtn_folderonly_CheckedChanged(object sender, EventArgs e)
        {

        }

        void SetProgressText(string value)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(SetProgressText), value);
                return;
            }

            Status2.Text = value;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (updating == true)
            {
                MessageBox.Show("Please wait for current process to finish");
                return;
            }
            Application.Exit();
        }

        private void AddFile_Click(object sender, EventArgs e)
        {
            if (updating == true)
            {
                MessageBox.Show("Please wait for current process to finish");
                return;
            } 
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true; //Allow multiselection of files
            ofd.ShowDialog();
            //If many files are selected, then all of them will be added to datagridview
            foreach (string file in ofd.FileNames)
            {
                
                var fs = System.IO.File.GetAccessControl(file);
                var sid = fs.GetOwner(typeof(SecurityIdentifier));
                var ntAccount = sid.Translate(typeof(NTAccount));
                dr = dt.NewRow();
                FileInfo fi = new FileInfo(file);
                dr[0] = "Manually Added";
                dr[1] = "File";
                dr[2] = file;//Filename will be shown in the first column of all rows
                dr[3] = ntAccount;
                dt.Rows.Add(dr);
                dgv_filescollection.DataSource = dt;
                dgv_filescollection.Focus();
                File.AppendAllText(Environment.GetEnvironmentVariable("ProgramData") + "\\alamode\\Common\\logs" + "\\Permissions.Check.log", DateTime.Now + " [I]: Loading " + "Manually Added file " + file + Environment.NewLine);
            }
        }

        static void LogError(string iType, string excepType, string eMessage, string path, string excepMessage)
        {
            File.AppendAllText(Environment.GetEnvironmentVariable("ProgramData") + "\\alamode\\Common\\logs" + "\\Permissions.Check.log",
            DateTime.Now +
            iType +
            excepType + " " +
            eMessage + " " +
            path +
            ", {" + excepMessage + "}" +
            Environment.NewLine);
        }

        private void AddFolders_Click(object sender, EventArgs e)//add a folder to datagridview
        {
            if (updating == true)
            {
                MessageBox.Show("Please wait for current process to finish");
                return;
            }//show folder browser dialog
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;
            fbd.ShowDialog();

            //if folder browser dialog box path is not empty
            if (fbd.SelectedPath != "")
            {
                if (Directory.Exists(fbd.SelectedPath))
                {
                    var fs = System.IO.File.GetAccessControl(fbd.SelectedPath);
                    var sid = fs.GetOwner(typeof(SecurityIdentifier));
                    var ntAccount = sid.Translate(typeof(NTAccount));
                    DirectoryInfo di = new DirectoryInfo(fbd.SelectedPath);
                    dr = dt.NewRow();
                    dr[0] = "Manually Added";
                    dr[1] = "Directory";
                    dr[2] = di.FullName;
                    dr[3] = ntAccount;
                    dt.Rows.Add(dr);
                    dgv_filescollection.DataSource = dt;
                    dgv_filescollection.Focus();//set focus to datagridview so that you can remove files/folders just by pressing "delete" 
                    File.AppendAllText(Environment.GetEnvironmentVariable("ProgramData") + "\\alamode\\Common\\logs" + "\\Permissions.Check.log", DateTime.Now + " [I]: Loading " + "Manually Added directory " + fbd.SelectedPath + Environment.NewLine);

                }
            }
            
        }

        private void FileAttributeChanger_Load(object sender, EventArgs e)
        {

        }

        private void dgv_filescollection_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            contextMenuStrip1.Enabled = dgv_filescollection.SelectedColumns !=null;
        }

        private void takeOwnershipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (updating == true)
            {
                MessageBox.Show("Please wait for current process to finish");
                return;
            }

            updating = true;
            SetControlState(false);
            message = "Waiting . . .";
            SetProgressText(message);
            foreach (DataGridViewRow dgvr in dgv_filescollection.SelectedRows)
            {
                //Get Current file name in the datagridview
                string filename = dgvr.Cells[2].Value.ToString();
                var result = MessageBox.Show(@"Would you like to attempt to take ownership of:" + Environment.NewLine + filename + Environment.NewLine + Environment.NewLine + "This can be a lengthy process and cannot be interupted once started"
                    , "Set Ownership"
                    , MessageBoxButtons.YesNo);
                switch (result)
                {
                    case DialogResult.Yes:
                        {

                            var bw = new BackgroundWorker();
                            //bw.ReportProgress = true;
                            bw.DoWork += delegate
                            {
                                File.AppendAllText(Environment.GetEnvironmentVariable("ProgramData") + "\\alamode\\Common\\logs" + "\\Permissions.Check.log", DateTime.Now + " [I]: " + "Begin Setting Ownership of " + filename + Environment.NewLine + "{" + Environment.NewLine);
                                filename = filename.TrimEnd(new[] { '\\' }); // Remove trailing backslash if it exists
                                message = "Setting Ownership of " + filename;
                                SetProgressText(message);
                                Process TakeOwn = new Process();
                                TakeOwn.StartInfo.FileName = "cmd.exe";
                                TakeOwn.StartInfo.Arguments = " /c color A & Echo. & Echo Taking ownership of: \"" + filename + "\" & Echo. & Echo This process can take sever minutes & Echo Please do not close this window & Echo it will close automatically once it is done & takeown /f \"" + filename + "\" /r /d y >> \"" + Environment.GetEnvironmentVariable("ProgramData") + "\\alamode\\Common\\logs\\Permissions.Check.log" + "\"";
                                TakeOwn.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                //MessageBox.Show(TakeOwn.StartInfo.FileName.ToString() + TakeOwn.StartInfo.Arguments.ToString());
                                TakeOwn.Start();
                                TakeOwn.WaitForExit();
                                File.AppendAllText(Environment.GetEnvironmentVariable("ProgramData") + "\\alamode\\Common\\logs" + "\\Permissions.Check.log", "}" + Environment.NewLine + DateTime.Now + " [I]: " + "Finished Setting Ownership of " + filename + Environment.NewLine);
                                message = "Setting Ownership, please wait . . .";
                                SetProgressText(message);
                                message = "";
                            };
                            //bw.ProgressChanged += delegate { "" };
                            bw.RunWorkerCompleted += delegate {
                                message = "Ready";
                                SetProgressText(message);
                                SetControlState(true);
                                updating = false;
                            };
                            bw.RunWorkerAsync();

                        }
                        break;
                    case DialogResult.No:
                        message = "Ready";
                        SetProgressText(message);
                        SetControlState(true);
                        updating = false;
                        break;
                    default:
                        message = "Ready";
                        SetProgressText(message);
                        SetControlState(true);
                        updating = false;
                        break;
                }

                
            }
        }

        private void myTimer_Tick(object sender, EventArgs e)
        {
            myTimer.Interval = 1000;
            if (updating == true)
                {
                message = message + " .";
                SetProgressText(message);
                }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        /*
         * private void dgv_filescollection_DoubleClick(object sender, DataGridViewCellEventArgs f, EventArgs e)
        {
            filename = dgv_filescollection.Rows[f.RowIndex].Cells[2].Value.ToString();
            MessageBox.Show(dgv_filescollection.Rows[f.RowIndex].Cells[2].Value.ToString());
        }
        */

        private void dgv_filescollection_DoubleClick(object sender, DataGridViewCellEventArgs e)

        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)

            {
                //MessageBox.Show("Double clicked");
                //MessageBox.Show(dgv_filescollection.Rows[e.RowIndex].Cells[2].Value.ToString());
                System.Diagnostics.Process.Start("explorer.exe", dgv_filescollection.Rows[e.RowIndex].Cells[2].Value.ToString());
            }

        }

    }
    }

    /// <summary>
    /// Reading and Writing INI Files
    /// This will allow the IniFile class to use the API functions without exposing them publicly
    /// From http://www.blackwasp.co.uk/IniFile.aspx
    /// </summary>
    class NativeMethods
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool WritePrivateProfileString(
            string lpAppName, string lpKeyName, string lpString, string lpFileName);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern uint GetPrivateProfileString(
            string lpAppName, string lpKeyName, string lpDefault, string lpReturnedString,
            uint nSize, string lpFileName);
    }

    public class IniFile
    {
        string _iniFile;

        public IniFile(string fileName)
        {
            _iniFile = fileName;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2122:DoNotIndirectlyExposeMethodsWithLinkDemands")]
        public void WriteSetting(string section, string key, string value)
        {
            if (NativeMethods.WritePrivateProfileString(section, key, value, _iniFile) == false)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }
        }

        public string ReadSetting(string section, string key, uint maxLength, string defaultValue)
        {
            string value = new string(' ', (int)maxLength);
            NativeMethods.GetPrivateProfileString(
                section, key, defaultValue, value, maxLength, _iniFile);
            return value.Split('\0')[0];
        }

        public string[] ReadSections()
        {
            string value = new string(' ', 65535);
            NativeMethods.GetPrivateProfileString(null, null, "\0", value, 65535, _iniFile);
            return SplitNullTerminatedStrings(value);
        }

        private static string[] SplitNullTerminatedStrings(string value)
        {
            string[] raw = value.Split('\0');
            int itemCount = raw.Length - 2;
            string[] items = new string[itemCount];
            Array.Copy(raw, items, itemCount);
            return items;
        }

        public string[] ReadKeysInSection(string section)
        {
            string value = new string(' ', 65535);
            NativeMethods.GetPrivateProfileString(section, null, "\0", value, 65535, _iniFile);
            return SplitNullTerminatedStrings(value);
        }


    }
