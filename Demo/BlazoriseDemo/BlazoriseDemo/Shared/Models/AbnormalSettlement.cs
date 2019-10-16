using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class AbnormalSettlement
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public string CwkmId { get; set; }
        public decimal PayMoney { get; set; }
        public string RelatedOrderId { get; set; }
        public string PayMark { get; set; }
        public string Memo1 { get; set; }
        public string Memo2 { get; set; }
        public string Memo3 { get; set; }
        public int Status { get; set; }
        public DateTime AddTime { get; set; }
        public string AddUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string UpdateUser { get; set; }
    }
}
