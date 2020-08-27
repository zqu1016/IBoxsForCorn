using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using IBoxs.Sdk.Cqp.Enum;

namespace IBoxs.Sdk.Cqp.EnumArgs
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PrivateMessageEvent  //128个字节0x80
    {
        public long FromQQ;
        public long robotQQ;
        public uint MessageReq;
        public long MessageSeq;
        public uint MessageReceiveTime;
        public long MessageGroupQQ;
        public uint MessageSendTime;
        public long MessageRandom;
        public uint MessageClip;
        public uint MessageClipCount;
        public long MessageClipID;
        public IntPtr MessageContent;
        public uint BubbleID;
        /// <summary>
        /// 消息类型(166)
        /// </summary>
        public MsgType.MessageType MessageType;
        /// <summary>
        /// 消息子类型134
        /// </summary>
        public MsgType.MessageSubType MessageSubType;
        /// <summary>
        /// 消息子临时类型0
        /// </summary>
        public MsgType.MessageSubTemporaryType MessageSubTemporaryType;
        /// <summary>
        /// 红包类型
        /// </summary>
        public uint RedEnvelopeType;
        public IntPtr SessionToken;
        public long SourceEventQQ;
        public IntPtr SourceEventQQName;
        public IntPtr FileID;
        public IntPtr FileMD5;
        public IntPtr FileName;
        public long FileSize;
    }
}
