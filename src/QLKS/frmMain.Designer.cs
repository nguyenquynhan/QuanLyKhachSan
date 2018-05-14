namespace QLKS
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.heThongMenuItem = new System.Windows.Forms.MenuItem();
            this.qlNguoiDungMenuItem = new System.Windows.Forms.MenuItem();
            this.qlNguoiDungMenuItemLine = new System.Windows.Forms.MenuItem();
            this.thoatMenuItem = new System.Windows.Forms.MenuItem();
            this.danhMucMenuItem = new System.Windows.Forms.MenuItem();
            this.qlLoaiPhongMenuItem = new System.Windows.Forms.MenuItem();
            this.qlDichVuMenuItem = new System.Windows.Forms.MenuItem();
            this.qlKhachHangMenuItem = new System.Windows.Forms.MenuItem();
            this.qlNhanVienMenuItem = new System.Windows.Forms.MenuItem();
            this.qlThuePhongMenuItem = new System.Windows.Forms.MenuItem();
            this.baoCaoMenuItem = new System.Windows.Forms.MenuItem();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.heThongMenuItem,
            this.danhMucMenuItem,
            this.baoCaoMenuItem});
            // 
            // heThongMenuItem
            // 
            this.heThongMenuItem.Index = 0;
            this.heThongMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.qlNguoiDungMenuItem,
            this.qlNguoiDungMenuItemLine,
            this.thoatMenuItem});
            this.heThongMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlH;
            this.heThongMenuItem.Text = "&Hệ thống";
            // 
            // qlNguoiDungMenuItem
            // 
            this.qlNguoiDungMenuItem.Index = 0;
            this.qlNguoiDungMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.qlNguoiDungMenuItem.Tag = "frmQuanLyNguoiDung";
            this.qlNguoiDungMenuItem.Text = "Quản lý &người dùng";
            // 
            // qlNguoiDungMenuItemLine
            // 
            this.qlNguoiDungMenuItemLine.Index = 1;
            this.qlNguoiDungMenuItemLine.Text = "-";
            // 
            // thoatMenuItem
            // 
            this.thoatMenuItem.Index = 2;
            this.thoatMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlT;
            this.thoatMenuItem.Tag = "Thoat";
            this.thoatMenuItem.Text = "&Thoát";
            // 
            // danhMucMenuItem
            // 
            this.danhMucMenuItem.Index = 1;
            this.danhMucMenuItem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.qlLoaiPhongMenuItem,
            this.qlDichVuMenuItem,
            this.qlKhachHangMenuItem,
            this.qlNhanVienMenuItem,
            this.qlThuePhongMenuItem});
            this.danhMucMenuItem.Text = "&Danh mục";
            // 
            // qlLoaiPhongMenuItem
            // 
            this.qlLoaiPhongMenuItem.Index = 0;
            this.qlLoaiPhongMenuItem.Text = "Quản lý loại phòng";
            // 
            // qlDichVuMenuItem
            // 
            this.qlDichVuMenuItem.Index = 1;
            this.qlDichVuMenuItem.Text = "Quản lý dịch vụ";
            // 
            // qlKhachHangMenuItem
            // 
            this.qlKhachHangMenuItem.Index = 2;
            this.qlKhachHangMenuItem.Text = "Quản lý khách hàng";
            // 
            // qlNhanVienMenuItem
            // 
            this.qlNhanVienMenuItem.Index = 3;
            this.qlNhanVienMenuItem.Text = "Quản lý nhân viên";
            // 
            // qlThuePhongMenuItem
            // 
            this.qlThuePhongMenuItem.Index = 4;
            this.qlThuePhongMenuItem.Tag = "frmThuePhong";
            this.qlThuePhongMenuItem.Text = "Quản lý thuê phòng";
            // 
            // baoCaoMenuItem
            // 
            this.baoCaoMenuItem.Index = 2;
            this.baoCaoMenuItem.Text = "Báo cáo";
            // 
            // tabControlMain
            // 
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControlMain.Font = new System.Drawing.Font("Arial", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(632, 24);
            this.tabControlMain.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControlMain.TabIndex = 2;
            this.tabControlMain.Visible = false;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.tabControlMain);
            this.IsMdiContainer = true;
            this.Menu = this.mainMenu;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý khách sạn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.MainMenu mainMenu;
        private System.Windows.Forms.MenuItem heThongMenuItem;
        private System.Windows.Forms.MenuItem qlNguoiDungMenuItem;
        private System.Windows.Forms.MenuItem qlNguoiDungMenuItemLine;
        private System.Windows.Forms.MenuItem thoatMenuItem;
        private System.Windows.Forms.MenuItem danhMucMenuItem;
        private System.Windows.Forms.MenuItem qlLoaiPhongMenuItem;
        private System.Windows.Forms.MenuItem qlDichVuMenuItem;
        private System.Windows.Forms.MenuItem qlKhachHangMenuItem;
        private System.Windows.Forms.MenuItem qlNhanVienMenuItem;
        private System.Windows.Forms.MenuItem baoCaoMenuItem;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.MenuItem qlThuePhongMenuItem;
    }
}



