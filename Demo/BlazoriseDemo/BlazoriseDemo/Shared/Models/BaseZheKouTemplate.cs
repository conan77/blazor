using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class BaseZheKouTemplate
    {
        public string Uid { get; set; }
        public string TempName { get; set; }
        public string TempCode { get; set; }
        public decimal Parameters { get; set; }
        public bool? IsEnable { get; set; }
        public int StoreId { get; set; }
        public bool NeedMember { get; set; }
        public int MinMemberLevel { get; set; }
        public string CanBieId { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Memo { get; set; }
        public string CaiPuIds { get; set; }
        public bool IsHuiYuanPrice { get; set; }
        public string ZongBuUid { get; set; }
        public decimal ZheKouLimit { get; set; }
    }
}
