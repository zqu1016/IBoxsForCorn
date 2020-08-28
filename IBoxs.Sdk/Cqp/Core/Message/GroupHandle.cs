using IBoxs.Sdk.Cqp.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IBoxs.Sdk.Cqp
{
   public class GroupHandle
    {
        delegate string setGroupCard(string pluginkey, Int64 ThisQQ,long GroupId, long SenderQQ,IntPtr card);
        delegate int GetGrouplist(string pkey, long thisQQ, ref GroupDataList[] GroupInfos);


        public static string setGroupMemberCard(string pKey, string ApiData, long ThisQQ,long GroupId, long SenderQQ, string Card)
        {
            string ret = string.Empty;
            int CardAddress = int.Parse(JObject.Parse(ApiData).SelectToken("设置群名片").ToString());
            IntPtr intPtr = new IntPtr(CardAddress);
            setGroupCard setGroupCard = (setGroupCard)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(setGroupCard));
            setGroupCard.Invoke(pKey, ThisQQ,GroupId, SenderQQ, Marshal.StringToCoTaskMemAnsi(Card));
            return ret;
        }

        /// <summary>
        /// 取群列表
        /// </summary>
        /// <param name="thisQQ"></param>
        /// <returns></returns>
        public static List<GroupInfo> Getgrouplist(string pKey,string ApiData, long thisQQ)
        {
            List<GroupInfo> list = new List<GroupInfo>();
            int MsgAddress = int.Parse(JObject.Parse(ApiData).SelectToken("取群列表").ToString());
            GroupDataList[] ptrArray = new GroupDataList[1024];
            GetGrouplist sendmsg = (GetGrouplist)Marshal.GetDelegateForFunctionPointer(new IntPtr(MsgAddress), typeof(GetGrouplist));
            int count = sendmsg(pKey, thisQQ, ref ptrArray);
            MessageBox.Show(count.ToString());
            if (count > 0)
            {
                IntPtr ptr = Marshal.UnsafeAddrOfPinnedArrayElement(ptrArray, 0);
                for (int i = 0; i < count; i++)
                {
                    int size = Marshal.SizeOf(typeof(IntPtr));
                    IntPtr StuctPtr = IntPtr.Add(ptr, size * 2 + size * i);
                    StuctPtr = Marshal.ReadIntPtr(StuctPtr);
                    GroupInfo info = (GroupInfo)Marshal.PtrToStructure(StuctPtr, typeof(GroupInfo));
                    list.Add(info);
                }
            }
            return list;
        }
    }
}
