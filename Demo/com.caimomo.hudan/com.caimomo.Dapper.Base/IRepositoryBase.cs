using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace com.caimomo.Dapper.Base
{
    /// <summary>
    /// 基类业务接口定义
    /// </summary>
    public interface IRepositoryBase
    {
        /// <summary>
        /// 数据连接字符串
        /// </summary>
        string ConnectionString { get; }
        /// <summary>
        /// 数据库类型
        /// </summary>
        RepositoryBaseType DatabaseType { get; }

        /// <summary>
        /// 数据库连接
        /// </summary>
        IDbConnection DbConnection { get; set; }

        #region Methods

        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        IEntity GetById(object id);

        List<IEntity> GetAll();
        
        // <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Insert(IEntity entity);

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Insert(IEnumerable<IEntity> entities);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Update(IEntity entity);

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Update(IEnumerable<IEntity> entities);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Delete(IEntity entity);

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Delete(IEnumerable<IEntity> entities);

        #endregion

    }
}
