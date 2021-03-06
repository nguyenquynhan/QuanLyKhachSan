﻿using System;
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
    public partial class frmQuanLyPhong : frmMDIChild
    {
        List<Phong> _phongs;
        PhongDAL _phongDAL = new PhongDAL();
        LoaiPhongDAL _loaiPhongDAL = new LoaiPhongDAL();
        ThuePhongDAL _thuePhongDAL = new ThuePhongDAL();
        ChiTietDichVuThuePhongDAL _ctdvDAL = new ChiTietDichVuThuePhongDAL();
        public frmQuanLyPhong()
        {
            InitializeComponent();
            dgvQLPhong.AutoGenerateColumns = false;
        }

        private void frmQuanLyPhong_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadCbbLoaiPhong();
            cbbLoaiPhong.Enabled = false;
        }

        private void LoadData()
        {
            _phongs = _phongDAL.GetAlldgvPhong();
            dgvQLPhong.DataSource = _phongs;
            lblCheck.Text = "t";
            //ReSelectDataGridview(0);
            ThemMoi();
            btnLuu.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
        }

        public void ThemMoi()
        {
            txtSoPhong.Text = string.Empty;
            txtSoPhong.Enabled = true;
            cbbLoaiPhong.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            cbbLoaiPhong.SelectedValue = 1;
        }

        public void LoadCbbLoaiPhong()
        {
            cbbLoaiPhong.ValueMember = "MaLoaiPH";
            cbbLoaiPhong.DisplayMember = "TenLoaiPH";
            cbbLoaiPhong.DataSource = _loaiPhongDAL.GetAllForLoaiPhong();
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
            txtSoPhong.Enabled = btnThem.Enabled = btnXoa.Enabled = false;
            cbbLoaiPhong.Enabled =  btnLuu.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            var confirmResult = MessageBox.Show("Bạn có chắc là muốn xóa phòng này?",
                                    "Xác nhận",
                                    MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                Phong phong = new Phong()
                {
                    MaPH = int.Parse(txtSoPhong.Text),
                    MaLoaiPH = (int)cbbLoaiPhong.SelectedValue,
                    NgaySua = DateTime.Today,
                    NguoiSua = Program.CurrentUser.MaND
                };
                bool isSuccess = true;
                //Xoa nhung chi can update tinh trang DaXoa cua phong
                isSuccess = _phongDAL.UpdateXoaForQLPhong(phong);
                if (isSuccess)
                {
                    LoadData();
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Xóa phòng bị lỗi, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

            if (txtSoPhong.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (IsNumber(txtSoPhong.Text) == false)
            {
                MessageBox.Show("Số phòng không hợp lệ, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Tao doi tuong phong
            Phong phong = new Phong()
            {
                MaPH = int.Parse(txtSoPhong.Text),
                MaLoaiPH = (int)cbbLoaiPhong.SelectedValue
            };
            bool isSuccess = true;
            // Kiem tra co phai dang them phong hay k?
            if (lblCheck.Text == "t")
            {
                _phongs = _phongDAL.GetAll();
                if (_phongs.Any(r => r.MaPH == phong.MaPH && r.DaXoa == true))//Kiem tra phong nay da ton tai thi cap nhat DaXoa = 0
                {
                    phong.NgaySua = DateTime.Today;
                    phong.NguoiSua = Program.CurrentUser.MaND;
                    isSuccess = _phongDAL.UpdateForQLPhong(phong);
                }
                else if (_phongs.Any(r => r.MaPH == phong.MaPH && r.DaXoa == false))
                {
                    MessageBox.Show("Phòng này đã tồn tại, vui lòng xem lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    phong.DaXoa = false;
                    phong.NgayTao = DateTime.Today;
                    phong.NguoiTao = Program.CurrentUser.MaND;
                    isSuccess = _phongDAL.Create(phong);
                }

            }
            // Kiem tra co phai dang sua phong hay k?
            else if (lblCheck.Text == "s")
            {
                if (_phongs.Any(r => r.MaLoaiPH != phong.MaLoaiPH
                    && r.MaPH == phong.MaPH))//Kiem tra neu khong sua gi het nhung van nhan luu
                {
                    phong.MaPH = int.Parse(txtSoPhong.Text);
                    phong.NgaySua = DateTime.Today;
                    phong.NguoiSua = Program.CurrentUser.MaND;
                    isSuccess = _phongDAL.Update(phong);
                }
                else
                    return;

            }
            int selectedIndex;
            if (isSuccess)
            {
                selectedIndex = dgvQLPhong.CurrentRow.Index;
                LoadData();
                ThemMoi();
                //ReSelectDataGridview(selectedIndex);
                MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK);
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                txtSoPhong.Enabled = false;
            }
            else
            {
                MessageBox.Show("Lưu phòng bị lỗi, vui lòng thử lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dgvQLPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvQLPhong == null) return;
            if (dgvQLPhong.CurrentRow.Selected)
            {

                btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
                Phong selected = (Phong)dgvQLPhong.CurrentRow.DataBoundItem;
                txtSoPhong.Text = selected.MaPH.ToString();
                cbbLoaiPhong.SelectedValue = selected.MaLoaiPH;
            }
            txtSoPhong.Enabled = cbbLoaiPhong.Enabled = false;
            btnLuu.Enabled = false;
        }

        private void btnReLoad_Click(object sender, EventArgs e)
        {
            txtSoPhong.Text = string.Empty;
            cbbLoaiPhong.SelectedValue = 1;
            cbbLoaiPhong.Enabled = false;
            txtSoPhong.Enabled = btnThem.Enabled = true;
        }
        
    }
}
