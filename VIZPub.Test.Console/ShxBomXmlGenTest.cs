using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub.Test.Console
{
    public class ShxBomXmlGenTest
    {
        public string ShxBomXmlGen_Path { get; set; }

        public ShxBomXmlGenTest()
        {
            ShxBomXmlGen_Path = "D:\\SH_GitHub\\VIZPub\\ShxBomXmlGen\\ShxBomXmlGen.exe";
        }

        public void Test()
        {
            //ExportEbomXml_Single_Top_Level_Assembly();
            //ExportEbomXml_Multiple_Top_Level_Assemblies();

            //ExportThumbnail_Model();
            //ExportThumbnail_AllNode();
        }

        public void ExportXML()
        {
            BomXmlParameter parameter = new BomXmlParameter();

            parameter.Add(BomXmlParameters.INPUT, "C:\\Temp\\sample.prt");           // INPUT FILE 경로(절대경로)
            parameter.Add(BomXmlParameters.OUTPUT, "C:\\Temp\\sample.xml");          // OUTPUT FILE 경로(절대경로)
            parameter.Add(BomXmlParameters.LOG, TranslateLog.OUTPUT_ALWAYS);         // 결과 XML 생성 여부

            parameter.Add(BomXmlParameters.EXPORT_FULL_STRUCTURE, false);            // [Optional] Default(False), Full Structure 추출 여부
            parameter.Add(BomXmlParameters.EXPORT_PART_ATTRIBUTE, false);            // [Optional] Default(False), Part Attribute 추출 여부
            parameter.Add(BomXmlParameters.EXPORT_CAD_INFORMATION, false);           // [Optional] Default(False), CAD 정보 추출 여부
            parameter.Add(BomXmlParameters.REFERENCE_NAME, false);                   // [Optional] Default(False), Hoops Reference Name 사용 여부
            parameter.Add(BomXmlParameters.USE_MULTI_PROCESS, false);                // [Optional] Default(False), Multi Process 사용 여부
            parameter.Add(BomXmlParameters.HIDDEN_ENTITY, false);                    // [Optional] Default(False), Hidden Entity 변환 여부 (InterOP)

            parameter.Add(BomXmlParameters.CREATE_NODE_MISSING_FILE, false);         // [Optional] Default(False), Missing File Node 생성 여부 (invertor)
            parameter.Add(BomXmlParameters.SPLIT_NAME_OPTION, false);                // [Optional] Default(False), Split Name Node 이름 필요없는 부분 삭제 여부 (invertor)

            parameter.Add(BomXmlParameters.READ_BREP, false);                        // [Optional] Default(False), Hoops Read Brep Option

            parameter.Add(BomXmlParameters.READ_DGMC, false);                        // [Optional] Default(False), Display Generic Form for Missing Boolean Components (PRO-E)
            parameter.Add(BomXmlParameters.READ_DGFC, false);                        // [Optional] Default(False), Display Generic Form for Flexible Boolean Components (PRO-E)

            List<string> referencePath = new List<string>();
            referencePath.Add("C:\\Common\\ST-PART");
            referencePath.Add("C:\\Common\\MECA-PART");
            referencePath.Add("C:\\Common\\EQUIP-PART");

            if (referencePath.Count > 0)
            {
                parameter.Add(BomXmlParameters.REFERENCE_FILE_PATH, referencePath);  // [Optional] 
            }

            // ShxBomXmlGen
            // Path : Ex) C:\SOFTHILLS\VIZPub\ShxBomXmlGen.exe
            BomXmlManager translate = new BomXmlManager(ShxBomXmlGen_Path);
            bool result = translate.ExportXML(parameter);
        }

        
        public void ExportEbomXml_Single_Top_Level_Assembly()
        {
            BomXmlParameter parameter = new BomXmlParameter();

            parameter.Add(BomXmlParameters.INPUT, "C:\\Temp\\sample.prt");           // INPUT FILE 경로(절대경로)
            parameter.Add(BomXmlParameters.OUTPUT, "C:\\Temp\\sample.xml");          // OUTPUT FILE 경로(절대경로)
            parameter.Add(BomXmlParameters.LOG, TranslateLog.OUTPUT_ALWAYS);         // 결과 XML 생성 여부

            parameter.Add(BomXmlParameters.SERVER_IP, "");                           // SERVER IP
            parameter.Add(BomXmlParameters.SERVER_PORT, "");                         // SERVER PORT
            parameter.Add(BomXmlParameters.EXPORT_FULL_STRUCTURE, true);             // [Optional] Default(False), Full Structure 추출 여부
            parameter.Add(BomXmlParameters.EXPORT_PART_ATTRIBUTE, true);             // [Optional] Default(False), Part Attribute 추출 여부
            parameter.Add(BomXmlParameters.EXPORT_CAD_INFORMATION, true);            // [Optional] Default(False), CAD 정보 추출 여부
            parameter.Add(BomXmlParameters.SUPRESSED_ENTITY, false);                 // [Optional] Default(False), Supressed Entity 변환 여부
            parameter.Add(BomXmlParameters.REFERENCE_NAME, false);                   // [Optional] Default(False), Hoops Reference Name 사용 여부

            // If File Exists
            List<string> referencePath = new List<string>();
            referencePath.Add("C:\\Common\\ST-PART");
            referencePath.Add("C:\\Common\\MECA-PART");
            referencePath.Add("C:\\Common\\EQUIP-PART");

            if(referencePath.Count > 0)
            {
                parameter.Add(BomXmlParameters.REFERENCE_FILE_PATH, referencePath);  // [Optional]
            }

            // ShxBomXmlGen
            // Path : Ex) C:\SOFTHILLS\VIZPub\ShxBomXmlGen.exe
            BomXmlManager translate = new BomXmlManager(ShxBomXmlGen_Path);
            bool result = translate.ExportEbomXml(parameter);
        }

        public void ExportEbomXml_Multiple_Top_Level_Assemblies()
        {
            BomXmlParameter parameter = new BomXmlParameter();

            parameter.Add(BomXmlParameters.INPUT, "C:\\Temp\\sample.prt");           // INPUT FILE 경로(절대경로)
            parameter.Add(BomXmlParameters.OUTPUT, "C:\\Temp\\sample");              // OUTPUT FILE 경로(절대경로)
            parameter.Add(BomXmlParameters.LOG, TranslateLog.OUTPUT_ALWAYS);         // 결과 XML 생성 여부

            parameter.Add(BomXmlParameters.SERVER_IP, "");                           // SERVER IP
            parameter.Add(BomXmlParameters.SERVER_PORT, "");                         // SERVER PORT
            parameter.Add(BomXmlParameters.EXPORT_PART_ATTRIBUTE, false);            // [Optional] Default(False), Part Attribute 추출 여부
            parameter.Add(BomXmlParameters.SUPRESSED_ENTITY, false);                 // [Optional] Default(False), Supressed Entity 변환 여부
            parameter.Add(BomXmlParameters.REFERENCE_NAME, false);                   // [Optional] Default(False), Hoops Reference Name 사용 여부

            // If File Exists
            List<string> referencePath = new List<string>();
            referencePath.Add("C:\\Common\\ST-PART");
            referencePath.Add("C:\\Common\\MECA-PART");
            referencePath.Add("C:\\Common\\EQUIP-PART");

            if (referencePath.Count > 0)
            {
                parameter.Add(BomXmlParameters.REFERENCE_FILE_PATH, referencePath);  // [Optional]
            }

            // ShxBomXmlGen
            // Path : Ex) C:\SOFTHILLS\VIZPub\ShxBomXmlGen.exe
            BomXmlManager translate = new BomXmlManager(ShxBomXmlGen_Path);
            bool result = translate.ExportEbomXml(parameter);
        }

        public void ExportThumbnail_Model()
        {
            BomXmlParameter parameter = new BomXmlParameter();

            parameter.Add(BomXmlParameters.INPUT, "C:\\Temp\\sample.prt");                  // INPUT FILE 경로(절대경로)
            parameter.Add(BomXmlParameters.OUTPUT, "C:\\Temp\\sample.jpg");                 // OUTPUT FILE 경로(절대경로)
            parameter.Add(BomXmlParameters.LOG, TranslateLog.OUTPUT_ALWAYS);                // 결과 XML 생성 여부

            parameter.Add(BomXmlParameters.SERVER_IP, "");                                  // SERVER IP
            parameter.Add(BomXmlParameters.SERVER_PORT, "");                                // SERVER PORT
            parameter.Add(BomXmlParameters.THUMBNAIL_IMAGE_WIDTH, 400);                     // [Optional] Default(400), Thumbnail Image 너비값
            parameter.Add(BomXmlParameters.THUMBNAIL_IMAGE_HEIGHT, 300);                    // [Optional] Default(300), Thumbnail Image 높이값
            parameter.Add(BomXmlParameters.RESOLUTION, 96);                                 // [Optional] Default(96), Thumbnail Image Resolution 값 지정
            parameter.Add(BomXmlParameters.IMAGE_QUALITY, 75);                              // [Optional] Default(75), Thumbnail Image Quality 지정
            parameter.Add(BomXmlParameters.THUMBNAIL_TARGET, ThumbnailImageTarget.MODEL);   // [Optional] Thumbnail 타겟 지정
            parameter.Add(BomXmlParameters.EXPORT_CAD_INFORMATION, false);                  // [Optional] Default(False), CAD 정보 추출 여부

            // If File Exists
            List<string> referencePath = new List<string>();
            referencePath.Add("C:\\Common\\ST-PART");
            referencePath.Add("C:\\Common\\MECA-PART");
            referencePath.Add("C:\\Common\\EQUIP-PART");

            if (referencePath.Count > 0)
            {
                parameter.Add(BomXmlParameters.REFERENCE_FILE_PATH, referencePath);  
            }

            parameter.Add(BomXmlParameters.SUPRESSED_ENTITY, false);                         // [Optional] Default(False), Supressed Entity 변환 여부
            parameter.Add(BomXmlParameters.REFERENCE_NAME, false);                           // [Optional] Default(False), Hoops Reference Name 사용 여부

            // ShxBomXmlGen
            // Path : Ex) C:\SOFTHILLS\VIZPub\ShxBomXmlGen.exe
            BomXmlManager translate = new BomXmlManager(ShxBomXmlGen_Path);
            bool result = translate.ExportThumbnail(parameter);
        }

        public void ExportThumbnail_AllNode()
        {
            BomXmlParameter parameter = new BomXmlParameter();

            parameter.Add(BomXmlParameters.INPUT, "C:\\Temp\\sample.prt");                           // INPUT FILE 경로(절대경로)
            parameter.Add(BomXmlParameters.OUTPUT, "C:\\Temp\\Image");                               // OUTPUT FILE 경로(절대경로)
            parameter.Add(BomXmlParameters.LOG, TranslateLog.OUTPUT_ALWAYS);                         // 결과 XML 생성 여부

            parameter.Add(BomXmlParameters.SERVER_IP, "");                                           // SERVER IP
            parameter.Add(BomXmlParameters.SERVER_PORT, "");                                         // SERVER PORT
            parameter.Add(BomXmlParameters.THUMBNAIL_IMAGE_WIDTH, 400);                              // [Optional] Default(400), Thumbnail Image 너비값
            parameter.Add(BomXmlParameters.THUMBNAIL_IMAGE_HEIGHT, 300);                             // [Optional] Default(300), Thumbnail Image 높이값
            parameter.Add(BomXmlParameters.RESOLUTION, 96);                                          // [Optional] Default(96), Thumbnail Image Resolution 값 지정
            parameter.Add(BomXmlParameters.IMAGE_QUALITY, 75);                                       // [Optional] Default(75), Thumbnail Image Quality 지정
            parameter.Add(BomXmlParameters.THUMBNAIL_TARGET, ThumbnailImageTarget.ALL_NODE);         // [Optional] Thumbnail 타겟 지정
            parameter.Add(BomXmlParameters.EXPORT_CAD_INFORMATION, false);                           // [Optional] Default(False), CAD 정보 추출 여부

            // If File Exists
            List<string> referencePath = new List<string>();
            referencePath.Add("C:\\Common\\ST-PART");
            referencePath.Add("C:\\Common\\MECA-PART");
            referencePath.Add("C:\\Common\\EQUIP-PART");

            if (referencePath.Count > 0)
            {
                parameter.Add(BomXmlParameters.REFERENCE_FILE_PATH, referencePath);
            }

            // ShxBomXmlGen
            // Path : Ex) C:\SOFTHILLS\VIZPub\ShxBomXmlGen.exe
            BomXmlManager translate = new BomXmlManager(ShxBomXmlGen_Path);
            bool result = translate.ExportThumbnail(parameter);
        }

        public void GetCADType()
        {
            BomXmlParameter parameter = new BomXmlParameter();

            parameter.Add(BomXmlParameters.INPUT, "C:\\Temp\\sample.prt");      // INPUT FILE 경로(절대경로)

            parameter.Add(BomXmlParameters.SERVER_IP, "");                      // SERVER IP
            parameter.Add(BomXmlParameters.SERVER_PORT, "");                    // SERVER PORT

            // ShxBomXmlGen
            // Path : Ex) C:\SOFTHILLS\VIZPub\ShxBomXmlGen.exe
            BomXmlManager translate = new BomXmlManager(ShxBomXmlGen_Path);
            bool result = translate.GetCADType(parameter);
        }
    }
}
