namespace QLKS
{
    partial class frmQuanLyNguoiDung
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
            this.dgvNguoiDung = new System.Windows.Forms.DataGridView();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsAdmin = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NgayTao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.cbbNhanVien = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cheIsAdmin = new System.Windows.Forms.CheckBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThemMoi = new System.Windows.Forms.Button();
            this.lblMaND = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoiDung)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNguoiDung
            // 
            this.dgvNguoiDung.AllowUserToAddRows = false;
            this.dgvNguoiDung.AllowUserToDeleteRows = false;
            this.dgvNguoiDung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvNguoiDung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNguoiDung.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.HoTen,
            this.UserName,
            this.IsAdmin,
            this.NgayTao});
            this.dgvNguoiDung.Location = new System.Drawing.Point(12, 121);
            this.dgvNguoiDung.Name = "dgvNguoiDung";
            this.dgvNguoiDung.ReadOnly = true;
            this.dgvNguoiDung.Size = new System.Drawing.Size(894, 342);
            this.dgvNguoiDung.TabIndex = 0;
            this.dgvNguoiDung.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNguoiDung_CellClick);
            // 
            // HoTen
            // 
            this.HoTen.DataPropertyName = "HoTen";
            this.HoTen.HeaderText = "Họ Tên";
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            this.HoTen.Width = 200;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "Tên đăng nhập";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Width = 200;
            // 
            // IsAdmin
            // 
            this.IsAdmin.DataPropertyName = "IsAdmin";
            this.IsAdmin.HeaderText = "Là quản lý";
            this.IsAdmin.Name = "IsAdmin";
            this.IsAdmin.ReadOnly = true;
            // 
            // NgayTao
            // 
            this.NgayTao.DataPropertyName = "NgayTao";
            this.NgayTao.HeaderText = "Ngày tạo";
            this.NgayTao.Name = "NgayTao";
            this.NgayTao.ReadOnly = true;
            this.NgayTao.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nhân viên";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(383, 14);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(148, 20);
            this.txtUserName.TabIndex = 2;
            // 
            // cbbNhanVien
            // 
            this.cbbNhanVien.FormattingEnabled = true;
            this.cbbNhanVien.Location = new System.Drawing.Point(74, 12);
            this.cbbNhanVien.Name = "cbbNhanVien";
            this.cbbNhanVien.Size = new System.Drawing.Size(168, 21);
            this.cbbNhanVien.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(296, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tên đăng nhập";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(567, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mật khẩu";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(625, 12);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(148, 20);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // cheIsAdmin
            // 
            this.cheIsAdmin.AutoSize = true;
            this.cheIsAdmin.Location = new System.Drawing.Point(815, 14);
            this.cheIsAdmin.Name = "cheIsAdmin";
            this.cheIsAdmin.Size = new System.Drawing.Size(75, 17);
            this.cheIsAdmin.TabIndex = 8;
            this.cheIsAdmin.Text = "Là quản lý";
            this.cheIsAdmin.UseVisualStyleBackColor = true;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(74, 66);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 9;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Location = new System.Drawing.Point(167, 66);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(75, 23);
            this.btnThemMoi.TabIndex = 10;
            this.btnThemMoi.Text = "Thêm mới";
            this.btnThemMoi.UseVisualStyleBackColor = true;
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // lblMaND
            // 
            this.lblMaND.AutoSize = true;
            this.lblMaND.Location = new System.Drawing.Point(812, 44);
            this.lblMaND.Name = "lblMaND";
            this.lblMaND.Size = new System.Drawing.Size(78, 13);
            this.lblMaND.TabIndex = 11;
            this.lblMaND.Text = "Mã người dùng";
            this.lblMaND.Visible = false;
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(261, 66);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // frmQuanLyNguoiDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 475);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.lblMaND);
            this.Controls.Add(this.btnThemMoi);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.cheIsAdmin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbNhanVien);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvNguoiDung);
            this.Name = "frmQuanLyNguoiDung";
            this.Text = "Quản lý người dùng";
            this.Load += new System.EventHandler(this.frmQuanLyNguoiDung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoiDung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNguoiDung;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.ComboBox cbbNhanVien;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox cheIsAdmin;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.Label lblMaND;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsAdmin;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayTao;
    }
}

