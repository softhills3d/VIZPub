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

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp\\CAD2CAD_Hoops.xml");

            parameter.Add(TranslateParameters.MASS_PROPERTY, false);                                // [Optional] True or False. Default(False)
            parameter.Add(TranslateParameters.TESSELLATION_QUALITY, TesselationQuality.Normal);      // [Optional] Default(Normal)
            parameter.Add(TranslateParameters.PSKERNEL, false);                                     // [Optional] Default(False)
            parameter.Add(TranslateParameters.OUTPUT_THUMBNAIL, false);                             // [Optional] Default(False)
            parameter.Add(TranslateParameters.OUTPUT_VIZM, false);                                  // [Optional] Default(False)
            parameter.Add(TranslateParameters.VIZ_VERSION, VIZVersion.V302);                        // [Optional] Default(False)

            parameter.Add(TranslateParameters.HEALING, false);                                      // [Optional] Default(False)
            parameter.Add(TranslateParameters.FREE_POINT, false);                                   // [Optional] Default(False)
            parameter.Add(TranslateParameters.FREE_CURVE, false);                                   // [Optional] Default(False)
            parameter.Add(TranslateParameters.HIDDEN_ENTITY, false);                                // [Optional] Default(False)
            parameter.Add(TranslateParameters.SUPRESSED_ENTITY, false);                             // [Optional] Default(False)

            parameter.Add(TranslateParameters.REFERENCE_NAME, false);                               // [Optional] Default(False)
            parameter.Add(TranslateParameters.UDA, false);                                          // [Optional] Default(False)
            parameter.Add(TranslateParameters.ASSEMBLY_ONLY, false);                                // [Optional] Default(False)
            parameter.Add(TranslateParameters.BODY_TO_PART, false);                                 // [Optional] Default(False)
            parameter.Add(TranslateParameters.FREE_SURFACE, false);                                 // [Optional] Default(False)
            parameter.Add(TranslateParameters.VISIBLE_LAYER_ONLY,false);                            // [Optional] Default(False)
            parameter.Add(TranslateParameters.WITH_PMI, false);                                     // [Optional] Default(False)

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

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp\\CAD2CAD_Hoops.xml");

            parameter.Add(TranslateParameters.STEP_VERSION, StepVersion.V203);  // [Optional] Default(V.203)

            parameter.Add(TranslateParameters.NURBS, false);                    // [Optional] Default(False)
            parameter.Add(TranslateParameters.FACET_TO_WIREFRAME, false);       // [Optional] Default(False)
            parameter.Add(TranslateParameters.USE_SHORT_NAME, false);           // [Optional] Default(False)
            parameter.Add(TranslateParameters.WRITE_PMI, false);                // [Optional] Default(False)

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

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp\\CAD2CAD_Hoops.xml");

            parameter.Add(TranslateParameters.NURBS, false);                    // [Optional] Default(False)
            parameter.Add(TranslateParameters.FACET_TO_WIREFRAME, false);       // [Optional] Default(False)
            parameter.Add(TranslateParameters.SOLID_AS_FACE, false);            // [Optional] Default(False)
            parameter.Add(TranslateParameters.HIDDEN_OBJECT, false);            // [Optional] Default(False)
            parameter.Add(TranslateParameters.WRITE_TESSELATION, false);        // [Optional] Default(False)

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

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp\\CAD2CAD_Hoops.xml");

            parameter.Add(TranslateParameters.PSKERNEL, false);                 // [Optional] Default(False)
            parameter.Add(TranslateParameters.HEALING, false);                  // [Optional] Default(False)
            parameter.Add(TranslateParameters.FREE_POINT, false);               // [Optional] Default(False)
            parameter.Add(TranslateParameters.FREE_CURVE, false);               // [Optional] Default(False)
            parameter.Add(TranslateParameters.HIDDEN_ENTITY, false);            // [Optional] Default(False)
            parameter.Add(TranslateParameters.SUPRESSED_ENTITY, false);         // [Optional] Default(False)

            parameter.Add(TranslateParameters.REFERENCE_NAME, false);           // [Optional] Default(False)
            parameter.Add(TranslateParameters.ACTIVE_OBJ, false);               // [Optional] Default(False)

            // VIZCoreTrans
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZCoreTrans.exe
            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.Export3DXML(parameter);
        }

        public void ExportEbomXml_Single_Top_Level_Assembly()
        {
            TranslateParameter parameter = new TranslateParameter();

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

            parameter.Add(TranslateParameters.SUPRESSED_ENTITY, false);         // [Optional] Default(False)
            parameter.Add(TranslateParameters.REFERENCE_NAME, false);           // [Optional] Default(False)

            // VIZCoreTrans
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZCoreTrans.exe
            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportEbomXml(parameter);
        }

        public void ExportEbomXml_Multiple_Top_Level_Assemblies()
        {
            TranslateParameter parameter = new TranslateParameter();

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

            parameter.Add(TranslateParameters.SUPRESSED_ENTITY, false);         // [Optional] Default(False)
            parameter.Add(TranslateParameters.REFERENCE_NAME, false);           // [Optional] Default(False)

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

            parameter.Add(TranslateParameters.THUMBNAIL_IMAGE_WIDTH, 400);                          // [Optional] Default(False)
            parameter.Add(TranslateParameters.THUMBNAIL_IMAGE_HEIGHT, 300);                         // [Optional] Default(False)
            parameter.Add(TranslateParameters.THUMBNAIL_TARGET, ThumbnailImageTarget.MODEL);        // [Optional] Default(False)
            parameter.Add(TranslateParameters.EXPORT_CAD_INFORMATION, false);                       // [Optional] Default(False)

            // If File Exists
            List<string> referencePath = new List<string>();
            referencePath.Add("C:\\Common\\ST-PART");
            referencePath.Add("C:\\Common\\MECA-PART");
            referencePath.Add("C:\\Common\\EQUIP-PART");

            if (referencePath.Count > 0)
            {
                parameter.Add(TranslateParameters.REFERENCE_FILE_PATH, referencePath);  
            }

            parameter.Add(TranslateParameters.SUPRESSED_ENTITY, false);         // [Optional] Default(False)
            parameter.Add(TranslateParameters.REFERENCE_NAME, false);           // [Optional] Default(False)

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

            parameter.Add(TranslateParameters.THUMBNAIL_IMAGE_WIDTH, 400);                              // [Optional] Default(False)
            parameter.Add(TranslateParameters.THUMBNAIL_IMAGE_HEIGHT, 300);                             // [Optional] Default(False)
            parameter.Add(TranslateParameters.THUMBNAIL_TARGET, ThumbnailImageTarget.ALL_NODE);         // [Optional] Default(False)
            parameter.Add(TranslateParameters.EXPORT_CAD_INFORMATION, false);                           // [Optional] Default(False)

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

        public void ExportPS()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.x_t");

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp\\CAD2CAD_Hoops.xml");

            parameter.Add(TranslateParameters.WRITE_TESSELATION, false);        // [Optional] Default(False)

            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportPS(parameter);
        }

        public void ExportPDF()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.pdf");

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp\\CAD2CAD_Hoops.xml");

            parameter.Add(TranslateParameters.PSKERNEL, false);                 // [Optional] Default(False)

            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportPDF(parameter);
        }

        public void ExportSTL()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.stl");

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp\\CAD2CAD_Hoops.xml");

            parameter.Add(TranslateParameters.SAVE_AS_BINARY, false);             // [Optional] Default(False)
            parameter.Add(TranslateParameters.KEEP_TESSELLATION, false);          // [Optional] Default(False)
            parameter.Add(TranslateParameters.ACCURATE_TESSELLATION, false);      // [Optional] Default(False)


            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportSTL(parameter);
        }

        public void ExportACIS()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.sat");

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp\\CAD2CAD_Hoops.xml");

            parameter.Add(TranslateParameters.SAVE_AS_MILLIMETER, false);           // [Optional] Default(False)
            parameter.Add(TranslateParameters.SAVE_AS_BINARY, false);               // [Optional] Default(False)

            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportACIS(parameter);
        }

        public void ExportJT()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.jt");

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp\\CAD2CAD_Hoops.xml");

            parameter.Add(TranslateParameters.PSKERNEL, false);                 // [Optional] Default(False)

            parameter.Add(TranslateParameters.HIDDEN_OBJECT, false);            // [Optional] Default(False)
            parameter.Add(TranslateParameters.WRITE_PMI, false);                // [Optional] Default(False)
            parameter.Add(TranslateParameters.JT_VERSION, JtVersion.JT_801);
            parameter.Add(TranslateParameters.WRITE_MODE, WritingMode.Tessellation);

            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportJT(parameter);
        }

        public void ExportU3D()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.u3d");

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp\\CAD2CAD_Hoops.xml");

            parameter.Add(TranslateParameters.MESH_QUALITY, false);                         // [Optional] Default(False)
            parameter.Add(TranslateParameters.U3D_VERSION, U3DVersion.U3D_CMA1);            // [Optional] Default(U3D-CMA1)

            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportU3D(parameter);
        }

        public void ExportVRML()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp\\CAD2CAD_Hoops.xml");

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.vrml");

            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportVRML(parameter);
        }

        public void ExportVIZM()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.vizm");
            parameter.Add(TranslateParameters.LOG, TranslateLog.OUTPUT_ALWAYS);

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp\\CAD2CAD_Hoops.xml");

            parameter.Add(TranslateParameters.PSKERNEL, false);                 // [Optional] Default(False)
            parameter.Add(TranslateParameters.HEALING, false);                  // [Optional] Default(False)
            parameter.Add(TranslateParameters.FREE_POINT, false);               // [Optional] Default(False)
            parameter.Add(TranslateParameters.FREE_CURVE, false);               // [Optional] Default(False)
            parameter.Add(TranslateParameters.HIDDEN_ENTITY, false);            // [Optional] Default(False)
            parameter.Add(TranslateParameters.SUPRESSED_ENTITY, false);         // [Optional] Default(False)

            parameter.Add(TranslateParameters.REFERENCE_NAME, false);          // [Optional] Default(False)
            parameter.Add(TranslateParameters.ASSEMBLY_ONLY, false);           // [Optional] Default(False)
            parameter.Add(TranslateParameters.BODY_TO_PART, false);            // [Optional] Default(False)
            parameter.Add(TranslateParameters.FREE_SURFACE, false);            // [Optional] Default(False)
            parameter.Add(TranslateParameters.VISIBLE_LAYER_ONLY, false);      // [Optional] Default(False)
            parameter.Add(TranslateParameters.WRITE_PMI, false);               // [Optional] Default(False)
            parameter.Add(TranslateParameters.OUTPUT_VIZM, false);             // [Optional] Default(False)

            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportVIZM(parameter);
        }

        public void ExportVIZW()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.vizw");

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp\\CAD2CAD_Hoops.xml");

            parameter.Add(TranslateParameters.MASS_PROPERTY, false);                                // [Optional] True or False. Default(False)
            parameter.Add(TranslateParameters.TESSELLATION_QUALITY, TesselationQuality.Normal);      // [Optional] Default(Normal)
            parameter.Add(TranslateParameters.PSKERNEL, false);                                     // [Optional] Default(False)
            parameter.Add(TranslateParameters.OUTPUT_THUMBNAIL, false);                             // [Optional] Default(False)
            parameter.Add(TranslateParameters.OUTPUT_VIZW_PATH, "C:\\Temp\\sample");
            parameter.Add(TranslateParameters.OUTPUT_THUMBNAIL_PATH, "C:\\Temp\\sample");
            parameter.Add(TranslateParameters.THUMBNAIL_IMAGE_WIDTH, 400);                          // [Optional] Default(False)
            parameter.Add(TranslateParameters.THUMBNAIL_IMAGE_HEIGHT, 300);                         // [Optional] Default(False)
            parameter.Add(TranslateParameters.VIZ_VERSION, VIZVersion.V302);

            parameter.Add(TranslateParameters.HEALING, false);                  // [Optional] Default(False)
            parameter.Add(TranslateParameters.FREE_POINT, false);               // [Optional] Default(False)
            parameter.Add(TranslateParameters.FREE_CURVE, false);               // [Optional] Default(False)
            parameter.Add(TranslateParameters.HIDDEN_ENTITY, false);            // [Optional] Default(False)
            parameter.Add(TranslateParameters.SUPRESSED_ENTITY, false);         // [Optional] Default(False)

            parameter.Add(TranslateParameters.REFERENCE_NAME, false);           // [Optional] Default(False)
            parameter.Add(TranslateParameters.ASSEMBLY_ONLY, false);            // [Optional] Default(False)
            parameter.Add(TranslateParameters.BODY_TO_PART,false);              // [Optional] Default(False)
            parameter.Add(TranslateParameters.FREE_SURFACE,false);              // [Optional] Default(False)
            parameter.Add(TranslateParameters.VISIBLE_LAYER_ONLY, false);       // [Optional] Default(False)

            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportVIZW(parameter);
        }

        public void Export3MF()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.3mf");

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp\\CAD2CAD_Hoops.xml");

            parameter.Add(TranslateParameters.KEEP_TESSELLATION, false);         // [Optional] Default(False)
            parameter.Add(TranslateParameters.ACCURATE_TESSELLATION, false);     // [Optional] Default(False)


            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.Export3MF(parameter);
        }

        public void ExportFBX()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.fbx");

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp\\CAD2CAD_Hoops.xml");

            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportFBX(parameter);
        }

        public void ExportGLTF()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.gltf");

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp\\CAD2CAD_Hoops.xml");

            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportGLTF(parameter);
        }

        public void ExportOBJ()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.obj");

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp\\CAD2CAD_Hoops.xml");

            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportOBJ(parameter);
        }

    }
}
