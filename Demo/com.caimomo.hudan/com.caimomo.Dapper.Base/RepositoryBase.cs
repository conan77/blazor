using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using Dapper.Contrib;

namespace com.caimomo.Dapper.Base
{
    /// <summary>
    /// 基类业务接口定义
    /// </summary>
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : IEntity 
    {
        #region 成员
        /// <summary>
        /// Dapper配置
        /// </summary>
        public DapperConfig Config { get; }
        public string TableName { get; }
        /// <summary>
        /// 数据库连接
        /// </summary>
        public SqlConnection DbConnection => Config.DbConnection as SqlConnection;

        #endregion

        #region 构造
        public RepositoryBase(DapperConfig config,string tableName)
        {
            this.Config = config;
            this.TableName = tableName;
        }
        private RepositoryBase() { }
        #endregion

        #region 公用方法
        
        /// <summary>
        /// 添加一个实体
        /// </summary>
        /// <param name="entity">要创建的实体</param>
        /// <returns>是否成功</returns>
        public bool CreateEntity(TEntity entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据主键Id获取一个实体
        /// </summary>
        /// <param name="uid">主键Id</param>
        /// <returns>实体</returns>
        public TEntity GetEntityById(object uid)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 条件获取实体
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <returns>查询的实体</returns>
        public IEnumerable<TEntity> GetEntityBySql(string sql)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取所有实体
        /// </summary>
        /// <returns>所有实体</returns>
        public IEnumerable<TEntity> GetAllEntity()
        {
            var sql = $"Select * from {TableName}";
            return DbConnection.Query<TEntity>(sql);
        }


        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="entity">要修改的实体</param>
        /// <returns>是否成功</returns>
        public bool UpdateEntity(TEntity entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据主键Id删除一个实体
        /// </summary>
        /// <param name="uid">主键Id</param>
        /// <returns>实体</returns>
        public bool DeleteEntityById(object uid)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
