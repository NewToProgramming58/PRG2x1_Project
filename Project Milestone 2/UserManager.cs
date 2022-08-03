﻿using System.Data.SqlClient;
using System.Windows.Forms;
using System;

namespace Project_Milestone_2
{
    public enum UserDetail { 
        Email,
        Password,
        Name, 
        Surname
    }
    internal class UserManager
    {
        public string userName;
        public string userSurname;
        public string userEmail;       
        readonly SqlConnection sqlConnection;
        public UserManager(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }

        // Checks if given email and password match and returns true or false.
        public bool Login(string email, string password)
        {
            bool ableToLogin = false;
            string cmdString = "SELECT * FROM Users WHERE Email = @email AND Password = @password";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = cmdString;
            sqlCommand.Parameters.AddWithValue("@email", email);
            sqlCommand.Parameters.AddWithValue("@password", password);
            try
            {
                int rows = sqlCommand.ExecuteNonQuery();
                if (rows == 1)
                {
                    ableToLogin = true;
                    userEmail = email;
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {                            
                            userName = (string)dataReader["Name"];
                            userSurname = (string)dataReader["Surname"];
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return ableToLogin;
        }

        // This method increases the quantity of an item by the given amount(Can be negative).
        public bool ChangeDetail(UserDetail userDetail,String newValue)
        {
            bool success = false;
            string cmdString = $"UPDATE Users SET \"{userDetail.ToString()}\" = @value WHERE Email = @email";
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = cmdString;
            sqlCommand.Parameters.AddWithValue("@email", userEmail);
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

        // Register a user        
        public bool Register(string email, string password, string name, string surname)
        {
            bool exists = true;
            string cmdString = $"SELECT * FROM Users WHERE Email = \"{email}\"";
            SqlCommand sqlCommand = new SqlCommand
            {
                Connection = sqlConnection,
                CommandText = cmdString
            };
            try
            {
                int rows = sqlCommand.ExecuteNonQuery();
                if (rows == 0)
                {
                    exists = false;
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            if (exists)
            {
                return false;            
            }
            else
            {
                bool success = false;
                cmdString = "INSERT INTO Users VALUES (@email, @password)";                      
                sqlCommand.CommandText = cmdString;
                sqlCommand.Parameters.AddWithValue("@email", email);
                sqlCommand.Parameters.AddWithValue("@password", password);
                sqlCommand.Parameters.AddWithValue("@name", name);
                sqlCommand.Parameters.AddWithValue("@surname", surname);
                try
                {
                    int rows = sqlCommand.ExecuteNonQuery();
                    if (rows == 1)
                    {
                        success = true;
                        userEmail = email;
                        using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                userName = (string)dataReader["Name"];
                                userSurname = (string)dataReader["Surname"];
                            }
                        }
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
}