using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Milestone_2
{
    internal class ItemManger
    {
        SqlConnection sqlConnection;

        public ItemManger(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }


    }
}
