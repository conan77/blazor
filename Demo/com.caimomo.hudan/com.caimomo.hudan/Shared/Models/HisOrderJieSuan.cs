using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class HisOrderJieSuan
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public string OrderId { get; set; }
        public string OrderCode { get; set; }
        public string Cwkmid { get; set; }
        public string Cwkmname { get; set; }
        public decimal ShouDaoMoney { get; set; }
        public decimal ZhaoLingMoney { get; set; }
        public decimal ShiShouMoney { get; set; }
        public byte JieSuanType { get; set; }
        public string JieSuanDesc { get; set; }
        public int JieSuanOrder { get; set; }
        public string Memo1 { get; set; }
        public string Memo2 { get; set; }
        public string Memo3 { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool? IsValid { get; set; }
    }
}
