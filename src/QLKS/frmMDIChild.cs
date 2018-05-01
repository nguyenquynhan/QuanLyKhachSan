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
    public partial class frmMDIChild : Form
    {
        //private Container _components = null;
        private TabControl tabCtrl;
        private TabPage tabPag;

        public frmMDIChild()
        {
            InitializeComponent();
        }
        
        public TabPage TabPag
        {
            get
            {
                return tabPag;
            }
            set
            {
                tabPag = value;
            }
        }

        public TabControl TabCtrl
        {
            set
            {
                tabCtrl = value;
            }
        }

        public void ShowInParent(Form mdiParent, TabControl tabControlMain)
        {
            this.MdiParent = mdiParent;

            //child Form will now hold a reference value to the tab control
            this.TabCtrl = tabControlMain;

            //Add a Tabpage and enables it
            TabPage tp = new TabPage();
            tp.Parent = tabControlMain;
            tp.Text = this.Text;
            tp.Show();

            //child Form will now hold a reference value to a tabpage
            this.TabPag = tp;

            //Activate the MDI child form
            this.Show();

            //Activate the newly created Tabpage
            tabControlMain.SelectedTab = tp;
        }
        
        private void MDIChild_Activated(object sender, System.EventArgs e)
        {
            //Activate the corresponding Tabpage
            tabCtrl.SelectedTab = tabPag;

            if (!tabCtrl.Visible)
            {
                tabCtrl.Visible = true;
            }
        }

        private void MDIChild_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Destroy the corresponding Tabpage when closing MDI child form
            this.tabPag.Dispose();

            //If no Tabpage left
            if (!tabCtrl.HasChildren)
            {
                tabCtrl.Visible = false;
            }
        }
    }
}
