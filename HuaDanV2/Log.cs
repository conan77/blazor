using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HuaDan
{
    public static class Log
    {
        /// <summary>
        /// 日志文件
        /// </summary>
        /// <param name="content"></param>
        public static void WriteLog(string content)
        {
            WriteLog("", content);
        }

        public static void WriteLog(string folderName, string content)
        {
            try
            {
                string directory = System.IO.Directory.GetCurrentDirectory() + @"\LogHuaDan\";
                FileInfo fileinfo = new FileInfo(directory + DateTime.Now.ToString("yyyyMMdd") + ".txt");
                if (!Directory.Exists(fileinfo.DirectoryName))
                    Directory.CreateDirectory(fileinfo.DirectoryName);

                using (FileStream fs = new FileStream(fileinfo.FullName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    StreamWriter sw = new StreamWriter(fs);
                    sw.BaseStream.Seek(0, SeekOrigin.End);
                    sw.WriteLine("=====================================");
                    sw.Write("添加日期为:" + DateTime.Now.ToString() + "\r\n");
                    sw.Write("日志内容为:" + content + "\r\n");
                    sw.WriteLine("=====================================");
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}
