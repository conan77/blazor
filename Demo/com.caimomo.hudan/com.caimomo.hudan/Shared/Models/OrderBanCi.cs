using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class OrderBanCi
    {
        public string Uid { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool IfJieBan { get; set; }
        public bool IfJiaoZhang { get; set; }
        public string BanCiHao { get; set; }
        public int StoreId { get; set; }
        public decimal JiaoZhangMoney { get; set; }
        public DateTime AddTime { get; set; }
        public string AddUser { get; set; }
        public bool? IfJiuShui { get; set; }
        public string Memo1 { get; set; }
        public string Memo2 { get; set; }
    }
}
