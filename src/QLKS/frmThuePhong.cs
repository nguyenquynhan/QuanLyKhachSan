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
    public partial class frmThuePhong : frmMDIChild
    {
        PhongDAL _phongDAL = new PhongDAL();
        ChiTietTienThuePhongDAL _ctTienPhongDAL = new ChiTietTienThuePhongDAL();
        public frmThuePhong()
        {
            InitializeComponent();
            dgvPhong.AutoGenerateColumns = false;
            dgvTienPhong.AutoGenerateColumns = false;
        }
        private void frmThuePhong_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            List<Phong> phongs = _phongDAL.GetAlldgvPhong();
            dgvPhong.DataSource = phongs;
        }

        private void btnNhanPhong_Click(object sender, EventArgs e)
        {
            frmNhanPhong frm = new frmNhanPhong();

            if (dgvPhong.CurrentRow.Selected)
            {
                frm.CurrentPhong = (Phong)dgvPhong.CurrentRow.DataBoundItem;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn cần chọn phòng cần nhận!");
                return;
            }

            
        }
    }
}
