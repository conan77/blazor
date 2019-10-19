using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace HuaDan
{
    public class Tools
    {
        public static SysGroupUser CurrentUser;
    }

    public class SysGroupUser
    {
        public string UID { get; set; }
        public int GroupID { get; set; }
        public int StoreID { get; set; }
        public string UserID { get; set; }
        public string TrueName { get; set; }
    }
}
