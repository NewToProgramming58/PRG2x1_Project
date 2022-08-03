using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

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
                int rows = sqlCommand.ExecuteNonQuery();
                if (rows > 0)
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
    }
}