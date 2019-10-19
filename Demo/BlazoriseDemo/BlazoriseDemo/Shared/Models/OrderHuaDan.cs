using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class OrderHuaDan
    {
        public string Uid { get; set; }
        public int? GroupId { get; set; }
        public int? StoreId { get; set; }
        public string ZtdishUid { get; set; }
        public string Ztname { get; set; }
        public DateTime? XiaDanTime { get; set; }
        public DateTime? QiangDanTime { get; set; }
        public DateTime? HuaDanTime { get; set; }
        public decimal? TotalNum { get; set; }
        public decimal? HuaDanNum { get; set; }
        public string QiangDanUser { get; set; }
        public bool? IsEnable { get; set; }
        public string AddUser { get; set; }
        public DateTime? AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string Bak1 { get; set; }
        public string Bak2 { get; set; }
        public string Bak3 { get; set; }
    }
}
