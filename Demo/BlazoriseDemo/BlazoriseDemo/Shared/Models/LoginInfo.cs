using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class LoginInfo
    {
        public string Uid { get; set; }
        public string UserId { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime LogoutTime { get; set; }
        public int Status { get; set; }
        public string Site { get; set; }
        public string Memo { get; set; }
        public DateTime AddTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
