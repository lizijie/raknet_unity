using UnityEngine;
using RakNet;

/// <summary>
/// 回射测试
/// </summary>
public class Client 
{
    public const int SEND_INTERVAL = 1;

    private float begin = 0;
    private RakPeerInterface client = null;
    private RakNet.BitStream data = null;
    private SystemAddress remote = null;

    public int Start(string ip, ushort port)
    {
        this.client = RakPeer.GetInstance();

        SocketDescriptor socketDescriptor = new SocketDescriptor();
        socketDescriptor.socketFamily = 2;

        StartupResult result = this.client.Startup(1, socketDescriptor, 1);
        if (result != StartupResult.RAKNET_STARTED)
        {
            string str = string.Format("客户端启动失败 retCode:{0}" ,result);
            Log.WriteLine(str);
            return -1;
        }

        ConnectionAttemptResult connResult = this.client.Connect(ip, port, "", 0);
        if (connResult != ConnectionAttemptResult.CONNECTION_ATTEMPT_STARTED)
        {
            string str = string.Format("连接失败 retCode:{0}", result);
            Log.WriteLine(str);
            return -2;
        }

        begin = Time.time + SEND_INTERVAL;

        // remote target 
        this.remote = new SystemAddress(ip, port);

        // send data
        this.data  = new RakNet.BitStream();
        this.data.Reset();
        this.data.Write((byte)DefaultMessageIDTypes.ID_USER_PACKET_ENUM);
        this.data.Write("hello world!");

        return 0;
    }

    public void Close()
    {
        if(this.client != null)
        {
            this.client.Shutdown(300);
            RakPeer.DestroyInstance(this.client);
        }

        this.client = null;
    }

    public void Update()
    {
        if (this.client == null)
        {
            Debug.LogError("this.client = null");
            return;
        }

        this.DoSend();
        this.DoReceive();
    }

    private void DoSend()
    {
        if (Time.time > begin)
        {
            this.client.Send(data, PacketPriority.HIGH_PRIORITY, PacketReliability.RELIABLE, (char)0, this.remote, false);
            begin = Time.time + SEND_INTERVAL;
        }
    }

    private void DoReceive()
    {
        Packet recvPkg = this.client.Receive();

        if (recvPkg == null)
        {
            return;
        }

        byte type = recvPkg.data[0];
        switch ((DefaultMessageIDTypes)type)
        {
            case DefaultMessageIDTypes.ID_DISCONNECTION_NOTIFICATION:
            case DefaultMessageIDTypes.ID_CONNECTION_LOST:
            case DefaultMessageIDTypes.ID_REMOTE_DISCONNECTION_NOTIFICATION:
            case DefaultMessageIDTypes.ID_REMOTE_CONNECTION_LOST:
                UnityEngine.Debug.Log("连接断开");
                break;

            case DefaultMessageIDTypes.ID_NEW_INCOMING_CONNECTION:
                UnityEngine.Debug.LogFormat("终端 {0} 连入", recvPkg.systemAddress.ToString(true));
                break;

            // 主动连接成功
            case DefaultMessageIDTypes.ID_CONNECTION_REQUEST_ACCEPTED:
                Log.WriteLine("连接成功");
                break;
            // 主动连接失败
            case DefaultMessageIDTypes.ID_CONNECTION_ATTEMPT_FAILED:
                Log.WriteLine("目标不可达");
                break;

            // raknet自定义事件类型
            case DefaultMessageIDTypes.ID_USER_PACKET_ENUM:
                {
                    RakNet.BitStream reader = new RakNet.BitStream();
                    reader.Write(recvPkg.data, recvPkg.length);
                    reader.IgnoreBytes(1);

                    string msg;
                    reader.Read(out msg);

                    Log.WriteLine(msg);

                    Debug.LogFormat("response msg:{0}", msg);
                }
                break;
        }
    }
}