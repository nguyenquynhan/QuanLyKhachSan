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
    public partial class frmDanhSachHoaDon : frmMDIChild
    {
        List<ThuePhong> _thuePhongs;
        ThuePhongDAL _thuePhongDAl = new ThuePhongDAL();
        
        public frmDanhSachHoaDon()
        {
            InitializeComponent();
            dgvDSHD.AutoGenerateColumns = false;
        }

        private void frmDanhSachHoaDon_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadDataCbbTimKiemTheo();
            cbbTimKiemTheo.Text = "Mã thuê phòng";
        }

        private void LoadData()
        {
            _thuePhongs = _thuePhongDAl.GetHoaDonThuePhong();
            dgvDSHD.DataSource = _thuePhongs;
            //lblCheck.Text = "t";
            ////ReSelectDataGridview(0);
            //ThemMoi();
            //btnLuu.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            //txtMaDV.Enabled = txtTenDV.Enabled = txtGia.Enabled = false;
        }

        public void LoadDataCbbTimKiemTheo()
        {
            cbbTimKiemTheo.Items.Clear();
            cbbTimKiemTheo.Items.Add("Mã thuê phòng");
            cbbTimKiemTheo.Items.Add("Mã phòng");
            cbbTimKiemTheo.Items.Add("Tên loại phòng");
            cbbTimKiemTheo.Items.Add("Tên khách hàng");
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            TimKiem();
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

        //Tim kiem theo ngay tra phong
        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            TimKiem();
        }

        private void TimKiem()
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date;
            if (denNgay < tuNgay)
            { 
                MessageBox.Show("Điều kiện tìm kiếm không đúng, vui lòng xem lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var thuePhongTemps = _thuePhongs.Where(tp => tp.NgayTraPH.Value.Date >= tuNgay && tp.NgayTraPH.Value.Date <= denNgay);
            if (cbbTimKiemTheo.SelectedItem != null && txtTimKiem.Text.Length > 0)
            {
                // Tim theo ma thue phong
                if (cbbTimKiemTheo.Text == "Mã thuê phòng")
                {
                        if (IsNumber(txtTimKiem.Text) == true)
                        {
                            int maTP = int.Parse(txtTimKiem.Text);
                            thuePhongTemps = thuePhongTemps.Where(tp => tp.MaTP == maTP).ToList();
                        }
                        else
                        {
                            MessageBox.Show("Điều kiện tìm kiếm không đúng, mã thuê phòng phải là kiểu số, vui lòng xem lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtTimKiem.Text = null;
                            LoadData();
                            return;
                        }
                   
                }
                //Tim theo ma phong
                else if (cbbTimKiemTheo.Text == "Mã phòng")
                {
                    
                        if (IsNumber(txtTimKiem.Text) == true)
                        {
                            int maPH = int.Parse(txtTimKiem.Text);
                            thuePhongTemps = thuePhongTemps.Where(tp => tp.MaPH == maPH).ToList();
                        }
                        else
                        {
                            MessageBox.Show("Điều kiện tìm kiếm không đúng,mã phòng phải là kiểu số, vui lòng xem lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtTimKiem.Text = null;
                            LoadData();
                            return;
                        }
                    
                }
                //Tim theo ten loai phong
                else if (cbbTimKiemTheo.Text == "Tên loại phòng")
                {
                    string tenLoaiPH = txtTimKiem.Text;
                    thuePhongTemps = thuePhongTemps.Where(tp => tp.TenLoaiPH.ToLower().Contains(tenLoaiPH.ToLower())
                        || tenLoaiPH.ToLower().Contains(tp.TenLoaiPH.ToLower())).ToList();
                }
                else
                {
                    string tenKH = txtTimKiem.Text;
                    thuePhongTemps = thuePhongTemps.Where(tp => tp.HoTen.ToLower().Contains(tenKH.ToLower())
                        || tenKH.ToLower().Contains(tp.HoTen.ToLower())).ToList();
                }

            }
            dgvDSHD.DataSource = thuePhongTemps.ToList();
        }

        private void dgvDSHD_DoubleClick(object sender, EventArgs e)
        {
            
            frmChiTietHoaDon frm = new frmChiTietHoaDon();
            frm.CurrentThuePhong = (ThuePhong)dgvDSHD.CurrentRow.DataBoundItem;
            frm.ShowDialog();
            
        }
        
      
    }
}
