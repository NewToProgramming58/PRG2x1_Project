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
    // Delegate to be used as container for event
    public delegate void EventHandler(Exception exception);
    public partial class FrmTuckShop : Form
    {
        // Event used to handle errors/exceptions so the program does not crash
        public static event EventHandler ErrorHandler;
        // Lists used for saving filters to outputs
        public List<string> editItemsFilterList = new List<string>();
        public List<string> editSalesFilterList = new List<string>();
        static SqlConnection sqlConnection;
        static ItemManager itemManager;
        static UserManager userManager;
        static SalesManger saleManager;

        public static void HandleError(Exception ex)
        {
            switch (ex.GetType().ToString())
            {
                default:
                    MessageBox.Show("An unknown error has occured, no changes will be made.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
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
                string createTables = File.ReadAllText(exepath + @"Queries\CreateTables.txt");
                // This text file conatians the query for items table.
                string addMockData = File.ReadAllText(exepath + @"Queries\InsertData.txt");
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
                    myCommand = new SqlCommand(createTables, sqlConnection);
                    myCommand.ExecuteNonQuery();
                    myCommand = new SqlCommand(addMockData, sqlConnection);
                    myCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    ErrorHandler.Invoke(ex);
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
            userManager = new UserManager(sqlConnection);
            saleManager = new SalesManger(sqlConnection);
            ///////////////////////////////////////////////////////////////////////////////////////////////
        }

        public FrmTuckShop()
        {
            InitializeComponent();
        }

        private void FrmTuckShop_Load(object sender, EventArgs e)
        {
            // Database Startup
            ErrorHandler += HandleError;
            ConnectToDB();
            tcMainScreen.Appearance = TabAppearance.FlatButtons;
            tcMainScreen.ItemSize = new Size(0, 1);
            tcMainScreen.SizeMode = TabSizeMode.Fixed;

            cboEditChangeItemCategory.DataSource = itemManager.FillCategories();
            cboEditChangeItemCategory.DisplayMember = "Category";
            cboEditChangeItemCategory.ValueMember = "CategoryID";
            cboEditAddItemCategory.DataSource = itemManager.FillCategories();
            cboEditAddItemCategory.DisplayMember = "Category";
            cboEditAddItemCategory.ValueMember = "CategoryID";
            cboSaleItems.DataSource = itemManager.FillNames();
            cboSaleItems.DisplayMember = "ItemName";
            cboSaleItems.ValueMember = "ItemID";
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
        //===============================================================================================
        private void BtnNavigateToRegister_Click(object sender, EventArgs e)
        {
            tcMainScreen.SelectedTab = tpRegister;
            Size = new Size(229, 418);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            OpenMenu();
        }
        //===============================================================================================



        // Register page
        //===============================================================================================
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
        //===============================================================================================



        // Menu page
        //===============================================================================================
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
            var result = MessageBox.Show("are you sure you want to exit?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                Close();
            }
        }
        //===============================================================================================



        // Order page
        //===============================================================================================
        private void BtnExitOrder_Click(object sender, EventArgs e)
        {
            OpenMenu();
        }
        //===============================================================================================



        // Edit records page
        //===============================================================================================
        private void BtnExitEdit_Click(object sender, EventArgs e)
        {
            OpenMenu();
            // Clears the filters that were applied.
            editItemsFilterList.Clear();
        }

        private void BtnEditFilter_Click(object sender, EventArgs e)
        {
            // Loads the field-titles into an input.
            cboEditFilterField.Items.Clear();
            for (int i = 0; i < dgvEdit.ColumnCount; i++)
            {
                cboEditFilterField.Items.Add(dgvEdit.Columns[i].HeaderText);
            }
            DisableEditForm();
            pnlEditFilter.Visible = true;
            pnlEditFilter.Enabled = true;
        }

        private void BtnEditFiltersCancel_Click(object sender, EventArgs e)
        {
            EnableEditForm();
            pnlEditFilter.Visible = false;
            pnlEditFilter.Enabled = false;
        }

        private void BtnEditFiltersRemove_Click(object sender, EventArgs e)
        {
            EnableEditForm();
            pnlEditFilter.Visible = false;
            pnlEditFilter.Enabled = false;
            lblEditFilters.Text = "Filters: No filters are applied";
            lblEditFilters.ForeColor = Color.Black;

            // Error check.
            try
            {
                // Checks to see which table is currently open to remove filter on thet table.
                if (cboEditCurrentTable.SelectedItem.ToString() == "Items")
                {
                    editItemsFilterList.Clear();
                    ShowItems();
                }
                else if (cboEditCurrentTable.SelectedItem.ToString() == "Sales")
                {
                    editSalesFilterList.Clear();
                    //dgvEdit.DataSource = saleManager.ShowAllItems();/////////////////////////////////////////////////////////////
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.Invoke(ex);
            }
        }

        private void BtnEditFiltersApply_Click(object sender, EventArgs e)
        {
            string filter;

            EnableEditForm();
            pnlEditFilter.Visible = false;
            pnlEditFilter.Enabled = false;

            // Error check.
            try
            {
                // Puts the filters in the correct format for the method.
                filter = cboEditFilterField.SelectedItem.ToString() + "#" + gboComparison.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text + "#" + txtEditFilterValue.Text;
                // Checks which table is currently open to be filtered.
                if (cboEditCurrentTable.SelectedItem.ToString() == "Items")
                {
                    editItemsFilterList.Add(filter);
                    // Applies the filter (the list has an added filter so the filter method runs).
                    ShowItems();
                }
                else if (cboEditCurrentTable.SelectedItem.ToString() == "Sales")
                {
                    editSalesFilterList.Add(filter);
                    //dgvEdit.DataSource = saleManager.FilterItems(editSalesFilterList);////////////////////////////////////////////////////////////
                }

                // Shows the user filters are applied.
                lblEditFilters.Text = "Filters: Filters are applied";
                lblEditFilters.ForeColor = Color.Blue;
            }
            catch (Exception ex)
            {
                ErrorHandler.Invoke(ex);
            }
        }

        private void BtnEditAdd_Click(object sender, EventArgs e)
        {
            if (cboEditCurrentTable.SelectedItem.ToString() == "Items")
            {
                DisableEditForm();
                pnlEditAddItem.Visible = true;
                pnlEditAddItem.Enabled = true;
            }
            else if (cboEditCurrentTable.SelectedItem.ToString() == "Sales")
            {
                // STILL HAVE TO DO//////////////////////////////////////////////////////////////////////////////////////
                DisableEditForm();
                pnlEditAddSale.Visible = true;
                pnlEditAddSale.Enabled = true;
            }
        }

        private void BtnEditAddItemCancel_Click(object sender, EventArgs e)
        {
            EnableEditForm();
            pnlEditAddItem.Visible = false;
            pnlEditAddItem.Enabled = false;
        }

        private void BtnEditAddItemSubmit_Click(object sender, EventArgs e)
        {
            // Error check for value conversion.
            try
            {          
                string itemName = txtEditAddItemName.Text;
                double itemPrice = double.Parse(txtEditAddItemPrice.Text);
                int itemCategory = int.Parse(cboEditAddItemCategory.SelectedValue.ToString());                
                int itemQuantity = int.Parse(nudEditAddItemQuantity.Value.ToString());

                itemManager.AddItem(itemName, itemCategory, itemQuantity, itemPrice);
                // Refreshes values.
                ShowItems();
            }
            catch (Exception ex)
            {
                ErrorHandler.Invoke(ex);
            }

            EnableEditForm();
            pnlEditAddItem.Visible = false;
            pnlEditAddItem.Enabled = false;
        }

        private void BtnEditChange_Click(object sender, EventArgs e)
        {
            if (cboEditCurrentTable.SelectedItem.ToString() == "Items")
            {
                DisableEditForm();
                pnlEditChangeItem.Visible = true;
                pnlEditChangeItem.Enabled = true;
                // Outputs the current values selected, into the input-areas.
                txtEditChangeItemID.Text = dgvEdit.Rows[dgvEdit.CurrentCell.RowIndex].Cells[0].Value.ToString();
                txtEditChangeItemName.Text = dgvEdit.Rows[dgvEdit.CurrentCell.RowIndex].Cells[1].Value.ToString();
                txtEditChangeItemPrice.Text = dgvEdit.Rows[dgvEdit.CurrentCell.RowIndex].Cells[2].Value.ToString();                         
                nudEditChangeItemQuantity.Value = int.Parse(dgvEdit.Rows[dgvEdit.CurrentCell.RowIndex].Cells[3].Value.ToString());
                cboEditChangeItemCategory.SelectedItem = dgvEdit.Rows[dgvEdit.CurrentCell.RowIndex].Cells[4].Value.ToString();
            }
            else if (cboEditCurrentTable.SelectedItem.ToString() == "Sales")
            {
                MessageBox.Show("Only Items can be changed. Sales can only be Removed or Added", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnEditChangeItemCancel_Click(object sender, EventArgs e)
        {
            EnableEditForm();
            pnlEditChangeItem.Visible = false;
            pnlEditChangeItem.Enabled = false;
        }

        private void btnEditChangeItemSubmit_Click(object sender, EventArgs e)
        {
            string values;
            string changedValues = "";

            // Error check for value conversion.
            try
            {
                // Stores values in correct format for method.
                values = txtEditChangeItemID.Text + "#" + txtEditChangeItemName.Text + "#" + txtEditChangeItemPrice.Text + "#" + nudEditChangeItemQuantity.Value.ToString() + "#" +
                         cboEditChangeItemCategory.SelectedValue;

                // Finds the changed values so they can be displayed.
                for (int i = 0; i < dgvEdit.Columns.Count; i++)
                {
                    var newValues = values.Split('#');
                    // Converts CategoryID to the name for display
                    if (i == 4)
                    {
                        newValues[i] = cboEditChangeItemCategory.Text;
                    }

                    if (dgvEdit.Rows[dgvEdit.CurrentCell.RowIndex].Cells[i].Value.ToString() != newValues[i])
                    {
                        changedValues = changedValues + "\n" + dgvEdit.Columns[i].HeaderText + ": " +
                        dgvEdit.Rows[dgvEdit.CurrentCell.RowIndex].Cells[i].Value.ToString().Trim() + " >> " + newValues[i].Trim();/////////////////////////////////////////////
                    }
                }
                var result = MessageBox.Show("Are you sure you want to update the following values: " + changedValues, "Change values", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    itemManager.UpdateItemInfo(values);
                }
                // Refreshes the data.
                ShowItems();
            }
            catch (Exception ex)
            {
                ErrorHandler.Invoke(ex);
            }

            EnableEditForm();
            pnlEditChangeItem.Visible = false;
            pnlEditChangeItem.Enabled = false;
        }

        private void BtnEditRemove_Click(object sender, EventArgs e)
        {
            var row = dgvEdit.Rows[dgvEdit.CurrentCell.RowIndex];
            string ID = row.Cells[0].Value.ToString();
            // Asks user if he/she is sure they want to delete the record and if Yes is selected, deletes appropriate record.
            var result = MessageBox.Show("Are you sure you want to delete record in Items containing: \nItemID: " +
                                    row.Cells[0].Value.ToString() + "\nItemname: " +
                                    row.Cells[1].Value.ToString().Trim() + "\nPrice: " +////////////////////////////////////////////////////
                                    row.Cells[2].Value.ToString() + "\nCategory: " +
                                    row.Cells[4].Value.ToString() + "\nQuantity: " +
                                    row.Cells[3].Value.ToString(), "Remove record", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // Error check.
                try
                {
                    if (cboEditCurrentTable.SelectedItem.ToString() == "Items")
                    {
                        itemManager.RemoveItem(ID);
                        // Refreshes values.
                        ShowItems();
                    }
                    else if (cboEditCurrentTable.SelectedItem.ToString() == "Sales")
                    {
                        //saleManager.RemoveItem(ID)//////////////////////////////////////////////////////////////////
                        //dgvEdit.DataSource = saleManager.ShowAllItems();
                    }
                }
                catch (Exception ex)
                {
                    ErrorHandler.Invoke(ex);
                }
            }
        }

        // Whenever the combobox changes, the table viewed changes.
        private void CboEditCurrentTable_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboEditCurrentTable.SelectedItem.ToString() == "Items")
            {
                ShowItems();
            }
            else if (cboEditCurrentTable.SelectedItem.ToString() == "Sales")
            {
                ShowSales();
            }
        }

        // Methods used for validation by disabling/enabling certain inputs.
        public void DisableEditForm()
        {
            cboEditCurrentTable.Enabled = false;
            btnEditAdd.Enabled = false;
            btnEditChange.Enabled = false;
            btnEditRemove.Enabled = false;
            btnEditFilter.Enabled = false;
            btnExitEdit.Enabled = false;
            dgvEdit.Enabled = false;
        }
        public void EnableEditForm()
        {
            cboEditCurrentTable.Enabled = true;
            btnEditAdd.Enabled = true;
            btnEditChange.Enabled = true;
            btnEditRemove.Enabled = true;
            btnEditFilter.Enabled = true;
            btnExitEdit.Enabled = true;
            dgvEdit.Enabled = true;
        }

        // This method checks if a filter is already applied or not when refreshing the datagrid.
        public void ShowItems()
        {
            if (editItemsFilterList.Count > 0)
            {
                dgvEdit.DataSource = itemManager.FilterItems(editItemsFilterList);
            }
            else
            {
                dgvEdit.DataSource = itemManager.ShowAllItems();
            }
        }

        public void ShowSales()
        {
            if (editItemsFilterList.Count > 0)
            {
                //dgvEdit.DataSource = saleManager.FilterItems(editItemsFilterList);
            }
            else
            {
                dgvEdit.DataSource = saleManager.ShowAllSales();
            }
        }
        //===============================================================================================



        // View page
        //===============================================================================================
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
        //===============================================================================================



        // Edit login for Admin page
        //===============================================================================================
        private void BtnExitAdminEditLogin_Click(object sender, EventArgs e)
        {
            OpenMenu();
            editItemsFilterList.Clear();
        }



        private void BtnCancelAdminFilter_Click(object sender, EventArgs e)
        {
            //EnableForm();
            pnlAdminFilter.Visible = false;
            pnlAdminFilter.Enabled = false;
        }

        private void BtnRemoveAdminFilters_Click(object sender, EventArgs e)
        {
            //EnableForm();
            editItemsFilterList.Clear();

            pnlAdminFilter.Visible = false;
            pnlAdminFilter.Enabled = false;
        }

        private void BtnApplyAdminFilter_Click(object sender, EventArgs e)
        {
            string value;
            double numTest;

            //EnableForm();
            pnlAdminFilter.Visible = false;
            pnlAdminFilter.Enabled = false;

            // This checks correctness of formats.
            try
            {
                //numTest = double.Parse(textBox3.Text);

                //value = numTest.ToString();
            }
            catch (Exception)
            {
                if ((comboBox5.SelectedItem.ToString() == "LIKE") || (comboBox5.SelectedItem.ToString() == "NOT LIKE"))
                {
                    //value = "'%" + textBox3.Text + "%'";
                }
                else
                {
                    //value = "'" + textBox3.Text + "'";
                }
            }
        }
        //===============================================================================================



        // Edit login for normal users page
        //===============================================================================================
        private void BtnExitEditLogin_Click(object sender, EventArgs e)
        {
            OpenMenu();
        }
        //===============================================================================================
    }
}
