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
    public partial class frmQuanLyLoaiPhong : frmMDIChild
    {
        LoaiPhongDAL _loaiPhongDAL = new LoaiPhongDAL();
        List<LoaiPhong> _loaiPhongs;
        
        public frmQuanLyLoaiPhong()
        {
            InitializeComponent();
            dgvLoaiPhong.AutoGenerateColumns = false;
        }

        private void frmQuanLyLoaiPhong_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {

            _loaiPhongs = _loaiPhongDAL.GetAllForLoaiPhong();
            dgvLoaiPhong.DataSource = _loaiPhongs;
            lblCheck.Text = "t";
            //ReSelectDataGridview(0);
            ThemMoi();
            btnLuu.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            txtMaLoaiPH.Enabled = txtTenLoaiPH.Enabled = txtGiaGioDau.Enabled = txtGiaGioHai.Enabled = txtGiaGioTiepTheo.Enabled = txtGiaTheoNgay.Enabled = false;
        }

        public void ThemMoi()
        {
            txtTenLoaiPH.Enabled = txtGiaGioDau.Enabled = txtGiaGioHai.Enabled = txtGiaGioTiepTheo.Enabled = txtGiaTheoNgay.Enabled = true;
            txtMaLoaiPH.Text = txtTenLoaiPH.Text = txtGiaGioDau.Text = txtGiaGioHai.Text = txtGiaGioTiepTheo.Text = txtGiaTheoNgay.Text = string.Empty;
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
            txtTenLoaiPH.Enabled = txtGiaGioDau.Enabled = txtGiaGioHai.Enabled = txtGiaGioTiepTheo.Enabled = txtGiaTheoNgay.Enabled = true;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            var confirmResult = MessageBox.Show("Bạn có chắc là muốn xóa phòng này?",
                                    "Xác nhận",
                                    MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                LoaiPhong loaiPH = new LoaiPhong()
                {
                    MaLoaiPH = int.Parse(txtMaLoaiPH.Text),
                    NgaySua = DateTime.Today,
                    NguoiSua = Program.CurrentUser.MaND
                };
                bool isSuccess = true;
                //Xoa nhung chi can update tinh trang DaXoa cua loai phong
                isSuccess = _loaiPhongDAL.UpdateXoaForQLLoaiPhong(loaiPH);
                if (isSuccess)
                {
                    LoadData();
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Xóa loại phòng bị lỗi, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenLoaiPH.Text.Length == 0 || txtGiaGioDau.Text.Length == 0 
                || txtGiaGioHai.Text.Length == 0 || txtGiaGioTiepTheo.Text.Length == 0 || txtGiaTheoNgay.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Kiem tra gia gio dau
            if (IsNumber(txtGiaGioDau.Text) == false || Decimal.Parse(txtGiaGioDau.Text) < 0)
            {
                MessageBox.Show("Giá giờ đầu không hợp lệ, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if ( Decimal.Parse(txtGiaGioDau.Text) < 0)
            {
                MessageBox.Show("Giá giờ đầu không hợp lệ, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Kiem tra gia gio hai
            if (IsNumber(txtGiaGioHai.Text) == false || Decimal.Parse(txtGiaGioHai.Text) < 0)
            {
                MessageBox.Show("Giá giờ hai không hợp lệ, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (Decimal.Parse(txtGiaGioHai.Text) < 0)
            {
                MessageBox.Show("Giá giờ hai không hợp lệ, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Kiem tra gia gio tiep theo
            if (IsNumber(txtGiaGioTiepTheo.Text) == false || Decimal.Parse(txtGiaGioTiepTheo.Text) < 0)
            {
                MessageBox.Show("Giá giờ tiếp theo không hợp lệ, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (Decimal.Parse(txtGiaGioTiepTheo.Text) < 0)
            {
                MessageBox.Show("Giá giờ tiếp theo không hợp lệ, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Kiem tra gia theo ngay
            if (IsNumber(txtGiaTheoNgay.Text) == false || Decimal.Parse(txtGiaTheoNgay.Text) < 0)
            {
                MessageBox.Show("Giá theo ngày không hợp lệ, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (Decimal.Parse(txtGiaTheoNgay.Text) < 0)
            {
                MessageBox.Show("Giá theo ngày không hợp lệ, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Tao doi tuong phong
            LoaiPhong loaiPhong = new LoaiPhong()
            {
                
                TenLoaiPH = txtTenLoaiPH.Text,
                GiaGioDau = double.Parse(txtGiaGioDau.Text),
                GiaGioHai = double.Parse(txtGiaGioHai.Text),
                GiaGioTiepTheo = double.Parse(txtGiaGioTiepTheo.Text),
                GiaTheoNgay = double.Parse(txtGiaTheoNgay.Text),
            };
            bool isSuccess = true;
            // Kiem tra co phai dang them loai phong hay k?
            if (lblCheck.Text == "t")
            {
                _loaiPhongs = _loaiPhongDAL.GetAll();
                if (_loaiPhongs.Any(r => r.MaLoaiPH == loaiPhong.MaLoaiPH))//Kiem tra loai phong nay da ton tai thi cap nhat DaXoa = 0
                {
                    loaiPhong.NgaySua = DateTime.Today;
                    loaiPhong.NguoiSua = Program.CurrentUser.MaND;
                    isSuccess = _loaiPhongDAL.UpdateForQLPhong(loaiPhong);
                }
                else
                {
                    loaiPhong.DaXoa = false;
                    loaiPhong.NgayTao = DateTime.Today;
                    loaiPhong.NguoiTao = Program.CurrentUser.MaND;
                    isSuccess = _loaiPhongDAL.Create(loaiPhong);
                }

            }
            // Kiem tra co phai dang sua loai phong hay k?
            else if (lblCheck.Text == "s")
            {
               loaiPhong.MaLoaiPH = int.Parse(txtMaLoaiPH.Text);
                if (_loaiPhongs.Any(r => (r.TenLoaiPH != loaiPhong.TenLoaiPH || r.GiaGioDau != loaiPhong.GiaGioDau
                    || r.GiaGioHai != loaiPhong.GiaGioHai || r.GiaGioTiepTheo != loaiPhong.GiaGioTiepTheo
                    || r.GiaTheoNgay != loaiPhong.GiaTheoNgay)
                    && r.MaLoaiPH == loaiPhong.MaLoaiPH))
                {
                    loaiPhong.MaLoaiPH = int.Parse(txtMaLoaiPH.Text);
                    loaiPhong.NgaySua = DateTime.Today;
                    loaiPhong.NguoiSua = Program.CurrentUser.MaND;
                    isSuccess = _loaiPhongDAL.Update(loaiPhong);
                }
                else
                    return;

            }
            //int selectedIndex;
            if (isSuccess)
            {
                //selectedIndex = dgvLoaiPhong.CurrentRow.Index;
                MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK);
                LoadData();
                ThemMoi();
                //ReSelectDataGridview(selectedIndex);
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtMaLoaiPH.Enabled = false;
            }
            else
            {
                MessageBox.Show("Lưu loại phòng bị lỗi, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
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

        private void dgvLoaiPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvLoaiPhong == null) return;
            if (dgvLoaiPhong.CurrentRow.Selected)
            {

                btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
                LoaiPhong selected = (LoaiPhong)dgvLoaiPhong.CurrentRow.DataBoundItem;
                txtMaLoaiPH.Text = selected.MaLoaiPH.ToString();
                txtTenLoaiPH.Text = selected.TenLoaiPH;
                txtGiaGioDau.Text = selected.GiaGioDau.ToString();
                txtGiaGioHai.Text = selected.GiaGioHai.ToString();
                txtGiaGioTiepTheo.Text = selected.GiaGioTiepTheo.ToString();
                txtGiaTheoNgay.Text = selected.GiaTheoNgay.ToString();
            }
            txtMaLoaiPH.Enabled = txtTenLoaiPH.Enabled = txtGiaGioDau.Enabled = txtGiaGioHai.Enabled = txtGiaGioTiepTheo.Enabled = txtGiaTheoNgay.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            LoadData();
            btnThem.Enabled = true;
        }
    }
}
