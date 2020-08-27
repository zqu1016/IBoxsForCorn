﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBoxs.Core.App.Core;

namespace IBoxs.Core.App
{
    public class AppConfig
    {
        public static string AppName{ get; set; }

        public static string SdkVersion { get; set; }

        public static string Author { get; set; }

        public static string Describe { get; set; }

        public static string AppVersion { get; set; }
        /// <summary>
        /// 应用信息
        /// </summary>
        /// <returns></returns>
        public static bool AppInfoConfig()
        {
            AppName = "C# CornSDK";
            SdkVersion = "2.6.7";
            Author = "IT格子";
            Describe = "C#应用于小栗子机器人的开发SDK";
            AppVersion = "1.0.0";
            return true;
        }
        /// <summary>
        /// 应用权限
        /// </summary>
        /// <returns></returns>
        public static string AppAuthority(string json)
        {
            AppInfo appInfo = new AppInfo();
            json = appInfo.SetPermission(0, "输出日志", json);
            json = appInfo.SetPermission(1, "发送好友消息", json);
            json = appInfo.SetPermission(3, "发送群临时消息", json);
            json = appInfo.SetPermission(4, "添加好友", json);
            /*    json = appInfo.SetPermission(2, "发送群消息", json);
                
                
                json = appInfo.SetPermission(5, "添加群", json);
                json = appInfo.SetPermission(6, "删除好友", json);
                json = appInfo.SetPermission(7, "置屏蔽好友", json);
                json = appInfo.SetPermission(8, "置特别关心好友", json);
                json = appInfo.SetPermission(11, "发送好友json消息", json);
                json = appInfo.SetPermission(12, "发送群json消息", json);
                json = appInfo.SetPermission(13, "上传好友图片", json);
                json = appInfo.SetPermission(14, "上传群图片", json);
                json = appInfo.SetPermission(15, "上传好友语音", json);
                json = appInfo.SetPermission(16, "上传群语音", json);
                json = appInfo.SetPermission(17, "上传头像", json);
                json = appInfo.SetPermission(18, "设置群名片", json);
                json = appInfo.SetPermission(19, "取昵称_从缓存", json);
                json = appInfo.SetPermission(20, "强制取昵称", json);
                json = appInfo.SetPermission(21, "获取skey", json);
                json = appInfo.SetPermission(22, "获取pskey", json);
                json = appInfo.SetPermission(23, "获取clientkey", json);
                json = appInfo.SetPermission(24, "取框架QQ", json);
                json = appInfo.SetPermission(25, "取好友列表", json);
                json = appInfo.SetPermission(26, "取群列表", json);
                json = appInfo.SetPermission(27, "取群成员列表", json);
                json = appInfo.SetPermission(28, "设置管理员", json);
                json = appInfo.SetPermission(29, "取管理员列表", json);
                json = appInfo.SetPermission(30, "取群名片", json);
                json = appInfo.SetPermission(31, "取个性签名", json);
                json = appInfo.SetPermission(32, "修改昵称", json);
                json = appInfo.SetPermission(33, "修改个性签名", json);
                json = appInfo.SetPermission(34, "删除群成员", json);
                json = appInfo.SetPermission(35, "禁言群成员", json);
                json = appInfo.SetPermission(36, "退出群", json);
                json = appInfo.SetPermission(37, "解散群", json);
                json = appInfo.SetPermission(38, "上传群头像", json);
                json = appInfo.SetPermission(39, "全员禁言", json);
                json = appInfo.SetPermission(40, "群权限_发起新的群聊", json);
                json = appInfo.SetPermission(41, "群权限_发起临时会话", json);
                json = appInfo.SetPermission(42, "群权限_上传文件", json);
                json = appInfo.SetPermission(43, "群权限_上传相册", json);
                json = appInfo.SetPermission(44, "群权限_邀请好友加群", json);
                json = appInfo.SetPermission(45, "群权限_匿名聊天", json);
                json = appInfo.SetPermission(46, "群权限_坦白说", json);
                json = appInfo.SetPermission(47, "群权限_新成员查看历史消息", json);
                json = appInfo.SetPermission(48, "群权限_邀请方式设置", json);
                json = appInfo.SetPermission(49, "撤回消息_群聊", json);
                json = appInfo.SetPermission(50, "撤回消息_私聊本身", json);
                json = appInfo.SetPermission(51, "设置位置共享", json);
                json = appInfo.SetPermission(52, "上报当前位置", json);
                json = appInfo.SetPermission(53, "是否被禁言", json);
                json = appInfo.SetPermission(54, "处理好友验证事件", json);
                json = appInfo.SetPermission(55, "处理群验证事件", json);
                json = appInfo.SetPermission(56, "查看转发聊天记录内容", json);
                json = appInfo.SetPermission(57, "上传群文件", json);
                json = appInfo.SetPermission(58, "创建群文件夹", json);
                json = appInfo.SetPermission(59, "设置在线状态", json);
                json = appInfo.SetPermission(60, "QQ点赞", json);
                json = appInfo.SetPermission(61, "取图片下载地址", json);
                json = appInfo.SetPermission(62, "查询好友信息", json);
                json = appInfo.SetPermission(63, "查询好友信息", json);
                json = appInfo.SetPermission(64, "查询群信息", json);
                json = appInfo.SetPermission(65, "框架重启", json);
                json = appInfo.SetPermission(66, "群文件转发至群", json);
                json = appInfo.SetPermission(67, "群文件转发至好友", json);
                json = appInfo.SetPermission(68, "好友文件转发至好友", json);
                json = appInfo.SetPermission(69, "置群消息接收", json);
                json = appInfo.SetPermission(70, "取群名称_从缓存", json);
                json = appInfo.SetPermission(71, "发送免费礼物", json);
                json = appInfo.SetPermission(72, "取好友在线状态", json);
                json = appInfo.SetPermission(73, "取QQ钱包个人信息", json);
                json = appInfo.SetPermission(74, "获取订单详情", json);
                json = appInfo.SetPermission(75, "提交支付验证码", json);
                json = appInfo.SetPermission(77, "分享音乐", json);
                json = appInfo.SetPermission(78, "更改群聊消息内容", json);
                json = appInfo.SetPermission(79, "更改私聊消息内容", json);
                json = appInfo.SetPermission(80, "群聊口令红包", json);
                json = appInfo.SetPermission(81, "群聊拼手气红包", json);
                json = appInfo.SetPermission(82, "群聊普通红包", json);
                json = appInfo.SetPermission(83, "群聊画图红包", json);
                json = appInfo.SetPermission(84, "群聊语音红包", json);
                json = appInfo.SetPermission(85, "群聊接龙红包", json);
                json = appInfo.SetPermission(86, "群聊专属红包", json);
                json = appInfo.SetPermission(87, "好友口令红包", json);
                json = appInfo.SetPermission(88, "好友普通红包", json);
                json = appInfo.SetPermission(89, "好友画图红包", json);
                json = appInfo.SetPermission(90, "好友语音红包", json);
                json = appInfo.SetPermission(91, "好友接龙红包", json);
                json = appInfo.SetPermission(92, "重命名群文件夹", json);
                json = appInfo.SetPermission(93, "删除群文件夹", json);
                json = appInfo.SetPermission(90, "删除群文件", json);
                json = appInfo.SetPermission(91, "保存文件到微云", json);
                json = appInfo.SetPermission(92, "移动群文件", json);
                json = appInfo.SetPermission(93, "取群文件列表", json);*/
            return json;
        }
    }
}
