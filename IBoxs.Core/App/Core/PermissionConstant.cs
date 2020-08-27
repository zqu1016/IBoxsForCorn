﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBoxs.Core.App.Core
{
    public static class PermissionConstant
    {
        public static Dictionary<string, string> PermiCon = new Dictionary<string, string>();
        public static void Init()
        {
            PermiCon.Add("API[0]", "输出日志");
            PermiCon.Add("API[1]", "发送好友消息");
            PermiCon.Add("API[2]", "发送群消息");
            PermiCon.Add("API[3]", "发送群临时消息");
            PermiCon.Add("API[4]", "添加好友");
            PermiCon.Add("API[5]", "添加群");
            PermiCon.Add("API[6]", "删除好友");
            PermiCon.Add("API[7]", "置屏蔽好友");
            PermiCon.Add("API[8]", "置特别关心好友");
            PermiCon.Add("API[11]", "发送好友json消息");
            PermiCon.Add("API[12]", "发送群json消息");
            PermiCon.Add("API[13]", "上传好友图片");
            PermiCon.Add("API[14]", "上传群图片");
            PermiCon.Add("API[15]", "上传好友语音");
            PermiCon.Add("API[16]", "上传群语音");
            PermiCon.Add("API[17]", "上传头像");
            PermiCon.Add("API[18]", "设置群名片");
            PermiCon.Add("API[19]", "取昵称_从缓存");
            PermiCon.Add("API[20]", "强制取昵称");
            PermiCon.Add("API[21]", "获取skey");
            PermiCon.Add("API[22]", "获取pskey");
            PermiCon.Add("API[23]", "获取clientkey");
            PermiCon.Add("API[24]", "取框架QQ");
            PermiCon.Add("API[25]", "取好友列表");
            PermiCon.Add("API[26]", "取群列表");
            PermiCon.Add("API[27]", "取群成员列表");
            PermiCon.Add("API[28]", "设置管理员");
            PermiCon.Add("API[29]", "取管理层列表");
            PermiCon.Add("API[30]", "取群名片");
            PermiCon.Add("API[31]", "取个性签名");
            PermiCon.Add("API[32]", "修改昵称");
            PermiCon.Add("API[33]", "修改个性签名");
            PermiCon.Add("API[34]", "删除群成员");
            PermiCon.Add("API[35]", "禁言群成员");
            PermiCon.Add("API[36]", "退群");
            PermiCon.Add("API[37]", "解散群");
            PermiCon.Add("API[38]", "上传群头像");
            PermiCon.Add("API[39]", "全员禁言");
            PermiCon.Add("API[40]", "群权限_发起新的群聊");
            PermiCon.Add("API[41]", "群权限_发起临时会话");
            PermiCon.Add("API[42]", "群权限_上传文件");
            PermiCon.Add("API[43]", "群权限_上传相册");
            PermiCon.Add("API[44]", "群权限_邀请好友加群");
            PermiCon.Add("API[45]", "群权限_匿名聊天");
            PermiCon.Add("API[46]", "群权限_坦白说");
            PermiCon.Add("API[47]", "群权限_新成员查看历史消息");
            PermiCon.Add("API[48]", "群权限_邀请方式设置");
            PermiCon.Add("API[49]", "撤回消息_群聊");
            PermiCon.Add("API[50]", "撤回消息_私聊本身");
            PermiCon.Add("API[51]", "设置位置共享");
            PermiCon.Add("API[52]", "上报当前位置");
            PermiCon.Add("API[53]", "是否被禁言");
            PermiCon.Add("API[54]", "处理好友验证事件");
            PermiCon.Add("API[55]", "处理群验证事件");
            PermiCon.Add("API[56]", "查看转发聊天记录内容");
            PermiCon.Add("API[57]", "上传群文件");
            PermiCon.Add("API[58]", "创建群文件夹");
            PermiCon.Add("API[59]", "设置在线状态");
            PermiCon.Add("API[60]", "QQ点赞");
            PermiCon.Add("API[61]", "取图片下载地址");
            PermiCon.Add("API[63]", "查询好友信息");
            PermiCon.Add("API[64]", "查询群信息");
            PermiCon.Add("API[65]", "框架重启");
            PermiCon.Add("API[66]", "群文件转发至群");
            PermiCon.Add("API[67]", "群文件转发至好友");
            PermiCon.Add("API[68]", "好友文件转发至好友");
            PermiCon.Add("API[69]", "置群消息接收");
            PermiCon.Add("API[70]", "取群名称_从缓存");
            PermiCon.Add("API[71]", "发送免费礼物");
            PermiCon.Add("API[72]", "取好友在线状态");
            PermiCon.Add("API[73]", "取QQ钱包个人信息");
            PermiCon.Add("API[74]", "获取订单详情");
            PermiCon.Add("API[75]", "提交支付验证码");
            PermiCon.Add("API[77]", "分享音乐");
            PermiCon.Add("API[78]", "更改群聊消息内容");
            PermiCon.Add("API[79]", "更改私聊消息内容");
            PermiCon.Add("API[80]", "群聊口令红包");
            PermiCon.Add("API[81]", "群聊拼手气红包");
            PermiCon.Add("API[82]", "群聊普通红包");
            PermiCon.Add("API[83]", "群聊画图红包");
            PermiCon.Add("API[84]", "群聊语音红包");
            PermiCon.Add("API[85]", "群聊接龙红包");
            PermiCon.Add("API[86]", "群聊专属红包");
            PermiCon.Add("API[87]", "好友口令红包");
            PermiCon.Add("API[88]", "好友普通红包");
            PermiCon.Add("API[89]", "好友画图红包");
            PermiCon.Add("API[90]", "好友语音红包");
            PermiCon.Add("API[91]", "好友接龙红包");
            PermiCon.Add("API[92]", "重命名群文件夹");
            PermiCon.Add("API[93]", "删除群文件夹");
            PermiCon.Add("API[94]", "删除群文件");
            PermiCon.Add("API[95]", "保存文件到微云");
            PermiCon.Add("API[96]", "移动群文件");
            PermiCon.Add("API[97]", "取群文件列表");

        }
    }
}
