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
            
            if (data.MessageType == Sdk.Cqp.Enum.MsgType.MessageType.GroupTemp)
            {
                CqGroupPrivateMessageEventArgs e = new CqGroupPrivateMessageEventArgs(data);
                Event.Event_Group.ReciveGroupPrivateMsg(e);
            }
            else
            {
                CqPrivateMessageEventArgs e = new CqPrivateMessageEventArgs(data);
                Event.Event_Private.RecivesFriendMsg(e);
            }
            return 1;
        }
    }
}
