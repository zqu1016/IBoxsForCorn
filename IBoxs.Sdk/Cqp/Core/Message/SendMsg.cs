using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace IBoxs.Sdk.Cqp.Core.Message
{
   public class SendMsg
    {
        delegate string SendPrivateMsg(string pluginkey, Int64 ThisQQ, long SenderQQ, IntPtr MessageContent, ref long MessageRandom, ref uint MessageReq);

        public static string SendPrivateMessage(string pKey, string ApiData, long ThisQQ, long SenderQQ, string MessageContent, long MessageRandom, uint MessageReq)
        {
            string ret = string.Empty;
            int privateMsgAddress = int.Parse(JObject.Parse(ApiData).SelectToken("发送好友消息").ToString());
            IntPtr intPtr = new IntPtr(privateMsgAddress);
            SendPrivateMsg sendPrivatemsg = (SendPrivateMsg)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(SendPrivateMsg));
            sendPrivatemsg.Invoke(pKey, ThisQQ, SenderQQ, Marshal.StringToCoTaskMemAnsi(MessageContent), ref MessageRandom, ref MessageReq);
            return ret;
        }

        delegate string SendGroupPrivateMsg(string pluginkey, Int64 ThisQQ, long GroupId, long SenderQQ, IntPtr MessageContent, ref long MessageRandom, ref uint MessageReq);

        public static string SendGroupPrivateMessage(string pKey, string ApiData, long ThisQQ, long GroupId, long SenderQQ, string MessageContent, long MessageRandom, uint MessageReq)
        {
            string ret = string.Empty;
            int privateMsgAddress = int.Parse(JObject.Parse(ApiData).SelectToken("发送群临时消息").ToString());
            IntPtr intPtr = new IntPtr(privateMsgAddress);
            SendGroupPrivateMsg sendPrivatemsg = (SendGroupPrivateMsg)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(SendGroupPrivateMsg));
            sendPrivatemsg.Invoke(pKey, ThisQQ, GroupId, SenderQQ, Marshal.StringToCoTaskMemAnsi(MessageContent), ref MessageRandom, ref MessageReq);
            return ret;
        }

        delegate string SendGroupMsg(string pluginkey, Int64 ThisQQ, long GroupId, IntPtr MessageContent,bool Anonymous);

        public static string SendGroupMessage(string pKey, string ApiData, long ThisQQ, long GroupId, string MessageContent,bool Anonymous)
        {
            string ret = string.Empty;
            int privateMsgAddress = int.Parse(JObject.Parse(ApiData).SelectToken("发送群消息").ToString());
            IntPtr intPtr = new IntPtr(privateMsgAddress);
            SendGroupMsg sendGroupmsg = (SendGroupMsg)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(SendGroupMsg));
            sendGroupmsg.Invoke(pKey, ThisQQ, GroupId, Marshal.StringToCoTaskMemAnsi(MessageContent), Anonymous);
            return ret;
        }

    }
}
