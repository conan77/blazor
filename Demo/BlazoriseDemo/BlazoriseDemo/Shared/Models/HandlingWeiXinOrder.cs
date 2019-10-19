using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class HandlingWeiXinOrder
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public string OrderId { get; set; }
        public string OrderCode { get; set; }
        public int TotalPeopleNum { get; set; }
        public int Status { get; set; }
        public string ZhuoTaiId { get; set; }
        public string ZhuoTaiName { get; set; }
        public decimal OrderMoney { get; set; }
        public string MemberId { get; set; }
        public string MemberName { get; set; }
        public string OrderDetail { get; set; }
        public DateTime AddTime { get; set; }
        public string AddUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string UpdateUser { get; set; }
    }
}
