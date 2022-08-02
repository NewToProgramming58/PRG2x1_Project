using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Milestone_2
{
    public partial class frmTuckShop : Form
    {
        static SqlConnection sqlConnection;
        static ItemManager itemManager;

        public static void ConnectToDB() 
        {
            ///////////////////////////////////////////////////////////////////////////////////////////////
            // DataBase connection         
            string existQuery = "SELECT * FROM master.dbo.sysdatabases WHERE name ='TuckShop'";
            bool isExist = false;
            using (SqlConnection con = new SqlConnection(@"Server=localhost\SQLExpress;Trusted_Connection=True;Integrated security=True;database=master"))
            {
                // Open connection ,run creation query and close.
                con.Open();
                using (SqlCommand command = new SqlCommand(existQuery, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Checks to see if database has rows. If not the HasRows = null.
                        isExist = reader.HasRows;
                    }
                }
                con.Close();
            }
            // When database doesnt exist, it is created programmatically.
            if (!isExist)
            {
                // This text file has Query for creation of the DB.
                string creationQuery = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "CreateDB.txt");
                // This text file conatians the query for items table. (Cant use GO in SQlCommand).
                string createitems = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Createitems.txt");
                // USE a Master connection to build DB.
                SqlConnection masterConnection = new SqlConnection(@"Server=localhost\SQLExpress;Trusted_Connection=True;Integrated security=True;database=master");

                SqlCommand myCommand = new SqlCommand(creationQuery, masterConnection);
                try
                {
                    // Open connection ,run creation query and close.
                    masterConnection.Open();
                    myCommand.ExecuteNonQuery();
                    masterConnection.Close();
                    //Create new connection to newly created database and create each table.
                    sqlConnection = new SqlConnection(@"Server=localhost\SQLExpress;Integrated Security=True;Trusted_Connection=True;Database=TuckShop");
                    sqlConnection.Open();
                    myCommand = new SqlCommand(createitems, sqlConnection);
                    myCommand.ExecuteNonQuery();
                }
                catch (System.Exception exeption)
                {
                    MessageBox.Show(exeption.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // When DB is 100% then simply open a connection
                sqlConnection = new SqlConnection(@"Server=localhost\SQLExpress;Integrated Security=True;Trusted_Connection=True;Database=TuckShop");
            }
            //Object to Manage DB control concerning Items
            itemManager = new ItemManager(sqlConnection);

            ///////////////////////////////////////////////////////////////////////////////////////////////
        }

        public frmTuckShop()
        {
            InitializeComponent();
        }

        private void frmTuckShop_Load(object sender, EventArgs e)
        {
            // Database Startup
            ConnectToDB();
            tcMainScreen.Appearance = TabAppearance.FlatButtons;
            tcMainScreen.ItemSize = new Size(0, 1);
            tcMainScreen.SizeMode = TabSizeMode.Fixed;

            foreach (TabPage tab in tcMainScreen.TabPages)
            {
                tab.Text = "";
            }
            Size = new Size(215, 266);
        }
        // Navigation
        public void OpenMenu()
        {
            tcMainScreen.SelectedTab = tpMenu;
            Size = new Size(275, 312);
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
            OpenMenu();
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
            // Loads the default table as Items
            if (cboEditCurrentTable.SelectedIndex == -1)
                cboEditCurrentTable.SelectedIndex = cboEditCurrentTable.FindString("Items");
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
            OpenMenu();
        }
        //-----------------------------------------------------------------------------------------------

        // Edit records page
        //-----------------------------------------------------------------------------------------------
        private void btnExitEdit_Click(object sender, EventArgs e)
        {
            OpenMenu();
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

        private void btnEditAdd_Click(object sender, EventArgs e)
        {
            //
        }

        private void btnEditChange_Click(object sender, EventArgs e)
        {
            //
        }
        private void btnEditRemove_Click(object sender, EventArgs e)
        {
            string ID = dgvEdit.Rows[dgvEdit.CurrentCell.RowIndex].Cells[0].Value.ToString();
            MessageBox.Show(ID);
        }

        //Whenever the combobox changes the table viewed changes
        private void cboEditCurrentTable_SelectedValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show(cboEditCurrentTable.SelectedItem.ToString());
            if (cboEditCurrentTable.SelectedItem.ToString() == "Items")
            {
                dgvEdit.DataSource = itemManager.ShowAllItems();
            }
            else if (cboEditCurrentTable.SelectedItem.ToString() == "Sales")
            {
                // Show Sales
            }
        }
        //-----------------------------------------------------------------------------------------------

        // View page
        //-----------------------------------------------------------------------------------------------
        private void btnExitView_Click(object sender, EventArgs e)
        {
            OpenMenu();
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
            OpenMenu();
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
            OpenMenu();
        }
        //-----------------------------------------------------------------------------------------------
    }
}
