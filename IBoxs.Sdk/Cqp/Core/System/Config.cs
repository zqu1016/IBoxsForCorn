using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IBoxs.Sdk.Cqp
{
   public class Config
    {
        delegate string GetCornQQ(string pluginkey);

        public static string getCornQQ(string pKey, string ApiData)
        {
            string ret = string.Empty;
            int Log = int.Parse(JObject.Parse(ApiData).SelectToken("取框架QQ").ToString());
            IntPtr intPtr = new IntPtr(Log);
            GetCornQQ getCornQQ = (GetCornQQ)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(GetCornQQ));
           ret= getCornQQ.Invoke(pKey);
            return ret;
        }
    }
}
