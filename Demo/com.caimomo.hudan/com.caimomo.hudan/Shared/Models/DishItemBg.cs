using System;
using System.Collections.Generic;
using com.caimomo.Dapper.Base;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class DishItemBg:IEntity
    {
        public string Uid { get; set; }
        public string ItemId { get; set; }
        public int Mode { get; set; }
        public string ForeColor { get; set; }
        public string BgColor { get; set; }
        public string BmpPath { get; set; }
        public DateTime AddTime { get; set; }
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
