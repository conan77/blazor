using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class BaseCanBie
    {
        public string Uid { get; set; }
        public int SeqId { get; set; }
        public int StoreId { get; set; }
        public string Cbname { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Memo { get; set; }
        public bool? IsEnable { get; set; }
        public bool? CanPreordain { get; set; }
    }
}
