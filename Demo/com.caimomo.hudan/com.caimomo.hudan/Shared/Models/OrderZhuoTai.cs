using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class OrderZhuoTai
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public string OrderId { get; set; }
        public string ZhuoTaiId { get; set; }
        public string ZhuoTaiName { get; set; }
        public int ZtpeopleNum { get; set; }
        public int ZhuoTaiDishOrder { get; set; }
        public string Memo { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string WaiterId { get; set; }
        public string WaiterName { get; set; }
        public string Bak1 { get; set; }
        public string Bak2 { get; set; }
    }
}
