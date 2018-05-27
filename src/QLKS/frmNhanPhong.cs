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
    public partial class frmNhanPhong : Form
    {
        KhachHangDAL _khDAL = new KhachHangDAL();
        ThuePhongDAL _thuePhongDAL = new ThuePhongDAL();
        PhongDAL _phongDAL = new PhongDAL();
        public Phong CurrentPhong {get; set;}
        public ThuePhong CurrentThuePhong { get; set; }

        public bool XacNhan = false;

      
        public frmNhanPhong()
        {
            InitializeComponent();
        }

        private void frmNhanPhong_Load(object sender, EventArgs e)
        {
            lblPhong.Text = CurrentPhong.MaPH.ToString();
            cbbKhachhang.DisplayMember = "HoTen";
            cbbKhachhang.ValueMember = "MaKH";
            cbbKhachhang.DataSource = _khDAL.GetAll();
            dtpNgaynhan.Value = DateTime.Now;
            
        }

        private void btnNhan_Click(object sender, EventArgs e)
        {
            if(lblPhong.Text.Length == 0 || cbbKhachhang.SelectedValue == null)
            {
                MessageBox.Show("Bạn cần nhập đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ThuePhong thuePhong = new ThuePhong()
            {
                MaKH = (int)cbbKhachhang.SelectedValue,
                MaPH = int.Parse(lblPhong.Text),
                NgayNhanPH = dtpNgaynhan.Value,
                SoLuongNguoi = (int) numSoLuongNguoi.Value,
                NguoiTao=Program.CurrentUser.MaND,
                NgayTao = DateTime.Today,
                HoTen = (string)cbbKhachhang.Text
                
            };

            CurrentThuePhong = _thuePhongDAL.Create(thuePhong);
            if (CurrentThuePhong != null)
            {
                MessageBox.Show("Nhận phòng thành công", "Thông báo", MessageBoxButtons.OK);
                _phongDAL.UpdateDangThue(thuePhong.MaPH);
                XacNhan = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Nhận phòng không thành công, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
