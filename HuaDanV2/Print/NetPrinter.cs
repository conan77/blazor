using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CaiMomoClient
{
    public class NetPrinter : BasePrinter
    {
        public Socket socket;

        public int POS_OPEN_NETPORT = 9100;// 0X238c
        public int Net_SendTimeout = 500;//1000
        public int Net_ReceiveTimeout = 1000;//1500
        public Byte[] outbytes; //传输的命令集

        String PrinterIPAddress;
        int Port;

        public NetPrinter() : base()
        {
            printerType = E_PRINTER_TYPE.网络打印机;
        }
        
        public override void initParameter(NameValueCollection paramJson)
        {
            base.initParameter(paramJson);

            this.PrinterIPAddress = paramJson["IPAddress"];
            try
            {
                this.Port = !string.IsNullOrEmpty(paramJson["ComPort"]) ? int.Parse(paramJson["ComPort"]) : 9100;
            }
            catch 
            {
                this.Port = 9100;
            }

            m_isInited = true;
        }

        public override  bool isInited()
        {
            return m_isInited;
        }

        public override bool open()
        {
            return open(PrinterIPAddress, Port);
        }

        public bool open(string ipaddress, int netport)
        {
            if (socket == null)
            {
                try
                {
                    IPAddress ip = IPAddress.Parse(ipaddress);
                    IPEndPoint ipe = new IPEndPoint(ip, netport);//把ip和端口转化为 IPEndPoint实例
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect(ipe);
                    socket.ReceiveTimeout = Net_ReceiveTimeout;
                    socket.SendTimeout = Net_SendTimeout;
                    IFOpen = true;
                    printState = E_PRINT_STATE.连接正常;
                }
                catch(Exception ex)
                {
                    IFOpen = false;
                    printState = E_PRINT_STATE.连接异常;
                    //Log.WriteLog("网络打印机异常，IP:" + ipaddress + " netport:" + netport + " 异常:" + ex.Message);
                }
            }
            else
            {
                socket.Close(Net_SendTimeout);
                try
                {
                    socket = null;
                    //socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    IPAddress ip = IPAddress.Parse(ipaddress);
                    IPEndPoint ipe = new IPEndPoint(ip, netport);//把ip和端口转化为 IPEndPoint实例
                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect(ipe);
                    socket.ReceiveTimeout = Net_ReceiveTimeout;
                    socket.SendTimeout = Net_SendTimeout;
                    IFOpen = true;
                    printState = E_PRINT_STATE.连接正常;
                }
                catch(Exception ex)
                {
                    IFOpen = false;
                    printState = E_PRINT_STATE.连接异常;
                    //Log.WriteLog("网络打印机异常1，IP:" + ipaddress + " netport:" + netport + " 异常:" + ex.Message);
                }
            }
            return IFOpen;
        }

        public override void close()
        {
            try
            {
                socket.Close(Net_SendTimeout);
                socket = null;
                printState = E_PRINT_STATE.连接正常;
            }
            catch(Exception ex)
            {
                printState = E_PRINT_STATE.连接异常;
            }
        }


        public override void send(string pcmd)
        {
            outbytes = System.Text.Encoding.Default.GetBytes(pcmd.ToCharArray());
            socket.Send(outbytes, outbytes.Length, 0);
        }

        public override void send(byte[] bytes)
        {
            socket.Send(bytes, bytes.Length, 0);
        }
    }
}
