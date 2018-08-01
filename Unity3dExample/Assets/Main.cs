using System;
using UnityEngine;

public class Main 
    : MonoBehaviour
{
    private Client client = new Client();
    private Server server = new Server();
    
    private string msg; 

    private void Start()
    {
        string ip = "127.0.0.1";
        ushort port = 60000;
        ushort maxConnections = 9999;

        server.Start(out ip, out port, maxConnections);
        client.Start(ip, port);
    }

    private void OnDestroy()
    {
        if (this.server != null)
        {
            this.server.Close();
        }

        if (this.client != null)
        {
            this.client.Close();
        }
    }

    private void Update()
    {
       if (this.server != null)
       {
            this.server.Update();
       }

       if (this.client != null)
       {
           this.client.Update();
       }

       System.Threading.Thread.Sleep(30);
    }

    private void OnGUI()
    {
        Rect scr = Screen.safeArea;
        GUI.skin.textArea.fontSize = 30;
        GUI.TextArea(scr, Log.ToString());
    }
}