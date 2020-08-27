using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IBoxs.Sdk.Cqp
{
   public class GroupHandle
    {
        delegate string setGroupCard(string pluginkey, Int64 ThisQQ,long GroupId, long SenderQQ,IntPtr card);

        public static string setGroupMemberCard(string pKey, string ApiData, long ThisQQ,long GroupId, long SenderQQ, string Card)
        {
            string ret = string.Empty;
            int CardAddress = int.Parse(JObject.Parse(ApiData).SelectToken("设置群名片").ToString());
            IntPtr intPtr = new IntPtr(CardAddress);
            setGroupCard setGroupCard = (setGroupCard)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(setGroupCard));
            setGroupCard.Invoke(pKey, ThisQQ,GroupId, SenderQQ, Marshal.StringToCoTaskMemAnsi(Card));
            return ret;
        }
        

    }
}
