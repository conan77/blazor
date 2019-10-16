using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class BaseKouWei
    {
        public string Uid { get; set; }
        public string Kwname { get; set; }
        public string Kwcode { get; set; }
        public bool? IsEnable { get; set; }
        public int StoreId { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Memo { get; set; }
        public string ZongBuUid { get; set; }
    }
}
