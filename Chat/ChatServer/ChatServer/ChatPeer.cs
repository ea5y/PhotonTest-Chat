using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotonHostRuntimeInterfaces;

namespace ChatServer
{
    class ChatPeer : ClientPeer
    {
        public ChatPeer(InitRequest initRequest) : base(initRequest)
        {
        }

        protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail)
        {
            throw new NotImplementedException();
        }

        //当客户端发起请求的时候调用
        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            
            Dictionary<byte, object> dict = new Dictionary<byte, object>();
            dict.Add(1, "easy");
            OperationResponse response = new OperationResponse(1, dict);
            //该方法用来给客户端响应
            SendOperationResponse(response, sendParameters);
        }
    }
}
