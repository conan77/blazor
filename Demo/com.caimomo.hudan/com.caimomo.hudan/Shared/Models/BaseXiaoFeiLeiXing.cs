using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class BaseXiaoFeiLeiXing
    {
        public string Uid { get; set; }
        public string Name { get; set; }
        public int StoreId { get; set; }
        public int GroupId { get; set; }
        public DateTime AddTime { get; set; }
        public string AddUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string UpdateUser { get; set; }
        public bool IfJiShi { get; set; }
        public int? JiShiMoShi { get; set; }
        public decimal? JiShiFeiYong { get; set; }
        public bool? IsEnable { get; set; }
        public int? DepositType { get; set; }
        public decimal? DepositPrice { get; set; }
    }
}
