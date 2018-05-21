using System;
using System.Windows.Forms;
using QLKS.DAL;
using QLKS.DTO;

namespace QLKS
{
    public partial class frmDangNhap : Form
    {
        NguoiDungDAL _nguoiDungDAL = new NguoiDungDAL();
        public NguoiDung CurrentUser { get; set; }
        public frmDangNhap()
        {            
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DangNhap();
            }
        }

        private void DangNhap()
        {
            lblError.Visible = false;
            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text;
            NguoiDung nguoiDung = _nguoiDungDAL.DangNhap(userName, password);
            if (nguoiDung != null)
            {
                CurrentUser = nguoiDung;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                lblError.Visible = true;
            }
        }


    }
}
