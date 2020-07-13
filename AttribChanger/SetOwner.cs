using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace PermissionsCheck
{
    public partial class SetOwner : Form
    {
        public SetOwner()
        {
            InitializeComponent();
        }

        private void SetOwner_Load(string[] args)
        {
            try
            {
                // If Create ACLs.bat already exists, delete it
                if (System.IO.File.Exists(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.bat"))
                {
                    // Use a try block to catch IOExceptions, to 
                    // handle the case of the file already being 
                    // opened by another process. 
                    try
                    {
                        System.IO.File.Delete(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.bat");
                    }
                    catch (System.IO.IOException e)
                    {
                        MessageBox.Show(e.Message);
                        return;
                    }
                }

                //Create new ACLs.bat
                File.AppendAllText(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.bat", "@ECHO OFF" + Environment.NewLine);
                File.AppendAllText(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.bat", "Color A" + Environment.NewLine);
                File.AppendAllText(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.bat", "Echo." + Environment.NewLine);
                File.AppendAllText(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.bat", "Setting Ownership" + Environment.NewLine);
                File.AppendAllText(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.bat", "Please Wait" + Environment.NewLine);
                File.AppendAllText(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.bat", "This process can take several minutes" + Environment.NewLine);
                File.AppendAllText(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.bat", "Please do not close this Window," + Environment.NewLine);
                File.AppendAllText(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.bat", "it will close Automatically when the process is complete" + Environment.NewLine);
                File.AppendAllText(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.bat", "takeown /f  \"C:\\programdata\\alamode\" / r / d y > null" + Environment.NewLine);
                File.AppendAllText(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.bat", "takeown /f  \"C:\\Users\\Public\\Documents\\a la mode\" / r / d y > nul" + Environment.NewLine);
                File.AppendAllText(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.bat", "CLS" + Environment.NewLine);
                File.AppendAllText(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.bat", "Color A" + Environment.NewLine);
                File.AppendAllText(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.bat", "Ownership Updated " + Environment.NewLine);
                File.AppendAllText(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.bat", "Setting Ownership" + Environment.NewLine);
                File.AppendAllText(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.bat", "Please Wait" + Environment.NewLine);
                File.AppendAllText(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.bat", "This process can take several minutes" + Environment.NewLine);
                File.AppendAllText(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.bat", "Please do not close this Window," + Environment.NewLine);
                File.AppendAllText(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.bat", "it will close Automatically when the process is complete" + Environment.NewLine);
                File.AppendAllText(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.bat", "PowerShell.exe -NoProfile -ExecutionPolicy Bypass -Command \"& '%~dpn0.ps1'\"" + Environment.NewLine);
                File.AppendAllText(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.bat", "echo Updating ACL's Complete" + Environment.NewLine);
                File.AppendAllText(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.bat", "Echo This window will now close" + Environment.NewLine);
                File.AppendAllText(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.bat", "Timeout /t 2 /NOBREAK > nul" + Environment.NewLine);
                File.AppendAllText(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.bat", "exit" + Environment.NewLine);

                // If Create ACLs.ps1 exists, delete it
                if (System.IO.File.Exists(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.ps1"))
                {
                    // Use a try block to catch IOExceptions, to 
                    // handle the case of the file already being 
                    // opened by another process. 
                    try
                    {
                        System.IO.File.Delete(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.ps1");
                    }
                    catch (System.IO.IOException e)
                    {
                        MessageBox.Show(e.Message);
                        return;
                    }
                }
                //Create new ACLs.ps1
                File.AppendAllText(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.ps1", "$path = \"C:\\programdata\\alamode\"" + Environment.NewLine);
                File.AppendAllText(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.ps1", "$acl = Get-Acl $path" + Environment.NewLine);
                File.AppendAllText(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.ps1", "Set-Acl $path $acl -Verbose" + Environment.NewLine);
                File.AppendAllText(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.ps1", Environment.NewLine);
                File.AppendAllText(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.ps1", "$path2 = \"C:\\Users\\Public\\Documents\\a la mode\"" + Environment.NewLine);
                File.AppendAllText(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.ps1", "$acl2 = Get-Acl $path2" + Environment.NewLine);
                File.AppendAllText(Environment.GetEnvironmentVariable("Temp") + "\\ACLs.ps1", "Set-Acl $path2 $acl2 -Verbose" + Environment.NewLine);

                File.AppendAllText(Environment.GetEnvironmentVariable("ProgramData") + "\\alamode\\Common\\logs" + "\\Permissions.Check.log", "}" + Environment.NewLine + DateTime.Now + " [I]: " + "Begin Fixing ACL's" + Environment.NewLine); //Log process
                Process TakeOwn = new Process(); //Create a new process
                TakeOwn.StartInfo.FileName = "cmd.exe"; //Set the process to run as the command prompt
                TakeOwn.StartInfo.Arguments = " /c" + Environment.GetEnvironmentVariable("Temp") + "\\ACLs.bat"; //Launch ACL.bat
                TakeOwn.StartInfo.WindowStyle = ProcessWindowStyle.Normal; //Display the comand prompt normally (not hidden)
                                                                           //MessageBox.Show(TakeOwn.StartInfo.FileName.ToString() + TakeOwn.StartInfo.Arguments.ToString());
                TakeOwn.Start(); //Run the cmd process we just created 
                TakeOwn.WaitForExit(); //Wait for the command prompt process to finish
                File.AppendAllText(Environment.GetEnvironmentVariable("ProgramData") + "\\alamode\\Common\\logs" + "\\Permissions.Check.log", "}" + Environment.NewLine + DateTime.Now + " [I]: " + "Finished Fixing ACL's" + Environment.NewLine);  // log the process finished
                Application.Restart(); //Reload the program to try to access the data again now that we attempted to repair them
            }
            catch (System.IO.IOException e)
            {
                MessageBox.Show("Type: " + e.Message,
                    "An Error Has Occcured, the program will now exit",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop,
                    MessageBoxDefaultButton.Button1);
                Application.Exit();
            }

        }
    }
}
