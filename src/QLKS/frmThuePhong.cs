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
using System.Configuration;

namespace QLKS
{
    public partial class frmThuePhong : frmMDIChild
    {
        PhongDAL _phongDAL = new PhongDAL();
        LoaiPhongDAL _loaiphongDAL = new LoaiPhongDAL();
        ChiTietTienThuePhongDAL _ctTienPhongDAL = new ChiTietTienThuePhongDAL();
        ThuePhongDAL _thuePhongDAL = new ThuePhongDAL();
        DichVuDAL _dichvuDAl= new DichVuDAL();
        ChiTietDichVuThuePhongDAL _chitietDVTP = new ChiTietDichVuThuePhongDAL();
        public ThuePhong SelectedThuePhong { get; set; }
        
        public frmThuePhong()
        {
            InitializeComponent();
            dgvPhong.AutoGenerateColumns = false;
            dgvTienThuePhong.AutoGenerateColumns = false;
            dgvDichVu.AutoGenerateColumns = false;
            dgvTienThuePhong.AutoGenerateColumns = false;
        }
        private void frmThuePhong_Load(object sender, EventArgs e)
        {
            LoadDataPhong();
            LoadCbbDichVu();
            btnNhanPhong.Enabled = false;
            btnThemDichVu.Enabled = false;
            btnXoaDichVu.Enabled = false;
            btnThanhToan.Enabled = false;
            rdbGio.Checked = true;
        }
        private void LoadDataPhong()
        {
            List<Phong> phongs = _phongDAL.GetAlldgvPhong();
            dgvPhong.DataSource = phongs;
        }

        private void LoadDataNhanPhong()
        {
            lblPhong.Text = this.SelectedThuePhong.MaPH.ToString();
            lblSoLuong.Text = this.SelectedThuePhong.SoLuongNguoi.ToString();
            lblNgayNhan.Text = this.SelectedThuePhong.NgayNhanPH.ToString();
            lblKhachHang.Text = this.SelectedThuePhong.HoTen;
            if (SelectedThuePhong.IsNgay == false)
                rdbGio.Checked = true; 
            else
                rdbNgay.Checked = true;

        }
        private void btnNhanPhong_Click(object sender, EventArgs e)
        {
            frmNhanPhong frm = new frmNhanPhong();

            if (dgvPhong.CurrentRow.Selected)
            {
                int selectedIndex = dgvPhong.CurrentRow.Index;
                frm.CurrentPhong = (Phong)dgvPhong.CurrentRow.DataBoundItem;
                frm.ShowDialog();
                SelectedThuePhong = frm.CurrentThuePhong;
                if (frm.XacNhan == true)
                {
                    LoadDataPhong();
                    LoadDataNhanPhong();
                    ReSelectDataGridview(selectedIndex);
                    LoadDataDgvTienPhong();
                    TinhTongTien();
                    btnNhanPhong.Enabled = false;
                    btnThemDichVu.Enabled = true;
                    btnXoaDichVu.Enabled = true;
                    btnThanhToan.Enabled = true;
                }
            }       
        }

        private void ReSelectDataGridview(int selectedIndex)
        {
            for (int i = 0; i < dgvPhong.Rows.Count; i++)
            {
                for (int j = 0; j < dgvPhong.Columns.Count; j++)
                {
                    dgvPhong.Rows[i].Cells[j].Selected = false;
                }
            }
            dgvPhong.Rows[selectedIndex].Selected = true;
            dgvPhong.CurrentCell = dgvPhong.Rows[selectedIndex].Cells[0];
        }

        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {
                Phong selected = (Phong)dgv.CurrentRow.DataBoundItem;
                btnNhanPhong.Enabled = !selected.DangThue;
                btnThemDichVu.Enabled = selected.DangThue;
                btnXoaDichVu.Enabled = selected.DangThue;
                cbbDichVu.SelectedValue = 0;
                txtSoLuongDV.Text = "1";
                if(selected.DangThue)
                {
                    SelectedThuePhong = _thuePhongDAL.GetThuePhongByMaPH(selected.MaPH);
                    LoadDataNhanPhong();
                    LoadDataDgvDichVu();
                    LoadDataDgvTienPhong();
                    TinhTongTien();
                    btnThanhToan.Enabled = true;

                }
                else
                {
                    
                    lblPhong.Text = string.Empty;
                    lblKhachHang.Text = string.Empty;
                    lblSoLuong.Text = string.Empty;
                    lblNgayNhan.Text = string.Empty;
                    rdbGio.Checked = true;

                    //Load Tong Tien Phong
                    lblTienPhong.Text = "0";
                    lblTienDichVu.Text = "0";
                    lblTongTienThuePhong.Text = "0";

                    dgvDichVu.DataSource = null;
                    dgvTienThuePhong.DataSource = null;
                    btnThanhToan.Enabled = false;
                }
                
            }
            
        }

        private void LoadDataDgvTienPhong()
        {
            
            List<ChiTietTienThuePhong> tienPhongs = new List<ChiTietTienThuePhong>();
            if (dgvPhong.CurrentRow.Selected)
                {
                    Phong selected = (Phong)dgvPhong.CurrentRow.DataBoundItem;
                    LoaiPhong lp = _loaiphongDAL.GetByMaLoaiPH(selected.MaLoaiPH);

                    ChiTietTienThuePhong cttp1 = new ChiTietTienThuePhong();
                    if (rdbGio.Checked == true)
                    {
                        bool issucess0 = _thuePhongDAL.UpdateIsNgay0(SelectedThuePhong);
                        int minMinutetoHour = int.Parse(ConfigurationManager.AppSettings["minMinutetoHour"]);
                        cttp1.LoaiTienPhong = LoaiTienGioEnum.GioDau;
                        cttp1.SoLuong = 1;
                        cttp1.Gia = lp.GiaGioDau;
                        cttp1.ThanhTien = cttp1.SoLuong * cttp1.Gia;
                        tienPhongs.Add(cttp1);
                        int soPhutMotGio = 60;
                        TimeSpan kqTimeSpan = DateTime.Now - SelectedThuePhong.NgayNhanPH.Value;
                        double soPhutThue = kqTimeSpan.TotalMinutes;
                        if (soPhutThue >= (soPhutMotGio + minMinutetoHour))
                        {
                            ChiTietTienThuePhong cttp2 = new ChiTietTienThuePhong();
                            cttp2.LoaiTienPhong = LoaiTienGioEnum.GioHai;
                            cttp2.SoLuong = 1;
                            cttp2.Gia = lp.GiaGioHai;
                            cttp2.ThanhTien = cttp2.SoLuong * cttp2.Gia;
                            tienPhongs.Add(cttp2);
                        }
                        
                        if (soPhutThue >= (soPhutMotGio * 2 + minMinutetoHour))
                        {
                            double soLuongPhut = kqTimeSpan.TotalMinutes - 2 * soPhutMotGio;
                            double soGio = soLuongPhut / soPhutMotGio;
                            double soPhutLe = soLuongPhut % soPhutMotGio;
                            if (soPhutLe >= 10) soGio++;

                            ChiTietTienThuePhong cttp3 = new ChiTietTienThuePhong();
                            cttp3.LoaiTienPhong = LoaiTienGioEnum.GioTiepTheo;
                            cttp3.SoLuong = (int)soGio;
                            cttp3.Gia = lp.GiaGioTiepTheo;
                            cttp3.ThanhTien = cttp3.SoLuong * cttp3.Gia;
                            tienPhongs.Add(cttp3);
                        }
                    }
                    if(rdbNgay.Checked == true)
                    {
                        bool issucess1 = _thuePhongDAL.UpdateIsNgay1(SelectedThuePhong);
                        int checkOutTime = int.Parse(ConfigurationManager.AppSettings["checkOutTime"]);
                        int surchargeBeforeTime = int.Parse(ConfigurationManager.AppSettings["surchargeBeforeTime"]);
                        int surchargeAfterTime = int.Parse(ConfigurationManager.AppSettings["surchargeAfterTime"]);
                        /////////////
                        ThuePhong tp = _thuePhongDAL.GetThuePhongByMaPH(selected.MaPH);
                        int gioNhanPH = tp.NgayNhanPH.Value.Hour;
                        DateTime ngayNhanPH = tp.NgayNhanPH.Value;
                        DateTime ngayTraPH = tp.NgayTraPH != null ? tp.NgayTraPH.Value : DateTime.Now;
                        int gioTraPH = ngayTraPH.Hour;
                       
                        double nuaNgay = 0.5;
                        double motNgay = 1;
                        double soNgayThuePhong = 0;
                        //////////
                        if (gioNhanPH >= surchargeBeforeTime && gioNhanPH < checkOutTime)
                        {
                            soNgayThuePhong += nuaNgay;
                            ngayNhanPH = new DateTime(ngayNhanPH.Year, ngayNhanPH.Month, ngayNhanPH.Day, checkOutTime, 0, 0);
                        }
                        //
                        if (gioTraPH <= checkOutTime)
                        {
                            TimeSpan temp = (TimeSpan)(ngayTraPH - ngayNhanPH);
                            soNgayThuePhong += Math.Ceiling(temp.TotalDays);
                        }
                        else if (gioTraPH > checkOutTime && gioTraPH <= surchargeAfterTime)
                        {
                            DateTime checkoutTimeTemp = new DateTime(ngayTraPH.Year, ngayTraPH.Month, ngayTraPH.Day, checkOutTime, 0, 0);
                            TimeSpan a = (TimeSpan)(checkoutTimeTemp - ngayNhanPH);
                            soNgayThuePhong += Math.Ceiling(a.TotalDays) + nuaNgay;
                        }
                        else
                        {
                            DateTime checkoutTimeTemp = new DateTime(ngayTraPH.Year, ngayTraPH.Month, ngayTraPH.Day, checkOutTime, 0, 0);
                            TimeSpan a = (TimeSpan)(checkoutTimeTemp - ngayNhanPH);
                            soNgayThuePhong += Math.Ceiling(a.TotalDays) + motNgay;
		
                        }
                        
                        cttp1.LoaiTienPhong = LoaiTienGioEnum.GioTheoNgay;
                        cttp1.SoLuong = soNgayThuePhong;
                        cttp1.Gia = lp.GiaTheoNgay;
                        cttp1.ThanhTien = soNgayThuePhong * lp.GiaTheoNgay;
                        tienPhongs.Add(cttp1);
                    }

                }
            dgvTienThuePhong.DataSource = tienPhongs;
        }

        private void LoadCbbDichVu()
        {
            cbbDichVu.DisplayMember="TenDV";
            cbbDichVu.ValueMember="MaDV";
            cbbDichVu.DataSource = _dichvuDAl.GetAllEXISTING();
        }

        private void btnThemDichVu_Click(object sender, EventArgs e)
        {
            DichVu SelectedDichVu;
            if(cbbDichVu.SelectedValue != null)
                SelectedDichVu = _dichvuDAl.GetDichVuByMaDV((int)cbbDichVu.SelectedValue);
            else
            {
                MessageBox.Show("Vui lòng chọn dịch vụ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (int.Parse(txtSoLuongDV.Text) < 1)
            {
                MessageBox.Show("Số lượng dịch vụ không hợp lệ, vui lòng xem lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ChiTietDichVuThuePhong chiTietDVTP = new ChiTietDichVuThuePhong()
            {
                MaTP = SelectedThuePhong.MaTP,
                MaDV =(int)cbbDichVu.SelectedValue,
                Gia = (double)SelectedDichVu.Gia,
                SoLuong = int.Parse(txtSoLuongDV.Text),
                ThanhTien = (double)SelectedDichVu.Gia * (int.Parse(txtSoLuongDV.Text)),
                NgayTao = DateTime.Now,
                NguoiTao = Program.CurrentUser.MaND 
            };
            // Đua data ChiTietDichVuThuePhong vao list
            //List<ChiTietDichVuThuePhong> ctdvtps = new List<ChiTietDichVuThuePhong>();
            //dgvDichVu.DataSource = ctdvtps;

            //Lay data o datasource len kiem tra xem them dich vu co trung khong
            List<ChiTietDichVuThuePhong> CTDVTPS = _chitietDVTP.GetChiTietDVTPByMaTP(chiTietDVTP.MaTP);
            bool isSuccess = true;
            if (CTDVTPS.Any(r => (r.MaDV == chiTietDVTP.MaDV)))
                isSuccess = _chitietDVTP.UpdateDV(chiTietDVTP);
            else
                isSuccess = _chitietDVTP.Create(chiTietDVTP);
            if (isSuccess)
            {
                LoadDataDgvDichVu();
                TinhTongTien();
            }
            else
                MessageBox.Show("Thêm mới thất bại, vui lòng xem lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void LoadDataDgvDichVu()
        {
            List<ChiTietDichVuThuePhong> chiTietDVTPs = _chitietDVTP.GetByMaTP(SelectedThuePhong.MaTP);
            dgvDichVu.DataSource = chiTietDVTPs;
        }

        private void dgvDichVu_CellClick(object sender, DataGridViewCellEventArgs e)
        {           
            if (dgvDichVu.CurrentRow.Selected)
            {
                ChiTietDichVuThuePhong selected = (ChiTietDichVuThuePhong)dgvDichVu.CurrentRow.DataBoundItem;
                txtSoLuongDV.Text = selected.SoLuong.ToString();
                cbbDichVu.SelectedValue = selected.MaDV;
            }
        }

        private void btnXoaDichVu_Click(object sender, EventArgs e)
        {
            if (dgvDichVu.CurrentRow.Selected)
            {
                ChiTietDichVuThuePhong selected = (ChiTietDichVuThuePhong)dgvDichVu.CurrentRow.DataBoundItem;
                var confirmResult = MessageBox.Show("Bạn có chắc là muốn xóa dịch vụ này?",
                                         "Xác nhận",
                                         MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    bool isSuccess = _chitietDVTP.Delete(selected.MaCTDVTP);
                    if (isSuccess)
                    {
                        LoadDataDgvDichVu();
                        TinhTongTien();
                    }
                    else
                    {
                        MessageBox.Show("Xóa người dùng bị lỗi, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
                MessageBox.Show("Vui lòng chọn dịch vụ cần xóa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void TinhTongTien()
        {
            List<ChiTietTienThuePhong> cttps = (List<ChiTietTienThuePhong>)dgvTienThuePhong.DataSource;
            double tongTienPhong = (double)cttps.Sum(r => r.ThanhTien);
            lblTienPhong.Text = tongTienPhong.ToString("#,##0");

            List<ChiTietDichVuThuePhong> ctdvs = (List<ChiTietDichVuThuePhong>)dgvDichVu.DataSource;
            double tongTienDichVu = 0;
            if (ctdvs != null && ctdvs.Count > 0 )
            {
                tongTienDichVu = (double)ctdvs.Sum(r => r.ThanhTien);
                lblTienDichVu.Text = tongTienDichVu.ToString("#,##0"); 
            }
            else
                lblTienDichVu.Text = "0";

            //Tong Tien Thue Phong
            lblTongTienThuePhong.Text = (tongTienPhong + tongTienDichVu).ToString("#,##0");

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {

            //Update Thue phong
            bool isSuccessTP = true;
            SelectedThuePhong.NgayTraPH = DateTime.Now;
            SelectedThuePhong.TongTien = float.Parse(lblTongTienThuePhong.Text.ToString());
            SelectedThuePhong.TongTienPH = float.Parse(lblTienPhong.Text.ToString());
            SelectedThuePhong.TongTienDV = float.Parse(lblTienDichVu.Text.ToString());
            SelectedThuePhong.NgaySua = DateTime.Now;
            SelectedThuePhong.NguoiSua = Program.CurrentUser.MaND;
            isSuccessTP = _thuePhongDAL.UpdateThuePhong(SelectedThuePhong);

            //Update Phong
            bool isSuccessPH = true;
            Phong selected = (Phong)dgvPhong.CurrentRow.DataBoundItem;
            selected.NgaySua = DateTime.Now;
            selected.NguoiSua = Program.CurrentUser.MaND;
            isSuccessPH = _phongDAL.UpdatePhong(selected);

            //Create Chi tiet tien thue phong
            List<ChiTietTienThuePhong> cttps = (List<ChiTietTienThuePhong>)dgvTienThuePhong.DataSource;
            bool isSuccessCtttp = true;
            foreach(ChiTietTienThuePhong value in cttps)
            {
                value.NguoiTao = Program.CurrentUser.MaND;
                value.NgayTao = DateTime.Now;
                value.MaTP = SelectedThuePhong.MaTP;
                isSuccessCtttp = _ctTienPhongDAL.Create(value);
            }
                    
            //Kiem tra
            if (isSuccessTP && isSuccessPH && isSuccessCtttp)
            {
                LoadDataPhong();
                dgvDichVu.DataSource = null;
                dgvTienThuePhong.DataSource = null;
                SelectedThuePhong = null;
                lblTienDichVu.Text = lblTienPhong.Text = lblTongTienThuePhong.Text = "0";
                MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButtons.OK);
                
            }
            else
            {
                MessageBox.Show("Thanh toán thất bại, vui lòng xem lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbGio_Click(object sender, EventArgs e)
        {
            Phong selected = (Phong)dgvPhong.CurrentRow.DataBoundItem;
            if (selected.DangThue == true)
            { 
                LoadDataDgvTienPhong();
                TinhTongTien();
            }
            else
                return;
        }

        private void rdbNgay_Click(object sender, EventArgs e)
        {
            Phong selected = (Phong)dgvPhong.CurrentRow.DataBoundItem;
            if (selected.DangThue == true)
            {
                LoadDataDgvTienPhong();
                TinhTongTien();
            }
            else
                return;
        }
        
    }
}
