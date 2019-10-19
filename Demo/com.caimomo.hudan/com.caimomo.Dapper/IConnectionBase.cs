using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.caimomo.Dapper
{
    public interface IConnectionBase
    {
        void ChangeDatabase(string databaseName);


        void Close();


        void Open();

        string ConnectString { get; }
        IDbConnection DbConnection { get; set; }
        NLog.Logger Log { get; set; }
    }
}
