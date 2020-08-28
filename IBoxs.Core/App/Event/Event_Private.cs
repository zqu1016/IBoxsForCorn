using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IBoxs.Sdk.Cqp.EventArgs;

namespace IBoxs.Core.App.Event
{
   public class Event_Private
    {
        /// <summary>
        /// 收到好友消息
        /// </summary>
        /// <param name="e"></param>
        public static void RecivesFriendMsg(CqPrivateMessageEventArgs e)
        {
            try
            {
                string f = Common.CqApi.GetGroupList(2812695303);
                string msg = "好友列表：\r\n" + f +
                    "登录QQ：" + "\r\n";
                MessageBox.Show(msg);
                Common.CqApi.SendPrivateMessage(2812695303, 320587491, msg, 0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
