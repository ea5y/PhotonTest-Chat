using ExitGames.Client.Photon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    class ChatServerListener : IPhotonPeerListener
    {
        public bool isConnected = false;

        public void DebugReturn(DebugLevel level, string message)
        {
            //throw new NotImplementedException();
        }

        public void OnEvent(EventData eventData)
        {
            //throw new NotImplementedException();
        }

        public void OnMessage(object messages)
        {
            //throw new NotImplementedException();
        }

        public void OnOperationResponse(OperationResponse operationResponse)
        {
            //得到服务器响应

            Dictionary<byte, object> dict = operationResponse.Parameters;

            object val = null;
            dict.TryGetValue(1, out val);

            Console.WriteLine("Get value from server: " + val.ToString());
        }

        public void OnStatusChanged(StatusCode statusCode)
        {
            switch (statusCode)
            {
                case StatusCode.Connect:
                    this.isConnected = true;
                    Console.WriteLine("Connected!");
                    break;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ChatServerListener listener = new ChatServerListener();
            PhotonPeer peer = new PhotonPeer(listener, ConnectionProtocol.Tcp);

            //连接服务器
            peer.Connect("127.0.0.1:4520", "ChatServer");

            Console.WriteLine("Connecting...");

            while(listener.isConnected == false)
                peer.Service();

            Dictionary<byte, object> dict = new Dictionary<byte, object>();
            dict.Add(1, "username");
            dict.Add(2, "password");

            peer.OpCustom(1, dict, true);

            while (true)
            {
                peer.Service();
            }

            Console.ReadKey();
        }
    }
}
