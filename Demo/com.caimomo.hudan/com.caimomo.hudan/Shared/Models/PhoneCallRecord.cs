using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class PhoneCallRecord
    {
        public string Uid { get; set; }
        public int GroupId { get; set; }
        public int StoreId { get; set; }
        public string Phone { get; set; }
        public string AddUser { get; set; }
        public DateTime? UpdateTime { get; set; }
        public int? Status { get; set; }
        public string Contact { get; set; }
        public DateTime? CallTime { get; set; }
    }
}
