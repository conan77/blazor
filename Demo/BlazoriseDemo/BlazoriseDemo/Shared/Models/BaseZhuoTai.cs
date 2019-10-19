using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class BaseZhuoTai
    {
        public string Uid { get; set; }
        public string Ztcode { get; set; }
        public string Ztname { get; set; }
        public string Tmlcid { get; set; }
        public int MaxPeopleNum { get; set; }
        public int MinPeopleNum { get; set; }
        public decimal MinMoney { get; set; }
        public bool? IsEnable { get; set; }
        public int DisplayId { get; set; }
        public int StoreId { get; set; }
        public bool IsTemp { get; set; }
        public string ParentId { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Memo { get; set; }
        public bool? CanPreordain { get; set; }
        public string ZhuoTaiType { get; set; }
        public string ZtquickCode { get; set; }
        public int MinXiaoFeiType { get; set; }
    }
}
