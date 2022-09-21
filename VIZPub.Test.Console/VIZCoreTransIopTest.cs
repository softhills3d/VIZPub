using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub.Test.Console
{
    public class VIZCoreTransIopTest
    {
        public string VIZCoreTrans_Path { get; set; }

        public VIZCoreTransIopTest()
        {
            VIZCoreTrans_Path = "D:\\SH_GitHub\\VIZPub\\VIZCoreTransIOP\\VIZCoreTrans.exe";
        }

        public void Test()
        {
            // Set Environment Path
            VIZPub.EnvironmentInterOp.SetPath(System.IO.Path.GetDirectoryName(VIZCoreTrans_Path), true);

            ExportVIZW();
        }

        public void ExportVIZW()
        {
            TranslateParameter parameter = new TranslateParameter();

            parameter.Add(TranslateParameters.INPUT, "C:\\Temp\\sample.prt");                       // INPUT FILE 경로(절대경로)
            parameter.Add(TranslateParameters.OUTPUT, "C:\\Temp\\sample.viz");                      // OUTPUT FILE 경로(절대경로)
            parameter.Add(TranslateParameters.OUTPUT_VIZW_PATH, "C:\\Temp\\sample\\sample.vizw");   // [Optional] VIZW 추출 경로

            parameter.Add(TranslateParameters.COMPRESSION, true);                                   // [Optional] Compress VIZW
            parameter.Add(TranslateParameters.LOG, TranslateLog.OUTPUT_ALWAYS);                     // 결과 XML 생성 여부

            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportVIZW(parameter);
        }
    }
}