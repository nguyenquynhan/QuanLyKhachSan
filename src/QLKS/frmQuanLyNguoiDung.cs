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
            ThemMoi();
            LoadData();
        }

        private void LoadData()
        {
            List<NguoiDung> nguoiDungs = _nguoiDungDAL.GetAllExisting();
            dgvNguoiDung.DataSource = nguoiDungs;
            btnLuu.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            cbbNhanVien.Enabled = txtUserName.Enabled = txtPassword.Enabled = false;
        }

        private void LoadNhanVien()
        {
            cbbNhanVien.DisplayMember = "HoTen";
            cbbNhanVien.ValueMember = "MaNV";
            cbbNhanVien.DataSource = _nhanVienDAL.GetAllExisting();
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
                txtPassword.Text = selected.Password;
                lblMaND.Text = selected.MaND.ToString();
               // txtPassword.Text = string.Empty;
                btnThemMoi.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
                cbbNhanVien.Enabled = txtPassword.Enabled = txtUserName.Enabled = btnLuu.Enabled = false;
            }
            btnXoa.Enabled = true;
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            lblCheck.Text = "t";
            btnLuu.Enabled = true;
            ThemMoi();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cbbNhanVien.SelectedValue == null
                || txtUserName.Text.Length == 0
                || (lblMaND.Text.Length == 0 && txtPassword.Text.Length == 0))
            {
                MessageBox.Show("Bạn cần nhập đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if(nguoiDungs.Any(r=> r.MaNV == nguoiDung.MaNV && r.DaXoa == false))
                {
                    MessageBox.Show("Nhân viên này đã có tài khoản người dùng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (nguoiDungs.Any(r => r.MaNV == nguoiDung.MaNV && r.DaXoa == true))
                {
                    
                    nguoiDung.NgaySua = DateTime.Today;
                    nguoiDung.NguoiSua = Program.CurrentUser.MaND;
                    isSuccess = _nguoiDungDAL.UpdateForQLNguoiDung(nguoiDung);
                }
                else
                {
                    nguoiDung.DaXoa = false;
                    isSuccess = _nguoiDungDAL.Create(nguoiDung);
                }
            }
            else
            {
                isSuccess = _nguoiDungDAL.Update(nguoiDung);
            }

            if (isSuccess)
            {
                MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK);
                LoadData();
                ThemMoi();   
            }
            else
            {
                MessageBox.Show("Lưu người dùng bị lỗi, làm ơn thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ThemMoi()
        {
            cbbNhanVien.Enabled = txtUserName.Enabled = txtPassword.Enabled = true;
            cbbNhanVien.SelectedValue = 0;
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            cheIsAdmin.Checked = false;
            lblMaND.Text = string.Empty;
            btnXoa.Enabled = btnSua.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

                var confirmResult = MessageBox.Show("Bạn có chắc là muốn xóa người dùng này?",
                                     "Xác nhận",
                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    NguoiDung nguoiDung = new NguoiDung()
                    {
                        MaND = int.Parse(lblMaND.Text),
                        NgaySua = DateTime.Today,
                        NguoiSua = Program.CurrentUser.MaND
                    };
                    bool isSuccess = _nguoiDungDAL.UpdateXoaForQLNguoiDung(nguoiDung);
                    if (isSuccess)
                    {
                        MessageBox.Show("Xóa thành công","Thông báo",MessageBoxButtons.OK);
                        LoadData();
                        ThemMoi();
                    }
                    else
                    {
                        MessageBox.Show("Xóa người dùng bị lỗi, làm ơn thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                btnLuu.Enabled = true; 
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            lblCheck.Text = "s";
            btnThemMoi.Enabled = btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            cbbNhanVien.Enabled = false;
            txtPassword.Enabled = txtUserName.Enabled = true;
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            ThemMoi();
            LoadData();
            btnThemMoi.Enabled = true;
        }
    }
}

