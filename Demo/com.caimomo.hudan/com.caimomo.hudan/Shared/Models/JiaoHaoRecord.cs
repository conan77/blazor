using System;
using System.Collections.Generic;
using com.caimomo.Dapper.Base;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class JiaoHaoRecord:IEntity
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public string OrderId { get; set; }
        public string Ztname { get; set; }
        public string OrderZhuoTaiDishUid { get; set; }
        public string DishName { get; set; }
        public int IsCallNumber { get; set; }
        public int Count { get; set; }
        public string Memo { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        /// <summary>
        /// 得到主键
        /// </summary>
        /// <returns></returns>
        public object GetPrimaryKey()
        {
            return this.Uid;
        }

        /// <summary>
        /// 设置主键
        /// </summary>
        /// <param name="value">主键值</param>
        public void SetPrimaryKey(object value)
        {
            this.Uid = value.ToString();
        }
    }
}
