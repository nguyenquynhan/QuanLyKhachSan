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
    public partial class frmQuanLyKhachHang : frmMDIChild
    {
        List<KhachHang> _khachHangs;
        KhachHangDAL _khachHangDAL = new KhachHangDAL();
        public frmQuanLyKhachHang()
        {
            InitializeComponent();
            dgvKhachHang.AutoGenerateColumns = false;
        }

        private void frmQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadDataCbbGioiTinh();
            LoadDataCbbTimKiemTheo();
            cbbTimKiemTheo.Text = "Mã khách hàng";
        }
        //Load du lieu cho datagridview
        private void LoadData()
        {
            _khachHangs = _khachHangDAL.GetAllExisting();
            dgvKhachHang.DataSource = _khachHangs;
            lblCheck.Text = "t";
            //ReSelectDataGridview(0);
            ThemMoi();
            btnLuu.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            txtMaKH.Enabled = txtCMND.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = txtTenKH.Enabled = dtpNgaySinh.Enabled = cbbGioiTinh.Enabled = false;
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
            cbbTimKiemTheo.Items.Add("Mã khách hàng");
            cbbTimKiemTheo.Items.Add("Tên khách hàng");
        }
        //Ham Xoa trang
        private void ThemMoi()
        {
            txtCMND.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = txtTenKH.Enabled = dtpNgaySinh.Enabled = cbbGioiTinh.Enabled = true;
            txtMaKH.Text = string.Empty;
            txtTenKH.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtCMND.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtSDT.Text = string.Empty;
            dtpNgaySinh.Value = DateTime.Today;
            cbbGioiTinh.SelectedValue = 0;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        //Them moi/Xoa trang
        private void btnThem_Click(object sender, EventArgs e)
        {
            lblCheck.Text = "t";
            btnLuu.Enabled = true;
            ThemMoi();
        }
        //Sua
        private void btnSua_Click(object sender, EventArgs e)
        {
            lblCheck.Text = "s";
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            txtCMND.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = txtTenKH.Enabled = dtpNgaySinh.Enabled = cbbGioiTinh.Enabled = true;
        }
        //Xoa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn có chắc là muốn xóa người dùng này?",
                                     "Xác nhận",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {

                KhachHang khachHang = new KhachHang()
                {
                    MaKH = int.Parse(txtMaKH.Text),
                    NgaySua = DateTime.Today,
                    NguoiSua = Program.CurrentUser.MaND
                };
                bool isSuccess = _khachHangDAL.UpdateXoaForQLKhachHang(khachHang);
                if (isSuccess)
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa khách hàng bị lỗi, làm ơn thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }    
        }
        //Luu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            //Tao doi tuong khach hang
            KhachHang khachHang = new KhachHang()
            {
               
                HoTen = txtTenKH.Text,
                NgaySinh = dtpNgaySinh.Value,
                SDT = txtSDT.Text,
                CMND = txtCMND.Text,
                DiaChi = txtDiaChi.Text,

            };
            if (cbbGioiTinh.SelectedValue == null)
                khachHang.GioiTinh = "Nam";
            else
                khachHang.GioiTinh = (string)cbbGioiTinh.SelectedValue;
            bool isSuccess = true;
            // Kiem tra co phai dang them khach hang hay k?
            if (lblCheck.Text == "t")
            {
                if (txtTenKH.Text.Length == 0 || txtSDT.Text.Length == 0 || txtCMND.Text.Length == 0)
                {
                    MessageBox.Show("Bạn cần nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (IsNumber(txtCMND.Text) == false && IsNumber(txtSDT.Text) == false)
                {
                    MessageBox.Show("Số CMND và số điện thoại không hợp lệ, vui lòng xem lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (IsNumber(txtSDT.Text) == false)
                {
                    MessageBox.Show("Số điện thoại không hợp lệ, vui lòng xem lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(IsNumber(txtCMND.Text) == false)
                {
                    MessageBox.Show("Số CMND không hợp lệ, vui lòng xem lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(DateTime.Today.Year -dtpNgaySinh.Value.Year < 18)
                {
                    MessageBox.Show("Khách hàng chưa đủ tuổi để đăng kí, vui lòng xem lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                    if (_khachHangs.Any(r => r.HoTen == khachHang.HoTen && r.CMND == khachHang.CMND))//Kiem tra khach hang nay da tung ton tai thi cap nhat DaXoa = 0
                    {
                        khachHang.NgaySua = DateTime.Today;
                        khachHang.NguoiSua = Program.CurrentUser.MaND;
                        isSuccess = _khachHangDAL.UpdateForQLKhachHang(khachHang);
                    }
                    else
                    {
                        khachHang.DaXoa = false;
                        khachHang.NgayTao = DateTime.Today;
                        khachHang.NguoiTao = Program.CurrentUser.MaND;
                        isSuccess = _khachHangDAL.Create(khachHang);
                    }
            }
            // Kiem tra co phai dang sua khach hang hay k?
            else if (lblCheck.Text == "s")
            {

                if (_khachHangs.Any(r => (r.HoTen != khachHang.HoTen || r.CMND != khachHang.CMND
                    || r.NgaySinh != khachHang.NgaySinh || r.SDT != khachHang.SDT || r.DiaChi != khachHang.DiaChi
                    || r.GioiTinh != khachHang.GioiTinh)
                    && r.MaKH == khachHang.MaKH)) //Kiem tra neu khong sua gi het nhung van nhan luu
                {
                    khachHang.MaKH = int.Parse(txtMaKH.Text);
                    khachHang.NgaySua = DateTime.Today;
                    khachHang.NguoiSua = Program.CurrentUser.MaND;
                    isSuccess = _khachHangDAL.Update(khachHang);
                }
                else
                    return;
            }
            int selectedIndex;
            if (isSuccess)
            {
                MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK);
                selectedIndex = dgvKhachHang.CurrentRow.Index;
                LoadData();
                ThemMoi();
                ReSelectDataGridview(selectedIndex);
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtCMND.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = txtTenKH.Enabled = dtpNgaySinh.Enabled = cbbGioiTinh.Enabled = false;
            }
            else
            {
                MessageBox.Show("Lưu khách hàng bị lỗi, làm ơn thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        //selected row[0].cell[0]
        private void ReSelectDataGridview(int selectedIndex)
        {
            for (int i = 0; i < dgvKhachHang.Rows.Count; i++)
            {
                for (int j = 0; j < dgvKhachHang.Columns.Count; j++)
                {
                    dgvKhachHang.Rows[i].Cells[j].Selected = false;
                }
            }
            dgvKhachHang.Rows[selectedIndex].Selected = true;
            dgvKhachHang.CurrentCell = dgvKhachHang.Rows[selectedIndex].Cells[0];
        }

        //Su kien Cell Click dgvKhachHang
        private void dgvKhachHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvKhachHang == null) return;
            if (dgvKhachHang.CurrentRow.Selected)
            {
                KhachHang selected = (KhachHang)dgvKhachHang.CurrentRow.DataBoundItem;
                txtMaKH.Text = selected.MaKH.ToString();
                txtTenKH.Text = selected.HoTen;
                txtCMND.Text = selected.CMND;
                txtDiaChi.Text = selected.DiaChi;
                txtSDT.Text = selected.SDT;
                cbbGioiTinh.SelectedValue = selected.GioiTinh;
                dtpNgaySinh.Value = (DateTime)selected.NgaySinh;

                btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
                txtCMND.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = txtTenKH.Enabled = dtpNgaySinh.Enabled = cbbGioiTinh.Enabled = false;
                btnLuu.Enabled = false;
            }
            
        }
        

        //Reload
        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadData();
            LoadDataCbbGioiTinh();
            LoadDataCbbTimKiemTheo();
            cbbTimKiemTheo.Text = "Mã khách hàng";
            btnThem.Enabled = true;
        }

        //Ham kiem tra chuoi nhap vao la kieu so hay k
        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            
            if (cbbTimKiemTheo.Text == "Mã khách hàng")
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
                        int maKH = int.Parse(txtTimKiem.Text);
                        dgvKhachHang.DataSource = _khachHangs.Where(kh => kh.MaKH == maKH).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Điều kiện tìm kiếm không đúng, mã khách hàng phải là kiểu số, vui lòng xem lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTimKiem.Text = null;
                    }
                }
            }
            else
            {
                string tenKH = txtTimKiem.Text;
                dgvKhachHang.DataSource = _khachHangs.Where(kh => kh.HoTen.ToLower().Contains(tenKH.ToLower())
                    || tenKH.ToLower().Contains(kh.HoTen.ToLower())).ToList();

            }
        }
        private void txtTimKiem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }



    }
}
