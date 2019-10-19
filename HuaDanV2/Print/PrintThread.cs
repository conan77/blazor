using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace CaiMomoClient
{
    public class PrintThread
    {
        ConcurrentQueue<PrintDataStruct> printQueue = new ConcurrentQueue<PrintDataStruct>();
        bool isPrinting = false;
        string printID;

        public static Object labelPrinterLockObj = new Object();

        public bool IsPrinting
        {
            get { return isPrinting; }
        }

        public string getPrintID { get { return printID; } }

        public PrintThread(string printID)
        {
            this.printID = printID;
        }

        public void AddQueue(PrintDataStruct data)
        {
            printQueue.Enqueue(data);

            ThreadStart ts = new ThreadStart(beginPrint);
            new Thread(ts).Start();
        }

        public E_PRINT_STATE state { get; set; }

        protected Object getLockObj()
        {
            IPrinter printer = Printer.LocalPrinter;
            if (object.Equals(null, printer))
                return this;

            if (printer.getPrinterType() == E_PRINTER_TYPE.标签打印机)
                return labelPrinterLockObj;
            else
                return this;
        }
        
        public void beginPrint()
        {
            lock (printQueue)
            {
                if (isPrinting)
                    return;
                isPrinting = true;
            }

            try
            {
                while (!printQueue.IsEmpty)
                {
                    if (! Printer.isRunning)
                        break;

                    PrintDataStruct data;
                    bool dequeue = printQueue.TryDequeue(out data);
                    if (dequeue)
                    {
                        lock (getLockObj())
                        {
                            if (!_print(data))
                            {
                                if (data.PrintContent.Trim().Equals("[openqianxiang]"))//打开钱箱
                                    continue;
                                if (Printer.isRunning)
                                {
                                    printQueue.Enqueue(data);
                                }
                            }
                        }
                    }

                    try
                    {
                        Thread.Sleep(500);
                    }
                    catch { }
                }
            }
            finally
            {
                isPrinting = false;
            }
        }

         public bool _print(PrintDataStruct data)
        {
            string printContent = data.PrintContent;
            if (printContent == null)
                return true;

            //var printerData = Printer.getPrinterData(printID);//查看数据表中打印机参数
            //if (printerData == null)
            //    return false;

            IPrinter printer = Printer.LocalPrinter;
            if (object.Equals(null,printer))
                return false;

            StringReader reader = new StringReader(printContent);
            int lineNum = 0;

            while (lineNum == 0)
            {
                if (!printer.open() || !printer.beginPrint())
                {
                    //Log.WriteLog("打印机未打开，id：" + printID + " 内容：" + printContent);
                    printer.printState = E_PRINT_STATE.连接异常;
                    return false;
                }

                try
                {
                    printer.reset();
                    string line = reader.ReadLine();
                    lineNum = 1;
                    while (line != null)
                    {
                        if ("[cutpage]".Equals(line, StringComparison.CurrentCultureIgnoreCase))
                        {
                            printer.cutPage(3);
                            try
                            {
                                Thread.Sleep(500);
                            }
                            catch (Exception ex) { }
                        }
                        else if ("[openqianxiang]".Equals(line, StringComparison.CurrentCultureIgnoreCase))
                        {
                            printer.openQianXiang();
                        }
                        else if ("".Equals(line.Trim()) || "[blank]".Equals(line, StringComparison.CurrentCultureIgnoreCase))
                        {
                            printer.printNewLines(1);
                        }
                        else if (line.StartsWith("[label]"))
                        {
                            
                        }
                        else if (line.StartsWith("[pic]"))
                        {
                            printPic(printer, line.Replace("[pic]", ""));

                            //系统打印机printDocument打完带切纸
                            if (printer.getPrinterType().Equals(E_PRINTER_TYPE.系统打印机)) {
                                line = reader.ReadLine();
                                lineNum++;

                                if ("[cutpage]".Equals(line, StringComparison.CurrentCultureIgnoreCase)) {
                                    line = reader.ReadLine();
                                    lineNum++;
                                    continue;
                                }
                            }
                        }
                        else if (line.StartsWith("[qr]"))
                        {
                            printQRCode(printer, line.Replace("[qr]", ""));
                        }
                        else if (line.StartsWith("[tiaoma]"))
                        {
                            try
                            {
                                Thread.Sleep(500);
                            }
                            catch (Exception ex) { }
                            printContent = line.Replace("[tiaoma]", "");
                            printer.printTiaoMa(printContent, 80,Printer.LocalPrinter.paperType == E_PaperType.八十毫米 ? 80 : 58, 2, 1, 0);
                        }
                        else
                        {
                            printText(printer, line, false);
                        }

                        if (lineNum >= 500)
                        {
                            lineNum = 0;
                            Thread.Sleep(1000);
                            break;
                        }

                        line = reader.ReadLine();
                        lineNum++;
                    }

                    printer.printState = E_PRINT_STATE.连接正常;
                }
                catch (Exception ex)
                {
                    printer.printState = E_PRINT_STATE.连接异常;
                    return false;
                }
                finally
                {
                    printer.endPrint();
                    printer.close();
                }
            }

            return true;
        }

         protected void printPic(IPrinter printer, string printText)
         {
             string[] queryStringSplit = printText.Split('&');
             StringDictionary queryStringMap = new StringDictionary();
             string[] queryStringParam;
             foreach (string qs in queryStringSplit)
             {
                 queryStringParam = qs.Split('=');
                 if (queryStringParam.Length == 2)
                     queryStringMap.Add(queryStringParam[0], queryStringParam[1]);
                 else
                     queryStringMap.Add(queryStringParam[0], "");
             }

             string stralign = queryStringMap["align"];
             string fileName = queryStringMap["name"] != null ? queryStringMap["name"].Trim() : "";

             int align = 0;
             if (stralign != null)
             {
                 try
                 {
                     align = int.Parse(stralign);
                 }
                 catch (Exception ex) { }
             }

             printer.printPic(fileName, align);
         }

        /// <summary>
        /// 打印二维码
        /// </summary>
        /// <param name="printer"></param>
        /// <param name="printText"></param>
         protected void printQRCode(IPrinter printer, string printText) 
         {
             string[] queryStringSplit = printText.Split('&');
             StringDictionary queryStringMap = new StringDictionary();
             string[] queryStringParam;
             foreach (string qs in queryStringSplit)
             {
                 queryStringParam = qs.Split('=');
                 if (queryStringParam.Length == 2)
                     queryStringMap.Add(queryStringParam[0], queryStringParam[1]);
                 else
                     queryStringMap.Add(queryStringParam[0], "");
             }

             string stralign = queryStringMap["align"];
             string strtimes = queryStringMap["times"];
             string text = queryStringMap["text"];

             int align = 0;
             int times = 1;
             if (stralign != null)
             {
                 try
                 {
                     align = int.Parse(stralign);
                 }
                 catch (Exception ex) { }
             }
             if (strtimes != null)
             {
                 try
                 {
                     times = int.Parse(strtimes);
                 }
                 catch (Exception ex) { }
             }

             printer.printQrcode(text, times, align);
         }

        /// <summary>
        /// 打印文本
        /// </summary>
        /// <param name="printer"></param>
        /// <param name="printText"></param>
        /// <param name="isZhengDa"></param>
         protected void printText(IPrinter printer, string printText, bool isZhengDa)
         {
             string[] printBlocks = printText.Split(new string[] { "&&&" },StringSplitOptions.RemoveEmptyEntries);//判断一行是否有多个控制指令

             foreach (string block in printBlocks) {
                 if (string.IsNullOrWhiteSpace(block))
                     continue;

                 string[] queryStringSplit = block.Split('&');
                 StringDictionary queryStringMap = new StringDictionary();
                 string[] queryStringParam;
                 foreach (string qs in queryStringSplit)
                 {
                     queryStringParam = qs.Split('=');
                     if (queryStringParam.Length == 2)
                         queryStringMap.Add(queryStringParam[0], queryStringParam[1]);
                     else
                         queryStringMap.Add(queryStringParam[0], "");
                 }


                 string stralign = queryStringMap["align"];
                 string strsize = queryStringMap["size"];
                 string text = queryStringMap["text"];
                 string strbold = queryStringMap["bold"];

                 int align = 0;
                 int size = 0;
                 int bold = 0;
                 if (stralign != null)
                 {
                     try
                     {
                         align = int.Parse(stralign);
                     }
                     catch { }
                 }
                 if (strsize != null)
                 {
                     try
                     {
                         size = int.Parse(strsize);
                     }
                     catch { }
                 }
                 if (strbold != null)
                 {
                     try
                     {
                         bold = int.Parse(strbold);
                     }
                     catch { }
                 }

                 printer.printText(text, align, size, bold, isZhengDa ? 1 : 0);
             }

             printer.printNewLines(1);
         }
    }
}
