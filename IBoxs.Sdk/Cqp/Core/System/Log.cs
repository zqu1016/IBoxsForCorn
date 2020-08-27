using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IBoxs.Sdk.Cqp
{
   public class Log
    {
        delegate string OutLog(string pluginkey, IntPtr MessageContent,int noteColor,int backColor);

        public static string outLogApi(string pKey, string ApiData, string note, int noteColor, int backColor)
        {
            string ret = string.Empty;
            int Log = int.Parse(JObject.Parse(ApiData).SelectToken("输出日志").ToString());
            IntPtr intPtr = new IntPtr(Log);
            OutLog outLog = (OutLog)Marshal.GetDelegateForFunctionPointer(intPtr, typeof(OutLog));
            outLog.Invoke(pKey,  Marshal.StringToCoTaskMemAnsi(note), noteColor,backColor);
            return ret;
        }
    }
}
