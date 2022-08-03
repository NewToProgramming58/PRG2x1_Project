using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Data;

namespace Project_Milestone_2
{
    internal class SalesManger
    {
        readonly SqlConnection sqlConnection;

        public SalesManger(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }

        public bool AddSale(List<int> quantities, List<double> prices, List<int> itemIDs) 
        {            
            bool success = false;
            string values = $"({itemIDs[0]}, {prices[0]}, {quantities[0]})";
            for (int i = 1; i < quantities.Count; i++)
            {
                values += $", ({itemIDs[i]}, {prices[i]}, {quantities[i]})";
            }
            string cmdString = $"INSERT INTO SaleItems (ItemID, Price, Quantity) VALUES {values}";
            SqlCommand sqlCommand = new SqlCommand
            {
                Connection = sqlConnection,
                CommandText = cmdString
            };
            try
            {
                int itemRows = sqlCommand.ExecuteNonQuery();
                cmdString = $"INSERT INTO Sales (TotalPrice, TimePlaced) VALUES ({prices.Sum()}, #{DateTime.Now}#)";
                int saleRows = sqlCommand.ExecuteNonQuery();
               
                if (itemRows > 0 && saleRows > 0)
                {
                    success = true;
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }           
            return success;
        }

        //Show all sales///////////////////////////////////////////////////
        public DataTable ShowAllSales()
        {
            string cmdString = "SELECT SaleID, TotalPrice, TimePlaced FROM Sales";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmdString, sqlConnection);

            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);

            return ds.Tables[0];
        }
    }
}