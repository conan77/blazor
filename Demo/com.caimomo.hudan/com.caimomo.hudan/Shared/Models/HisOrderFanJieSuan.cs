using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class HisOrderFanJieSuan
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public string OrderId { get; set; }
        public string OrderCode { get; set; }
        public string JieSuanOrderId { get; set; }
        public decimal FanJieSuanMoney { get; set; }
        public int FanJieSuanNum { get; set; }
        public string OrderFanJieSuanDesc { get; set; }
        public string Memo1 { get; set; }
        public string Memo2 { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
