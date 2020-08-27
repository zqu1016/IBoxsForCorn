﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBoxs.Core.App.Core
{
    public class AppInfo
    {
        /// <summary>
        /// SDK版本
        /// </summary>
        public string sdkv { get; set; }
        /// <summary>
        /// 应用名
        /// </summary>
        public string appname { get; set; }
        /// <summary>
        /// 应用作者
        /// </summary>
        public string author { get; set; }
        /// <summary>
        /// 应用说明
        /// </summary>
        public string describe { get; set; }
        /// <summary>
        /// 应用版本
        /// </summary>
        public string appv { get; set; }

        /// <summary>
        /// 群消息处理函数
        /// </summary>
        public long groupmsaddres { get; set; }
        /// <summary>
        /// 私聊消息处理函数
        /// </summary>
        public long friendmsaddres { get; set; }
        /// <summary>
        /// 事件消息处理函数
        /// </summary>
        public long eventmsaddres { get; set; }
        /// <summary>
        /// 将被卸载处理函数
        /// </summary>
        public long unitproaddres { get; set; }
        /// <summary>
        /// 点击插件设置处理函数
        /// </summary>
        public long setproaddres { get; set; }
        /// <summary>
        /// 插件被启用处理函数
        /// </summary>
        public long useproaddres { get; set; }
        /// <summary>
        /// 插件被禁用处理函数
        /// </summary>
        public long banproaddres { get; set; }

        public string Info(AppInfo appInfo)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(appInfo);
        }

        public string SetPermission(int permissionNum, string desc, string json)
        {
            string outjson = string.Empty;
            string a = $"API[{permissionNum}]";
            if (PermissionConstant.PermiCon.ContainsKey($"API[{permissionNum}]"))
            {
                JObject jObject = JsonConvert.DeserializeObject<JObject>(json);
                string name = PermissionConstant.PermiCon[$"API[{permissionNum}]"];
                string check = "QQ点赞|获取clientkey|获取pskey|获取skey|解散群|删除好友|退群|置屏蔽好友|修改个性签名|修改昵称|上传头像|框架重启|取QQ钱包个人信息|更改群聊消息内容|更改私聊消息内容";
                JObject jObject0 = new JObject();
                JObject jObject1 = new JObject();
                if (check.Contains(name))
                {
                    jObject1["state"] = "0";
                    jObject1["safe"] = "1";
                }
                else
                {
                    jObject1["state"] = "1";
                    jObject1["safe"] = "1";
                }
                jObject1["desc"] = desc;
                jObject0[name] = jObject1;
                if (jObject["data"] == null)
                {
                    jObject["data"] = new JObject();
                }
                if (jObject["data"]["needapilist"] == null)
                {
                    jObject["data"]["needapilist"] = jObject0;
                }
                else
                {
                    jObject["data"]["needapilist"][name] = jObject1;
                }

                outjson = JsonConvert.SerializeObject(jObject);
            }
            return outjson;
        }
    }
}
