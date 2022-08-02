using System.Data.SqlClient;

namespace Project_Milestone_2
{
    internal class SalesManger
    {
        readonly SqlConnection sqlConnection;

        public SalesManger(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }


    }
}