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

            //ExportVIZ();
            ExportVIZM();
        }

        private static void ExportVIZ()
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model.rvm");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model.viz");

            parameter.Add(PublishParameters.GENERATE_EDGE, true);                   // [Optional] True or False. Default(True)
            parameter.Add(PublishParameters.GENERATE_THUMBNAIL, true);              // [Optional] True or False. Default(True)

            parameter.Add(PublishParameters.CYLINDER_SIDE_COUNT_NORMAL, 12);        // [Optional] 6 ~ 36. Default(12)
            parameter.Add(PublishParameters.CYLINDER_SIDE_COUNT_SMALL, 6);          // [Optional] 6 ~ 36. Default(6)

            parameter.Add(PublishParameters.REMOVE_NODENAME_SLASH, false);          // [Optional] True or False. Default(False)

            parameter.Add(PublishParameters.VERSION, 303);                          // [Optional] 303 or 304. Default(303)

            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.ExportVIZ(parameter);
        }

        private static void ExportVIZM()
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model.viz");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model.vizm");

            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.ExportVIZM(parameter);
        }

        private static void ExportVIZW()
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model.viz");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model.vizw");

            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.ExportVIZW(parameter);
        }
    }
}
