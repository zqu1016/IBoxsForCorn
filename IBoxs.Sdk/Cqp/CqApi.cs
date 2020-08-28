using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using IBoxs.Sdk.Cqp.Model;
using IBoxs.Sdk.Cqp.Core.Message;
using IBoxs. Sdk.Cqp.Expand;
using System.Windows.Forms;

namespace IBoxs.Sdk.Cqp
{
    /// <summary>
    /// 酷Q Api封装类
    /// </summary>
    public class CqApi
    {
        #region --字段--
        private readonly string _pKey = null;
        private readonly Encoding _defaultEncoding = null;
        private readonly string _ApiData = null;
        #endregion

        #region --属性--
        /// <summary>
        /// 获取或设置该实例的验证码
        /// </summary>
        public string pKey { get { return _pKey; } }
        public string ApiData { get { return _ApiData; } }
        #endregion

        #region --构造函数--
        /// <summary>
        /// 初始化一个 <see cref="CqApi"/> 类的新实例, 该实例将由 <code>Initialize (int)</code> 函数授权
        /// </summary>
        /// <param name="authCode">插件验证码</param>
        public CqApi(string pKey, string ApiData)
        {
            this._pKey = pKey;
            this._defaultEncoding = Encoding.GetEncoding("GB18030");
            this._ApiData = ApiData;
        }
        #endregion

        /// <summary>
        /// 发送私聊消息
        /// </summary>
        /// <param name="RobotQQ">机器人QQ</param>
        /// <param name="qqId">对方QQ</param>
        /// <param name="message">消息内容</param>
        /// <param name="Type">消息类型（1为普通，2为匿名）</param>
        /// <param name="Bubble">气泡ID（-1为随机）</param>
        /// <returns></returns>
        public string SendPrivateMessage(long RobotQQ, long qqId, string message, long Type, uint Bubble)
        {
            string c = SendMsg.SendPrivateMessage(pKey, ApiData, RobotQQ, qqId, message, Type, Bubble);
            return c;
        }
        /// <summary>
        /// 发送群私聊消息
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="groupId"></param>
        /// <param name="qqId"></param>
        /// <param name="message"></param>
        /// <param name="Type"></param>
        /// <param name="Bubble"></param>
        /// <returns></returns>
        public string SendGroupPrivateMessage(long RobotQQ, long groupId, long qqId, string message, long Type, uint Bubble)
        {
            string c = SendMsg.SendGroupPrivateMessage(pKey, ApiData, RobotQQ, groupId, qqId, message, Type, Bubble);
            return c;
        }

        public string SendGroupMessage(long RobotQQ, long groupId, string message, bool Anonymous = false)
        {
            string c = SendMsg.SendGroupMessage(pKey, ApiData, RobotQQ, groupId, message, Anonymous);
            return c;
        }



        /// <summary>
        /// 输出日志
        /// </summary>
        /// <param name="note"></param>
        /// <param name="color">颜色16进制转十进制值</param>
        /// <param name="backColor">颜色16进制转十进制值</param>
        /// <returns></returns>
        public string OutLog(string note, int color, int backColor)
        {
            string c = Log.outLogApi(pKey, ApiData, note, color, backColor);
            return c;
        }
        /// <summary>
        /// 设置群名片
        /// </summary>
        /// <param name="RobotQQ"></param>
        /// <param name="groupId"></param>
        /// <param name="Card"></param>
        /// <returns></returns>
        public string SetGroupMemberCard(long RobotQQ, long groupId, long qqId, string Card)
        {
            string c = GroupHandle.setGroupMemberCard(pKey, ApiData, RobotQQ, groupId, qqId, Card);
            return c;
        }


        /// <summary>
        /// 取框架QQ
        /// </summary>
        /// <returns></returns>
        public string GetLoginQQ()
        {
            string ret = Config.getCornQQ(pKey, ApiData);
            return ret;
        }

        /// <summary>
        /// 获取QQ昵称
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <param name="qqId"></param>
        /// <param name="Cache">是否优先使用缓存</param>
        /// <returns></returns>
        public string GetQQNick(long robotQQ, long qqId, bool Cache=false)
        {
            string nick = string.Empty;
            if (Cache)
            {
                nick = FriendHandle.GetQQNickCache(pKey, ApiData, qqId).Trim();
                if (nick.Length < 1)
                    nick = string.Empty;
            }
            if (nick == string.Empty)
            {
                nick = FriendHandle.GetQQNick(pKey, ApiData, robotQQ, qqId);
            }
            return nick;
        }
        /// <summary>
        /// 获取群列表
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <returns></returns>
        public List<GroupInfo> GetGroupList(long robotQQ)
        {
            List<GroupInfo> result = GroupHandle.Getgrouplist(pKey, ApiData, robotQQ);
            return result;
        }

        /// <summary>
        /// 获取好友列表
        /// </summary>
        /// <param name="robotQQ"></param>
        /// <returns></returns>
        public string GetFriendList(long robotQQ)
        {
            try
            {
                string result = (FriendHandle.GetFriendList(pKey, ApiData, robotQQ))[0].Card;
                MessageBox.Show(result);
            }
            catch(Exception ex) { MessageBox.Show(ex.ToString()); }
            /* if (string.IsNullOrEmpty(result))
             {
                 return null;
             }
             MessageBox.Show(result);
             using (BinaryReader reader = new BinaryReader(new MemoryStream(Convert.FromBase64String(result))))
             {
                 if (reader.Length() < 4)
                 {
                     return null;
                 }

                 List<FriendInfo> friends = new List<FriendInfo>();
                 for (int i = 0, len = reader.ReadInt32_Ex(); i < len; i++)
                 {
                     FriendInfo temp = new FriendInfo();
                     if (reader.Length() <= 0)
                     {
                         return null;
                     }

                     using (BinaryReader tempReader = new BinaryReader(new MemoryStream(reader.ReadToken_Ex())))
                     {
                         if (tempReader.Length() < 12)
                         {
                             return null;
                         }

                         temp.Id = tempReader.ReadInt64_Ex();
                         temp.Nick = tempReader.ReadString_Ex(_defaultEncoding);
                         temp.Card = tempReader.ReadString_Ex(_defaultEncoding);
                     }

                     friends.Add(temp);
                 }
                 return friends;
             }*/
            return "112";
        }
    }
}
