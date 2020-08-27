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
        delegate string getQQNickCache(string pluginkey,  long SenderQQ);
        public static string GetQQNickCache(string pKey, string ApiData, long SenderQQ)
        {
            string ret = string.Empty;
            int privateMsgAddress = int.Parse(JObject.Parse(ApiData).SelectToken("取昵称_从缓存").ToString());
            IntPtr intPtr = new IntPtr(privateMsgAddress);
            getQQNickCache GetQQNick = (getQQNickCache)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(getQQNickCache));
            ret= GetQQNick.Invoke(pKey,  SenderQQ);
            return ret;
        }

        delegate string getQQNick(string pluginkey,long RobotQQ, long SenderQQ);
        public static string GetQQNick(string pKey, string ApiData,long RobotQQ, long SenderQQ)
        {
            string ret = string.Empty;
            int privateMsgAddress = int.Parse(JObject.Parse(ApiData).SelectToken("强制取昵称").ToString());
            IntPtr intPtr = new IntPtr(privateMsgAddress);
            getQQNick GetQQNick = (getQQNick)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(getQQNick));
            ret= GetQQNick.Invoke(pKey,RobotQQ, SenderQQ);
            return ret;
        }


        delegate string getFriendlist(string pluginkey, long RobotQQ,IntPtr Info);
        public static string GetFriendList(string pKey, string ApiData, long RobotQQ)
        {
            string c = "";
            GCHandle Info = GCHandle.Alloc(c, GCHandleType.WeakTrackResurrection);
            IntPtr addr = GCHandle.ToIntPtr(Info);
            string ret = string.Empty;
            int privateMsgAddress = int.Parse(JObject.Parse(ApiData).SelectToken("强制取昵称").ToString());
            IntPtr intPtr = new IntPtr(privateMsgAddress);
            getFriendlist GetQQNick = (getFriendlist)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(getFriendlist));
            ret = GetQQNick.Invoke(pKey, RobotQQ,addr);
            c = Marshal.PtrToStringAnsi(addr);
            return c;
        }
    }
}
