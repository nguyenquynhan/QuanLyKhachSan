using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            PhanQuyen();

            //Regist event click menu item
            foreach(MenuItem menu in mainMenu.MenuItems)
            {
                foreach (MenuItem subMenu in menu.MenuItems)
                {
                    subMenu.Click += MenuItem_Click;
                }
            }            
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            MenuItem currentMenu = (MenuItem)sender;
            frmMDIChild childForm = null;
            if (currentMenu.Tag.Equals(qlNguoiDungMenuItem.Tag))
                childForm = new frmQuanLyNguoiDung();
            else if (currentMenu.Tag.Equals(qlThuePhongMenuItem.Tag))
                childForm = new frmThuePhong();
            
            //Add any other form at here
            else if (currentMenu.Tag.Equals(thoatMenuItem.Tag))
            {
                Close();
            }

            if(childForm != null)
                childForm.ShowInParent(this, tabControlMain);
        }

        private void PhanQuyen()
        {
            //Nếu không phải là quản lý thì ẩn menu quản lý người dùng
            if (!Program.CurrentUser.IsAdmin)
            {
                qlNguoiDungMenuItem.Visible = false;
                qlNguoiDungMenuItemLine.Visible = false;
            }
        }

        private void tabControlMain_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            foreach (frmMDIChild childForm in this.MdiChildren)
            {
                //Check for its corresponding MDI child form
                if (childForm.TabPag.Equals(tabControlMain.SelectedTab))
                {
                    //Activate the MDI child form
                    childForm.Select();
                }
            }
        }

    }
}
