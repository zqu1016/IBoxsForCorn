using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using IBoxs.Sdk.Cqp.Model;
using System.Windows.Forms;

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

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct GroupDataList
        {
            public int count;
            public FriendInfo pgroupInfo;
        }

        delegate int getFriendlist(string pkey, long thisQQ, ref GroupDataList[] GroupInfos);
        public static List<FriendInfo> GetFriendList(string pKey, string ApiData, long RobotQQ)
        {
            List<FriendInfo> list = new List<FriendInfo>();
            int MsgAddress = int.Parse(JObject.Parse(ApiData).SelectToken("取好友列表").ToString());
            GroupDataList[] ptrArray = new GroupDataList[1024];
            MessageBox.Show("12");
            getFriendlist sendmsg = (getFriendlist)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(getFriendlist));
            MessageBox.Show("123");
            int count = sendmsg(pKey, RobotQQ, ref ptrArray);
            MessageBox.Show("3");
            if (count > 0)
            {
                IntPtr ptr = Marshal.UnsafeAddrOfPinnedArrayElement(ptrArray, 0);
                for (int i = 0; i < count; i++)
                {
                    int size = Marshal.SizeOf(typeof(IntPtr));
                    IntPtr StuctPtr = IntPtr.Add(ptr, size * 2 + size * i);
                    StuctPtr = Marshal.ReadIntPtr(StuctPtr);
                    FriendInfo info = (FriendInfo)Marshal.PtrToStructure(StuctPtr, typeof(FriendInfo));
                    list.Add(info);
                }
            }
            return list;
        }
    }
}
