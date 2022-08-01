//Hello world
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Milestone_2
{
    public partial class frmTuckShop : Form
    {
        public frmTuckShop()
        {
            InitializeComponent();
        }
        private void frmTuckShop_Load(object sender, EventArgs e)
        {
            tcMainScreen.Appearance = TabAppearance.FlatButtons;
            tcMainScreen.ItemSize = new Size(0, 1);
            tcMainScreen.SizeMode = TabSizeMode.Fixed;

            foreach (TabPage tab in tcMainScreen.TabPages)
            {
                tab.Text = "";
            }
            Size = new Size(215, 266);
        }

        // Login page
        //-----------------------------------------------------------------------------------------------
        private void btnNavigateToRegister_Click(object sender, EventArgs e)
        {
            tcMainScreen.SelectedTab = tpRegister;
            Size = new Size(229, 418);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            tcMainScreen.SelectedTab = tpMenu;
            Size = new Size(275, 312);
        }
        //-----------------------------------------------------------------------------------------------

        // Register page
        //-----------------------------------------------------------------------------------------------
        private void btnExitRegister_Click(object sender, EventArgs e)
        {
            tcMainScreen.SelectedTab = tpLogin;
            Size = new Size(215, 266);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            tcMainScreen.SelectedTab = tpLogin;
            Size = new Size(215, 266);
        }
        //-----------------------------------------------------------------------------------------------

        // Menu page
        //-----------------------------------------------------------------------------------------------
        private void btnExitMenu_Click(object sender, EventArgs e)
        {
            tcMainScreen.SelectedTab = tpLogin;
            Size = new Size(215, 266);
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            tcMainScreen.SelectedTab = tpOrder;
            Size = new Size(286, 360);
        }

        private void btnEditRecords_Click(object sender, EventArgs e)
        {
            tcMainScreen.SelectedTab = tpEdit;
            Size = new Size(966, 558);
        }

        private void btnViewRecords_Click(object sender, EventArgs e)
        {
            tcMainScreen.SelectedTab = tpView;
            Size = new Size(966, 558);
        }

        private void btnEditLogin_Click(object sender, EventArgs e)
        {
            //We have to check if the user is an admin
            tcMainScreen.SelectedTab = tpAdminEditLogin;
            Size = new Size(968, 561);

            //tcMainScreen.SelectedTab = tpEditLogin;
            //Size = new Size(324, 266);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("are you sure you want to exit?", "Exit", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Close();
            }
        }
        //-----------------------------------------------------------------------------------------------

        // Order page
        //-----------------------------------------------------------------------------------------------
        private void btnExitOrder_Click(object sender, EventArgs e)
        {
            tcMainScreen.SelectedTab = tpMenu;
            Size = new Size(275, 312);
        }
        //-----------------------------------------------------------------------------------------------

        // Edit records page
        //-----------------------------------------------------------------------------------------------
        private void btnExitEdit_Click(object sender, EventArgs e)
        {
            tcMainScreen.SelectedTab = tpMenu;
            Size = new Size(275, 312);
        }

        private void btnEditFilter_Click(object sender, EventArgs e)
        {
            pnlEditFilter.Visible = true;
        }

        private void btnCancelEditFilter_Click(object sender, EventArgs e)
        {
            pnlEditFilter.Visible = false;
        }

        private void btnRemoveEditFilters_Click(object sender, EventArgs e)
        {
            pnlEditFilter.Visible = false;
        }

        private void btnApplyEditFilters_Click(object sender, EventArgs e)
        {
            pnlEditFilter.Visible = false;
        }
        //-----------------------------------------------------------------------------------------------

        // View page
        //-----------------------------------------------------------------------------------------------
        private void btnExitView_Click(object sender, EventArgs e)
        {
            tcMainScreen.SelectedTab = tpMenu;
            Size = new Size(275, 312);
        }

        private void btnViewFilter_Click(object sender, EventArgs e)
        {
            pnlViewFilter.Visible = true;
        }
        private void btnCancelViewFilter_Click(object sender, EventArgs e)
        {
            pnlViewFilter.Visible = false;
        }

        private void btnApplyViewFilter_Click(object sender, EventArgs e)
        {
            pnlViewFilter.Visible = false;
        }
        private void btnRemoveViewFilters_Click(object sender, EventArgs e)
        {
            pnlViewFilter.Visible = false;
        }
        //-----------------------------------------------------------------------------------------------

        // Edit login for Admin page
        //-----------------------------------------------------------------------------------------------
        private void btnExitAdminEditLogin_Click(object sender, EventArgs e)
        {
            tcMainScreen.SelectedTab = tpMenu;
            Size = new Size(275, 312);
        }

        private void btnAdminFilter_Click(object sender, EventArgs e)
        {
            pnlAdminFilter.Visible = true;
        }

        private void btnCancelAdminFilter_Click(object sender, EventArgs e)
        {
            pnlAdminFilter.Visible = false;
        }

        private void btnRemoveAdminFilters_Click(object sender, EventArgs e)
        {
            pnlAdminFilter.Visible = false;
        }

        private void btnApplyAdminFilter_Click(object sender, EventArgs e)
        {
            pnlAdminFilter.Visible = false;
        }
        //-----------------------------------------------------------------------------------------------

        // Edit login for normal users page
        //-----------------------------------------------------------------------------------------------
        private void btnExitEditLogin_Click(object sender, EventArgs e)
        {
            tcMainScreen.SelectedTab = tpMenu;
            Size = new Size(275, 312);
        }
        //-----------------------------------------------------------------------------------------------
    }
}
