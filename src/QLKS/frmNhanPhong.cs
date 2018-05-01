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
        public Phong CurrentPhong {get; set;}

        public frmNhanPhong()
        {
            InitializeComponent();
        }

        private void frmNhanPhong_Load(object sender, EventArgs e)
        {
            lblPhong.Text = CurrentPhong.MaPH.ToString();
            cbbKhachhang.DisplayMember = "HoTen";
            cbbKhachhang.ValueMember = "MaKH";
            cbbKhachhang.DataSource = _khDAL.GetTen();
            dtpNgaynhan.Value = DateTime.Now;
            
        }

        private void btnNhan_Click(object sender, EventArgs e)
        {

        }
    }
}
