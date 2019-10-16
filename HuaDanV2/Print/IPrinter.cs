using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace CaiMomoClient
{
    public enum E_PRINT_STATE
    {
        未连接, 连接异常, 连接正常, 中止打印
    }

    public enum E_PaperType
    {
        八十毫米 = 0, 五十八毫米, 标签40乘30, 标签60乘40, 标签80乘60
    }

    public interface IPrinter
    {
        E_PRINTER_TYPE getPrinterType();
        E_PaperType paperType { get; set; }
        void initParameter(NameValueCollection paramJson);
        bool isInited();
        bool open();
        void close();
        void reset();
        void printText(string pszString, int nFontAlign, int nFontSize, int nFontStyle, int ifzhenda);
        void printEnter();
        void cutPage(int pagenum);
        void printNewLines(int lines);
        void printLabel(int count);
        void printLabelText(int x, int y, int fontSize, bool isBold, string text);
        void printLabelTiaoMa(int x, int y, int height, int narrow, int wide, string code);
        void printQrcode(string content, int times, int align);
        void printPic(string fileName, int align);
        void openQianXiang();
        void printTiaoMa(string numstr, int height, int width, int numweizi, int fontalign, int fontsize);
        void printBeep(int count, int leap, int printerType);
        string printerID { get; set; }
        string printerName { get; set; }

        E_PRINT_STATE printState { get; set; }

        bool beginPrint();
        void endPrint();
    }

    public class PrinterFactory
    {
        //1-网络打印机 2-USB 3-串口 4-蓝牙打印机
        public static IPrinter GetPrinter(int printType)
        {
            IPrinter printer = null;
            switch (printType)
            {
                case 1:
                    printer = new NetPrinter();
                    break;
                case 3:
                    printer = new SerialPortPrinter();
                    break;
                case 5:
                    printer = new SystemPrinter();
                    break;
                default:
                    printer = new NetPrinter();
                    break;
            }

            return printer;
        }
    }

    public class PrintDataStruct
    {
        public string UID { get; set; }

        bool isPrinterError = false;
        public string PrinterID { get; set; }
        public string PrintContent { get; set; }
        public bool isPrintError
        {
            get
            {
                return isPrinterError;
            }
            set
            {
                isPrinterError = value;
                if (isPrinterError)
                    errorCount++;
            }
        }
        public DateTime AddTime { get; set; }
        public DateTime LastPrintTime { get; set; }
        public int errorCount { get; set; }

        public PrintDataStruct(string printerID, string content)
        {
            this.UID = Guid.NewGuid().ToString("N");
            this.PrinterID = printerID;
            this.PrintContent = content;
            this.AddTime = DateTime.Now;
        }

        public PrintDataStruct(string UID, string printerID, string content)
        {
            this.UID = UID;
            this.PrinterID = printerID;
            this.PrintContent = content;
            this.AddTime = DateTime.Now;
        }
    }

    public class Printer
    {
        public static IPrinter LocalPrinter { get; set; }
        public static PrintThread PrintThread { get { return _PrintThread; } }

        private static PrintThread _PrintThread = new PrintThread("1");

        public static string LockObject = "Printer";

        public static bool isRunning = true;

        public static bool IsPrinting
        {
            get
            {
                return PrintThread.IsPrinting;
            }
        }

        public static bool print(string printContent)
        {
            if (PrintThread != null)
            {
                PrintDataStruct data = new PrintDataStruct("1", printContent);
                PrintThread.AddQueue(data);
                return true;
            }
            else
                return false;
        }

        public static bool print(PrintDataStruct data)
        {
            if (PrintThread != null)
            {
                PrintThread.AddQueue(data);
            }

            return true;
        }

        //public static E_PaperType PagerType { get; set; }

        /*
        public static IPrinter getPrinter(String printID)
        {
            IPrinter printer = null;

            lock (printers)
            {
                if (!printers.ContainsKey(printID))
                {
                    try
                    {
                        string jsonPrinter = JavaScriptInterop.Instance.executeQuery("SELECT * FROM BasePrinter WHERE UID='" + printID + "'", null);
                        JArray jsonArray = (JArray)JsonConvert.DeserializeObject(jsonPrinter);

                        if (jsonArray.Count > 0)
                        {
                            JToken printerObj = jsonArray[0];

                            NameValueCollection values = new NameValueCollection();
                            foreach (JProperty jp in printerObj)
                            {
                                values.Add(jp.Name, jp.Value.ToString());
                            }

                            printer = PrinterFactory.GetPrinter(int.Parse(values["PrinterType"].ToString()));
                            printer.initParameter(values);
                            printers.Add(printID, printer);
                        }
                        else
                        {
                            return null;
                        }
                    }
                    catch (Exception e)
                    {
                        return null;
                    }
                }
                else
                {
                    printer = printers[printID];
                }
            }

            return printer;
        }*/
    }

}
