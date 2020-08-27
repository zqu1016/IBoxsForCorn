using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using IBoxs.Sdk.Cqp.EventArgs;
using System.IO;

namespace IBoxs.Core.App.Core
{
    public class XLZMain
    {
        /// <summary>
        /// 静态构造函数, 注册依赖注入回调
        /// </summary>
        static XLZMain()
        {
            // 初始化 Costura.Fody
            CosturaUtility.Initialize();
        }

        [DllExport(CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        public static string apprun(string apidata, string pluginkey)
        {
            Common.CqApi = new Sdk.Cqp.CqApi(pluginkey, apidata);
            PermissionConstant.Init();//权限常量初始化
            AppConfig.AppInfoConfig();
            AppInfo appInfo = new AppInfo();
            appInfo.appname = AppConfig.AppName;
            appInfo.appv = AppConfig.AppVersion;
            appInfo.author = AppConfig.Author;
            appInfo.describe = AppConfig.Describe;
            appInfo.sdkv = AppConfig.SdkVersion;
            var d = new App.Core.Handle.Friends.RecvicePrivateMsg(App.Core.Handle.Friends.RecvicetPrivateMessage);
            appInfo.friendmsaddres = Marshal.GetFunctionPointerForDelegate(d).ToInt64();
            string json = appInfo.Info(appInfo);
            json = AppConfig.AppAuthority(json);
            return json;
        }
    }
}
