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
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; }
        /// <summary>
        /// 主键名
        /// </summary>
        public string KeyName { get; }
        /// <summary>
        /// 数据库连接
        /// </summary>
        public DbConnection DbConnection => Config.DbConnection;
        #endregion

        #region 构造
        public RepositoryBase(DapperConfig config)
        {
            this.Config = config;
            this.TableName = GetTableName<TEntity>();
            this.KeyName = GetKey<TEntity>();

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
            var sql = FixSql($"Select * from {TableName} where {GetKey<TEntity>()}={uid}");
            return DbConnection.Query<TEntity>(sql).FirstOrDefault();
        }

        /// <summary>
        /// 条件获取实体
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <returns>查询的实体</returns>
        public IEnumerable<TEntity> GetEntityBySql(string sql)
        {
            sql = FixSql(sql);
            return DbConnection.Query<TEntity>(sql);
        }

        /// <summary>
        /// 获取所有实体
        /// </summary>
        /// <returns>所有实体</returns>
        public IEnumerable<TEntity> GetAllEntity()
        {
            var sql = FixSql($"Select * from {TableName}");
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

        #region 私有方法
        /// <summary>
        /// 修复sql
        /// </summary>
        /// <param name="sql">原始sql</param>
        /// <returns>修复后的</returns>
        private string FixSql(string sql)
        {
            return sql;
        }

        /// <summary>
        /// 得到主键名
        /// </summary>
        /// <typeparam name="TEntity">实体类</typeparam>
        /// <exception cref="DbException">未定义主键错误</exception>
        /// <returns>主键名</returns>
        private string GetKey<TEntity>()
        {
            var type = typeof(TEntity);
            var props = type.GetProperties().SelectMany(x => x.CustomAttributes);
            var prop = props.FirstOrDefault(x => x.AttributeType.Name.Equals("KeyAttribute", StringComparison.CurrentCultureIgnoreCase));
            if (prop != null)
            {
                return prop.AttributeType.Name;
            }
            else
            {
                throw new Exception("未定义主键");
            }
        }

        private string GetTableName<TEntity>()
        {
            var type = typeof(TEntity);
            string defaultName = type.Name;
            var props = type.CustomAttributes;
            var prop = props.FirstOrDefault(x => x.AttributeType.Name.Equals("TableAttribute", StringComparison.CurrentCultureIgnoreCase));
            if (prop != null)
            {
                return prop.ConstructorArguments.First().ToString();
            }
            return defaultName;
        }
        #endregion
    }
}
