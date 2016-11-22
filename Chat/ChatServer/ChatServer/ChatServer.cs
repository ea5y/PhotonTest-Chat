using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    //server入口程序
    public class ChatServer : ApplicationBase
    {
        //当客户端链接到服务器端的时候调用
        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            return new ChatPeer(initRequest);
        }

        //当server启动的时候调用
        protected override void Setup()
        {
            //throw new NotImplementedException();
        }

        //当server停掉的时候调用
        protected override void TearDown()
        {
            //throw new NotImplementedException();
        }
    }
}
