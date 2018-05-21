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
        List<KhachHang> khachHangs;
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
            khachHangs = _khachHangDAL.GetAll();
            dgvKhachHang.DataSource = khachHangs;
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
                int maKH = int.Parse(txtMaKH.Text);
                bool isSuccess = _khachHangDAL.Delete(maKH);
                if (isSuccess)
                {
                    LoadData();
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Xóa khách hàng bị lỗi, làm ơn thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }    
        }
        //Luu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
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
                    MessageBox.Show("Bạn cần nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    khachHang.NgayTao = DateTime.Today;
                    khachHang.NguoiTao = Program.CurrentUser.MaND;
                    isSuccess = _khachHangDAL.Create(khachHang);
                }
            }
            // Kiem tra co phai dang sua khach hang hay k?
            else if (lblCheck.Text == "s") 
            {
                khachHang.MaKH = int.Parse(txtMaKH.Text);
                khachHang.NgaySua = DateTime.Today;
                khachHang.NguoiSua = Program.CurrentUser.MaND;
                isSuccess = _khachHangDAL.Update(khachHang);

            }
            int selectedIndex;
            if (isSuccess)
            {
                selectedIndex = dgvKhachHang.CurrentRow.Index;
                LoadData();
                ThemMoi();
                ReSelectDataGridview(selectedIndex);
                MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Lưu khách hàng bị lỗi, làm ơn thử lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtCMND.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = txtTenKH.Enabled = dtpNgaySinh.Enabled = cbbGioiTinh.Enabled = false;
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

                btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
                KhachHang selected = (KhachHang)dgvKhachHang.CurrentRow.DataBoundItem;
                txtMaKH.Text = selected.MaKH.ToString();
                txtTenKH.Text = selected.HoTen;
                txtCMND.Text = selected.CMND;
                txtDiaChi.Text = selected.DiaChi;
                txtSDT.Text = selected.SDT;
                cbbGioiTinh.SelectedValue = selected.GioiTinh;
                dtpNgaySinh.Value = (DateTime)selected.NgaySinh;
            }
            txtCMND.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = txtTenKH.Enabled = dtpNgaySinh.Enabled = cbbGioiTinh.Enabled = false;
            btnLuu.Enabled = false;
        }
        //Tim kiem
        private void btnFind_Click(object sender, EventArgs e)
        {
            //DataTable table = new DataTable();
            //table = _khachHangDAL.LayDL();
            //DataView dv = new DataView(table);
            //dv.RowFilter = "[HoTen] Like '%" + txtTimKiem.Text + "%'";
            List<KhachHang> listkh = _khachHangDAL.GetAll();
            //dgvKhachHang.DataSource = dv;
            var listThanhVien = from ltv in listkh
                                where ltv.HoTen.StartsWith(txtTimKiem.Text)
                                select ltv;
            dgvKhachHang.DataSource = listThanhVien;
           // DataView dataView = (DataView)dgvKhachHang.DataSource;
           
        //    if(txtTimKiem.Text == "")
        //    {
        //        MessageBox.Show("Bạn cần nhập điều kiện tìm kiếm!");
        //        return;
        //    }
        //    else if(cbbTimKiemTheo.Text == "Mã khách hàng")
        //    {
        //        if (IsNumber(txtTimKiem.Text) == true)
        //        {
        //            int maKH = int.Parse(txtTimKiem.Text);
        //            KhachHang kh = _khachHangDAL.GetKhachHangByMaKH(maKH);
        //            dgvKhachHang.DataSource = kh;
        //        }
        //        else
        //            MessageBox.Show("Ma khach hang khong dung! Vui long nhap lai");
        //    }
        //    else
        //    {
        //        string tenKH = txtTimKiem.Text;
        //        List<KhachHang> listkh = _khachHangDAL.GetKhachHangByTenKH(tenKH);
        //        dgvKhachHang.DataSource = listkh;
        //    }
        }

        //Reload
        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadData();
            LoadDataCbbGioiTinh();
            LoadDataCbbTimKiemTheo();
            cbbTimKiemTheo.Text = "Mã khách hàng";
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
                    //LoadData();
                    return;
                }
                else
                {
                    if (IsNumber(txtTimKiem.Text) == true)
                    {
                        int maKH = int.Parse(txtTimKiem.Text);
                        dgvKhachHang.DataSource = khachHangs.Where(kh => kh.MaKH == maKH).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Điều kiện tìm kiếm không đúng, mã khách hàng phải là kiểu số, vui lòng xem lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTimKiem.Text = null;
                    }
                }
            }
            else
            {
                string tenKH = txtTimKiem.Text;
                dgvKhachHang.DataSource = khachHangs.Where(kh => kh.HoTen.ToLower().Contains(tenKH.ToLower())
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
