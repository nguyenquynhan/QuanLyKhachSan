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
    public partial class frmQuanLyNhanVien : frmMDIChild
    {
        List<NhanVien> _nhanViens;
        NhanVienDAL _nhanVienDAL = new NhanVienDAL();
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
            dgvNhanVien.AutoGenerateColumns = false;
        }

        private void frmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadDataCbbGioiTinh();
            LoadDataCbbTimKiemTheo();
        }
        public void LoadData()
        {

            _nhanViens = _nhanVienDAL.GetAllExisting();
            dgvNhanVien.DataSource = _nhanViens;
            lblCheck.Text = "t";
            //ReSelectDataGridview(0);
            ThemMoi();
            cbbTimKiemTheo.Text = "Mã nhân viên";
            btnLuu.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            txtMaNV.Enabled = txtCMND.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = txtTenNV.Enabled = dtpNgaySinh.Enabled = cbbGioiTinh.Enabled = txtEmail.Enabled = dtpNgayLamViec.Enabled = false;
        }
        public void LoadDataCbbGioiTinh()
        {
            List<GioiTinh> gioitinh = new List<GioiTinh>();
            gioitinh.Add(new GioiTinh() { Ten = "Nam" });
            gioitinh.Add(new GioiTinh() { Ten = "Nữ" });
            cbbGioiTinh.ValueMember = "Ten";
            cbbGioiTinh.DisplayMember = "Ten";
            cbbGioiTinh.DataSource = gioitinh;
        }

        public void LoadDataCbbTimKiemTheo()
        {
            cbbTimKiemTheo.Items.Clear();
            cbbTimKiemTheo.Items.Add("Mã nhân viên");
            cbbTimKiemTheo.Items.Add("Tên nhân viên");
        }

        public void ThemMoi()
        {
            txtCMND.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = txtTenNV.Enabled = dtpNgaySinh.Enabled = cbbGioiTinh.Enabled = txtEmail.Enabled = dtpNgayLamViec.Enabled = true;
            txtMaNV.Text = string.Empty;
            txtTenNV.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtCMND.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtEmail.Text = string.Empty;
            dtpNgaySinh.Value = DateTime.Today;
            dtpNgayLamViec.Value = DateTime.Today;
            cbbGioiTinh.SelectedValue = 0;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            lblCheck.Text = "t";
            btnLuu.Enabled = true;
            ThemMoi();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            lblCheck.Text = "s";
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            txtCMND.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = txtTenNV.Enabled = dtpNgaySinh.Enabled = cbbGioiTinh.Enabled = txtEmail.Enabled = dtpNgayLamViec.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn có chắc là muốn xóa người dùng này?",
                                    "Xác nhận",
                                    MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {

                NhanVien nhanVien = new NhanVien()
                {
                    MaNV = int.Parse(txtMaNV.Text),
                    NgaySua = DateTime.Today,
                    NguoiSua = Program.CurrentUser.MaND
                };
                bool isSuccess = _nhanVienDAL.UpdateXoaForQLNhanVien(nhanVien);
                if (isSuccess)
                {    
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa nhân viên bị lỗi, vui lòng thử lại!","Lỗi", MessageBoxButtons.OK);
                }
            }    
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
           
            //Tao doi tuong nhan vien
            
            NhanVien nhanVien = new NhanVien()
            {

                HoTen = txtTenNV.Text,
                NgaySinh = dtpNgaySinh.Value,
                NgayLamViec = dtpNgayLamViec.Value,
                Email = txtEmail.Text,
                SDT = txtSDT.Text,
                CMND = txtCMND.Text,
                DiaChi = txtDiaChi.Text,
                //GioiTinh = (string)cbbGioiTinh.SelectedValue,

            };
            _nhanViens = _nhanVienDAL.GetAll();
            if ( cbbGioiTinh.SelectedValue == null)
                nhanVien.GioiTinh = "Nam";
            else
                nhanVien.GioiTinh = (string)cbbGioiTinh.SelectedValue;
            bool isSuccess = true;
            // Kiem tra co phai dang them nhan vien hay k?
            if (lblCheck.Text == "t")
            {
                
                if (txtTenNV.Text.Length == 0 || txtSDT.Text.Length == 0 || txtCMND.Text.Length == 0)
                {
                    MessageBox.Show("Bạn cần nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnXoa.Enabled = false;
                    btnSua.Enabled = false;
                    return;
                }
                else if (IsNumber(txtCMND.Text) == false && IsNumber(txtSDT.Text) == false)
                {
                    MessageBox.Show("Số CMND và số điện thoại không hợp lệ, vui lòng xem lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (IsNumber(txtSDT.Text) == false)
                {
                    MessageBox.Show("Số điện thoại không hợp lệ, vui lòng xem lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (IsNumber(txtCMND.Text) == false)
                {
                    MessageBox.Show("Số CMND không hợp lệ, vui lòng xem lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if ((dtpNgayLamViec.Value.Year -dtpNgaySinh.Value.Year) < 18)
                {
                    MessageBox.Show("Ngày làm việc không hợp lệ, nhân viên này chưa đủ 18 tuổi, vui lòng xem lại ngày làm việc hoặc ngày sinh!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                if (_nhanViens.Any(r => r.HoTen == nhanVien.HoTen && r.CMND == nhanVien.CMND))//Kiem tra nhan vien nay da tung ton tai thi cap nhat DaXoa = 0
                {
                    nhanVien.NgaySua = DateTime.Today;
                    nhanVien.NguoiSua = Program.CurrentUser.MaND;
                    isSuccess = _nhanVienDAL.UpdateForQLNhanVien(nhanVien);
                }
                else
                {
                    nhanVien.DaXoa = false;
                    nhanVien.NgayTao = DateTime.Today;
                    nhanVien.NguoiTao = Program.CurrentUser.MaND;
                    isSuccess = _nhanVienDAL.Create(nhanVien);
                }
            }
            // Kiem tra co phai dang sua nhan vien hay k?
            else if (lblCheck.Text == "s")
            {
                if (_nhanViens.Any(r => (r.HoTen != nhanVien.HoTen || r.CMND != nhanVien.CMND
                    || r.NgaySinh != nhanVien.NgaySinh || r.SDT != nhanVien.SDT || r.DiaChi != nhanVien.DiaChi
                    || r.Email != nhanVien.Email || r.NgayLamViec != nhanVien.NgayLamViec)
                    && r.MaNV == nhanVien.MaNV))//Kiem tra neu khong sua gi het nhung van nhan luu
                {

                    nhanVien.MaNV = int.Parse(txtMaNV.Text);
                    nhanVien.NgaySua = DateTime.Today;
                    nhanVien.NguoiSua = Program.CurrentUser.MaND;
                    isSuccess = _nhanVienDAL.Update(nhanVien);
                  
                }
                else
                {
                    return;
                }

            }
            int selectedIndex;
            if (isSuccess)
            {
                MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK);
                selectedIndex = dgvNhanVien.CurrentRow.Index;
                LoadData();
                ThemMoi();
               // ReSelectDataGridview(selectedIndex);
                btnThem.Enabled = true;
                txtCMND.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = txtTenNV.Enabled = dtpNgaySinh.Enabled = cbbGioiTinh.Enabled = txtEmail.Enabled = dtpNgayLamViec.Enabled = false;
            }
            else
            {
                MessageBox.Show("Lưu khách hàng bị lỗi, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        //selected row[0].cell[0]
        private void ReSelectDataGridview(int selectedIndex)
        {
            for (int i = 0; i < dgvNhanVien.Rows.Count; i++)
            {
                for (int j = 0; j < dgvNhanVien.Columns.Count; j++)
                {
                    dgvNhanVien.Rows[i].Cells[j].Selected = false;
                }
            }
            dgvNhanVien.Rows[selectedIndex].Selected = true;
            dgvNhanVien.CurrentCell = dgvNhanVien.Rows[selectedIndex].Cells[0];
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNhanVien == null) return;
            if (dgvNhanVien.CurrentRow.Selected)
            {              
                NhanVien selected = (NhanVien)dgvNhanVien.CurrentRow.DataBoundItem;
                txtMaNV.Text = selected.MaNV.ToString();
                txtTenNV.Text = selected.HoTen;
                txtCMND.Text = selected.CMND;
                txtDiaChi.Text = selected.DiaChi;
                txtEmail.Text = selected.Email;
                dtpNgayLamViec.Value = (DateTime)selected.NgayLamViec;
                txtSDT.Text = selected.SDT;
                cbbGioiTinh.SelectedValue = selected.GioiTinh;
                dtpNgaySinh.Value = (DateTime)selected.NgaySinh;
                //Hieu chinh Enable cua cac nut lenh va object
                btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
                txtCMND.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = txtTenNV.Enabled = dtpNgaySinh.Enabled = cbbGioiTinh.Enabled = txtEmail.Enabled = dtpNgayLamViec.Enabled = false;
                btnLuu.Enabled = false;
            }
            
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
            LoadDataCbbGioiTinh();
            btnThem.Enabled = true;
        }

        private void txttnv_TextChanged(object sender, EventArgs e)
        {
            if (cbbTimKiemTheo.Text == "Mã nhân viên")
            {
                if (txtTimKiem.Text.Length == 0)
                {
                    LoadData();
                    return;
                }
                else
                {
                    if (IsNumber(txtTimKiem.Text) == true)
                    {
                        int maNV = int.Parse(txtTimKiem.Text);
                        dgvNhanVien.DataSource = _nhanViens.Where(nv => nv.MaNV == maNV).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Điều kiện tìm kiếm không đúng, mã nhân viên phải là kiểu số, vui lòng xem lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTimKiem.Text = null;
                    }
                }
            }
            else
            {
                string tenNV = txtTimKiem.Text;
                dgvNhanVien.DataSource = _nhanViens.Where(nv => nv.HoTen.ToLower().Contains(tenNV.ToLower())
                    || tenNV.ToLower().Contains(nv.HoTen.ToLower())).ToList();
            }
         }
        //Ham kiem tra kieu so
         public bool IsNumber(string pValue)
            {
                foreach (Char c in pValue)
                {
                    if (!Char.IsDigit(c))
                        return false;
                }
                return true;
            }







    }
}
