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
            //ExportVIZ();

            //ExportStep();

            //ExportIges();

            //Export3DXML();

            //ExportEbomXml_Single_Top_Level_Assembly();
            //ExportEbomXml_Multiple_Top_Level_Assemblies();

            //ExportThumbnail_Model();
            //ExportThumbnail_AllNode();

            ExportVIZW();
        }

        public void ExportXML()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");           // INPUT FILE 경로(절대경로)
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.xml");          // OUTPUT FILE 경로(절대경로)
            parameter.Add(TranslateParameters.LOG, TranslateLog.OUTPUT_ALWAYS);         // 결과 XML 생성 여부
            parameter.Add(TranslateParameters.SERVER_IP, "");                           // SERVER IP
            parameter.Add(TranslateParameters.SERVER_PORT, "");                         // SERVER PORT
            parameter.Add(TranslateParameters.EXPORT_FULL_STRUCTURE, false);            // [Optional] Default(False), Full Structure 추출 여부
            parameter.Add(TranslateParameters.EXPORT_PART_ATTRIBUTE, false);            // [Optional] Default(False), Part Attribute 추출 여부
            parameter.Add(TranslateParameters.EXPORT_CAD_INFORMATION, false);           // [Optional] Default(False), CAD 정보 추출 여부
            parameter.Add(TranslateParameters.REFERENCE_NAME, false);                   // [Optional] Default(False), Hoops Reference Name 사용 여부
            parameter.Add(TranslateParameters.USE_MULTI_PROCESS, false);                // [Optional] Default(False), Multi Process 사용 여부

            parameter.Add(TranslateParameters.CREATE_NODE_MISSING_FILE, false);         // [Optional] Default(False), Missing File Node 생성 여부 (invertor)
            parameter.Add(TranslateParameters.SPLIT_NAME_OPTION, false);                // [Optional] Default(False), Split Name Node 이름 필요없는 부분 삭제 여부 (invertor)

            parameter.Add(TranslateParameters.READ_BREP, false);                        // [Optional] Default(False), Hoops Read Brep Option

            parameter.Add(TranslateParameters.READ_DGMC, false);                        // [Optional] Default(False), Display Generic Form for Missing Boolean Components (PRO-E)
            parameter.Add(TranslateParameters.READ_DGFC, false);                        // [Optional] Default(False), Display Generic Form for Flexible Boolean Components (PRO-E)

            List<string> referencePath = new List<string>();
            ///referencePath.Add("C:\\Common\\ST-PART");
            ///referencePath.Add("C:\\Common\\MECA-PART");
            ///referencePath.Add("C:\\Common\\EQUIP-PART");
            referencePath.Add("C:\\RefPath.txt");

            if (referencePath.Count > 0)
            {
                parameter.Add(TranslateParameters.REFERENCE_FILE_PATH, referencePath);  // [Optional] 
            }


            // VIZCoreTrans
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZCoreTrans.exe
            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportXML(parameter);
        }

        public void ExportVIZ()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");                       // INPUT FILE 경로(절대경로)
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.viz");                      // OUTPUT FILE 경로(절대경로)
            parameter.Add(TranslateParameters.LOG, TranslateLog.OUTPUT_ALWAYS);                     // 결과 XML 생성 여부

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp");                                 // CAD to CAD XML 경로

            parameter.Add(TranslateParameters.MASS_PROPERTY, false);                                // [Optional] True or False. Default(False), Mass Property 사용 여부
            parameter.Add(TranslateParameters.TESSELLATION_QUALITY, TesselationQuality.Normal);     // [Optional] Default(Normal), Tessellation 품질
            parameter.Add(TranslateParameters.OUTPUT_THUMBNAIL, false);                             // [Optional] Default(False), 썸네일 EXPORT 여부
            parameter.Add(TranslateParameters.OUTPUT_VIZM, false);                                  // [Optional] Default(False), VIZM FILE EXPORT 여부
            parameter.Add(TranslateParameters.VIZ_VERSION, VIZVersion.V302);                        // [Optional] Default(203), VIZ FILE 버전 지정

            parameter.Add(TranslateParameters.HEALING, false);                                      // [Optional] Default(False), Healing 여부
            parameter.Add(TranslateParameters.FREE_POINT, false);                                   // [Optional] Default(False), Free Point 변환 여부
            parameter.Add(TranslateParameters.FREE_CURVE, false);                                   // [Optional] Default(False), Free Curve 변환 여부
            parameter.Add(TranslateParameters.HIDDEN_ENTITY, false);                                // [Optional] Default(False), Hidden Entity 변환 여부
            parameter.Add(TranslateParameters.SUPRESSED_ENTITY, false);                             // [Optional] Default(False), Supressed Entity 변환 여부

            parameter.Add(TranslateParameters.REFERENCE_NAME, false);                               // [Optional] Default(False), Hoops Reference Name 사용 여부
            parameter.Add(TranslateParameters.ASSEMBLY_ONLY, false);                                // [Optional] Default(False), Assembly만 변환할 것인지 여부
            parameter.Add(TranslateParameters.BODY_TO_PART, false);                                 // [Optional] Default(False), Body를 Part로 변환할 것인지 여부
            parameter.Add(TranslateParameters.FREE_SURFACE, false);                                 // [Optional] Default(False), Free Surface 변환 여부
            parameter.Add(TranslateParameters.VISIBLE_LAYER_ONLY,false);                            // [Optional] Default(False), Visible Layer만 변환할 것인지 여부
            parameter.Add(TranslateParameters.WITH_PMI, false);                                     // [Optional] Default(False), PMI Data 변환여부

            // VIZCoreTrans
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZCoreTrans.exe
            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportVIZ(parameter);
        }

        public void ExportStep()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");                       // INPUT FILE 경로(절대경로)
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.stp");                      // OUTPUT FILE 경로(절대경로)

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp\\VIZCoreTrans Test XML\\STEP");    // CAD to CAD XML 경로

            parameter.Add(TranslateParameters.STEP_VERSION, StepVersion.V203);                      // [Optional] Default(V.203), STEP FILE 버전 지정

            parameter.Add(TranslateParameters.NURBS, false);                                        // [Optional] Default(False), NURBS 저장 여부
            parameter.Add(TranslateParameters.FACET_TO_WIREFRAME, false);                           // [Optional] Default(False), Facet을 Wireframe으로 변환할 것인지 여부
            parameter.Add(TranslateParameters.USE_SHORT_NAME, false);                               // [Optional] Default(False), Entity Name을 줄일 것인지 여부
            parameter.Add(TranslateParameters.WRITE_PMI, false);                                    // [Optional] Default(False), PMI Data 변환여부

            // VIZCoreTrans
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZCoreTrans.exe
            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportStep(parameter);
        }

        public void ExportIges()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");                       // INPUT FILE 경로(절대경로)
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.igs");                      // OUTPUT FILE 경로(절대경로)

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp\\VIZCoreTrans Test XML\\IGES");    // CAD to CAD XML 경로

            parameter.Add(TranslateParameters.NURBS, false);                                        // [Optional] Default(False), NURBS 저장 여부
            parameter.Add(TranslateParameters.FACET_TO_WIREFRAME, false);                           // [Optional] Default(False), Facet을 Wireframe으로 변환할 것인지 여부
            parameter.Add(TranslateParameters.SOLID_AS_FACE, false);                                // [Optional] Default(False), Solid를 Face로 변환할 것인지 여부
            parameter.Add(TranslateParameters.HIDDEN_OBJECT, false);                                // [Optional] Default(False), Hidden Object 변환 여부
            parameter.Add(TranslateParameters.WRITE_TESSELATION, false);                            // [Optional] Default(False), Tessellation 변환 여부

            // VIZCoreTrans
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZCoreTrans.exe
            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportIges(parameter);
        }

        public void Export3DXML()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");           // INPUT FILE 경로(절대경로)
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.3dxml");        // OUTPUT FILE 경로(절대경로)

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp");                     // CAD to CAD XML 경로

            parameter.Add(TranslateParameters.HEALING, false);                          // [Optional] Default(False), Healing 여부
            parameter.Add(TranslateParameters.FREE_POINT, false);                       // [Optional] Default(False), Free Point 변환 여부
            parameter.Add(TranslateParameters.FREE_CURVE, false);                       // [Optional] Default(False), Free Curve 변환 여부
            parameter.Add(TranslateParameters.HIDDEN_ENTITY, false);                    // [Optional] Default(False), Hidden Entity 변환 여부
            parameter.Add(TranslateParameters.SUPRESSED_ENTITY, false);                 // [Optional] Default(False), Supressed Entity 변환 여부

            parameter.Add(TranslateParameters.REFERENCE_NAME, false);                   // [Optional] Default(False), Hoops Reference Name 사용 여부
            parameter.Add(TranslateParameters.ACTIVE_OBJ, false);                       // [Optional] Default(False), 선택된 Object만 변환할 것인지 여부

            // VIZCoreTrans
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZCoreTrans.exe
            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.Export3DXML(parameter);
        }

        public void ExportEbomXml_Single_Top_Level_Assembly()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");           // INPUT FILE 경로(절대경로)
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.xml");          // OUTPUT FILE 경로(절대경로)
            parameter.Add(TranslateParameters.LOG, TranslateLog.OUTPUT_ALWAYS);         // 결과 XML 생성 여부
            parameter.Add(TranslateParameters.SERVER_IP, "");                           // SERVER IP
            parameter.Add(TranslateParameters.SERVER_PORT, "");                         // SERVER PORT
            parameter.Add(TranslateParameters.EXPORT_FULL_STRUCTURE, true);             // [Optional] Default(False), Full Structure 추출 여부
            parameter.Add(TranslateParameters.EXPORT_PART_ATTRIBUTE, true);             // [Optional] Default(False), Part Attribute 추출 여부
            parameter.Add(TranslateParameters.EXPORT_CAD_INFORMATION, true);            // [Optional] Default(False), CAD 정보 추출 여부
            parameter.Add(TranslateParameters.SUPRESSED_ENTITY, false);                 // [Optional] Default(False), Supressed Entity 변환 여부
            parameter.Add(TranslateParameters.REFERENCE_NAME, false);                   // [Optional] Default(False), Hoops Reference Name 사용 여부

            // If File Exists
            List<string> referencePath = new List<string>();
            ///referencePath.Add("C:\\Common\\ST-PART");
            ///referencePath.Add("C:\\Common\\MECA-PART");
            ///referencePath.Add("C:\\Common\\EQUIP-PART");
            referencePath.Add("C:\\RefPath.txt");

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

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");           // INPUT FILE 경로(절대경로)
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.txt");          // OUTPUT FILE 경로(절대경로)
            parameter.Add(TranslateParameters.LOG, TranslateLog.OUTPUT_ALWAYS);         // 결과 XML 생성 여부
            parameter.Add(TranslateParameters.SERVER_IP, "");                           // SERVER IP
            parameter.Add(TranslateParameters.SERVER_PORT, "");                         // SERVER PORT
            parameter.Add(TranslateParameters.EXPORT_PART_ATTRIBUTE, false);            // [Optional] Default(False), Part Attribute 추출 여부
            parameter.Add(TranslateParameters.SUPRESSED_ENTITY, false);                 // [Optional] Default(False), Supressed Entity 변환 여부
            parameter.Add(TranslateParameters.REFERENCE_NAME, false);                   // [Optional] Default(False), Hoops Reference Name 사용 여부

            // If File Exists
            List<string> referencePath = new List<string>();
            ///referencePath.Add("C:\\Common\\ST-PART");
            ///referencePath.Add("C:\\Common\\MECA-PART");
            ///referencePath.Add("C:\\Common\\EQUIP-PART");
            referencePath.Add("C:\\RefPath.txt");

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

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");                  // INPUT FILE 경로(절대경로)
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.jpg");                 // OUTPUT FILE 경로(절대경로)
            parameter.Add(TranslateParameters.LOG, TranslateLog.OUTPUT_ALWAYS);                // 결과 XML 생성 여부
            parameter.Add(TranslateParameters.SERVER_IP, "");                                  // SERVER IP
            parameter.Add(TranslateParameters.SERVER_PORT, "");                                // SERVER PORT
            parameter.Add(TranslateParameters.THUMBNAIL_IMAGE_WIDTH, 400);                     // [Optional] Default(400), Thumbnail Image 너비값
            parameter.Add(TranslateParameters.THUMBNAIL_IMAGE_HEIGHT, 300);                    // [Optional] Default(300), Thumbnail Image 높이값
            parameter.Add(TranslateParameters.RESOLUTION, 96);                                 // [Optional] Default(96), Thumbnail Image Resolution 값 지정
            parameter.Add(TranslateParameters.IMAGE_QUALITY, 75);                              // [Optional] Default(75), Thumbnail Image Quality 지정
            parameter.Add(TranslateParameters.THUMBNAIL_TARGET, ThumbnailImageTarget.MODEL);   // [Optional] Thumbnail 타겟 지정
            parameter.Add(TranslateParameters.EXPORT_CAD_INFORMATION, false);                  // [Optional] Default(False), CAD 정보 추출 여부

            // If File Exists
            List<string> referencePath = new List<string>();
            ///referencePath.Add("C:\\Common\\ST-PART");
            ///referencePath.Add("C:\\Common\\MECA-PART");
            ///referencePath.Add("C:\\Common\\EQUIP-PART");
            referencePath.Add("C:\\RefPath.txt");

            if (referencePath.Count > 0)
            {
                parameter.Add(TranslateParameters.REFERENCE_FILE_PATH, referencePath);  
            }

            parameter.Add(TranslateParameters.SUPRESSED_ENTITY, false);                         // [Optional] Default(False), Supressed Entity 변환 여부
            parameter.Add(TranslateParameters.REFERENCE_NAME, false);                           // [Optional] Default(False), Hoops Reference Name 사용 여부

            // VIZCoreTrans
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZCoreTrans.exe
            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportThumbnail(parameter);
        }

        public void ExportThumbnail_AllNode()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");                           // INPUT FILE 경로(절대경로)
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\Image.txt");                           // OUTPUT FILE 경로(절대경로)
            parameter.Add(TranslateParameters.LOG, TranslateLog.OUTPUT_ALWAYS);                         // 결과 XML 생성 여부
            parameter.Add(TranslateParameters.SERVER_IP, "");                                           // SERVER IP
            parameter.Add(TranslateParameters.SERVER_PORT, "");                                         // SERVER PORT
            parameter.Add(TranslateParameters.THUMBNAIL_IMAGE_WIDTH, 400);                              // [Optional] Default(400), Thumbnail Image 너비값
            parameter.Add(TranslateParameters.THUMBNAIL_IMAGE_HEIGHT, 300);                             // [Optional] Default(300), Thumbnail Image 높이값
            parameter.Add(TranslateParameters.RESOLUTION, 96);                                          // [Optional] Default(96), Thumbnail Image Resolution 값 지정
            parameter.Add(TranslateParameters.IMAGE_QUALITY, 75);                                       // [Optional] Default(75), Thumbnail Image Quality 지정
            parameter.Add(TranslateParameters.THUMBNAIL_TARGET, ThumbnailImageTarget.ALL_NODE);         // [Optional] Thumbnail 타겟 지정
            parameter.Add(TranslateParameters.EXPORT_CAD_INFORMATION, false);                           // [Optional] Default(False), CAD 정보 추출 여부

            // If File Exists
            List<string> referencePath = new List<string>();
            ///referencePath.Add("C:\\Common\\ST-PART");
            ///referencePath.Add("C:\\Common\\MECA-PART");
            ///referencePath.Add("C:\\Common\\EQUIP-PART");
            referencePath.Add("C:\\RefPath.txt");

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

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");             // INPUT FILE 경로(절대경로)
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.x_t");            // OUTPUT FILE 경로(절대경로)

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp\\VIZCoreTrans Test XML\\Parasolid");// CAD to CAD XML 경로

            parameter.Add(TranslateParameters.WRITE_TESSELATION, false);                // [Optional] Default(False), Tessellation 변환 여부

            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportPS(parameter);
        }

        public void ExportPDF()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");                   //INPUT FILE 경로(절대경로)
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.pdf");                  //OUTPUT FILE 경로(절대경로)

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp");

            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportPDF(parameter);
        }

        public void ExportSTL()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");                   // INPUT FILE 경로(절대경로)
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.stl");                  // OUTPUT FILE 경로(절대경로)

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp\\VIZCoreTrans Test XML\\STL"); // CAD to CAD XML 경로

            parameter.Add(TranslateParameters.SAVE_AS_BINARY, false);             // [Optional] Default(False), Binary 사용 여부
            parameter.Add(TranslateParameters.KEEP_TESSELLATION, false);          // [Optional] Default(False), 현재 Tessellation 유지 여부
            parameter.Add(TranslateParameters.ACCURATE_TESSELLATION, false);      // [Optional] Default(False), 적합한 Tessellation 설정 여부


            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportSTL(parameter);
        }

        public void ExportACIS()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");               // INPUT FILE 경로(절대경로)
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.sat");              // OUTPUT FILE 경로(절대경로)

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp\\VIZCoreTrans Test XML\\ACIS");// CAD to CAD XML 경로

            parameter.Add(TranslateParameters.SAVE_AS_MILLIMETER, false);           // [Optional] Default(False), 현재 모델 단위 대신 mm로 저장할 것인지 여부
            parameter.Add(TranslateParameters.SAVE_AS_BINARY, false);               // [Optional] Default(False), Binary File로 저장할 것인지 여부

            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportACIS(parameter);
        }

        public void ExportJT()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");               // INPUT FILE 경로(절대경로)
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.jt");               // OUTPUT FILE 경로(절대경로)

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp\\VIZCoreTrans Test XML\\JT");// CAD to CAD XML 경로

            parameter.Add(TranslateParameters.HIDDEN_OBJECT, false);                         // [Optional] Default(False), Hidden Object 변환 여부
            parameter.Add(TranslateParameters.WRITE_PMI, false);                             // [Optional] Default(False), PMI Data 변환 여부
            parameter.Add(TranslateParameters.JT_VERSION, JtVersion.JT_801);                 // [Optional] Default(801), JT FILE 버전 선택
            parameter.Add(TranslateParameters.WRITE_MODE, WritingMode.Tessellation);         // [Optional] Default(Tessellation), Model File 작성 모드 선택

            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportJT(parameter);
        }

        public void ExportU3D()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");               // INPUT FILE 경로(절대경로)
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.u3d");              // OUTPUT FILE 경로(절대경로)

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp\\VIZCoreTrans Test XML\\U3D");// CAD to CAD XML 경로

            parameter.Add(TranslateParameters.MESH_QUALITY, false);                         // [Optional] Default(False), Mesh 품질 Tessellation 압축 여부
            parameter.Add(TranslateParameters.U3D_VERSION, U3DVersion.U3D_CMA1);            // [Optional] Default(U3D-CMA1), U3D FILE 버전 선택

            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportU3D(parameter);
        }

        public void ExportVRML()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");               // INPUT FILE 경로(절대경로)
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.vrml");             // OUTPUT FILE 경로(절대경로)

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp");                         // CAD to CAD XML 경로

            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportVRML(parameter);
        }

        public void ExportVIZM()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");                       // INPUT FILE 경로(절대경로)
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.vizm");                     // OUTPUT FILE 경로(절대경로)
            parameter.Add(TranslateParameters.LOG, TranslateLog.OUTPUT_ALWAYS);                     // 결과 XML 생성 여부

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp");                                 // CAD to CAD XML 경로

            parameter.Add(TranslateParameters.MASS_PROPERTY, false);                                // [Optional] True or False. Default(False), Mass Property 사용 여부
            parameter.Add(TranslateParameters.OUTPUT_THUMBNAIL, false);                             // [Optional] Default(False), 썸네일 EXPORT 여부
            parameter.Add(TranslateParameters.HEALING, false);                                      // [Optional] Default(False), Healing 여부
            parameter.Add(TranslateParameters.FREE_POINT, false);                                   // [Optional] Default(False), Free Point 변환 여부
            parameter.Add(TranslateParameters.FREE_CURVE, false);                                   // [Optional] Default(False), Free Curve 변환 여부
            parameter.Add(TranslateParameters.HIDDEN_ENTITY, false);                                // [Optional] Default(False), Hidden Entity 변환 여부
            parameter.Add(TranslateParameters.SUPRESSED_ENTITY, false);                             // [Optional] Default(False), Supressed Entity 변환 여부

            parameter.Add(TranslateParameters.REFERENCE_NAME, false);                               // [Optional] Default(False), Hoops Reference Name 사용 여부 
            parameter.Add(TranslateParameters.ASSEMBLY_ONLY, false);                                // [Optional] Default(False), Assembly만 변환할 것인지 여부 
            parameter.Add(TranslateParameters.BODY_TO_PART, false);                                 // [Optional] Default(False), Body를 Part로 변환할 것인지 여부
            parameter.Add(TranslateParameters.FREE_SURFACE, false);                                 // [Optional] Default(False), Free Surface 변환 여부 
            parameter.Add(TranslateParameters.VISIBLE_LAYER_ONLY, false);                           // [Optional] Default(False), Visible Layer만 변환할 것인지 여부 
            parameter.Add(TranslateParameters.WRITE_PMI, false);                                    // [Optional] Default(False), PMI Data 변환여부 
            parameter.Add(TranslateParameters.OUTPUT_VIZM, false);                                  // [Optional] Default(False), VIZM 추출여부
                                                                                                            
            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);                           
            bool result = translate.ExportVIZM(parameter);                                                  
        }                                                                                                   

        public void ExportVIZW()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");                       // INPUT FILE 경로(절대경로)
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.viz");                      // OUTPUT FILE 경로(절대경로)
            parameter.Add(TranslateParameters.LOG, TranslateLog.OUTPUT_ALWAYS);                     // 결과 XML 생성 여부

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp");                                 // CAD to CAD XML 경로

            parameter.Add(TranslateParameters.MASS_PROPERTY, false);                                // [Optional] True or False. Default(False), Mass Property 사용 여부
            parameter.Add(TranslateParameters.TESSELLATION_QUALITY, TesselationQuality.Normal);     // [Optional] Default(Normal), Tessellation 품질

            parameter.Add(TranslateParameters.OUTPUT_VIZW_PATH, "C:\\Temp\\sample\\sample.vizw");   // [Optional] VIZW 추출 경로

            parameter.Add(TranslateParameters.OUTPUT_THUMBNAIL, false);                             // [Optional] Default(False), 썸네일 EXPORT 여부
            parameter.Add(TranslateParameters.OUTPUT_THUMBNAIL_PATH, "C:\\Temp\\sample");           // [Optional] Thumbnail 추출 경로
            parameter.Add(TranslateParameters.THUMBNAIL_IMAGE_WIDTH, 400);                          // [Optional] Default(400), Thumbnail Image 너비값
            parameter.Add(TranslateParameters.THUMBNAIL_IMAGE_HEIGHT, 300);                         // [Optional] Default(300), Thumbnail Image 높이값
            parameter.Add(TranslateParameters.THUMBNAIL_DEFAULT_VIEW, 0);                           // [Optional] Default(0), Thumbnail defualt

            parameter.Add(TranslateParameters.VIZ_VERSION, VIZVersion.V302);                        // [Optional] Default(302), VIZ FILE 버전
            parameter.Add(TranslateParameters.SPLIT_COUNT, 1);                                      // [Optional] Default(1), VIZW 파일분할 개수

            parameter.Add(TranslateParameters.HEALING, false);                                      // [Optional] Default(False), Healing 여부
            parameter.Add(TranslateParameters.FREE_POINT, false);                                   // [Optional] Default(False), Free Point 변환 여부
            parameter.Add(TranslateParameters.FREE_CURVE, false);                                   // [Optional] Default(False), Free Curve 변환 여부
            parameter.Add(TranslateParameters.HIDDEN_ENTITY, false);                                // [Optional] Default(False), Hidden Entity 변환 여부
            parameter.Add(TranslateParameters.SUPRESSED_ENTITY, false);                             // [Optional] Default(False), Supressed Entity 변환 여부

            parameter.Add(TranslateParameters.REFERENCE_NAME, false);                               // [Optional] Default(False), Hoops Reference Name 사용 여부 
            parameter.Add(TranslateParameters.ASSEMBLY_ONLY, false);                                // [Optional] Default(False), Assembly만 변환할 것인지 여부 
            parameter.Add(TranslateParameters.BODY_TO_PART, false);                                 // [Optional] Default(False), Body를 Part로 변환할 것인지 여부
            parameter.Add(TranslateParameters.FREE_SURFACE, false);                                 // [Optional] Default(False), Free Surface 변환 여부 
            parameter.Add(TranslateParameters.VISIBLE_LAYER_ONLY, false);                           // [Optional] Default(False), Visible Layer만 변환할 것인지 여부 

            parameter.Add(TranslateParameters.COMPRESSION, true);                                   // [Optional] Compress VIZW

            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportVIZW(parameter);
        }

        public void Export3MF()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");                       // INPUT FILE 경로(절대경로)
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.3mf");                      // OUTPUT FILE 경로(절대경로)

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp\\VIZCoreTrans Test XML\\3MF");     // CAD to CAD XML 경로

            parameter.Add(TranslateParameters.KEEP_TESSELLATION, false);         // [Optional] Default(False), 현재 Tessellation 유지 여부
            parameter.Add(TranslateParameters.ACCURATE_TESSELLATION, false);     // [Optional] Default(False), 적합한 Tessellation 설정 여부


            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.Export3MF(parameter);
        }

        public void ExportFBX()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");                       // INPUT FILE 경로(절대경로)
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.fbx");                      // OUTPUT FILE 경로(절대경로)

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp");                                 // CAD to CAD XML 경로

            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportFBX(parameter);
        }

        public void ExportGLTF()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");                           // INPUT FILE 경로(절대경로)
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.gltf");                         // OUTPUT FILE 경로(절대경로)

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp");                                     // CAD to CAD XML 경로

            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportGLTF(parameter);
        }

        public void ExportOBJ()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");                       // INPUT FILE 경로(절대경로)
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.obj");                      // OUTPUT FILE 경로(절대경로)

            parameter.Add(TranslateParameters.CAD2CAD, "C:\\Temp");                                 // CAD to CAD XML 경로

            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportOBJ(parameter);
        }
    }
}
