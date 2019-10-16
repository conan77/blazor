using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class HisPreordain
    {
        public string Uid { get; set; }
        public int GroupId { get; set; }
        public int StoreId { get; set; }
        public string MemberUid { get; set; }
        public string MemberName { get; set; }
        public byte? Sex { get; set; }
        public bool? IsMember { get; set; }
        public string Contact { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public int? PeopleNum { get; set; }
        public int? Status { get; set; }
        public string Memo1 { get; set; }
        public string Memo2 { get; set; }
        public string Memo3 { get; set; }
        public string ZhuoTaiUids { get; set; }
        public string ZhuoTaiNames { get; set; }
        public DateTime? AddTime { get; set; }
        public string AddUser { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string UpdateUser { get; set; }
        public string CanBieUid { get; set; }
        public DateTime? PreordainDate { get; set; }
        public string PhoneCallRecordUid { get; set; }
        public string ManagerUid { get; set; }
        public string ManagerName { get; set; }
        public int MemberLevel { get; set; }
        public DateTime? ArriveTime { get; set; }
        public string PreordainType { get; set; }
        public string PreordainCode { get; set; }
    }
}
