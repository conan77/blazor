using System;
using System.Collections.Generic;
using com.caimomo.Dapper.Base;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class PrintHistory:IEntity
    {
        public string Uid { get; set; }
        public string PrinterId { get; set; }
        public string PrinterName { get; set; }
        public string PrintContent { get; set; }
        public string LastPrinter { get; set; }
        public string LastPrinterName { get; set; }
        public int PrintStatus { get; set; }
        public string Client { get; set; }
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
