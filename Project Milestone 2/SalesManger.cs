﻿using System;
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
                for (int i = 0; i < quantities.Count; i++)
                {

                    cmdString = "UPDATE Items SET Quantity = Quantity - @quant WHERE ItemID = @id";
                    sqlCommand.Parameters.AddWithValue("@id", itemIDs[i]);
                    sqlCommand.Parameters.AddWithValue("@quant", quantities[i]);
                    sqlCommand.ExecuteNonQuery();
                }
                
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

        // Removes the record of an item from the DB/////////////////////////////////////////////////////
        public bool RemoveSale(String id)
        {
            bool success = false;
            string cmdString = "DELETE FROM Sales WHERE SaleID = @id";
            SqlCommand sqlCommand = new SqlCommand
            {
                Connection = sqlConnection,
                CommandText = cmdString
            };
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

        //Show all sales///////////////////////////////////////////////////
        public DataTable ShowAllSales()
        {
            string cmdString = "SELECT SaleID, TotalPrice, TimePlaced FROM Sales";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmdString, sqlConnection);

            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);

            return ds.Tables[0];
        }

        public DataTable FilterSales(List<string> filters)
        {
            List<string> fields = new List<string>();
            List<string> signs = new List<string>();
            List<string> values = new List<string>();

            foreach (string filter in filters)
            {
                // 0 = field
                // 1 = sign
                // 2 = value
                var splitFilters = filter.Split('#');
                fields.Add(splitFilters[0]);
                if (splitFilters[1].Equals("="))
                    signs.Add("LIKE");
                else if (splitFilters[1].Equals("!="))
                    signs.Add("NOT LIKE");
                else
                    signs.Add(splitFilters[1]);
       
                if ((splitFilters[1].Equals("LIKE") || splitFilters[1].Equals("NOT LIKE")) && !splitFilters[1].Equals("="))
                    values.Add($"%{splitFilters[2]}%");
                else
                    values.Add(splitFilters[2]);
            }
            string cmdString = $"SELECT * FROM Sales WHERE {fields[0]} {signs[0]} {values[0]}";
            if (fields.Count > 1)
            {
                for (int i = 1; i < signs.Count; i++)
                {
                    cmdString += $" AND {fields[i]} {signs[i]} {values[i]}";
                }
            }
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmdString, sqlConnection);

            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);

            return ds.Tables[0];
        }
    }
}