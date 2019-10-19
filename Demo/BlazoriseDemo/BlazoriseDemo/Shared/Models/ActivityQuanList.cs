using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class ActivityQuanList
    {
        public string Uid { get; set; }
        public int GroupId { get; set; }
        public int StoreId { get; set; }
        public string OrderId { get; set; }
        public string ActivityId { get; set; }
        public string ActivityName { get; set; }
        public string MemberId { get; set; }
        public string QuanId { get; set; }
        public int Num { get; set; }
        public int Status { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime AddTime { get; set; }
        public string AddUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string UpdateUser { get; set; }
    }
}
