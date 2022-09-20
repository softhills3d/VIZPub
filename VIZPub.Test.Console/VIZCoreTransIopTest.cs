using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub.Test.Console
{
    public class VIZCoreTransIopTest
    {
        public string VIZCoreTrans_Path { get; set; }

        public VIZCoreTransIopTest()
        {
            VIZCoreTrans_Path = "D:\\SH_GitHub\\VIZPub\\VIZCoreTransIOP\\VIZCoreTrans.exe";
        }

        public void Test()
        {
            // Set Environment Path
            VIZPub.EnvironmentInterOp.SetPath(System.IO.Path.GetDirectoryName(VIZCoreTrans_Path));

            ExportVIZW();
        }

        public void ExportVIZW()
        {

        }
    }
}
