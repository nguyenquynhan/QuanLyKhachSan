using QLKS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
