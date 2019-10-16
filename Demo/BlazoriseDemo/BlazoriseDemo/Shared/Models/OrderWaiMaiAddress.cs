using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class OrderWaiMaiAddress
    {
        public string Uid { get; set; }
        public string OrderId { get; set; }
        public string Code { get; set; }
        public string MemberId { get; set; }
        public string Address { get; set; }
        public string LinkName { get; set; }
        public string LinkTel { get; set; }
        public string ArriveTime { get; set; }
        public string Sender { get; set; }
        public bool HasSend { get; set; }
        public bool HasPay { get; set; }
        public bool? HasAccept { get; set; }
        public string Bak1 { get; set; }
        public string Bak2 { get; set; }
        public string Bak3 { get; set; }
        public DateTime AddTime { get; set; }
        public string AddUser { get; set; }
        public bool HasRefused { get; set; }
        public int Source { get; set; }
        public string Bak4 { get; set; }
        public string Bak5 { get; set; }
        public string Bak6 { get; set; }
        public string Bak7 { get; set; }
        public string Bak8 { get; set; }
    }
}
