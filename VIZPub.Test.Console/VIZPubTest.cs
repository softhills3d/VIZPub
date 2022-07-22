using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub.Test.Console
{
    public class VIZPubTest
    {
        public string VIZPub_Path { get; set; }

        public VIZPubTest()
        {
            VIZPub_Path = "D:\\SH_GitHub\\VIZPub\\VIZPub\\VIZPub.exe";
        }

        public void Test()
        {
            //ExportVIZ();
            //ExportVIZ("C:\\Temp\\Model1.rvm");
            //ExportVIZ("C:\\Temp\\Model2.rvm");
            //ExportVIZ("C:\\Temp\\Model3.rvm");

            //ExportVIZ_VIZXML();
            //ExportVIZ_FBX();

            //ExportVIZ_Dir();

            //ExportVIZM();                 // VIZM - Android (VIZWing)
            //ExportVIZW();                 // VIZW - Web (VIZWeb3D)

            //ExportMetadata();             // Structure, BoundBox, Kind
            //LoadMetadata();

            //MergeVIZ();                   // Merge VIZ By Metadata
            //MergeVIZM();                  // Merge VIZM By Metadata
            //MergeVIZW();                  // Merge VIZW By Metadata

            //MergeVIZ_Rotate();            // Merge VIZ By Metadata And Rotate Model

            //MergeLeafAssemblyToPart();    // Leaf Assembly To Part

            //ExportImage_Case1();          // Image - Whole Model
            //ExportImage_Case2();          // Image - Node

            ExportAttribute();            // Export Attribute
            //LoadAttribute();              // Load Attribute
            //ImportAttribute();            // Import Attribute
            //ClearAttribute();             // Clear Attribute

            //MergeByRuleXMLFile();         // Merge By Rule XML File

            //ExportNode();                 // Export Node

            //Simplify_Case1();             // Simplify
            //Simplify_Case2();             // Simplify

            //ExportVIZWide3D();            // Export VIZWide3D

            //ChangeColor();                // Change Color
            //ChangeColor_XML();             // Change Color (XML)
            //ChangeColor_SameFile();

            //ExportFBX();                  // VIZ to FBX


            //ExportHMF();                  // NWD to HMF

            //ExportZone();                 // Export Model In Bounding Box

            //ExportModelBoundBox();        // Export Model BoundBox

            //ExportGrid();                   // Export Grid
            //ExportGrid_XML();               // Export Grid From XML

            //ExportOutside();                // Export Outside

            //RotateModel();                  // Rotate Model
        }

        private void ExportVIZ()
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

        private void ExportVIZ_VIZXML()
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\VIZXML_Case6.vizxml");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model_VIZXML.viz");

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

        private void ExportVIZ(string input)
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

        private void ExportVIZ_Dir()
        {
            string path = "C:\\Models";
            string[] items = System.IO.Directory.GetFiles(path, "*.*", System.IO.SearchOption.TopDirectoryOnly);

            foreach (string item in items)
            {
                ExportVIZ(item);
            }
        }

        private void ExportVIZ_FBX()
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model.fbx");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model.viz");
            parameter.Add(PublishParameters.FBX_SDK, true);

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

        private void ExportVIZM()
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

        private void ExportVIZW()
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

        public void ExportMetadata()
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model.viz");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model.txt");

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.ExportMetadata(parameter);
        }

        public void LoadMetadata()
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

                // ID, Name, NodePath
                System.Console.WriteLine(string.Format("[{0}] {1} : {2}", item.ID, item.Name, item.NodePath));
            }
        }

        public void MergeVIZ()
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

        public void MergeVIZM()
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

        public void MergeVIZW()
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

        public void MergeVIZ_Rotate()
        {
            MergeItemManager manager = new MergeItemManager();
            manager.Add(new MergeItem("C:\\Temp\\Model1.viz"));
            manager.Add(new MergeItem("C:\\Temp\\Model2.viz"));
            manager.Add(new MergeItem("C:\\Temp\\Model3.viz"));
            manager.Export("C:\\Temp\\MergeItem.txt");

            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\MergeItem.txt");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model_MergeItem_Rotate.viz");
            parameter.Add(PublishParameters.VERSION, 303);      // [Optional] 303 or 304. Default(303)

            parameter.Add(PublishParameters.ROTATE_X, 180);     // Rotate X
            parameter.Add(PublishParameters.ROTATE_Y, 0);       // Rotate Y
            parameter.Add(PublishParameters.ROTATE_Z, 0);       // Rotate Z

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.MergeVIZ(parameter);
        }

        public void ExportImage_Case1()
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

        public void ExportImage_Case2()
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

        public void ExportAttribute()
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model_Attribute.viz");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model_Attribute.txt");

            parameter.Add(PublishParameters.INCLUDE_BODY_ATTRIBUTE, true);                  // [Optional] True or False. Default(False)

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.ExportAttribute(parameter);
        }

        public void LoadAttribute()
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

        public void ExportMetadata_Attribute()
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model_Attribute.viz");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model_Attribute_Metadata.txt");

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.ExportMetadata(parameter);
        }

        public void ImportAttribute()
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
                if (item.Kind == Node.NodeKind.ASSEMBLY) continue;

                attribute.Add(new AttributeItem(item.ID, "NAME", item.Name));

                if(item.Kind == Node.NodeKind.BODY)
                    attribute.Add(new AttributeItem(item.ID, "KIND", "BODY"));
                else if(item.Kind == Node.NodeKind.PART)
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

        public void ClearAttribute()
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model_Attribute.viz");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model_Attribute_Clear.viz");

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.ClearAttribute(parameter);
        }

        public void MergeLeafAssemblyToPart()
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

        public void MergeByRuleXMLFile()
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

        public void ExportNode()
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

        public void Simplify_Case1()
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model.viz");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model_Simplified.viz");

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.Simplify(parameter);
        }

        public void Simplify_Case2()
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

        public void ExportVIZWide3D()
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

            parameter.Add(PublishParameters.COMPRESS_VIZW, true);                           // [Optional] Default(False)

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.ExportVIZWide3D(parameter);
        }

        public void ChangeColor()
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

        public void ChangeColor_XML()
        {
            /*
            <?xml version="1.0" encoding="UTF-8"?>
            <Colors>
                <Color NodeId="32" R="0" G="0" B="255" A="255" />
                <Color NodeId="39" R="255" G="0" B="0" A="255" />
                <Color NodeId="59" R="0" G="128" B="0" A="150" />
            </Colors>
            */

            List<ColorItem> colors = new List<ColorItem>();
            colors.Add(new ColorItem(32, System.Drawing.Color.Blue));
            colors.Add(new ColorItem(39, System.Drawing.Color.FromArgb(255, 0, 0)));
            colors.Add(new ColorItem(59, System.Drawing.Color.FromArgb(150, System.Drawing.Color.Green)));

            string colorXml = "C:\\Temp\\Model_Color_Xml.xml";
            ColorManager manager = new ColorManager();
            manager.Export(colorXml, colors);

            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model.viz");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model_Color_Xml.viz");
            parameter.Add(PublishParameters.COLOR_XML, colorXml);

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.ChangeColors(parameter);
        }

        public void ChangeColor_SameFile()
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model_Color.viz");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model_Color.viz");
            parameter.Add(PublishParameters.COLOR, System.Drawing.Color.Yellow);

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.ChangeColor(parameter);
        }

        public void ExportFBX()
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

        public void ExportHMF()
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model.nwd");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model.hmf");
            parameter.Add(PublishParameters.LOAD_HIDDEN_ENTITY, true);          // [Optional] True or False. Default(False)

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.ExportHMF(parameter);
        }

        public void NWDtoVIZ()
        {
            // NWD to HMF
            {
                VIZPub.PublishParameter parameter = new PublishParameter();

                parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model.nwd");
                parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model.hmf");
                parameter.Add(PublishParameters.LOAD_HIDDEN_ENTITY, true);          // [Optional] True or False. Default(False)

                // VIZPub
                // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
                VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
                bool result = publish.ExportHMF(parameter);

                if (result == false) return;
            }

            // HMF to VIZ
            {
                VIZPub.PublishParameter parameter = new PublishParameter();

                parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model.hmf");
                parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model.viz");

                // VIZPub
                // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
                VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
                bool result = publish.ExportVIZ(parameter);
            }
        }

        public void ExportZone()
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model.viz");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model_Space.viz");

            parameter.Add(PublishParameters.BOUNDBOX_SEARCH_OPTION, BoundBoxSearchOption.IncludingPart);

            parameter.Add(PublishParameters.BOUNDBOX_MIN_X, 0);
            parameter.Add(PublishParameters.BOUNDBOX_MIN_Y, 0);
            parameter.Add(PublishParameters.BOUNDBOX_MIN_Z, 0);
            parameter.Add(PublishParameters.BOUNDBOX_MAX_X, 100);
            parameter.Add(PublishParameters.BOUNDBOX_MAX_Y, 100);
            parameter.Add(PublishParameters.BOUNDBOX_MAX_Z, 100);

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.ExportZone(parameter);
        }

        public void ExportModelBoundBox()
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model.viz");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model_BoundBox.txt");

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.ExportModelBoundBox(parameter);
        }

        public void ExportGrid()
        {
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model.viz");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model_Grid.viz");

            parameter.Add(PublishParameters.BOUNDBOX_MIN_X, 0);
            parameter.Add(PublishParameters.BOUNDBOX_MIN_Y, 0);
            parameter.Add(PublishParameters.BOUNDBOX_MIN_Z, 0);
            parameter.Add(PublishParameters.BOUNDBOX_MAX_X, 100);
            parameter.Add(PublishParameters.BOUNDBOX_MAX_Y, 100);
            parameter.Add(PublishParameters.BOUNDBOX_MAX_Z, 100);

            parameter.Add(PublishParameters.KEEP_STRUCTURE, true);      // True : Keep Structure, False : Merge Single Node

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.ExportGrid(parameter);
        }

        public void ExportGrid_XML()
        {
            /*
            <?xml version="1.0" encoding="UTF-8"?>
            <Spaces>
	            <Box KeepStructure="0" Path="C:\Temp\Model_Box1.viz">
		            <Minimum X="0" Y="0" Z="0" />
		            <Maximum X="100" Y="100" Z="100" />
	            </Box>
	            <Box KeepStructure="1" Path="C:\Temp\Model_Box2.viz">
		            <Minimum X="100" Y="0" Z="0" />
		            <Maximum X="200" Y="100" Z="100" />
	            </Box>
            </Spaces>
            */

            // Define Space
            List<BoundBoxItem> items = new List<BoundBoxItem>();
            items.Add(new BoundBoxItem("C:\\Temp\\Model_Box1.viz", false, new List<int>() { 0, 0, 0, 100, 100, 100 }));
            items.Add(new BoundBoxItem("C:\\Temp\\Model_Box2.viz", true, new List<int>() { 100, 0, 0, 200, 100, 100 }));

            string path_box = "C:\\Temp\\Model_Box.xml";
            BoundBoxManager manager = new BoundBoxManager();
            manager.Export(path_box, items);
            
            // Publish
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model.viz");

            parameter.Add(PublishParameters.BOUNDBOX_XML, path_box);

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.ExportGridFromXml(parameter);
        }

        public void ExportOutside()
        {
            // Publish
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model.viz");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model_Outside.viz");

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.ExportOutside(parameter);
        }

        public void RotateModel()
        {
            // Publish
            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model.viz");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model_Rotate_180_0_0.viz");

            parameter.Add(PublishParameters.ROTATE_X, 180); // X Axis. - 180 Degree
            parameter.Add(PublishParameters.ROTATE_Y, 0);   // Y Axis. -   0 Degree
            parameter.Add(PublishParameters.ROTATE_Z, 0);   // Z Axis. -   0 Degree

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
            bool result = publish.RotateModel(parameter);
        }
    }
}
