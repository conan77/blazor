using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class HandlingWeiXinPreordainOrder
    {
        public string Uid { get; set; }
        public int GroupId { get; set; }
        public int StoreId { get; set; }
        public string ReserveUid { get; set; }
        public string MemberId { get; set; }
        public string MemberName { get; set; }
        public string MemberTel { get; set; }
        public int? PeoPleCount { get; set; }
        public int? ZhuoTaiCount { get; set; }
        public DateTime? ReserveTime { get; set; }
        public decimal? Price { get; set; }
        public int? Status { get; set; }
        public int? DealStatus { get; set; }
        public string Remark { get; set; }
        public string HisPreordainUid { get; set; }
        public string CanBieUid { get; set; }
        public string CanBieName { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool? IsEnable { get; set; }
        public string AddUser { get; set; }
        public DateTime? AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string Ztuid { get; set; }
        public string Ztname { get; set; }
        public string Reason { get; set; }
        public string Bak1 { get; set; }
        public string Bak2 { get; set; }
        public string Bak3 { get; set; }
    }
}
