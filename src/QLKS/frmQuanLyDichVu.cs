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
    public partial class frmQuanLyDichVu : frmMDIChild
    {
        List<DichVu> dichVus;
        DichVuDAL _dichVuDAL = new DichVuDAL();
        public frmQuanLyDichVu()
        {
            InitializeComponent();
            dgvDSDV.AutoGenerateColumns = false;
        }

        private void frmQuanLyDichVu_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadDataCbbTimKiemTheo();
            cbbTimKiemTheo.Text = "Mã dịch vụ";
        }
        private void LoadData()
        {
            dichVus = _dichVuDAL.GetAll();
            dgvDSDV.DataSource = dichVus;
            lblCheck.Text = "t";
            //ReSelectDataGridview(0);
            ThemMoi();
            btnLuu.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            txtMaDV.Enabled = txtTenDV.Enabled = txtGia.Enabled= false;
        }

        private void ThemMoi()
        {
            txtTenDV.Enabled = txtGia.Enabled = true;
            txtMaDV.Text = string.Empty;
            txtTenDV.Text = string.Empty;
            txtGia.Text = string.Empty;
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
            txtTenDV.Enabled = txtGia.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Bạn có chắc là muốn xóa người dùng này?",
                                     "Xác nhận",
                                     MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                int maDV = int.Parse(txtMaDV.Text);
                bool isSuccess = _dichVuDAL.Delete(maDV);
                if (isSuccess)
                {
                    LoadData();
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Xóa dịch vụ bị lỗi, làm ơn thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }    
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            if (txtTenDV.Text.Length == 0 || txtGia.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(IsNumber(txtGia.Text) == false)
            {
                MessageBox.Show("Giá dịch vụ không hợp lệ, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Tao doi tuong dich vu
            DichVu dichVu= new DichVu()
            {
                TenDV = txtTenDV.Text,
                Gia = Decimal.Parse(txtGia.Text)
            };
            bool isSuccess = true;
            // Kiem tra co phai dang them dich vu hay k?
            if (lblCheck.Text == "t")
            {
             
                    dichVu.NgayTao = DateTime.Today;
                    dichVu.NguoiTao = Program.CurrentUser.MaND;
                    isSuccess = _dichVuDAL.Create(dichVu);
                
            }
            // Kiem tra co phai dang sua kdich vu hay k?
            else if (lblCheck.Text == "s")
            {
                dichVu.MaDV = int.Parse(txtMaDV.Text);
                dichVu.NgaySua = DateTime.Today;
                dichVu.NguoiSua = Program.CurrentUser.MaND;
                isSuccess = _dichVuDAL.Update(dichVu);

            }
            int selectedIndex;
            if (isSuccess)
            {
                selectedIndex = dgvDSDV.CurrentRow.Index;
                LoadData();
                ThemMoi();
                //ReSelectDataGridview(selectedIndex);
                MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK);
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtTenDV.Enabled = txtGia.Enabled = false;
            }
            else
            {
                MessageBox.Show("Lưu dịch vụ bị lỗi, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void dgvDSDV_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvDSDV == null) return;
            if (dgvDSDV.CurrentRow.Selected)
            {

                btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
                DichVu selected = (DichVu)dgvDSDV.CurrentRow.DataBoundItem;
                txtMaDV.Text = selected.MaDV.ToString();
                txtTenDV.Text = selected.TenDV;
                txtGia.Text =selected.Gia.ToString();
            }
            txtTenDV.Enabled = txtGia.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadData();
            LoadDataCbbTimKiemTheo();
            cbbTimKiemTheo.Text = "Mã dịch vụ";
        }
        public void LoadDataCbbTimKiemTheo()
        {
            cbbTimKiemTheo.Items.Clear();
            cbbTimKiemTheo.Items.Add("Mã dịch vụ");
            cbbTimKiemTheo.Items.Add("Tên tên dịch vụ");
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

            if (cbbTimKiemTheo.Text == "Mã dịch vụ")
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
                        int maDV = int.Parse(txtTimKiem.Text);
                        dgvDSDV.DataSource = dichVus.Where(dv => dv.MaDV == maDV).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Điều kiện tìm kiếm không đúng, mã dịch vụ phải là kiểu số, vui lòng xem lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTimKiem.Text = null;
                    }
                }
            }
            else
            {
                string tenDV = txtTimKiem.Text;
                dgvDSDV.DataSource = dichVus.Where(dv => dv.TenDV.ToLower().Contains(tenDV.ToLower())
                    || tenDV.ToLower().Contains(dv.TenDV.ToLower())).ToList();

            }
        }
    }
}
