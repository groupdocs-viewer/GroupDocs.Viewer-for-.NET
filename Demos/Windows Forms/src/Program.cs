using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroupDocs.Viewer.Forms.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException +=
           (sender, args) => HandleUnhandledException(args.ExceptionObject as Exception);
            Application.ThreadException +=
                (sender, args) => HandleUnhandledException(args.Exception);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        static void HandleUnhandledException(Exception e)
        {
            MessageBox.Show($"Exception was occured! {e.Message}");
        }
    }
}
