using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBoxs.Sdk.Cqp.Enum
{
   public class MsgType
    {
        public enum MessageType
        {
            /// <summary>
            /// 普通消息(包括图片、红包、短视频)
            /// </summary>
            General=166,
            /// <summary>
            /// 好友文件
            /// </summary>
            FileMsg=529,
            /// <summary>
            /// 好友语音
            /// </summary>
            VoiceMsg=208,
            /// <summary>
            /// 视频通话未接听消息
            /// </summary>
            VideoCall=734,
            /// <summary>
            /// 群临时会话
            /// </summary>
            GroupTemp=141
        }

        public enum MessageSubType
        {
            /// <summary>
            /// 普通消息
            /// </summary>
            General=134,
            /// <summary>
            /// 好友红包(包含红包、转账)
            /// </summary>
            RedEnvelopes=78,
            /// <summary>
            /// 好友文件
            /// </summary>
            FileMsg=4,
            /// <summary>
            /// 视频通话未接听消息
            /// </summary>
            VideoCall = 0
        }
        /// <summary>
        /// 临时消息类型
        /// </summary>
        public enum MessageSubTemporaryType
        {
            /// <summary>
            /// 普通消息
            /// </summary>
            General = 0,
            /// <summary>
            /// 公众号
            /// </summary>
            Official=129,
            /// <summary>
            /// 网页QQ咨询
            /// </summary>
            WebQQ=201
        }
    }
}
