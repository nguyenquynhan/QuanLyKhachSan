namespace QLKS
{
    partial class frmQuanLyLoaiPhong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCheck = new System.Windows.Forms.Label();
            this.btnReLoad = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGiaGioTiepTheo = new System.Windows.Forms.TextBox();
            this.txtTenLoaiPH = new System.Windows.Forms.TextBox();
            this.txtGiaTheoNgay = new System.Windows.Forms.TextBox();
            this.txtGiaGioDau = new System.Windows.Forms.TextBox();
            this.txtGiaGioHai = new System.Windows.Forms.TextBox();
            this.txtMaLoaiPH = new System.Windows.Forms.TextBox();
            this.dgvLoaiPhong = new System.Windows.Forms.DataGridView();
            this.MaLoaiPH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenLoaiPH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaGioDau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaGioHai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaGioTiepTheo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaTheoNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiPhong)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCheck
            // 
            this.lblCheck.AutoSize = true;
            this.lblCheck.Location = new System.Drawing.Point(61, 127);
            this.lblCheck.Name = "lblCheck";
            this.lblCheck.Size = new System.Drawing.Size(81, 13);
            this.lblCheck.TabIndex = 37;
            this.lblCheck.Text = "Them hoac sua";
            this.lblCheck.Visible = false;
            // 
            // btnReLoad
            // 
            this.btnReLoad.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnReLoad.Image = global::QLKS.Properties.Resources.reload;
            this.btnReLoad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReLoad.Location = new System.Drawing.Point(386, 143);
            this.btnReLoad.Name = "btnReLoad";
            this.btnReLoad.Size = new System.Drawing.Size(96, 36);
            this.btnReLoad.TabIndex = 36;
            this.btnReLoad.Text = "Reload";
            this.btnReLoad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReLoad.UseVisualStyleBackColor = true;
            this.btnReLoad.Click += new System.EventHandler(this.btnReLoad_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLuu.Image = global::QLKS.Properties.Resources.save;
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(291, 143);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(81, 36);
            this.btnLuu.TabIndex = 32;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXoa.Image = global::QLKS.Properties.Resources.Delete;
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(199, 143);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(79, 36);
            this.btnXoa.TabIndex = 33;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSua.Image = global::QLKS.Properties.Resources.save__2_;
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(111, 143);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(76, 36);
            this.btnSua.TabIndex = 34;
            this.btnSua.Text = "Sửa";
            this.btnSua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThem.Image = global::QLKS.Properties.Resources.insert__2_;
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(15, 143);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(83, 36);
            this.btnThem.TabIndex = 35;
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Giá theo ngày";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(280, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Giá giờ tiếp theo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(280, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Giá giờ hai";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Giá giờ đầu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tên loại phòng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Mã loại phòng";
            // 
            // txtGiaGioTiepTheo
            // 
            this.txtGiaGioTiepTheo.Location = new System.Drawing.Point(381, 99);
            this.txtGiaGioTiepTheo.Name = "txtGiaGioTiepTheo";
            this.txtGiaGioTiepTheo.Size = new System.Drawing.Size(100, 20);
            this.txtGiaGioTiepTheo.TabIndex = 6;
            // 
            // txtTenLoaiPH
            // 
            this.txtTenLoaiPH.Location = new System.Drawing.Point(102, 52);
            this.txtTenLoaiPH.Name = "txtTenLoaiPH";
            this.txtTenLoaiPH.Size = new System.Drawing.Size(100, 20);
            this.txtTenLoaiPH.TabIndex = 5;
            // 
            // txtGiaTheoNgay
            // 
            this.txtGiaTheoNgay.Location = new System.Drawing.Point(102, 95);
            this.txtGiaTheoNgay.Name = "txtGiaTheoNgay";
            this.txtGiaTheoNgay.Size = new System.Drawing.Size(100, 20);
            this.txtGiaTheoNgay.TabIndex = 4;
            // 
            // txtGiaGioDau
            // 
            this.txtGiaGioDau.Location = new System.Drawing.Point(381, 15);
            this.txtGiaGioDau.Name = "txtGiaGioDau";
            this.txtGiaGioDau.Size = new System.Drawing.Size(100, 20);
            this.txtGiaGioDau.TabIndex = 3;
            // 
            // txtGiaGioHai
            // 
            this.txtGiaGioHai.Location = new System.Drawing.Point(381, 52);
            this.txtGiaGioHai.Name = "txtGiaGioHai";
            this.txtGiaGioHai.Size = new System.Drawing.Size(100, 20);
            this.txtGiaGioHai.TabIndex = 2;
            // 
            // txtMaLoaiPH
            // 
            this.txtMaLoaiPH.Location = new System.Drawing.Point(102, 12);
            this.txtMaLoaiPH.Name = "txtMaLoaiPH";
            this.txtMaLoaiPH.Size = new System.Drawing.Size(100, 20);
            this.txtMaLoaiPH.TabIndex = 1;
            // 
            // dgvLoaiPhong
            // 
            this.dgvLoaiPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoaiPhong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaLoaiPH,
            this.TenLoaiPH,
            this.GiaGioDau,
            this.GiaGioHai,
            this.GiaGioTiepTheo,
            this.GiaTheoNgay});
            this.dgvLoaiPhong.Location = new System.Drawing.Point(16, 185);
            this.dgvLoaiPhong.Name = "dgvLoaiPhong";
            this.dgvLoaiPhong.Size = new System.Drawing.Size(652, 150);
            this.dgvLoaiPhong.TabIndex = 0;
            this.dgvLoaiPhong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoaiPhong_CellClick);
            // 
            // MaLoaiPH
            // 
            this.MaLoaiPH.DataPropertyName = "MaLoaiPH";
            this.MaLoaiPH.HeaderText = "Mã Loại Phòng";
            this.MaLoaiPH.Name = "MaLoaiPH";
            // 
            // TenLoaiPH
            // 
            this.TenLoaiPH.DataPropertyName = "TenLoaiPH";
            this.TenLoaiPH.HeaderText = "Tên  loại phòng";
            this.TenLoaiPH.Name = "TenLoaiPH";
            // 
            // GiaGioDau
            // 
            this.GiaGioDau.DataPropertyName = "GiaGioDau";
            this.GiaGioDau.HeaderText = "Giá giờ đầu";
            this.GiaGioDau.Name = "GiaGioDau";
            // 
            // GiaGioHai
            // 
            this.GiaGioHai.DataPropertyName = "GiaGioHai";
            this.GiaGioHai.HeaderText = "Giá giờ hai";
            this.GiaGioHai.Name = "GiaGioHai";
            // 
            // GiaGioTiepTheo
            // 
            this.GiaGioTiepTheo.DataPropertyName = "GiaGioTiepTheo";
            this.GiaGioTiepTheo.HeaderText = "Giá giờ tiếp theo";
            this.GiaGioTiepTheo.Name = "GiaGioTiepTheo";
            // 
            // GiaTheoNgay
            // 
            this.GiaTheoNgay.DataPropertyName = "GiaTheoNgay";
            this.GiaTheoNgay.HeaderText = "Giá Theo Ngày";
            this.GiaTheoNgay.Name = "GiaTheoNgay";
            // 
            // frmQuanLyLoaiPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 374);
            this.Controls.Add(this.lblCheck);
            this.Controls.Add(this.btnReLoad);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtGiaGioTiepTheo);
            this.Controls.Add(this.txtTenLoaiPH);
            this.Controls.Add(this.txtGiaTheoNgay);
            this.Controls.Add(this.txtGiaGioDau);
            this.Controls.Add(this.txtGiaGioHai);
            this.Controls.Add(this.txtMaLoaiPH);
            this.Controls.Add(this.dgvLoaiPhong);
            this.Name = "frmQuanLyLoaiPhong";
            this.Text = "frmQuanLyLoaiPhong";
            this.Load += new System.EventHandler(this.frmQuanLyLoaiPhong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiPhong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLoaiPhong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLoaiPH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenLoaiPH;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaGioDau;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaGioHai;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaGioTiepTheo;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaTheoNgay;
        private System.Windows.Forms.TextBox txtMaLoaiPH;
        private System.Windows.Forms.TextBox txtGiaGioHai;
        private System.Windows.Forms.TextBox txtGiaGioDau;
        private System.Windows.Forms.TextBox txtGiaTheoNgay;
        private System.Windows.Forms.TextBox txtTenLoaiPH;
        private System.Windows.Forms.TextBox txtGiaGioTiepTheo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnReLoad;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label lblCheck;
    }
}