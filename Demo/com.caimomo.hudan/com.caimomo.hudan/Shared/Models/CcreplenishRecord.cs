using System;
using System.Collections.Generic;
using com.caimomo.Dapper.Base;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class CcreplenishRecord:IEntity
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public string BatchCode { get; set; }
        public DateTime OperateDate { get; set; }
        public string DishTypeId { get; set; }
        public string DishTypeName { get; set; }
        public string DishId { get; set; }
        public string DishName { get; set; }
        public decimal DishNum { get; set; }
        public string UnitId { get; set; }
        public string UnitName { get; set; }
        public decimal DishSignNum { get; set; }
        public string SignType { get; set; }
        public bool IsBuHuo { get; set; }
        public bool IsEnable { get; set; }
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
