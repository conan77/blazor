using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class SysMedias
    {
        public string Uid { get; set; }
        public int StoreId { get; set; }
        public int GroupId { get; set; }
        public string ParentId { get; set; }
        public bool IsDefault { get; set; }
        public DateTime AddTime { get; set; }
        public string AddUser { get; set; }
        public string FilePath { get; set; }
        public string MimeType { get; set; }
        public string FileName { get; set; }
        public string Memo { get; set; }
    }
}
