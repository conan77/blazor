using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HuaDan
{
    /// <summary>
    /// 网络通讯事件模型委托
    /// </summary>
    public delegate void NetEvent(object sender, NetEventArgs e);

    public delegate void ErrorEvent(object sender);

    /// <summary>
    /// 提供Tcp网络连接服务的服务器类 
    /// <summary>
    public class TcpServer
    {

        #region 定义字段

        /// <summary>
        /// 默认的服务器最大连接客户端端数据
        /// </summary>
        public const int DefaultMaxClient = 100;

        /// <summary>
        /// 接收数据缓冲区大小64K
        /// </summary>
        public const int DefaultBufferSize = 64 * 1024;

        /// <summary>
        /// 最大数据报文大小
        /// </summary>
        public const int MaxDatagramSize = 640 * 1024;

        /// <summary>
        /// 服务器程序使用的端口
        /// </summary>
        private int _port;

        /// <summary>
        /// 服务器程序允许的最大客户端连接数
        /// </summary>
        private int _maxClient;

        /// <summary>
        /// 服务器的运行状态
        /// </summary>
        private bool _isRun;

        /// <summary>
        /// 接收数据缓冲区
        /// </summary>
        private byte[] _recvDataBuffer;

        /// <summary>
        /// 服务器使用的异步Socket类,
        /// </summary>
        private Socket _svrSock;

        /// <summary>
        /// 保存所有客户端会话的哈希表
        /// </summary>
        private Hashtable _sessionTable;

        /// <summary>
        /// 当前的连接的客户端数
        /// </summary>
        private ushort _clientCount;

        #endregion

        #region 事件定义

        /// <summary>
        /// 客户端建立连接事件
        /// </summary>
        public event NetEvent ClientConn;

        /// <summary>
        /// 客户端关闭事件
        /// </summary>
        public event NetEvent ClientClose;

        /// <summary>
        /// 服务器已经满事件
        /// </summary>
        public event NetEvent ServerFull;

        /// <summary>
        /// 服务器接收到数据事件
        /// </summary>
        public event NetEvent RecvData;

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数(默认使用Default编码方式)
        /// </summary>
        /// <param name="port">服务器端监听的端口号</param>
        /// <param name="maxClient">服务器能容纳客户端的最大能力</param>
        public TcpServer(int port, int maxClient)
        {
            _port = port;
            _maxClient = maxClient;
        }

        // <summary>
        /// 构造函数(默认使用Default编码方式和DefaultMaxClient(100)个客户端的容量)
        /// </summary>
        /// <param name="port">服务器端监听的端口号</param>
        public TcpServer(int port)
            : this(port, DefaultMaxClient)
        {
        }

        #endregion

        #region 属性

        /// <summary>
        /// 服务器的Socket对象
        /// </summary>
        public Socket ServerSocket
        {
            get
            {
                return _svrSock;
            }
        }

        /// <summary>
        /// 客户端会话数组,保存所有的客户端,不允许对该数组的内容进行修改
        /// </summary>
        public Hashtable SessionTable
        {
            get
            {
                return _sessionTable;
            }
        }

        /// <summary>
        /// 服务器可以容纳客户端的最大能力
        /// </summary>
        public int Capacity
        {
            get
            {
                return _maxClient;
            }
        }

        /// <summary>
        /// 当前的客户端连接数
        /// </summary>
        public int SessionCount
        {
            get
            {
                return _clientCount;
            }
        }

        /// <summary>
        /// 服务器运行状态
        /// </summary>
        public bool IsRun
        {
            get
            {
                return _isRun;
            }

        }

        #endregion

        #region 公有方法

        /// <summary>
        /// 启动服务器程序,开始监听客户端请求
        /// </summary>
        public virtual void Start()
        {
            if (_isRun)
            {
                //throw (new ApplicationException("TcpSvr已经在运行."));
                return;
            }

            GC.Collect();

            _sessionTable = new Hashtable(53);

            _recvDataBuffer = new byte[DefaultBufferSize];

            try
            {
                //初始化socket
                _svrSock = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                //绑定端口
                IPEndPoint iep = new IPEndPoint(IPAddress.Any, _port);
                _svrSock.Bind(iep);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //开始监听
            _svrSock.Listen(5);

            _isRun = true;

            //设置异步方法接受客户端连接
            _svrSock.BeginAccept(new AsyncCallback(AcceptConn), _svrSock);

        }

        /// <summary>
        /// 停止服务器程序,所有与客户端的连接将关闭
        /// </summary>
        public virtual void Stop()
        {
            if (!_isRun)
            {
                //throw (new ApplicationException("TcpSvr已经停止"));
                return;
            }

            //这个条件语句，一定要在关闭所有客户端以前调用
            //否则在EndConn会出现错误
            _isRun = false;

            //关闭数据连接,负责客户端会认为是强制关闭连接
            if (_svrSock.Connected)
            {
                _svrSock.Shutdown(SocketShutdown.Both);
            }

            CloseAllClient();

            //清理资源
            _svrSock.Close();

            _sessionTable = null;

            GC.Collect();

        }


        /// <summary>
        /// 关闭所有的客户端会话,与所有的客户端连接会断开
        /// </summary>
        public virtual void CloseAllClient()
        {
            foreach (Session client in _sessionTable.Values)
            {
                //				LED_PACK_MANAGER.Instance.set_terminal(client.terminal_id,false);	
                //客户端强制关闭链接
                if (ClientClose != null)
                {
                    ClientClose(this, new NetEventArgs(client));
                }

                client.Close();
            }

            _sessionTable.Clear();

            GC.Collect();
        }


        /// <summary>
        /// 关闭一个与客户端之间的会话
        /// </summary>
        /// <param name="closeClient">需要关闭的客户端会话对象</param>
        public virtual void CloseSession(Session closeClient)
        {
            Debug.Assert(closeClient != null);

            if (closeClient != null)
            {

                closeClient.Datagram = null;

                _sessionTable.Remove(closeClient.ID);

                _clientCount--;

                //客户端强制关闭链接
                if (ClientClose != null)
                {
                    ClientClose(this, new NetEventArgs(closeClient));
                }

                closeClient.Close();

                GC.Collect();
            }
        }


        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="recvDataClient">接收数据的客户端会话</param>
        /// <param name="datagram">数据报文</param>
        public virtual void Send(Session recvDataClient, byte[] data)
        {
            try
            {
                recvDataClient.ClientSocket.BeginSend(data, 0, data.Length, SocketFlags.None,
                    new AsyncCallback(SendDataEnd), recvDataClient.ClientSocket);
            }
            catch//(SocketException ex)
            {
                //客户端强制关闭
                CloseClient(recvDataClient.ClientSocket, Session.ExitType.ExceptionExit);
            }
        }

        #endregion

        #region 受保护方法
        /// <summary>
        /// 关闭一个客户端Socket,首先需要关闭Session
        /// </summary>
        /// <param name="client">目标Socket对象</param>
        /// <param name="exitType">客户端退出的类型</param>
        protected virtual void CloseClient(Socket client, Session.ExitType exitType)
        {
            Debug.Assert(client != null);

            //查找该客户端是否存在,如果不存在,抛出异常
            Session closeClient = FindSession(client);

            if (!object.Equals(null, closeClient))
            {
                closeClient.TypeOfExit = exitType;
                CloseSession(closeClient);
            }
            //else
            //{
            //    throw (new ApplicationException("需要关闭的Socket对象不存在"));
            //}
        }


        /// <summary>
        /// 客户端连接处理函数
        /// </summary>
        /// <param name="iar">欲建立服务器连接的Socket对象</param>
        protected virtual void AcceptConn(IAsyncResult iar)
        {
            //如果服务器停止了服务,就不能再接收新的客户端
            if (!_isRun)
            {
                return;
            }

            //接受一个客户端的连接请求
            Socket oldserver = (Socket)iar.AsyncState;

            Socket client = oldserver.EndAccept(iar);


            //检查是否达到最大的允许的客户端数目
            if (_clientCount == _maxClient)
            {
                //服务器已满,发出通知
                if (ServerFull != null)
                {
                    ServerFull(this, new NetEventArgs(new Session(client)));
                }

            }
            else
            {
                Session newSession = new Session(client);

                _sessionTable.Add(newSession.ID, newSession);

                //客户端引用计数+1
                _clientCount++;

                string ip = string.Empty;

                try
                {
                    ip = ((System.Net.IPEndPoint)(((System.Net.EndPoint)(client.RemoteEndPoint)))).Address.ToString();

                    //开始接受来自该客户端的数据
                    client.BeginReceive(_recvDataBuffer, 0, _recvDataBuffer.Length, SocketFlags.None,
                        new AsyncCallback(ReceiveData), client);

                    //新的客户段连接,发出通知
                    if (ClientConn != null)
                    {
                        ClientConn(this, new NetEventArgs(newSession));
                    }

                }
                catch (Exception ex)
                {
                    Log.WriteLog("TcpServer AcceptConn : \r\n" + ex.ToString());
                }

            }

            CallNumServer.sendBeiCanData(true);

            //继续接受客户端
            _svrSock.BeginAccept(new AsyncCallback(AcceptConn), _svrSock);
        }


        /// <summary>
        /// 通过Socket对象查找Session对象
        /// </summary>
        /// <param name="client"></param>
        /// <returns>找到的Session对象,如果为null,说明并不存在该回话</returns>
        private Session FindSession(Socket client)
        {
            try
            {
                SessionId id = new SessionId((int)client.Handle);

                return (Session)_sessionTable[id];
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// 接受数据完成处理函数，异步的特性就体现在这个函数中
        /// </summary>
        /// <param name="iar">目标客户端Socket</param>
        protected virtual void ReceiveData(IAsyncResult iar)
        {
            Socket client = (Socket)iar.AsyncState;
            Session sendDataSession = FindSession(client);

            if (sendDataSession == null)
                return;

            try
            {
                //如果两次开始了异步的接收,所以当客户端退出的时候
                //会两次执行EndReceive    
                int recv = client.EndReceive(iar);

                if (recv == 0)
                {
                    //正常的关闭
                    CloseClient(client, Session.ExitType.NormalExit);
                    return;
                }

                try
                {
                    //发布收到数据的事件
                    if (RecvData != null)
                    {
                        ICloneable copySession = (ICloneable)sendDataSession;

                        Session clientSession = (Session)copySession.Clone();

                        clientSession.Datagram = _recvDataBuffer;

                        RecvData(this, new NetEventArgs(clientSession));
                    }

                }
                catch (Exception ex)
                {
                    Log.WriteLog("TcpServer ReceiveData : \r\n" + ex.ToString());
                    return;
                }
                finally
                {
                    _recvDataBuffer = new byte[DefaultBufferSize];
                    //继续接收来自来客户端的数据
                    client.BeginReceive(_recvDataBuffer, 0, _recvDataBuffer.Length, SocketFlags.None,
                        new AsyncCallback(ReceiveData), client);
                }

            }
            catch (SocketException ex)
            {
                //客户端退出
                if (10054 == ex.ErrorCode)
                {
                    //客户端强制关闭
                    CloseClient(client, Session.ExitType.ExceptionExit);
                }

            }
            catch (ObjectDisposedException ex)
            {
                //这里的实现不够优雅
                //当调用CloseSession()时,会结束数据接收,但是数据接收
                //处理中会调用int recv = client.EndReceive(iar);
                //就访问了CloseSession()已经处置的对象
                //我想这样的实现方法也是无伤大雅的.
                if (ex != null)
                {
                    ex = null;
                    //DoNothing;
                }
            }

        }

        /// <summary>
        /// 发送数据完成处理函数
        /// </summary>
        /// <param name="iar">目标客户端Socket</param>
        protected virtual void SendDataEnd(IAsyncResult iar)
        {
            Socket client = (Socket)iar.AsyncState;

            int sent = client.EndSend(iar);
        }

        #endregion

    }

    /// <summary>
    /// 客户端与服务器之间的会话类        
    /// </summary>
    public class Session : ICloneable
    {
        #region 字段

        /// <summary>
        /// 会话ID
        /// </summary>
        private SessionId _id;

        /// <summary>
        /// 客户端发送到服务器的字节集合
        /// </summary>
        private byte[] _datagram;

        /// <summary>
        /// 客户端的Socket
        /// </summary>
        private Socket _cliSock;

        /// <summary>
        /// 客户端的退出类型
        /// </summary>
        private ExitType _exitType;

        public string ip
        {
            get
            {
                if (!object.Equals(null, _cliSock))
                    return ((System.Net.IPEndPoint)(((System.Net.EndPoint)(_cliSock.RemoteEndPoint)))).Address.ToString();
                else
                    return "";
            }
        }

        public int port
        {
            get
            {
                if (!object.Equals(null, _cliSock))
                    return ((System.Net.IPEndPoint)(((System.Net.EndPoint)(_cliSock.RemoteEndPoint)))).Port;
                else
                    return 0;
            }
        }

        public string remoteEndPoint
        {
            get
            {
                if (!object.Equals(null, _cliSock))
                    return _cliSock.RemoteEndPoint.ToString();
                else
                    return "";
            }
        }

        /// <summary>
        /// 退出类型枚举
        /// </summary>
        public enum ExitType
        {
            NormalExit,
            ExceptionExit
        };

        #endregion

        #region 属性

        /// <summary>
        /// 返回会话的ID
        /// </summary>
        public SessionId ID
        {
            get
            {
                return _id;
            }
        }

        /// <summary>
        /// 存取会话的报文
        /// </summary>
        public byte[] Datagram
        {
            get
            {
                return _datagram;
            }
            set
            {
                _datagram = value;
            }
        }

        /// <summary>
        /// 获得与客户端会话关联的Socket对象
        /// </summary>
        public Socket ClientSocket
        {
            get
            {
                return _cliSock;
            }
        }

        /// <summary>
        /// 存取客户端的退出方式
        /// </summary>
        public ExitType TypeOfExit
        {
            get
            {
                return _exitType;
            }

            set
            {
                _exitType = value;
            }
        }

        #endregion

        #region 方法

        /// <summary>
        /// 使用Socket对象的Handle值作为HashCode,它具有良好的线性特征.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return (int)_cliSock.Handle;
        }

        /// <summary>
        /// 返回两个Session是否代表同一个客户端
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            Session rightObj = (Session)obj;

            return (int)_cliSock.Handle == (int)rightObj.ClientSocket.Handle;

        }

        /// <summary>
        /// 重载ToString()方法,返回Session对象的特征
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = string.Format("Session:{0},IP:{1}",
                _id, _cliSock.RemoteEndPoint.ToString());

            //result.C
            return result;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="cliSock">会话使用的Socket连接</param>
        public Session(Socket cliSock)
        {
            Debug.Assert(cliSock != null);

            _cliSock = cliSock;

            _id = new SessionId((int)cliSock.Handle);
        }

        /// <summary>
        /// 关闭会话
        /// </summary>
        public void Close()
        {
            Debug.Assert(_cliSock != null);

            //关闭数据的接受和发送
            _cliSock.Shutdown(SocketShutdown.Both);

            //清理资源
            _cliSock.Close();
        }

        #endregion

        #region ICloneable 成员

        object System.ICloneable.Clone()
        {
            Session newSession = new Session(_cliSock);
            newSession.Datagram = _datagram;
            newSession.TypeOfExit = _exitType;

            return newSession;
        }

        #endregion
    }

    /// <summary>
    /// 唯一的标志一个Session,辅助Session对象在Hash表中完成特定功能
    /// </summary>
    public class SessionId
    {
        /// <summary>
        /// 与Session对象的Socket对象的Handle值相同,必须用这个值来初始化它
        /// </summary>
        private int _id;

        /// <summary>
        /// 返回ID值
        /// </summary>
        public int ID
        {
            get
            {
                return _id;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="id">Socket的Handle值</param>
        public SessionId(int id)
        {
            _id = id;
        }

        /// <summary>
        /// 重载.为了符合Hashtable键值特征
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                SessionId right = (SessionId)obj;

                return _id == right._id;
            }
            else if (this == null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 重载.为了符合Hashtable键值特征
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return _id;
        }

        /// <summary>
        /// 重载,为了方便显示输出
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _id.ToString();
        }

    }


    /// <summary>
    /// 服务器程序的事件参数,包含了激发该事件的会话对象
    /// </summary>
    public class NetEventArgs : EventArgs
    {

        #region 字段

        /// <summary>
        /// 客户端与服务器之间的会话
        /// </summary>
        private Session _client;

        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="client">客户端会话</param>
        public NetEventArgs(Session client)
        {
            if (null == client)
            {
                throw (new ArgumentNullException());
            }

            _client = client;
        }
        #endregion

        #region 属性

        /// <summary>
        /// 获得激发该事件的会话对象
        /// </summary>
        public Session Client
        {
            get
            {
                return _client;
            }

        }

        #endregion

    }
}
