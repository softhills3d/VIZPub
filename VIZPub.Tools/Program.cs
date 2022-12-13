using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub.Tools
{
    class Program
    {
        // ================================================
        // Attribute & Property
        // ================================================
        private static string VIZPub_Path { get; set; }


        // ================================================
        // Main
        // ================================================
        static void Main(string[] args)
        {
            VIZPub_Path = System.Configuration.ConfigurationManager.AppSettings.Get("VIZPub");

            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Args is null.");
                return;
            }

            // Args[0] : Command
            // Args[1] : Input
            // Args[2] : Output
            // Args[3 ~ n] : ... 

            string cmd = args[0].ToUpper();
            string input = args[1];
            string output = args[2];

            switch (cmd)
            {
                case "VIZ2VIZXML":
                    {
                        string nodeKind = args[3];
                        ConvertVIZtoVIZXML(
                            input                               /* INPUT */
                            , output                            /* OUTPUT */
                            , nodeKind == "0" ? false : true    /* NODE KIND : 0(PART), 1(BODY) */
                            );
                    }
                    break;
                default:
                    break;
            }
        }

        // ================================================
        // Function
        // ================================================
        private static void ConvertVIZtoVIZXML(string input, string output, bool body)
        {
            // Export Metadata
            string metadata = string.Format("{0}\\{1}.txt", System.IO.Path.GetDirectoryName(input), System.IO.Path.GetFileNameWithoutExtension(input));

            {
                VIZPub.PublishParameter parameter = new PublishParameter();

                parameter.Add(PublishParameters.INPUT, input);
                parameter.Add(PublishParameters.OUTPUT, metadata);

                // VIZPub
                // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
                VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
                bool result_Metadata = publish.ExportMetadata(parameter);

                if (result_Metadata == false)
                {
                    Console.WriteLine("Metadata is null.");
                    return;
                }
            }


            // Export Models
            string model_Path = string.Format("{0}\\{1}_Files", System.IO.Path.GetDirectoryName(input), System.IO.Path.GetFileNameWithoutExtension(input));
            if (System.IO.Directory.Exists(model_Path) == false)
                System.IO.Directory.CreateDirectory(model_Path);

            {
                VIZPub.PublishParameter parameter = new PublishParameter();

                parameter.Add(PublishParameters.INPUT, input);
                parameter.Add(PublishParameters.OUTPUT, model_Path);
                parameter.Add(PublishParameters.OUTPUT_FILE_FORMAT, OutputFileFormat.VIZ);
                parameter.Add(PublishParameters.OUTPUT_NAME_KIND, NameKind.NODE_ID);
                parameter.Add(PublishParameters.OUTPUT_TARGET_NODE, body == true ? TargetNodeKind.BODY : TargetNodeKind.PART);

                // VIZPub
                // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
                VIZPub.PublishManager publish = new PublishManager(VIZPub_Path);
                bool result_export = publish.ExportNode(parameter);

                if (result_export == false)
                {
                    Console.WriteLine("Model is null.");
                    return;
                }
            }

            // VIZ to VIZXML
            VIZPub.VIZXMLGenerator generator = new VIZPub.VIZXMLGenerator();

            generator.MetadataPath = metadata;

            generator.ModelPath = model_Path;
            generator.ModelLinkUnit = body == true ? Node.NodeKind.BODY : VIZPub.Node.NodeKind.PART;

            bool result = generator.GenerateVIZXML(output, false);
        }
    }
}
