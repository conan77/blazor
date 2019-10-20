using System;
using System.Collections.Generic;
using com.caimomo.Dapper.Base;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class SysMedias:IEntity
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public int GroupId { get; set; }
        public string ParentId { get; set; }
        public bool IsDefault { get; set; }
        public DateTime AddTime { get; set; }
        public string AddUser { get; set; }
        public string FilePath { get; set; }
        public string MimeType { get; set; }
        public string FileName { get; set; }
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
