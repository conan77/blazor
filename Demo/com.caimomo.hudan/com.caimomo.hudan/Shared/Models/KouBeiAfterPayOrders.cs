using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class KouBeiAfterPayOrders
    {
        public string Uid { get; set; }
        public string KouBeiOrderId { get; set; }
        public string BatchNo { get; set; }
        public string RelatedOrderId { get; set; }
        public string OrderZhuoTaiId { get; set; }
        public string BizProduct { get; set; }
        public string BusinessType { get; set; }
        public string DinnerType { get; set; }
        public string PayStyle { get; set; }
        public string OrderStyle { get; set; }
        public string TableNo { get; set; }
        public string Detail { get; set; }
        public int PeopleNum { get; set; }
        public decimal TotalAmount { get; set; }
        public string UserId { get; set; }
        public DateTime ReceiptTimeout { get; set; }
        public DateTime OrderTime { get; set; }
        public string Memo1 { get; set; }
        public string Memo2 { get; set; }
        public string Memo3 { get; set; }
        public DateTime AddTime { get; set; }
        public string AddUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string UpdateUser { get; set; }
        public int OrderStatus { get; set; }
    }
}
