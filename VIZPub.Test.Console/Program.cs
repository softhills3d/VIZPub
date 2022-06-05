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
            //ExportVIZ("C:\\Temp\\Model1.rvm");
            //ExportVIZ("C:\\Temp\\Model2.rvm");
            //ExportVIZ("C:\\Temp\\Model3.rvm");

            //ExportVIZM();
            //ExportVIZW();

            //ExportMetadata();
            //LoadMetadata();

            //MergeVIZ();     // Merge VIZ By Metadata
            //MergeVIZM();    // Merge VIZM By Metadata
            //MergeVIZW();    // Merge VIZW By Metadata

            // (6) Thumbnail
            // (8) Export Attribute
            // (9) Import Attribute
            // (10) Remove Attribute
            // (12) Leaf Assembly To Part
            // (13) Merge By Rule XML File
            // (14) Export Node
            // (15) Export Neutral File
            // (16) Create VTD
            // (17) Simplify
            // (18) Export VIZWide3D
            // (19) NWD to HMF
            // (60) Change Color
            // (100) HMF to VIZ, VIZW
            // (200) VIZ to FBX
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

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.ExportVIZ(parameter);
        }

        private static void ExportVIZ(string input)
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, input);
            parameter.Add(PublishParameters.OUTPUT, string.Format("{0}\\{1}.viz", System.IO.Path.GetDirectoryName(input), System.IO.Path.GetFileNameWithoutExtension(input)));

            parameter.Add(PublishParameters.GENERATE_EDGE, true);                   // [Optional] True or False. Default(True)
            parameter.Add(PublishParameters.GENERATE_THUMBNAIL, true);              // [Optional] True or False. Default(True)

            parameter.Add(PublishParameters.CYLINDER_SIDE_COUNT_NORMAL, 12);        // [Optional] 6 ~ 36. Default(12)
            parameter.Add(PublishParameters.CYLINDER_SIDE_COUNT_SMALL, 6);          // [Optional] 6 ~ 36. Default(6)

            parameter.Add(PublishParameters.REMOVE_NODENAME_SLASH, false);          // [Optional] True or False. Default(False)

            parameter.Add(PublishParameters.VERSION, 303);                          // [Optional] 303 or 304. Default(303)

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.ExportVIZ(parameter);
        }

        private static void ExportVIZM()
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            //parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model.rvm");
            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model.viz");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model.vizm");

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.ExportVIZM(parameter);
        }

        private static void ExportVIZW()
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            //parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model.rvm");
            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model.viz");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model.vizw");

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.ExportVIZW(parameter);
        }

        public static void ExportMetadata()
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model.viz");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model.txt");

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.ExportMetadata(parameter);
        }

        public static void LoadMetadata()
        {
            VIZPub.MetadataLoader loader = new MetadataLoader();

            List<VIZPub.Node> items = new List<VIZPub.Node>();

            bool result = loader.Load("C:\\Temp\\Model.txt", out items);

            if (result == false) return;

            foreach (VIZPub.Node item in items)
            {
                if (item.Kind == Node.NodeKind.BODY) continue;

                System.Console.WriteLine(string.Format("ID : {0} / PID : {1} / DEPTH : {2} / KIND : {3} / NAME : {4}", item.ID, item.PARENTID, item.Depth, item.Kind, item.Name));
                System.Console.WriteLine(string.Format("{0} / {1} / {2}", item.BoundBoxMinX, item.BoundBoxMinY, item.BoundBoxMinZ));
                System.Console.WriteLine(string.Format("{0} / {1} / {2}", item.BoundBoxMaxX, item.BoundBoxMaxY, item.BoundBoxMaxZ));
            }
        }

        public static void MergeVIZ()
        {
            MergeItemManager manager = new MergeItemManager();
            manager.Add(new MergeItem("C:\\Temp\\Model1.viz"));
            manager.Add(new MergeItem("C:\\Temp\\Model2.viz"));
            manager.Add(new MergeItem("C:\\Temp\\Model3.viz"));
            manager.Export("C:\\Temp\\MergeItem.txt");

            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\MergeItem.txt");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model_MergeItem.viz");
            parameter.Add(PublishParameters.VERSION, 303);      // [Optional] 303 or 304. Default(303)

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.MergeVIZ(parameter);
        }

        public static void MergeVIZM()
        {
            MergeItemManager manager = new MergeItemManager();
            manager.Add(new MergeItem("C:\\Temp\\Model1.viz"));
            manager.Add(new MergeItem("C:\\Temp\\Model2.viz"));
            manager.Add(new MergeItem("C:\\Temp\\Model3.viz"));
            manager.Export("C:\\Temp\\MergeItem.txt");

            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\MergeItem.txt");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model_MergeItem.vizm");
            parameter.Add(PublishParameters.VERSION, 303);      // [Optional] 303 or 304. Default(303)

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.MergeVIZM(parameter);
        }

        public static void MergeVIZW()
        {
            MergeItemManager manager = new MergeItemManager();
            manager.Add(new MergeItem("C:\\Temp\\Model1.viz"));
            manager.Add(new MergeItem("C:\\Temp\\Model2.viz"));
            manager.Add(new MergeItem("C:\\Temp\\Model3.viz"));
            manager.Export("C:\\Temp\\MergeItem.txt");

            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\MergeItem.txt");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model_MergeItem.vizw");
            parameter.Add(PublishParameters.VERSION, 303);      // [Optional] 303 or 304. Default(303)

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.MergeVIZW(parameter);
        }
    }
}
