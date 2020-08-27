using IBoxs.Sdk.Cqp.EnumArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using IBoxs.Core.App.Event;
using IBoxs.Sdk.Cqp.EventArgs;

namespace IBoxs.Core.App.Core.Handle
{
    public class Friends
    {
        public delegate int RecvicePrivateMsg(IntPtr intPtr);

        public static int RecvicetPrivateMessage(IntPtr intPtr)
        {
            PrivateMessageEvent data = new PrivateMessageEvent();
            data = (PrivateMessageEvent)Marshal.PtrToStructure(intPtr, typeof(PrivateMessageEvent));

            string msg = data.MessageType.ToString() + "|" + data.MessageSubType.ToString() + "|" + data.MessageSubTemporaryType.ToString();
            Common.CqApi.SendPrivateMessage(data.robotQQ, data.FromQQ, msg, 0, 0);
            if (data.MessageType == Sdk.Cqp.Enum.MsgType.MessageType.GroupTemp)
            {
                CqPrivateMessageEventArgs e = new CqPrivateMessageEventArgs(data);
                Event.Event_Private.RecivesFriendMsg(e);
            }
            else
            {
                CqGroupPrivateMessageEventArgs e = new CqGroupPrivateMessageEventArgs(data);
                Event.Event_Group.ReciveGroupPrivateMsg(e);
            }
            return 1;
        }
    }
}
