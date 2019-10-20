using System;
using System.Collections.Generic;
using com.caimomo.Dapper.Base;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class SysBiaoQianDetail:IEntity
    {
        public string Uid { get; set; }
        public string BiaoQianUid { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int FontSize { get; set; }
        public int Bold { get; set; }
        public int Width { get; set; }
        public string FiledName { get; set; }
        public int LineNum { get; set; }
        public bool ShowTitle { get; set; }
        public string ShowTitleName { get; set; }
        public string DateFormat { get; set; }
        public string Font { get; set; }
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
