using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLKS.DAL;
using QLKS.DTO;

namespace QLKS
{
    public partial class frmDangNhap : Form
    {
        NguoiDungDAL _nguoiDungDAL = new NguoiDungDAL();
        public frmDangNhap()
        {            
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text;
            bool isOK = _nguoiDungDAL.DangNhap(userName, password);
            if (isOK)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                lblError.Visible = true;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
