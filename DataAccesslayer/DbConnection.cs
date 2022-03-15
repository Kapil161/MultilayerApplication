using System;
using CommonAccesslayer.Models;
using Microsoft.Data.SqlClient;

namespace DataAccesslayer
{
    public class DbConnection
    {
        public SqlConnection cnn;
        public DbConnection()
        {
            cnn = new SqlConnection(Connection.ConnectionStr);
        }

    }
}
