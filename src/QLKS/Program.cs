using QLKS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS
{
    static class Program
    {
        public static NguoiDung CurrentUser { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
                        
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.ThreadException += ApplicationThreadException;
                AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;

                frmDangNhap fLogin = new frmDangNhap();
                if (fLogin.ShowDialog() == DialogResult.OK)
                {
                    CurrentUser = fLogin.CurrentUser;
                    Application.Run(new frmMain());
                }
                else
                {
                    Application.Exit();
                }
          
        }

        /// <summary>
        /// Global exceptions in Non User Interfarce(other thread) antipicated error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string title = "Sorry, something went wrong.";
            string detail = ((Exception)e.ExceptionObject).Message + "\r\n" + ((Exception)e.ExceptionObject).StackTrace;
            new frmException(title, detail).ShowDialog();
        }

        /// <summary>
        /// Global exceptions in User Interfarce antipicated error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
        {
            string title = "Sorry, something went wrong.";
            string detail = e.Exception.Message + "\r\n" + e.Exception.StackTrace;
            new frmException(title, detail).ShowDialog();
        }
    }
}
