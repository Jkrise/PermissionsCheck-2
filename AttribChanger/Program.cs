using PermissionsCheck;
using System;
using System.Windows.Forms;

namespace AttribChanger
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new FileAttributeChanger());
            try
            {
                Application.Run(new FileAttributeChanger());
            }
            catch (System.Exception ex)
            {

                MessageBox.Show("Type: " + ex.GetType().ToString() + Environment.NewLine + ex.Message, 
                    "An Error Has Occcured", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation, 
                    MessageBoxDefaultButton.Button1);

                var result = MessageBox.Show(@"Would you like to attempt to repair?" + Environment.NewLine + "This can be a lengthy process and cannot be interupted once started", "Confirmation", MessageBoxButtons.YesNoCancel);
                switch (result)
                {
                    case DialogResult.Yes:
                        Application.Run(new SetOwner());
                        break;
                    case DialogResult.No:
                        Application.Exit();
                        break;
                    default:
                        Application.Exit();
                        break;
                }
            }
        }
    }
}