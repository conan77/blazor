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
    public class SqlServerRepository<TEntity> where TEntity : IEntity , IRepositoryBase
    {
        public SqlServerRepository(SqlConnection dbConnection)
        {
            this.DbConnection = dbConnection;
        }
        public SqlServerRepository(string connectionString)
        {
            this.DbConnection = new SqlConnection(connectionString);
        }

        public string ConnectionString => DbConnection?.ConnectionString ?? string.Empty;

        public RepositoryBaseType DatabaseType => RepositoryBaseType.Sqlserver;

        public IDbConnection DbConnection { get; set; }
        public TEntity GetById(object id)
        {
            throw new NotImplementedException();
        }

        public List<IEntity> GetAll()
        {
            var tableName = nameof(TEntity);
            DbConnection.
            throw new NotImplementedException();
        }

        public void Insert(TEntity entity)
        {

        }

        public void Insert(IEnumerable<TEntity> entities)
        {
        }

        public void Update(TEntity entity)
        {
        }

        public void Update(IEnumerable<TEntity> entities)
        {
        }

        public void Delete(TEntity entity)
        {
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
        }
    }
}
