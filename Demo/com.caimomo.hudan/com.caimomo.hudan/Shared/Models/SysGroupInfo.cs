using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class SysGroupInfo
    {
        public int Uid { get; set; }
        public string GroupName { get; set; }
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
        public DateTime AddTime { get; set; }
        public string AddUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string UpdateUser { get; set; }
        public string AppId { get; set; }
        public string AppSecret { get; set; }
        public string MchId { get; set; }
        public string AboutUs { get; set; }
        public string Wxid { get; set; }
        public string WelImageUrl { get; set; }
    }
}
