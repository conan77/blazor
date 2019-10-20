using System;
using System.Collections.Generic;
using com.caimomo.Dapper.Base;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class BaseMdbrand : IEntity
    {
        public string BrandId { get; set; }
        public int GroupId { get; set; }
        public int StoreId { get; set; }
        public string BrandNo { get; set; }
        public string BrandName { get; set; }
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
            return this.BrandId;
        }

        /// <summary>
        /// 设置主键
        /// </summary>
        /// <param name="value">主键值</param>
        public void SetPrimaryKey(object value)
        {
            this.BrandId = value.ToString();
        }
    }
}
