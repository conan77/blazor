using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class BaseMdbrand
    {
        public string BrandId { get; set; }
        public int GroupId { get; set; }
        public int StoreId { get; set; }
        public string BrandNo { get; set; }
        public string BrandName { get; set; }
        public string Memo { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
