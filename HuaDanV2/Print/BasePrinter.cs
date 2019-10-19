using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace CaiMomoClient
{
    public enum E_PRINTER_TYPE
    {
        其他打印机,网络打印机, USB打印机, 串口打印机, 蓝牙打印机, 系统打印机, 标签打印机
    }

    public abstract class BasePrinter : IPrinter
    {
        public string command = ""; //打印命令字符串

        public string printerID { get; set; }
        public string printerName { get; set; }

        public E_PaperType paperType { get; set; }

        protected E_PRINT_STATE state = E_PRINT_STATE.未连接;

        protected E_PRINTER_TYPE printerType;

        protected PrinterCMD pcmd = new PrinterCMD();

        protected bool m_isInited = false;

        public bool IFOpen = false;

        public E_PRINT_STATE printState
        {
            get
            {
                return state;
            }
            set
            {
                E_PRINT_STATE originState = state;
                state = value;
            }
        }

        public E_PRINTER_TYPE getPrinterType() {
            return printerType;
        }

        public virtual void initParameter(NameValueCollection paramJson)
        {
            this.printerName = paramJson["Name"];
            this.printerID = paramJson["UID"];
        }
        public abstract bool isInited();
        public abstract bool open();
        public abstract void close();

        public virtual bool beginPrint()
        {
            return true;
        }

        public virtual void endPrint()
        {
        }

        /// <summary>
        /// 初始化打印机
        /// </summary>
        public virtual void reset()
        {
            command = pcmd.cmdSetPos();
            send(command);
        }
        /// <summary>
        /// 打印的文本
        /// </summary>
        /// <param name="pszString"></param>
        /// <param name="nFontAlign">0:居左 1:居中 2:居右</param>
        /// <param name="nfontsize">字体大小0:正常大小 1:两倍高 2:两倍宽 3:两倍大小 4:三倍高 5:三倍宽 6:三倍大小 7:四倍高 8:四倍宽 9:四倍大小 10:五倍高 11:五倍宽 12:五倍大小</param>
        /// <param name="nFontStyle">字体样式 0：正常 1：粗体 2：下划线 3：粗体+下划线 </param>
        /// <param name="color">字体颜色 0：黑 1：红 </param>
        /// <param name="ifzhenda">0:非针打  1:针打</param> 
        public virtual void printText(string pszString, int nFontAlign, int nFontSize,int nFontStyle, int ifzhenda)
        {
            command = pcmd.cmdTextAlign(nFontAlign);
            send(command);

            //command = pcmd.cmdTextBold(nFontStyle);
            //send(command);

            if (ifzhenda == 1)
            {
                command = pcmd.cmdFontSizeBTPM280(nFontSize);
                send(command);

                command = pcmd.cmdFontSizeBTPM2801(nFontSize);
                send(command);
            }
            else
            {
                command = pcmd.cmdFontSize(nFontSize);
                send(command);
            }

            command = pszString;// +pcmd.cmdEnter();
            send(command);
        }
        public virtual void printEnter()
        {
            command = pcmd.cmdEnter();
            send(command);
        }
                
        /// <summary>
        /// 鸣叫(适用于GP-80xxx系列)
        /// </summary>
        /// <param name="count">鸣叫次数</param>
        /// <param name="leap">鸣叫间隔(leep*50毫秒)</param>
        public virtual void printBeep(int count,int leap,int printerType)
        {
        }
        public virtual void cutPage(int pagenum)
        {
            command = pcmd.cmdPageGO(pagenum) + pcmd.cmdEnter();
            send(command);

            command = pcmd.cmdCutPage() + pcmd.cmdEnter();
            send(command);
        }
        public virtual void printNewLines(int lines)
        {
            command = pcmd.cmdFontSize(0);
            send(command);

            for (int i = 0; i < lines; i++)
            {
                command = "" + pcmd.cmdEnter();
                send(command);
            }
        }
        public virtual void openQianXiang()
        {
            command = "" + pcmd.cmdQianXiang();
            send(command);
        }
        public virtual void printTiaoMa(string numstr, int height, int width, int numweizi, int fontalign, int fontsize)
        {
            command = pcmd.cmdTiaoMaHeight(height);
            send(command);

            command = pcmd.cmdTiaoMaWidth(width);
            send(command);

            command = pcmd.cmdTiaoMaWeiZi(numweizi);
            send(command);

            command = pcmd.cmdTextAlign(fontalign);
            send(command);

            command = pcmd.cmdFontSize(fontsize);
            send(command);

            command = pcmd.cmdTiaoMaPrint(numstr);
            send(command);
        }
        
        public abstract void send(string pcmd);

        public virtual void send(byte[] bytes) 
        {
            string pmd = "";
            foreach (byte bt in bytes)
            {
                pmd += ((char)bt).ToString();
            }

            send(pmd);
        }

        public virtual void printLabel(int count) { }

        public virtual void printLabelText(int x,int y,int fontSize,bool isBold,string text){}

        public virtual void printLabelTiaoMa(int x, int y, int height, int narrow, int wide, string code) { }

        public virtual void printPic(string filename, int align = 1)
        {
            string filePath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath) + "\\image\\" + filename;
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
                    printPic(bmp, align);
            }
        }

        /// <summary>
        /// 打印图片
        /// </summary>
        /// <param name="bmp">需要打印的图片（BMP格式，最好分辨率为40*40）</param>
        /// <param name="nFontAlign">对齐方式（0，left;1 center;2 right）</param>
        public virtual void printPic(Bitmap bmp, int nFontAlign = 1)
        {
            if (bmp != null)
            {
                //初始化打印机，并打印
                command = pcmd.cmdTextAlign(nFontAlign);
                send(command);

                send(pcmd.cmdEnter());

                byte[] data = new byte[] { 0x1B, 0x33, 0x00 };
                //string dat = ((char)0x1B).ToString() + ((char)0x33).ToString() + ((char)0x00).ToString();
                send(data);

                data[0] = (byte)'\x00';
                data[1] = (byte)'\x00';
                data[2] = (byte)'\x00';    // Clear to Zero.

                Color pixelColor;

                // ESC * m nL nH 点阵图
                byte[] escBmp = new byte[] { 0x1B, 0x2A, 0x00, 0x00, 0x00 };

                escBmp[2] = (byte)'\x21';

                //nL, nH
                escBmp[3] = (byte)(bmp.Width % 256);
                escBmp[4] = (byte)(bmp.Width / 256);

                // data
                for (int i = 0; i < (bmp.Height / 24) + 1; i++)
                {
                    send(escBmp);
                    for (int j = 0; j < bmp.Width; j++)
                    {
                        for (int k = 0; k < 24; k++)
                        {
                            if (((i * 24) + k) < bmp.Height)   // if within the BMP size
                            {
                                pixelColor = bmp.GetPixel(j, (i * 24) + k);
                                if (pixelColor.R == 0)
                                {
                                    data[k / 8] += (byte)(128 >> (k % 8));
                                }
                            }
                        }
                        
                        send(data);
                        data[0] = (byte)'\x00';
                        data[1] = (byte)'\x00';
                        data[2] = (byte)'\x00';    // Clear to Zero.
                    }
                    send(pcmd.cmdEnter()) ;
                }
                send(pcmd.cmdNormalLineSpacing());
            }
        }

        public void printQrcode(string content, int times, int align)
        {
        }

   }
}
