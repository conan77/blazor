using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class BaseZheKouRight
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public string ZheKouId { get; set; }
        public string UserId { get; set; }
        public DateTime AddTime { get; set; }
        public string AddUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string UpdateUser { get; set; }
    }
}
