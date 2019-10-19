using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class HisOrderShouQuanRecords
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public string OrderId { get; set; }
        public string OrderCode { get; set; }
        public string ShouQuanRight { get; set; }
        public string ShouQuanContent { get; set; }
        public string ShouQuanUserId { get; set; }
        public string ShouQuanUserName { get; set; }
        public string Memo1 { get; set; }
        public string Memo2 { get; set; }
        public string AddUser { get; set; }
        public string AddUserName { get; set; }
        public DateTime AddTime { get; set; }
    }
}
