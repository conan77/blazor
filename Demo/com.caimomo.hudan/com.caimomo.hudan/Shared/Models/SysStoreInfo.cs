using System;
using System.Collections.Generic;
using com.caimomo.Dapper.Base;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class SysStoreInfo:IEntity
    {
        public int Uid { get; set; }
        public int GroupId { get; set; }
        public string StoreName { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string RegionId { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string ContactName { get; set; }
        public string Telephone { get; set; }
        public int BankType { get; set; }
        public string BankAccountName { get; set; }
        public string BankAccount { get; set; }
        public bool? IsSingleStore { get; set; }
        public string WeiXinId { get; set; }
        public DateTime AddTime { get; set; }
        public string AddUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string UpdateUser { get; set; }
        public string CaiPuUid { get; set; }
        public string CaiPuName { get; set; }
        public string BrandUid { get; set; }
        public string BrandName { get; set; }
        public int StoreType { get; set; }
        public int? DistributionCenterId { get; set; }
        public string JingDu { get; set; }
        public string WeiDu { get; set; }
        public string ImgUrl { get; set; }
        public bool IfShowInWeixin { get; set; }
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
            this.Uid = Convert.ToInt32(value);
        }
    }
}
