using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class HisPreordainBanquet
    {
        public string Uid { get; set; }
        public int GroupId { get; set; }
        public int StoreId { get; set; }
        public string PreOrdainUid { get; set; }
        public string EmployerName { get; set; }
        public string EmployerPhone { get; set; }
        public string EmployerName1 { get; set; }
        public string EmployerPhone1 { get; set; }
        public int Ztnum { get; set; }
        public int ZtnumBeiXuan { get; set; }
        public string BanquetUid { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
