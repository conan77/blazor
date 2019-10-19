using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class BaseDishCuXiao
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public int GroupId { get; set; }
        public string CuXiaoName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Weeks { get; set; }
        public string CanBieIds { get; set; }
        public bool IsEnable { get; set; }
        public string AddUser { get; set; }
        public DateTime AddTime { get; set; }
        public string UpdateUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public int MaxCount { get; set; }
        public int ActivityShare { get; set; }
    }
}
