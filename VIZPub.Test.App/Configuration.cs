using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub.Test.App
{
    public sealed class Configuration
    {
        public static string VIZPub_EXE { get; set; }
        public static string VIZCoreTrans_EXE { get; set; }

        static Configuration()
        {
            VIZPub_EXE = "D:\\SH_GitHub\\VIZPub\\VIZPub\\VIZPub.exe";
            VIZCoreTrans_EXE = "D:\\SH_GitHub\\VIZPub\\VIZCoreTrans\\VIZCoreTrans.exe";
        }
    }
}
