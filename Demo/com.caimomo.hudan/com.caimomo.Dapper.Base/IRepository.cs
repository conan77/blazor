using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.caimomo.Dapper.Base
{
    /// <summary>
    /// 基类业务接口定义
    /// </summary>
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        #region 成员
        /// <summary>
        /// Dapper配置
        /// </summary>
        DapperConfig Config { get; }
        #endregion

        #region 公用方法
        /// <summary>
        /// 添加一个实体
        /// </summary>
        /// <param name="entity">要创建的实体</param>
        /// <returns>是否成功</returns>
        bool CreateEntity(TEntity entity);

        /// <summary>
        /// 根据主键Id获取一个实体
        /// </summary>
        /// <param name="uid">主键Id</param>
        /// <returns>实体</returns>
        TEntity GetEntityById(object uid);

        /// <summary>
        /// 条件获取实体
        /// </summary>
        /// <param name="sql">Sql语句</param>
        /// <returns>查询的实体</returns>
        IEnumerable<TEntity> GetEntityBySql(string sql);

        /// <summary>
        /// 获取所有实体
        /// </summary>
        /// <returns>所有实体</returns>
        IEnumerable<TEntity> GetAllEntity();


        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="entity">要修改的实体</param>
        /// <returns>是否成功</returns>
        bool UpdateEntity(TEntity entity);

        /// <summary>
        /// 根据主键Id删除一个实体
        /// </summary>
        /// <param name="uid">主键Id</param>
        /// <returns>实体</returns>
        bool DeleteEntityById(object uid);
        #endregion
    }
}
