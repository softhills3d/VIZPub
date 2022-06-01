using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub.Test.Console
{
    class Program
    {
        private static string VIZPub_Path { get; set; }

        static void Main(string[] args)
        {
            VIZPub_Path = "D:\\SH_GitHub\\VIZPub\\VIZPub\\VIZPub.exe";

            ExportVIZ();
        }

        private static void ExportVIZ()
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model.rvm");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model.viz");

            parameter.Add(PublishParameters.GENERATE_EDGE, 1);          // True or False, 1 or 0 
            parameter.Add(PublishParameters.GENERATE_THUMBNAIL, true);  // True or False, 1 or 0 

            parameter.Add(PublishParameters.NORMAL_CYLINDER_COUNT, 12);
            parameter.Add(PublishParameters.SMALL_CYLINDER_COUNT, 6);

            parameter.Add(PublishParameters.REMOVE_NODENAME_SLASH, false);

            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.ExportVIZ(parameter);
        }
    }
}
