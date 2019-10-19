using System;
using System.Collections.Generic;

namespace com.caimomo.hudan.Shared.Models
{
    public partial class BaseDepartment
    {
        public string Uid { get; set; }
        public int GroupId { get; set; }
        public int StoreId { get; set; }
        public string DeptNo { get; set; }
        public string DeptName { get; set; }
        public string QuickCode { get; set; }
        public string ParentId { get; set; }
        public bool IsWarehouse { get; set; }
        public string Memo { get; set; }
        public string ManagerUid { get; set; }
        public string ManagerName { get; set; }
        public bool IsEnable { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public bool? IsNeedInventory { get; set; }
    }
}
