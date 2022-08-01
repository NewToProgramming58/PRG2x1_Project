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
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            tcMainScreen.SelectedTab = tpMainMenu;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            tcMainScreen.SelectedTab = tpRegister;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            tcMainScreen.SelectedTab = tpLogin;
        }
    }
}
