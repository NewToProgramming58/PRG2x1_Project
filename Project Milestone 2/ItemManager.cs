using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Milestone_2
{
    public enum ItemDetail
    {
        Category,
        ItemName,
        Price,
        Quantity
    }
    internal class ItemManager
    {
        readonly SqlConnection sqlConnection;

        public ItemManager(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }

        // This method simply adds a new item to the sql database.
        public void AddItem(String name, String cat, int quantity, double price) 
        {
            string cmdString = "INSERT INTO Items (ItemName, Price, Category, Quantity) VALUES (@name, @price, @cat, @quant)";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = cmdString;
            sqlCommand.Parameters.AddWithValue("@name", name);
            sqlCommand.Parameters.AddWithValue("@price", price);
            sqlCommand.Parameters.AddWithValue("@cat", cat);
            sqlCommand.Parameters.AddWithValue("@quant", quantity);
            try
            {          
                sqlCommand.ExecuteNonQuery();
            }
            catch(SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        // This method increases the quantity of an item by the given amount(Can be negative).
        public bool ChangeQuantity(String id, int quantity)
        {
            bool success = false;
            string cmdString = "UPDATE Items SET Quantity = Quantity + @quant WHERE ItemID = @id";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = cmdString;
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.Parameters.AddWithValue("@quant", quantity);
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
        // This method changes the an items information.
        public bool UpdateItemInfo(String id,ItemDetail itemDetail ,string newValue)
        {
            bool success = false;
            string cmdString = $"UPDATE Items SET \"{itemDetail.ToString()}\" = @value WHERE ItemID = @id";  
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = cmdString;
            sqlCommand.Parameters.AddWithValue("@id", id);           
            sqlCommand.Parameters.AddWithValue("@value", newValue);
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
        // Removes the record of an item from the DB
        public bool RemoveItem(String id)
        {
            bool success = false;
            string cmdString = "DELETE FROM Items WHERE ItemID = @id";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = cmdString;
            sqlCommand.Parameters.AddWithValue("@id", id);
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
