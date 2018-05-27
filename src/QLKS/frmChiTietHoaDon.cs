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
    public partial class frmChiTietHoaDon : Form
    {
        ChiTietTienThuePhongDAL _ctTienPhongDAL = new ChiTietTienThuePhongDAL();
        ChiTietDichVuThuePhongDAL _chitietDVTPDAL = new ChiTietDichVuThuePhongDAL();
        public ThuePhong CurrentThuePhong { get; set; }
        public frmChiTietHoaDon()
        {
            InitializeComponent();
            dgvTienThuePhong.AutoGenerateColumns = false;
            dgvDichVu.AutoGenerateColumns = false;
        }

        private void frmChiTietHoaDon_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        public void LoadData()
        {
            List<ChiTietTienThuePhong> ctttps = _ctTienPhongDAL.GetByMaTP(CurrentThuePhong.MaTP);
            dgvTienThuePhong.DataSource = ctttps;
            List<ChiTietDichVuThuePhong> ctdvtps = _chitietDVTPDAL.GetByMaTP(CurrentThuePhong.MaTP);
            dgvDichVu.DataSource = ctdvtps;
            lblPH.Text = CurrentThuePhong.MaPH.ToString();
            lblKH.Text = CurrentThuePhong.HoTen;
            lblLP.Text = CurrentThuePhong.TenLoaiPH;
            lblSL.Text = CurrentThuePhong.SoLuongNguoi.ToString();
            lblNgayN.Text = CurrentThuePhong.NgayNhanPH.ToString();
            lblNgayT.Text = CurrentThuePhong.NgayTraPH.ToString();
            lblTongTienPH.Text = CurrentThuePhong.TongTienPH.HasValue ? CurrentThuePhong.TongTienPH.Value.ToString("#,##0") : "0";
            lblTongTienDV.Text = CurrentThuePhong.TongTienDV.HasValue ? CurrentThuePhong.TongTienDV.Value.ToString("#,##0") : "0";
            lblTongTien.Text = CurrentThuePhong.TongTien.Value.ToString("#,##0");
            
        }
    }
}
