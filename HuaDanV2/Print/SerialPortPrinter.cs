using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;

namespace CaiMomoClient
{
    class SerialPortPrinter : BasePrinter
    {
        public string Com_Name = "Com1"; // com1,com2,com3 .......
        public int Com_DataBits = 8; // 4,5,6,7,8
        public string Com_XiangYLeiX = "ASB"; //  ASB, TM, TP
        public string Com_JiaoY = "无";//偶 奇 无 标志 空格
        public int Com_XiangYSuD = 1; //1 2  4 
        public decimal Com_StopBits = 1; // 1, 1.5, 2
        public int Com_BaudRate = 9600; // 9600  4800 14400  19200 38400 57600 115200 
        public string Com_LiuKongZ = "无"; //Xon/Xoff   硬件  无

        System.IO.Ports.SerialPort com;

        public SerialPortPrinter() : base()
        {
            printerType = E_PRINTER_TYPE.串口打印机;
        }

        public override void initParameter(NameValueCollection paramJson)
        {
            base.initParameter(paramJson);
            try
            {
                this.Com_Name = !string.IsNullOrEmpty(paramJson["ComPort"]) ? paramJson["ComPort"] : "Com5";
            }
            catch
            {
                this.Com_Name = "Com5";
            }

            m_isInited = true;
        }


        public override bool isInited()
        {
            return m_isInited;
        }

        public override bool open()
        {
            try
            {
                if (com == null)
                {

                    com = new System.IO.Ports.SerialPort(Com_Name);
                    com.BaudRate = Com_BaudRate;
                    com.DataBits = Com_DataBits;

                    com.WriteTimeout = 1000;
                    com.ReadTimeout = 1500;
                    com.Encoding = System.Text.Encoding.GetEncoding("GB2312");
                    //com.Encoding = gb;

                    switch (Com_JiaoY)
                    {
                        case "偶":
                            com.Parity = System.IO.Ports.Parity.Even;
                            break;

                        case "奇":
                            com.Parity = System.IO.Ports.Parity.Mark;
                            break;

                        case "无":
                            com.Parity = System.IO.Ports.Parity.None;
                            break;

                        case "标志":
                            com.Parity = System.IO.Ports.Parity.Odd;
                            break;

                        case "空格":
                            com.Parity = System.IO.Ports.Parity.Space;
                            break;
                    }

                    switch (Com_StopBits.ToString())
                    {
                        case "1":
                            com.StopBits = System.IO.Ports.StopBits.One;
                            break;

                        case "1.5":
                            com.StopBits = System.IO.Ports.StopBits.OnePointFive;
                            break;

                        case "2":
                            com.StopBits = System.IO.Ports.StopBits.Two;
                            break;

                    }

                    switch (Com_LiuKongZ)
                    {
                        case "Xon/Xoff":
                            com.Handshake = System.IO.Ports.Handshake.XOnXOff;
                            break;

                        case "硬件":
                            com.Handshake = System.IO.Ports.Handshake.RequestToSendXOnXOff;
                            break;

                        case "无":
                            com.Handshake = System.IO.Ports.Handshake.None;
                            break;

                    }
                    com.Open();
                    IFOpen = true;
                    printState = E_PRINT_STATE.连接正常;
                }
                else if (!com.IsOpen)
                {
                    com.Open();
                    IFOpen = true;
                    printState = E_PRINT_STATE.连接正常;
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("连接不成功");
                IFOpen = false;
                printState = E_PRINT_STATE.连接异常;
            }

            return IFOpen;
        }


        public override void close()
        {
            try
            {
                com.Close();
                com = null;
                IFOpen = false;
                printState = E_PRINT_STATE.连接正常;
            }
            catch
            {
                IFOpen = false;
                printState = E_PRINT_STATE.连接异常;
            }
        }

        public override void send(string pcmd)
        {
            com.Write(pcmd);
        }
    }
}
