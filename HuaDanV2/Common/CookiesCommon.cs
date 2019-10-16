using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace HuaDan
{
    public class CookiesCommon
    {

        public static string getCurrentUserCookie(string uid)
        {

            if (string.IsNullOrEmpty(uid.Trim()))
                return "";

            string sql = "select * from SysGroupUser where uid='" + uid + "'";
            DataTable dtSource = DBHelper.ExeSqlForDataTable(sql);

            List<SysGroupUserModel> sysgroupuserList = EntityUtil.ToList<SysGroupUserModel>(dtSource);
            if (sysgroupuserList.Count > 0)
            {
                sysgroupuserList[0].Password = "";
                sysgroupuserList[0].PasswordBak = "";
                //sysGroupUser.AllStore = sysGroupUser.AllStore == 1 ? true : false;
                //sysGroupUser.IsManager = sysGroupUser.IsManager == 1 ? true : false;
                //sysGroupUser.IsEnable = sysGroupUser.IsEnable == 1 ? true : false;
                //sysGroupUser.IsGuestManager = sysGroupUser.IsEnable == 1 ? true : false;
                return "EasyTimeStudio_CurrentUser=" + JSONConvert.serialToJson(sysgroupuserList[0]);
            }
            return "";
        }

        public static string handleCookie(string cookie)
        {
            string result = cookie;
            try
            {
                if (string.IsNullOrEmpty(cookie))
                    return result;

                string str = cookie.Substring(cookie.IndexOf("\"TrueName\":") + 11);
                string trueName = str.Substring(0, str.IndexOf(","));
                result = cookie.Replace("\"TrueName\":" + trueName, "\"TrueName\":\"\"");
                result = "EasyTimeStudio_CurrentUser=" +  HttpUtility.UrlEncode(result.Substring(("EasyTimeStudio_CurrentUser=").Length));
            }
            catch (Exception ex)
            {
                Log.WriteLog("Common handleCookie():\r\ncookie:" + cookie + "\r\n" + ex.ToString());
            }
            return result;
        }
    }

 
}
