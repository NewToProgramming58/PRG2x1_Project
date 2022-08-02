﻿using System;
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
    public partial class FrmTuckShop : Form
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
                string exepath = AppDomain.CurrentDomain.BaseDirectory;
                // This text file has Query for creation of the DB.
                string creationQuery = File.ReadAllText(exepath + @"Queries\CreateDB.txt");
                // This text file conatians the query for items table. (Cant use GO in SQlCommand).
                string createitems = File.ReadAllText(exepath + @"Queries\Createitems.txt");
                // USE a Master connection to build DB.
                SqlConnection masterConnection = new SqlConnection(@"Server=localhost\SQLExpress;Trusted_Connection=True;Integrated security=True;database=master");

                SqlCommand myCommand = new SqlCommand(creationQuery, masterConnection);
                try
                {
                    // Open connection, run creation query and close.
                    masterConnection.Open();
                    myCommand.ExecuteNonQuery();
                    masterConnection.Close();
                    //Create new connection to newly created database and create each table.
                    sqlConnection = new SqlConnection(@"Server=localhost\SQLExpress;Integrated Security=True;Trusted_Connection=True;Database=TuckShop");
                    sqlConnection.Open();
                    myCommand = new SqlCommand(createitems, sqlConnection);
                    myCommand.ExecuteNonQuery();
                }
                catch (Exception exeption)
                {
                    MessageBox.Show(exeption.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                // When DB is 100% then simply open a connection
                sqlConnection = new SqlConnection(@"Server=localhost\SQLExpress;Integrated Security=True;Trusted_Connection=True;Database=TuckShop");
                sqlConnection.Open();
            }
            //Object to Manage DB control concerning Items
            itemManager = new ItemManager(sqlConnection);

            ///////////////////////////////////////////////////////////////////////////////////////////////
        }

        public FrmTuckShop()
        {
            InitializeComponent();
        }

        private void FrmTuckShop_Load(object sender, EventArgs e)
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
        private void BtnNavigateToRegister_Click(object sender, EventArgs e)
        {
            tcMainScreen.SelectedTab = tpRegister;
            Size = new Size(229, 418);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            OpenMenu();
        }
        //-----------------------------------------------------------------------------------------------

        // Register page
        //-----------------------------------------------------------------------------------------------
        private void BtnExitRegister_Click(object sender, EventArgs e)
        {
            tcMainScreen.SelectedTab = tpLogin;
            Size = new Size(215, 266);
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            tcMainScreen.SelectedTab = tpLogin;
            Size = new Size(215, 266);
        }
        //-----------------------------------------------------------------------------------------------

        // Menu page
        //-----------------------------------------------------------------------------------------------
        private void BtnExitMenu_Click(object sender, EventArgs e)
        {
            tcMainScreen.SelectedTab = tpLogin;
            Size = new Size(215, 266);
        }

        private void BtnPlaceOrder_Click(object sender, EventArgs e)
        {
            tcMainScreen.SelectedTab = tpOrder;
            Size = new Size(286, 360);
        }

        private void BtnEditRecords_Click(object sender, EventArgs e)
        {
            tcMainScreen.SelectedTab = tpEdit;
            Size = new Size(966, 558);
            // Loads the default table as Items
            if (cboEditCurrentTable.SelectedIndex == -1)
                cboEditCurrentTable.SelectedIndex = cboEditCurrentTable.FindString("Items");
            dgvEdit.DataSource = itemManager.ShowAllItems();
        }

        private void BtnViewRecords_Click(object sender, EventArgs e)
        {
            tcMainScreen.SelectedTab = tpView;
            Size = new Size(966, 558);
        }

        private void BtnEditLogin_Click(object sender, EventArgs e)
        {
            //We have to check if the user is an admin
            tcMainScreen.SelectedTab = tpAdminEditLogin;
            Size = new Size(968, 561);

            //tcMainScreen.SelectedTab = tpEditLogin;
            //Size = new Size(324, 266);
        }

        private void BtnExit_Click(object sender, EventArgs e)
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
        private void BtnExitOrder_Click(object sender, EventArgs e)
        {
            OpenMenu();
        }
        //-----------------------------------------------------------------------------------------------

        // Edit records page
        //-----------------------------------------------------------------------------------------------
        private void BtnExitEdit_Click(object sender, EventArgs e)
        {
            OpenMenu();
        }

        private void BtnEditFilter_Click(object sender, EventArgs e)
        {
            pnlEditFilter.Visible = true;
            pnlEditFilter.Enabled = true;
        }

        private void BtnCancelEditFilter_Click(object sender, EventArgs e)
        {
            pnlEditFilter.Visible = false;
            pnlEditFilter.Enabled = false;
        }

        private void BtnRemoveEditFilters_Click(object sender, EventArgs e)
        {
            pnlEditFilter.Visible = false;
            pnlEditFilter.Enabled = false;
        }

        private void BtnApplyEditFilters_Click(object sender, EventArgs e)
        {
            pnlEditFilter.Visible = false;
            pnlEditFilter.Enabled = false;
        }

        private void BtnEditAdd_Click(object sender, EventArgs e)
        {
            if (cboEditCurrentTable.SelectedItem.ToString() == "Items")
            {
                pnlEditAddItem.Visible = true;
                pnlEditAddItem.Enabled = true;
            }
            else if (cboEditCurrentTable.SelectedItem.ToString() == "Sales")
            {
                // STILL HAVE TO DO
                pnlEditAddSale.Visible = true;
                pnlEditAddSale.Enabled = true;
            }
        }
        private void BtnEditAddItemSubmit_Click(object sender, EventArgs e)
        {
            string itemName = txtEditAddItemName.Text;
            double itemPrice = double.Parse(txtEditAddItemPrice.Text);
            string itemCategory = cboEditAddItemCategory.SelectedItem.ToString();
            int itemQuantity = int.Parse(nudEditAddItemQuantity.Value.ToString());
            itemManager.AddItem(itemName, itemCategory, itemQuantity, itemPrice);
            dgvEdit.DataSource = itemManager.ShowAllItems();
            pnlEditAddItem.Visible = false;
            pnlEditAddItem.Enabled = false;
        }
        private void BtnEditAddItemCancel_Click(object sender, EventArgs e)
        {
            pnlEditAddItem.Visible = false;
            pnlEditAddItem.Enabled = false;
        }

        private void BtnEditChange_Click(object sender, EventArgs e)
        {
            //
        }

        // Asks user if he/she is sure they want to delete the record and if Yes is selected, deletes appropriate record
        private void BtnEditRemove_Click(object sender, EventArgs e)
        {
            var row = dgvEdit.Rows[dgvEdit.CurrentCell.RowIndex];
            string ID = row.Cells[0].Value.ToString();
            var result = MessageBox.Show("Are you sure you want to delete record in Items containing: \nItemID: " +
                                    row.Cells[0].Value.ToString() + "\nItemname: " +
                                    row.Cells[1].Value.ToString() + "\nPrice: " +
                                    row.Cells[2].Value.ToString() + "\nCategory: " +
                                    row.Cells[3].Value.ToString() + "\nQuantity: " +
                                    row.Cells[4].Value.ToString(), "Remove record", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (cboEditCurrentTable.SelectedItem.ToString() == "Items")
                {
                    itemManager.RemoveItem(ID);
                    dgvEdit.DataSource = itemManager.ShowAllItems();
                }
                else if (cboEditCurrentTable.SelectedItem.ToString() == "Sales")
                {
                    // STILL HAVE TO DO
                    //saleManager.RemoveItem(ID)
                    //dgvEdit.DataSource = saleManager.ShowAllItems();
                }
            }
        }

        //Whenever the combobox changes the table viewed changes
        private void CboEditCurrentTable_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboEditCurrentTable.SelectedItem.ToString() == "Items")
            {

                dgvEdit.DataSource = itemManager.ShowAllItems();
            }
            else if (cboEditCurrentTable.SelectedItem.ToString() == "Sales")
            {
                // Show Sales
                //dgvEdit.DataSource = saleManager.ShowAllItems();
            }
        }
        //-----------------------------------------------------------------------------------------------

        // View page
        //-----------------------------------------------------------------------------------------------
        private void BtnExitView_Click(object sender, EventArgs e)
        {
            OpenMenu();
        }

        private void BtnViewFilter_Click(object sender, EventArgs e)
        {
            pnlViewFilter.Visible = true;
        }
        private void BtnCancelViewFilter_Click(object sender, EventArgs e)
        {
            pnlViewFilter.Visible = false;
        }

        private void BtnApplyViewFilter_Click(object sender, EventArgs e)
        {
            pnlViewFilter.Visible = false;
        }
        private void BtnRemoveViewFilters_Click(object sender, EventArgs e)
        {
            pnlViewFilter.Visible = false;
        }
        //-----------------------------------------------------------------------------------------------

        // Edit login for Admin page
        //-----------------------------------------------------------------------------------------------
        private void BtnExitAdminEditLogin_Click(object sender, EventArgs e)
        {
            OpenMenu();
        }

        private void BtnAdminFilter_Click(object sender, EventArgs e)
        {
            pnlAdminFilter.Visible = true;
        }

        private void BtnCancelAdminFilter_Click(object sender, EventArgs e)
        {
            pnlAdminFilter.Visible = false;
        }

        private void BtnRemoveAdminFilters_Click(object sender, EventArgs e)
        {
            pnlAdminFilter.Visible = false;
        }

        private void BtnApplyAdminFilter_Click(object sender, EventArgs e)
        {
            pnlAdminFilter.Visible = false;
        }
        //-----------------------------------------------------------------------------------------------

        // Edit login for normal users page
        //-----------------------------------------------------------------------------------------------
        private void BtnExitEditLogin_Click(object sender, EventArgs e)
        {
            OpenMenu();
        }
        //-----------------------------------------------------------------------------------------------
    }
}
