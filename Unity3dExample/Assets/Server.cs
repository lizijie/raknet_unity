
using UnityEngine;
using RakNet;

public class Server
{
    private RakPeerInterface server;

    public int Start(out string ip, out ushort port, ushort maxConnections)
    {
        this.server = RakPeer.GetInstance();
        this.server.SetMaximumIncomingConnections(maxConnections);
        StartupResult result = this.server.Startup(maxConnections, new SocketDescriptor(), 1);

        SystemAddress adr = this.server.GetMyBoundAddress();
        ip  = adr.ToString(false);
        port = adr.GetPort();

        Log.WriteLine(string.Format("监听server {0}:{1}", ip, port));

        if (result != StartupResult.RAKNET_STARTED)
        {
            Log.WriteLine(string.Format("服务器启动失败 retCode:{0}", result));
            return -1;
        }

        return 0;
    }

    public void Close()
    {
        if(server != null)
        {
            server.Shutdown(300);
            RakPeer.DestroyInstance(server);
        }

        server = null;
    }

    public void Update()
    {
        if (this.server == null)
        {
            Debug.LogError("this.server = null");
            return;
        }

        Packet recvPkg = this.server.Receive();

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
                Log.WriteLine("连接断开");
                break;

            case DefaultMessageIDTypes.ID_NEW_INCOMING_CONNECTION:
                string str = string.Format("终端 {0} 连入", recvPkg.systemAddress.ToString(true));
                Log.WriteLine(str);
                break;

            // raknet自定义事件类型
            case DefaultMessageIDTypes.ID_USER_PACKET_ENUM:
                {
                    // 回转
                    RakNet.BitStream bs = new RakNet.BitStream();
                    bs.Write(recvPkg.data, recvPkg.length);
                    server.Send(bs, PacketPriority.LOW_PRIORITY, PacketReliability.RELIABLE_ORDERED, (char)0, recvPkg.systemAddress, false);
                }
                break;
        }

        server.DeallocatePacket(recvPkg);
    }

}