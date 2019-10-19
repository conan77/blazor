using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class HisOrderZheKou
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public string OrderId { get; set; }
        public string OrderCode { get; set; }
        public string Zkid { get; set; }
        public string Zkname { get; set; }
        public decimal ZkziDingYi { get; set; }
        public byte ZheKouType { get; set; }
        public string AddUser { get; set; }
        public string AddUserName { get; set; }
        public string ShouQuanRenId { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public int ZheKouSource { get; set; }
        public string Bak1 { get; set; }
        public string Bak2 { get; set; }
        public string AttachZheKouId { get; set; }
    }
}
