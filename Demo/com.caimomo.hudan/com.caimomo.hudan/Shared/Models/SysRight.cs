using System;
using System.Collections.Generic;
using com.caimomo.Dapper.Base;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class SysRight:IEntity
    {
        public int RightId { get; set; }
        public string RightName { get; set; }
        public int RightType { get; set; }
        public string PageName { get; set; }
        public string ClassName { get; set; }
        public int Sort { get; set; }
        /// <summary>
        /// 得到主键
        /// </summary>
        /// <returns></returns>
        public object GetPrimaryKey()
        {
            return this.RightId;
        }

        /// <summary>
        /// 设置主键
        /// </summary>
        /// <param name="value">主键值</param>
        public void SetPrimaryKey(object value)
        {
            this.RightId = Convert.ToInt32(value);
        }
    }
}
