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

            //ExportVIZM();                 // VIZM - Android (VIZWing)
            //ExportVIZW();                 // VIZW - Web (VIZWeb3D)

            //ExportMetadata();             // Structure, BoundBox, Kind
            //LoadMetadata();

            //MergeVIZ();                   // Merge VIZ By Metadata
            //MergeVIZM();                  // Merge VIZM By Metadata
            //MergeVIZW();                  // Merge VIZW By Metadata

            //MergeLeafAssemblyToPart();    // Leaf Assembly To Part

            //ExportImage_Case1();          // Image - Whole Model
            //ExportImage_Case2();          // Image - Node

            //ExportAttribute();            // Export Attribute
            //LoadAttribute();              // Load Attribute
            //ImportAttribute();            // Import Attribute
            //ClearAttribute();             // Clear Attribute

            //MergeByRuleXMLFile();         // Merge By Rule XML File

            //ExportNode();                 // Export Node

            //Simplify_Case1();             // Simplify
            //Simplify_Case2();             // Simplify

            //ExportVIZWide3D();            // Export VIZWide3D

            //ChangeColor();                // Change Color

            //ExportFBX();                  // VIZ to FBX


            // (19) NWD to HMF
            // (100) HMF to VIZ, VIZW

            // Export Grid
        }

        private static void ExportVIZ()
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model.rvm");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model.viz");

            parameter.Add(PublishParameters.GENERATE_EDGE, true);                           // [Optional] True or False. Default(True)
            parameter.Add(PublishParameters.GENERATE_THUMBNAIL, true);                      // [Optional] True or False. Default(True)

            parameter.Add(PublishParameters.CYLINDER_SIDE_COUNT_NORMAL, 12);                // [Optional] 6 ~ 36. Default(12)
            parameter.Add(PublishParameters.CYLINDER_SIDE_COUNT_SMALL, 6);                  // [Optional] 6 ~ 36. Default(6)

            parameter.Add(PublishParameters.REMOVE_NODENAME_SLASH, false);                  // [Optional] True or False. Default(False)

            parameter.Add(PublishParameters.VERSION, 303);                                  // [Optional] 303 or 304. Default(303)

            parameter.Add(PublishParameters.NODE_MERGE_OPTIONS, NodeMergeOptions.AS_IS);    // [Optional] As-Is. Default(As-Is) 

            parameter.Add(PublishParameters.LOG, LogKind.INFORMATION);                      // [Optional] Default(None)

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

        public static void ExportImage_Case1()
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model.viz");
            parameter.Add(PublishParameters.THUMBNAIL_WIDTH, 400);
            parameter.Add(PublishParameters.THUMBNAIL_HEIGHT, 300);
            parameter.Add(PublishParameters.THUMBNAIL_VIEW_DIRECTION, ViewDirection.ISO_PLUS);
            parameter.Add(PublishParameters.THUMBNAIL_IMAGE_FORMAT, ImageFormat.PNG);
            parameter.Add(PublishParameters.THUMBNAIL_IMAGE_NODE_UNIT, NodeUnit.ALL_MODEL);
            parameter.Add(PublishParameters.THUMBNAIL_IMAGE_NAME, NameKind.NONE);
            //parameter.Add(PublishParameters.THUMBNAIL_IMAGE_MATRIX, "");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model.png");

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.ExportImage(parameter);
        }

        public static void ExportImage_Case2()
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model.viz");
            parameter.Add(PublishParameters.THUMBNAIL_WIDTH, 400);
            parameter.Add(PublishParameters.THUMBNAIL_HEIGHT, 300);
            parameter.Add(PublishParameters.THUMBNAIL_VIEW_DIRECTION, ViewDirection.ISO_PLUS);
            parameter.Add(PublishParameters.THUMBNAIL_IMAGE_FORMAT, ImageFormat.PNG);
            parameter.Add(PublishParameters.THUMBNAIL_IMAGE_NODE_UNIT, NodeUnit.NODE_UNIT);
            parameter.Add(PublishParameters.THUMBNAIL_IMAGE_NAME, NameKind.NODE_ID);
            //parameter.Add(PublishParameters.THUMBNAIL_IMAGE_MATRIX, "");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Image");

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.ExportImage(parameter);
        }

        public static void ExportAttribute()
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model_Attribute.viz");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model_Attribute.txt");

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.ExportAttribute(parameter);
        }

        public static void LoadAttribute()
        {
            VIZPub.AttributeLoader loader = new AttributeLoader();

            Dictionary<int, List<AttributeItem>> items = new Dictionary<int, List<AttributeItem>>();

            bool result = loader.Load("C:\\Temp\\Model_Attribute.txt", out items);

            if (result == false) return;

            foreach (KeyValuePair<int, List<AttributeItem>> item in items)
            {
                int nodeId = item.Key;
                List<AttributeItem> values = item.Value;

                foreach (AttributeItem value in values)
                {
                    System.Console.WriteLine(string.Format("{0} : {1} - {2}", value.NodeID, value.Key, value.Value));
                }
            }
        }

        public static void ExportMetadata_Attribute()
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model_Attribute.viz");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model_Attribute_Metadata.txt");

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.ExportMetadata(parameter);
        }

        public static void ImportAttribute()
        {
            ExportMetadata_Attribute();

            VIZPub.MetadataLoader loader = new MetadataLoader();
            List<VIZPub.Node> items = new List<VIZPub.Node>();
            bool result_metadata = loader.Load("C:\\Temp\\Model_Attribute_Metadata.txt", out items);
            if (result_metadata == false) return;

            /*
            int count_assembly = 0;
            int count_part = 0;
            int count_body = 0;

            foreach (VIZPub.Node item in items)
            {
                switch (item.Kind)
                {
                    case Node.NodeKind.ASSEMBLY:
                        count_assembly++;
                        break;
                    case Node.NodeKind.PART:
                        count_part++;
                        break;
                    case Node.NodeKind.BODY:
                        count_body++;
                        break;
                    default:
                        break;
                }
            }

            System.Console.WriteLine(string.Format("CA : {0:#,0} / CP : {1:#,0} / CB : {2:#,0}", count_assembly, count_part, count_body));
            */

            List<AttributeItem> attribute = new List<AttributeItem>();
            foreach (VIZPub.Node item in items)
            {
                if (item.Kind == Node.NodeKind.BODY) continue;
                if (item.Kind == Node.NodeKind.ASSEMBLY) continue;

                attribute.Add(new AttributeItem(item.ID, "NAME", item.Name));
                attribute.Add(new AttributeItem(item.ID, "KIND", "PART"));
            }

            AttributeItemManager attributeItemManager = new AttributeItemManager();
            attributeItemManager.Export("C:\\Temp\\Model_Attribute_Import.txt", attribute);


            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model_Attribute_Clear.viz");
            parameter.Add(PublishParameters.ATTRIBUTE_FILE, "C:\\Temp\\Model_Attribute_Import.txt");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model_Attribute_Import.viz");

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.ImportAttribute(parameter);
        }

        public static void ClearAttribute()
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model_Attribute.viz");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model_Attribute_Clear.viz");

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.ClearAttribute(parameter);
        }

        public static void MergeLeafAssemblyToPart()
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model.viz");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model_LEAF_ASSY_TO_PART.viz");

            parameter.Add(PublishParameters.GENERATE_EDGE, true);   // [Optional] True or False. Default(True)

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.MergeLeafAssemblyToPart(parameter);
        }

        public static void MergeByRuleXMLFile()
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model.rvm");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model_RuleXmlFile.viz");
            parameter.Add(PublishParameters.MERGE_RULE_FILE, "C:\\Temp\\MergeRules.xml");

            parameter.Add(PublishParameters.GENERATE_EDGE, true);                           // [Optional] True or False. Default(True)
            parameter.Add(PublishParameters.REMOVE_NODENAME_SLASH, false);                  // [Optional] True or False. Default(False)

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.MergeByRuleXMLFile(parameter);
        }

        public static void ExportNode()
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model.viz");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Node");
            parameter.Add(PublishParameters.OUTPUT_FILE_FORMAT, OutputFileFormat.VIZ);
            parameter.Add(PublishParameters.OUTPUT_NAME_KIND, NameKind.NODE_ID);
            parameter.Add(PublishParameters.OUTPUT_TARGET_NODE, TargetNodeKind.PART);

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.ExportNode(parameter);
        }

        public static void Simplify_Case1()
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model.viz");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model_Simplified.viz");
            
            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.Simplify(parameter);
        }

        public static void Simplify_Case2()
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model.viz");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model_Simplified.viz");

            parameter.Add(PublishParameters.BOUNDBOX_INSPECTIOIN, true);
            parameter.Add(PublishParameters.BOUNDBOX_MIN_X, 0.0f);
            parameter.Add(PublishParameters.BOUNDBOX_MIN_Y, 0.0f);
            parameter.Add(PublishParameters.BOUNDBOX_MIN_Z, 0.0f);
            parameter.Add(PublishParameters.BOUNDBOX_MAX_X, 100.0f);
            parameter.Add(PublishParameters.BOUNDBOX_MAX_Y, 100.0f);
            parameter.Add(PublishParameters.BOUNDBOX_MAX_Z, 100.0f);

            parameter.Add(PublishParameters.LIMIT_TRIANGLE, true);
            parameter.Add(PublishParameters.LIMIT_TRIANGEL_COUNT, 1000);

            parameter.Add(PublishParameters.KEEP_STRUCTURE, false);

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.Simplify(parameter);
        }

        public static void ExportVIZWide3D()
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model.viz");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\VIZWide3D");

            parameter.Add(PublishParameters.GENERATE_EDGE, true);                           // [Optional] True or False. Default(True)
            parameter.Add(PublishParameters.GENERATE_THUMBNAIL, true);                      // [Optional] True or False. Default(True)

            parameter.Add(PublishParameters.CYLINDER_SIDE_COUNT_NORMAL, 12);                // [Optional] 6 ~ 36. Default(12)
            parameter.Add(PublishParameters.CYLINDER_SIDE_COUNT_SMALL, 6);                  // [Optional] 6 ~ 36. Default(6)

            parameter.Add(PublishParameters.REMOVE_NODENAME_SLASH, false);                  // [Optional] True or False. Default(False)

            parameter.Add(PublishParameters.VERSION, 303);                                  // [Optional] 303 or 304. Default(303)

            parameter.Add(PublishParameters.NODE_MERGE_OPTIONS, NodeMergeOptions.AS_IS);    // [Optional] As-Is. Default(As-Is) 

            parameter.Add(PublishParameters.LOG, LogKind.INFORMATION);                      // [Optional] Default(None)

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.ExportVIZWide3D(parameter);
        }

        public static void ChangeColor()
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model.viz");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model_Color.viz");
            parameter.Add(PublishParameters.COLOR, System.Drawing.Color.Blue);

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.ChangeColor(parameter);
        }

        public static void ExportFBX()
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model.viz");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model.fbx");
            parameter.Add(PublishParameters.FBX_FILE_ASCII, true);

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.ExportFBX(parameter);
        }
    }
}
