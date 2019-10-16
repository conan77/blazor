using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class CccheckDish
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public DateTime CheckDate { get; set; }
        public bool IsEnable { get; set; }
        public bool IsJiaoZhang { get; set; }
        public bool IsSoldOut { get; set; }
        public bool IsValid { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
