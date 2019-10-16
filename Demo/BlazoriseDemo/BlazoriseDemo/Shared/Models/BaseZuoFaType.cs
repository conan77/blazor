using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class BaseZuoFaType
    {
        public string Uid { get; set; }
        public string TypeName { get; set; }
        public string QuickCode { get; set; }
        public bool IsEnable { get; set; }
        public int GroupId { get; set; }
        public int StoreId { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Memo { get; set; }
    }
}
