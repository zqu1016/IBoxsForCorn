using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IBoxs.Sdk.Cqp
{
   public class FriendHandle
    {
        delegate string getQQNick(string pluginkey,  long SenderQQ);

        public static string SendGroupPrivateMessage(string pKey, string ApiData, long ThisQQ, long GroupId, long SenderQQ, string MessageContent, long MessageRandom, uint MessageReq)
        {
            string ret = string.Empty;
            int privateMsgAddress = int.Parse(JObject.Parse(ApiData).SelectToken("发送群临时消息").ToString());
            IntPtr intPtr = new IntPtr(privateMsgAddress);
            getQQNick GetQQNick = (getQQNick)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(getQQNick));
            GetQQNick.Invoke(pKey,  SenderQQ);
            return ret;
        }
    }
}
