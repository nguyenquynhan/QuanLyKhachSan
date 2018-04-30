using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLKS.DTO;
using QLKS.DAL;

namespace QLKS
{
    public partial class frmQuanLyNguoiDung : frmMDIChild
    {
        NguoiDungDAL _nguoiDungDAL = new NguoiDungDAL();
        NhanVienDAL _nhanVienDAL = new NhanVienDAL();
        public frmQuanLyNguoiDung()
        {
            InitializeComponent();
            dgvNguoiDung.AutoGenerateColumns = false;

        }

        private void frmQuanLyNguoiDung_Load(object sender, EventArgs e)
        {
            LoadNhanVien();
            LoadData();
            ThemMoi();
        }

        private void LoadData()
        {
            List<NguoiDung> nguoiDungs = _nguoiDungDAL.GetAll();
            dgvNguoiDung.DataSource = nguoiDungs;
        }

        private void LoadNhanVien()
        {
            cbbNhanVien.DisplayMember = "HoTen";
            cbbNhanVien.ValueMember = "MaNV";
            cbbNhanVien.DataSource = _nhanVienDAL.GetAll();
        }

        private void dgvNguoiDung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv =  (DataGridView)sender;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {
                NguoiDung selected = (NguoiDung)dgv.CurrentRow.DataBoundItem;
                cbbNhanVien.SelectedValue = selected.MaNV;
                txtUserName.Text = selected.UserName;
                cheIsAdmin.Checked = selected.IsAdmin;
                lblMaND.Text = selected.MaND.ToString();
                txtPassword.Text = string.Empty;
            }
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            ThemMoi();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cbbNhanVien.SelectedValue == null
                || txtUserName.Text.Length == 0
                || (lblMaND.Text.Length == 0 && txtPassword.Text.Length == 0))
            {
                MessageBox.Show("Bạn cần nhập đầy đủ thông tin.");
                return;
            }

            NguoiDung nguoiDung = new NguoiDung()
            {
                MaNV = (int)cbbNhanVien.SelectedValue,
                UserName = txtUserName.Text,
                Password = txtPassword.Text,
                IsAdmin = cheIsAdmin.Checked
            };

            if(lblMaND.Text.Length > 0)
            {
                nguoiDung.MaND = int.Parse(lblMaND.Text);
            }

            bool isSuccess = true;
            if (lblMaND.Text.Length == 0)
            {
                List<NguoiDung> nguoiDungs = _nguoiDungDAL.GetAll();
                if(nguoiDungs.Any(r=> r.MaNV == nguoiDung.MaNV))
                {
                    MessageBox.Show("Nhân viên này đã có tài khoản người dùng!");
                    return;
                }
                else
                {
                    isSuccess = _nguoiDungDAL.Create(nguoiDung);
                }
            }
            else
            {
                isSuccess = _nguoiDungDAL.Update(nguoiDung);
            }

            if (isSuccess)
            {
                LoadData();
                ThemMoi();
            }
            else
            {
                MessageBox.Show("Lưu người dùng bị lỗi, làm ơn thử lại!");
            }
        }

        private void ThemMoi()
        {
            cbbNhanVien.SelectedValue = 0;
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            cheIsAdmin.Checked = false;
            lblMaND.Text = string.Empty;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lblMaND.Text.Length > 0)
            {
                var confirmResult = MessageBox.Show("Bạn có chắc là muốn xóa người dùng này?",
                                     "Xác nhận",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    int maND = int.Parse(lblMaND.Text);
                    bool isSuccess = _nguoiDungDAL.Delete(maND);
                    if (isSuccess)
                    {
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa người dùng bị lỗi, làm ơn thử lại!");
                    }
                }                
            }
        }
    }
}
