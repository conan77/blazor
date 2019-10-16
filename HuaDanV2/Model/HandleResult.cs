using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace HuaDan
{
    public class HandleResult
    {
        public int ResultCode { get; set; }  //0-表示成功，其他数字表示失败的代码
        public string Message { get; set; }  //返回的执行消息
        public object Data { get; set; }     //执行后返回的数据

        public HandleResult()
        {
            this.ResultCode = 1;
            this.Message = "";
            this.Data = "";
        }

        public HandleResult(bool result, string message, object data)
        {
            this.ResultCode = result ? 0 : 1;
            this.Message = message;
            this.Data = data;
        }

        public bool completeSuccess()
        {
            return this.ResultCode == 0;
        }

        public static HandleResult DeserializeResultObj(string json)
        {
            HandleResult result = new HandleResult(false, "转换HandleResult对象出错", "");
            try
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                result = (HandleResult)serializer.Deserialize(json, typeof(HandleResult));
            }
            catch (Exception ex)
            {
                Log.WriteLog("Common DeserializeResultObj() : jsonStr : " + json + "\r\n" + ex.ToString());
            }

            return result;
        }
    }
}
