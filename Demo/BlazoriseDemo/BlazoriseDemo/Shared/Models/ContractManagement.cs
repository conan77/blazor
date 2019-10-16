using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class ContractManagement
    {
        public string Uid { get; set; }
        public int GroupId { get; set; }
        public int StoreId { get; set; }
        public string Name { get; set; }
        public int SeqId { get; set; }
        public string Sign { get; set; }
        public bool IsEnable { get; set; }
        public string Remark { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
