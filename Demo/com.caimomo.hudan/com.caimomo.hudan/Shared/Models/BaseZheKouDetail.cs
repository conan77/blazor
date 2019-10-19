using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class BaseZheKouDetail
    {
        public string Uid { get; set; }
        public string TemplateId { get; set; }
        public decimal Parameters { get; set; }
        public decimal DiscountPrice { get; set; }
        public byte Xxtype { get; set; }
        public string Xxid { get; set; }
        public int StoreId { get; set; }
        public bool IsRefParameters { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Memo { get; set; }
    }
}
