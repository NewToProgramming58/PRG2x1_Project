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

        public bool AddSale() 
        {            
            bool success = false;
            string cmdString = "INSERT INTO Items (ItemName, Price, Category, Quantity) VALUES (@name, @price, @cat, @quant)";
            SqlCommand sqlCommand = new SqlCommand
            {
                Connection = sqlConnection,
                CommandText = cmdString
            };
            //sqlCommand.Parameters.AddWithValue("@name", name);
            //sqlCommand.Parameters.AddWithValue("@price", price);
            //sqlCommand.Parameters.AddWithValue("@cat", cat);
            //sqlCommand.Parameters.AddWithValue("@quant", quantity);
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