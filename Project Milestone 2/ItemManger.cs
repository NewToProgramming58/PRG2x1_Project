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
    internal class ItemManger
    {
        SqlConnection sqlConnection;

        public ItemManger(SqlConnection sqlConnection)
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
        public void ChangeQuantity(String id, int quantity)
        {
            string cmdString = "UPDATE Items SET Quantity = Quantity + @quant WHERE ItemID = @id";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = cmdString;
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.Parameters.AddWithValue("@quant", quantity);
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        // This method changes the an items information.
        public void UpdateItemInfo(String id, int quantity)
        {
            string cmdString = "UPDATE Items SET Quantity = Quantity + @quant WHERE ItemID = @id";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = cmdString;
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.Parameters.AddWithValue("@quant", quantity);
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
        // Removes the record of an item from the DB
        public void RemoveItem(String id)
        {
            string cmdString = "DELETE FROM Items WHERE ItemID = @id";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = cmdString;
            sqlCommand.Parameters.AddWithValue("@id", id);
            try
            {
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
