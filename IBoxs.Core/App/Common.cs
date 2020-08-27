using IBoxs.Sdk.Cqp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity;

namespace IBoxs.Core.App
{
    /// <summary>
    /// 用于存放 App 数据的公共类
    /// </summary>
    public static class Common
    {
        public static int AppVersionId { get; set; }

        public static CqApi CqApi { get; set; }
    }
}
