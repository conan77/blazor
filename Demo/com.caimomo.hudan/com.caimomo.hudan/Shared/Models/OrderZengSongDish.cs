using System;
using System.Collections.Generic;
using com.caimomo.Dapper.Base;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class OrderZengSongDish:IEntity
    {
        public string Uid { get; set; }
        public string OrderId { get; set; }
        public int StoreId { get; set; }
        public string OrderZhuoTaiId { get; set; }
        public string OrderZhuoTaiDishId { get; set; }
        public bool IsPackage { get; set; }
        public string PackageDishDetailId { get; set; }
        public string ZengSongDesc { get; set; }
        public decimal DishNum { get; set; }
        public decimal Tzsnum { get; set; }
        public DateTime AddTime { get; set; }
        public string AddUser { get; set; }

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
