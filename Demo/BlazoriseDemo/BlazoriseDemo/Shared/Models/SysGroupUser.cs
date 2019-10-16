using System;
using System.Collections.Generic;

namespace BlazoriseDemo.Shared
{
    public partial class SysGroupUser
    {
        public string Uid { get; set; }
        public int GroupId { get; set; }
        public int StoreId { get; set; }
        public string UserId { get; set; }
        public string TrueName { get; set; }
        public string Password { get; set; }
        public string CurrentToken { get; set; }
        public bool? AllStore { get; set; }
        public string StoreList { get; set; }
        public string Macbind { get; set; }
        public string Telephone { get; set; }
        public string Qq { get; set; }
        public string Wxid { get; set; }
        public int CheckCode { get; set; }
        public DateTime LastCheckTime { get; set; }
        public string ShouQuanCode { get; set; }
        public bool IsManager { get; set; }
        public string PasswordBak { get; set; }
        public DateTime AddTime { get; set; }
        public string AddUser { get; set; }
        public DateTime UpdateTime { get; set; }
        public string UpdateUser { get; set; }
        public bool? IsEnable { get; set; }
        public decimal YouMian { get; set; }
        public string OtherAccountType { get; set; }
        public string OtherUserName { get; set; }
        public string OtherPassWord { get; set; }
        public bool? IsGuestManager { get; set; }
        public int? YouMianBiLi { get; set; }
        public int? ZheKouBiLi { get; set; }
    }
}
