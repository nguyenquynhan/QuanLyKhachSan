using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            PhanQuyen();
        }
        private void qlNguoiDungMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyNguoiDung childForm = new frmQuanLyNguoiDung();
            childForm.ShowInParent(this, tabControlMain);
        }

        private void thoatMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PhanQuyen()
        {
            //Nếu không phải là quản lý thì ẩn menu quản lý người dùng
            if (!Program.CurrentUser.IsAdmin)
            {
                qlNguoiDungMenuItem.Visible = false;
                qlNguoiDungMenuItemLine.Visible = false;
            }
        }
    }
}
