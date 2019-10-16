using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HuaDan
{
    public class SysGroupUserModel
    {
        public string UID { get; set; }

        public int GroupID { get; set; }

        public int StoreID { get; set; }

        public string UserID { get; set; }

        public string TrueName { get; set; }

        public string Password { get; set; }

        public string CurrentToken { get; set; }

        public bool AllStore { get; set; }

        public string StoreList { get; set; }

        public string MACBind { get; set; }

        public string Telephone { get; set; }

        public string QQ { get; set; }

        public string WXID { get; set; }

        public string ShouQuanCode { get; set; }

        public int CheckCode { get; set; }

        public System.DateTime LastCheckTime { get; set; }

        public bool IsManager { get; set; }

        public bool IsEnable { get; set; }

        public decimal YouMian { get; set; }

        public string PasswordBak { get; set; }

        public System.DateTime AddTime { get; set; }

        public string AddUser { get; set; }

        public System.DateTime UpdateTime { get; set; }

        public string UpdateUser { get; set; }

        public string OtherAccountType { get; set; }

        public string OtherUserName { get; set; }

        public string OtherPassWord { get; set; }

        public bool IsGuestManager { get; set; }

        public System.Nullable<int> YouMianBiLi { get; set; }

        public System.Nullable<int> ZheKouBiLi { get; set; }
    }
}
