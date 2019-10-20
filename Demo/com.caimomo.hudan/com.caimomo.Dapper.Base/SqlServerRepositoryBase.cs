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
    public class SqlServerRepositoryBase : IRepositoryBase
    {
        public SqlServerRepositoryBase(SqlConnection dbConnection)
        {
            this.DbConnection = dbConnection;
        }
        public SqlServerRepositoryBase(string connectionString)
        {
            this.DbConnection = new SqlConnection(connectionString);
        }

        public string ConnectionString => DbConnection?.ConnectionString ?? string.Empty;

        public RepositoryBaseType DatabaseType => RepositoryBaseType.Sqlserver;

        public IDbConnection DbConnection { get; set; }
        public IEntity GetById(object id)
        {
            throw new NotImplementedException();
        }

        public List<IEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(IEnumerable<IEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(IEnumerable<IEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IEnumerable<IEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}
