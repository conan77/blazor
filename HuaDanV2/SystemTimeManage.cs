using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace HuaDan
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public class SystemTime
    {

        public ushort vYear;

        public ushort vMonth;

        public ushort vDayOfWeek;

        public ushort vDay;

        public ushort vHour;

        public ushort vMinute;

        public ushort vSecond;

    }


    public class SystemTimeManage
    {
        [DllImportAttribute("Kernel32.dll")]
        private static extern void SetLocalTime(SystemTime st);

        public static void setCurrentTime()
        {
            setSystemTime(DateTime.Now);
        }

        public static void setSystemTime(DateTime time)
        {
            SystemTime mySystemTime = new SystemTime();

            mySystemTime.vYear = (ushort)time.Year;

            mySystemTime.vMonth = (ushort)time.Month;

            mySystemTime.vDay = (ushort)time.Day;

            mySystemTime.vHour = (ushort)time.Hour;

            mySystemTime.vMinute = (ushort)time.Minute;

            mySystemTime.vSecond = (ushort)time.Second;
 
            SetLocalTime(mySystemTime);
        }
    }
}
