using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class DailyBalanceRecord
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public string SettleDate { get; set; }
        public int Status { get; set; }
        public DateTime SettleTime { get; set; }
        public string SettleUserId { get; set; }
        public string SettleUserName { get; set; }
        public string Bak1 { get; set; }
        public string Bak2 { get; set; }
        public DateTime AddTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
