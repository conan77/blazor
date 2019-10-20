using System;
using System.Collections.Generic;
using com.caimomo.Dapper.Base;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class BaseZheKouDetail:IEntity
    {
        public string Uid { get; set; }
        public string TemplateId { get; set; }
        public decimal Parameters { get; set; }
        public decimal DiscountPrice { get; set; }
        public byte Xxtype { get; set; }
        public string Xxid { get; set; }
        public int StoreId { get; set; }
        public bool IsRefParameters { get; set; }
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
