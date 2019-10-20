using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace com.caimomo.Dapper.Base
{
    /// <summary>
    /// 基类业务接口定义
    /// </summary>
    public class SqlServerRepository : IRepositoryBase
    {
        public SqlServerRepository(SqlConnection dbConnection)
        {
            this.DbConnection = dbConnection;
        }
        public SqlServerRepository(string connectionString)
        {
            this.DbConnection = new SqlConnection(connectionString);
        }

        public string ConnectionString { get; set; }

        public RepositoryBaseType DatabaseType => RepositoryBaseType.Sqlserver;

        public IDbConnection DbConnection { get; set; }
    }
}
