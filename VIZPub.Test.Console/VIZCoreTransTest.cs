using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub.Test.Console
{
    public class VIZCoreTransTest
    {
        public string VIZCoreTrans_Path { get; set; }

        public VIZCoreTransTest()
        {
            VIZCoreTrans_Path = "D:\\SH_GitHub\\VIZPub\\VIZCoreTrans\\VIZCoreTrans.exe";
        }

        public void Test()
        {
            ExportVIZ();

            ExportStep();

            ExportIges();

            Export3DXML();

            ExportEbomXml_Single_Top_Level_Assembly();
            ExportEbomXml_Multiple_Top_Level_Assemblies();

            ExportThumbnail_Model();
            ExportThumbnail_AllNode();
        }

        public void ExportVIZ()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.viz");
            parameter.Add(TranslateParameters.LOG, TranslateLog.OUTPUT_ALWAYS);

            parameter.Add(TranslateParameters.MASS_PROPERTY, false);                                // [Optional] True or False. Default(False)
            parameter.Add(TranslateParameters.TESSELATION_QUALITY, TesselationQuality.Normal);      // [Optional] Default(Normal)
            parameter.Add(TranslateParameters.PSKERNEL, false);                                     // [Optional] Default(False)
            parameter.Add(TranslateParameters.HEALING, false);                                      // [Optional] Default(False)
            parameter.Add(TranslateParameters.FREE_POINT, false);                                   // [Optional] Default(False)
            parameter.Add(TranslateParameters.FREE_CURVE, false);                                   // [Optional] Default(False)
            parameter.Add(TranslateParameters.HIDDEN_ENTITY, false);                                // [Optional] Default(False)
            parameter.Add(TranslateParameters.SUPRESSED_ENTITY, false);                             // [Optional] Default(False)

            // VIZCoreTrans
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZCoreTrans.exe
            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportVIZ(parameter);
        }

        public void ExportStep()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.stp");

            parameter.Add(TranslateParameters.PSKERNEL, false);                 // [Optional] Default(False)
            parameter.Add(TranslateParameters.HEALING, false);                  // [Optional] Default(False)
            parameter.Add(TranslateParameters.FREE_POINT, false);               // [Optional] Default(False)
            parameter.Add(TranslateParameters.FREE_CURVE, false);               // [Optional] Default(False)
            parameter.Add(TranslateParameters.HIDDEN_ENTITY, false);            // [Optional] Default(False)
            parameter.Add(TranslateParameters.SUPRESSED_ENTITY, false);         // [Optional] Default(False)
            parameter.Add(TranslateParameters.STEP_VERSION, StepVersion.V203);  // [Optional] Default(V.203)

            // VIZCoreTrans
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZCoreTrans.exe
            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportStep(parameter);
        }

        public void ExportIges()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.igs");

            parameter.Add(TranslateParameters.PSKERNEL, false);                 // [Optional] Default(False)
            parameter.Add(TranslateParameters.HEALING, false);                  // [Optional] Default(False)
            parameter.Add(TranslateParameters.FREE_POINT, false);               // [Optional] Default(False)
            parameter.Add(TranslateParameters.FREE_CURVE, false);               // [Optional] Default(False)
            parameter.Add(TranslateParameters.HIDDEN_ENTITY, false);            // [Optional] Default(False)
            parameter.Add(TranslateParameters.SUPRESSED_ENTITY, false);         // [Optional] Default(False)

            // VIZCoreTrans
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZCoreTrans.exe
            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportIges(parameter);
        }

        public void Export3DXML()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.3dxml");

            parameter.Add(TranslateParameters.PSKERNEL, false);                 // [Optional] Default(False)
            parameter.Add(TranslateParameters.HEALING, false);                  // [Optional] Default(False)
            parameter.Add(TranslateParameters.FREE_POINT, false);               // [Optional] Default(False)
            parameter.Add(TranslateParameters.FREE_CURVE, false);               // [Optional] Default(False)
            parameter.Add(TranslateParameters.HIDDEN_ENTITY, false);            // [Optional] Default(False)
            parameter.Add(TranslateParameters.SUPRESSED_ENTITY, false);         // [Optional] Default(False)

            // VIZCoreTrans
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZCoreTrans.exe
            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.Export3DXML(parameter);
        }

        public void ExportEbomXml_Single_Top_Level_Assembly()
        {
            TranslateParameter parameter = new TranslateParameter();
            parameter.Add(TranslateParameters.MODE, "xml");

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.xml");
            parameter.Add(TranslateParameters.LOG, TranslateLog.OUTPUT_ALWAYS);

            parameter.Add(TranslateParameters.EXPORT_FULL_STRUCTURE, false);            // [Optional] Default(False)
            parameter.Add(TranslateParameters.EXPORT_PART_ATTRIBUTE, false);            // [Optional] Default(False)
            parameter.Add(TranslateParameters.EXPORT_CAD_INFORMATION, false);           // [Optional] Default(False)   

            // If File Exists
            List<string> referencePath = new List<string>();
            referencePath.Add("C:\\Common\\ST-PART");
            referencePath.Add("C:\\Common\\MECA-PART");
            referencePath.Add("C:\\Common\\EQUIP-PART");

            if(referencePath.Count > 0)
            {
                parameter.Add(TranslateParameters.REFERENCE_FILE_PATH, referencePath);  // [Optional]
            }

            // VIZCoreTrans
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZCoreTrans.exe
            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportEbomXml(parameter);
        }

        public void ExportEbomXml_Multiple_Top_Level_Assemblies()
        {
            TranslateParameter parameter = new TranslateParameter();
            parameter.Add(TranslateParameters.MODE, "rootxml");

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.xml");
            parameter.Add(TranslateParameters.LOG, TranslateLog.OUTPUT_ALWAYS);

            parameter.Add(TranslateParameters.EXPORT_PART_ATTRIBUTE, false);            // [Optional] Default(False)

            // If File Exists
            List<string> referencePath = new List<string>();
            referencePath.Add("C:\\Common\\ST-PART");
            referencePath.Add("C:\\Common\\MECA-PART");
            referencePath.Add("C:\\Common\\EQUIP-PART");

            if (referencePath.Count > 0)
            {
                parameter.Add(TranslateParameters.REFERENCE_FILE_PATH, referencePath);  // [Optional]
            }

            // VIZCoreTrans
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZCoreTrans.exe
            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportEbomXml(parameter);
        }

        public void ExportThumbnail_Model()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.jpg");  // File Path
            parameter.Add(TranslateParameters.LOG, TranslateLog.OUTPUT_ALWAYS);

            parameter.Add(TranslateParameters.THUMBNAIL_IMAGE_WIDTH, 400);
            parameter.Add(TranslateParameters.THUMBNAIL_IMAGE_HEIGHT, 300);
            parameter.Add(TranslateParameters.THUMBNAIL_TARGET, ThumbnailImageTarget.MODEL);
            parameter.Add(TranslateParameters.EXPORT_CAD_INFORMATION, false);

            // If File Exists
            List<string> referencePath = new List<string>();
            referencePath.Add("C:\\Common\\ST-PART");
            referencePath.Add("C:\\Common\\MECA-PART");
            referencePath.Add("C:\\Common\\EQUIP-PART");

            if (referencePath.Count > 0)
            {
                parameter.Add(TranslateParameters.REFERENCE_FILE_PATH, referencePath);  
            }

            // VIZCoreTrans
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZCoreTrans.exe
            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportThumbnail(parameter);
        }

        public void ExportThumbnail_AllNode()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\Image");           // Directory
            parameter.Add(TranslateParameters.LOG, TranslateLog.OUTPUT_ALWAYS);

            parameter.Add(TranslateParameters.THUMBNAIL_IMAGE_WIDTH, 400);
            parameter.Add(TranslateParameters.THUMBNAIL_IMAGE_HEIGHT, 300);
            parameter.Add(TranslateParameters.THUMBNAIL_TARGET, ThumbnailImageTarget.ALL_NODE);
            parameter.Add(TranslateParameters.EXPORT_CAD_INFORMATION, false);

            // If File Exists
            List<string> referencePath = new List<string>();
            referencePath.Add("C:\\Common\\ST-PART");
            referencePath.Add("C:\\Common\\MECA-PART");
            referencePath.Add("C:\\Common\\EQUIP-PART");

            if (referencePath.Count > 0)
            {
                parameter.Add(TranslateParameters.REFERENCE_FILE_PATH, referencePath);
            }

            // VIZCoreTrans
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZCoreTrans.exe
            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportThumbnail(parameter);
        }
    }
}
