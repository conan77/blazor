using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using NLog;

namespace com.caimomo.Dapper
{
    public class ConnectionBase : IConnectionBase
    {
       public void ChangeDatabase(string databaseName)
        {
            DbConnection.ChangeDatabase(databaseName);
        }

        public void Close()
        {
            if (DbConnection.State != ConnectionState.Closed)
            {
                DbConnection.Close();
            }
        }

        public void Open()
        {
            if (DbConnection.State != ConnectionState.Open)
            {
                DbConnection.Open();
            }
        }


        public string ConnectString => DbConnection.ConnectionString ?? string.Empty;

        public IDbConnection DbConnection { get; set; }
        public Logger Log { get; set; }
    }
}
