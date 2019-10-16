using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;
using System.Collections.Specialized;

using System.Security;
using System.ComponentModel;
using System.Drawing.Printing; 


namespace CaiMomoClient
{
    class SystemPrinter : BasePrinter
    {
        public SystemPrinter() : base()
        {
            printerType = E_PRINTER_TYPE.系统打印机;
        }

        //public Byte[] outbytes; //传输的命令集
        //public bool IFOpen = false;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct DOCINFOW
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pDataType;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct structPrinterDefaults
        {
            [MarshalAs(UnmanagedType.LPTStr)]
            public String pDatatype;
            public IntPtr pDevMode;
            [MarshalAs(UnmanagedType.I4)]
            public int DesiredAccess;
        }; 

        //[DllImport("winspool.Drv", EntryPoint = "OpenPrinterW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
        //public static extern bool OpenPrinter(string src, ref IntPtr hPrinter, long pd);

        [DllImport("winspool.Drv", EntryPoint = "OpenPrinter", SetLastError = true,CharSet = CharSet.Unicode, ExactSpelling = false, CallingConvention = CallingConvention.StdCall),SuppressUnmanagedCodeSecurityAttribute()]
         internal static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPTStr)] string printerName,out IntPtr phPrinter,ref structPrinterDefaults pd); 


        [DllImport("winspool.Drv", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
        public static extern bool ClosePrinter(IntPtr hPrinter);



        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, int level, ref DOCINFOW pDI);



        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);


        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);


        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);


        [DllImport("winspool.Drv", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, int dwCount, ref int dwWritten);

        public IntPtr hPrinter;//  = System.IntPtr.Zero; 

        public DOCINFOW di;// new DOCINFOW();

        public override void initParameter(NameValueCollection paramJson)
        {
            base.initParameter(paramJson);

            hPrinter = System.IntPtr.Zero;

            di = new DOCINFOW();// new DOCINFOW();
            di.pDocName = "My Document";
            di.pDataType = "RAW";

            m_isInited = true;
        }

        public override bool isInited()
        {
            return m_isInited;
        }
        

        public bool SendBytesToPrinter(IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError;

            Int32 dwWritten = 0;
            bool bSuccess;
            bSuccess = false;
            //if (StartDocPrinter(hPrinter, 1, ref di))
            //{
            //    if (StartPagePrinter(hPrinter))
            //    {
            bSuccess = WritePrinter(hPrinter, pBytes, dwCount, ref dwWritten);
            //EndPagePrinter(hPrinter);
            //    }
            //    EndDocPrinter(hPrinter);
            //}
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }

        /// <summary>
        /// 将文件数据写入系统打印机
        /// </summary>
        /// <param name="szFileName"></param>
        /// <returns></returns>
        public bool SendFileToPrinter(string szFileName)
        {
            FileStream stream1 = new FileStream(szFileName, FileMode.Open);
            BinaryReader reader1 = new BinaryReader(stream1);
            byte[] buffer1 = new byte[((int)stream1.Length) + 1];
            buffer1 = reader1.ReadBytes((int)stream1.Length);
            IntPtr ptr1 = Marshal.AllocCoTaskMem((int)stream1.Length);
            Marshal.Copy(buffer1, 0, ptr1, (int)stream1.Length);
            bool flag1 = SendBytesToPrinter(ptr1, (int)stream1.Length);
            Marshal.FreeCoTaskMem(ptr1);
            return flag1;

        }

        /// <summary>
        /// 向系统打印机写数据
        /// </summary>
        /// <param name="pcmd"></param>
        public override void send(string pcmd)
        {
            IntPtr pBytes;
            Int32 dwCount;
            dwCount = GetLength(pcmd);
            pBytes = Marshal.StringToCoTaskMemAnsi(pcmd);

            SendBytesToPrinter(pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
        }

        /// <summary>
        /// 计算字符串的长度
        /// </summary>
        /// <param name="aOrgStr"></param>
        /// <returns></returns>
        public int GetLength(String aOrgStr)
        {
            int intLen = aOrgStr.Length;
            int i;
            char[] chars = aOrgStr.ToCharArray();
            for (i = 0; i < chars.Length; i++)
            {
                if (System.Convert.ToInt32(chars[i]) > 255)
                {
                    intLen++;
                }
            }
            return intLen;
        }

        
        public override bool open()
        {
            structPrinterDefaults defaults = new structPrinterDefaults();

            return OpenPrinter(printerName, out hPrinter, ref defaults);
            //return OpenPrinter(this.printerName, ref hPrinter, 0);
        }
        /// <summary>
        /// 关闭并口
        /// </summary>
        /// <returns></returns>
        public override void close()
        {
            ClosePrinter(hPrinter);
        }

        public override bool beginPrint()
        {
            return StartDocPrinter(hPrinter, 1, ref di) && StartPagePrinter(hPrinter);
        }

        public override void endPrint()
        {
            EndPagePrinter(hPrinter);
            EndDocPrinter(hPrinter);
        }

        string qrCodeFileName = "公众号.png";
        public override void printPic(string filename, int align = 1)
        {
            this.endPrint();//图片跟在单据后面，先打印单据

            qrCodeFileName = filename;
            var printDocument = new PrintDocument();
            printDocument.PrintController = new StandardPrintController();
            //指定打印机
            printDocument.PrinterSettings.PrinterName = this.printerName;
            //设置页边距
            printDocument.PrinterSettings.DefaultPageSettings.Margins.Left = 0;
            printDocument.PrinterSettings.DefaultPageSettings.Margins.Top = 0;
            printDocument.PrinterSettings.DefaultPageSettings.Margins.Right = 0;
            printDocument.PrinterSettings.DefaultPageSettings.Margins.Bottom = 0;
            //设置尺寸大小，如不设置默认是A4纸
            //A4纸的尺寸是210mm×297mm，
            //当你设定的分辨率是72像素/英寸时，A4纸的尺寸的图像的像素是595×842
            //当你设定的分辨率是150像素/英寸时，A4纸的尺寸的图像的像素是1240×1754
            //当你设定的分辨率是300像素/英寸时，A4纸的尺寸的图像的像素是2479×3508，
            printDocument.DefaultPageSettings.PaperSize = new PaperSize("A4", 595, 842);

            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
            try
            {
                printDocument.Print();
            }
            catch (Exception ex)
            {
                //Log.WriteLog("SystemPrinter printPic():\r\n" + ex.ToString());
            }
            finally
            {
                printDocument.Dispose();
            }

            this.beginPrint();
        }

        void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                string filePath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\image\\" + qrCodeFileName;
                if (File.Exists(filePath))
                {
                    Bitmap bmp = null;
                    using (FileStream fs = File.OpenRead(filePath))
                    {
                        byte[] imgPic = new byte[fs.Length];
                        fs.Read(imgPic, 0, imgPic.Length);
                        fs.Close();

                        MemoryStream memStream = new MemoryStream(imgPic);
                        bmp = new Bitmap(memStream);
                    }

                    if (bmp != null)
                    {
                        if (this.paperType == E_PaperType.八十毫米)
                            e.Graphics.DrawImage(bmp, 50, 20, 150, 150);
                        else
                            e.Graphics.DrawImage(bmp, 20, 20, 150, 150);
                    }
                }
            }
            catch (Exception ex) 
            {
                //Log.WriteLog("SystemPrinter printDocument_PrintPage():\r\n" + ex.ToString());
            }
        }
    }
}
