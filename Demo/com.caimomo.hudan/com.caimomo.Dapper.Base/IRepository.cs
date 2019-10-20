using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace com.caimomo.Dapper.Base
{
    /// <summary>
    /// 基类业务接口定义
    /// </summary>
    public interface IRepository<T> : IRepositoryBase where T : IEntity
    {
        /// <summary>
        /// 添加一个实体
        /// </summary>
        /// <param name="entity">要创建的实体</param>
        /// <returns>是否成功</returns>
        bool CreateEntity(T entity);

        /// <summary>
        /// 根据主键Id获取一个实体
        /// </summary>
        /// <param name="uid">主键Id</param>
        /// <returns>实体</returns>
        T GetEntityById(object uid);

        /// <summary>
        /// 获取所有实体
        /// </summary>
        /// <returns>所有实体</returns>
        IEnumerable<T> GetAllEntity();

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="entity">要修改的实体</param>
        /// <returns>是否成功</returns>
        bool UpdateEntity(T entity);

        /// <summary>
        /// 根据主键Id删除一个实体
        /// </summary>
        /// <param name="uid">主键Id</param>
        /// <returns>实体</returns>
        bool DeleteEntityById(object uid);
    }
}
