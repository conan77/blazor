using System;
using System.Collections.Generic;
using com.caimomo.Dapper.Base;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class BasePackageNotUsed : IEntity
    {
        public string Uid { get; set; }
        public string PackageCode { get; set; }
        public string PackageName { get; set; }
        public string UnitId { get; set; }
        public string UintName { get; set; }
        public string QuickCode { get; set; }
        public decimal SalePrice { get; set; }
        public decimal Vipprice { get; set; }
        public decimal WebPrice { get; set; }
        public decimal TotalMoney { get; set; }
        public bool? IsEnable { get; set; }
        public int StoreId { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Memo { get; set; }

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
