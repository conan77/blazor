using System;
using System.Collections.Generic;
using com.caimomo.Dapper.Base;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class SysBiaoQian:IEntity
    {
        public string Uid { get; set; }
        public string BiaoQianName { get; set; }
        public string PaperType { get; set; }
        public int? DisplayOrder { get; set; }
        public bool IsEnable { get; set; }
        public string AddUser { get; set; }
        public DateTime? AddTime { get; set; }
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
