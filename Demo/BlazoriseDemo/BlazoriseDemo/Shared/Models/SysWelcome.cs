using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class SysWelcome
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public int GroupId { get; set; }
        public string Welcome { get; set; }
        public string KeyWord { get; set; }
        public string Memo { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string CenterUid { get; set; }
    }
}
