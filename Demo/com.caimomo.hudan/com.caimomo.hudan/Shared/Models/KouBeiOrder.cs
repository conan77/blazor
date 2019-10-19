using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class KouBeiOrder
    {
        public string Uid { get; set; }
        public string OrderCode { get; set; }
        public int StoreId { get; set; }
        public string BusinessType { get; set; }
        public string DinnerType { get; set; }
        public string OrderStyle { get; set; }
        public string PayStyle { get; set; }
        public string Channel { get; set; }
        public int PeopleNum { get; set; }
        public string TakeStyle { get; set; }
        public string TakeNo { get; set; }
        public decimal BillAmount { get; set; }
        public decimal ReceiptAmount { get; set; }
        public decimal TradeAmount { get; set; }
        public decimal PayAmount { get; set; }
        public decimal ServiceAmount { get; set; }
        public decimal PackingAmount { get; set; }
        public decimal OtherAmount { get; set; }
        public DateTime TableTime { get; set; }
        public DateTime OrderTime { get; set; }
        public string UserMobile { get; set; }
        public string Memo { get; set; }
        public string DishDetail { get; set; }
        public bool MemberFlag { get; set; }
        public string PayChannels { get; set; }
        public string ExtInfo { get; set; }
        public string ActionRemark { get; set; }
        public string OrderState { get; set; }
        public string PayState { get; set; }
        public bool NeedSupplement { get; set; }
        public string RelatedOrderId { get; set; }
        public string Bak1 { get; set; }
        public string Bak2 { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
