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
            ExportEbomXml();
            ExportThumbnail();
        }

        public void ExportVIZ()
        {
            TranslateParameter parameter = new TranslateParameter();

            // VIZCoreTrans
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZCoreTrans.exe
            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportVIZ(parameter);
        }

        public void ExportStep()
        {
            TranslateParameter parameter = new TranslateParameter();

            // VIZCoreTrans
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZCoreTrans.exe
            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportStep(parameter);
        }

        public void ExportIges()
        {
            TranslateParameter parameter = new TranslateParameter();

            // VIZCoreTrans
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZCoreTrans.exe
            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportIges(parameter);
        }

        public void Export3DXML()
        {
            TranslateParameter parameter = new TranslateParameter();

            // VIZCoreTrans
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZCoreTrans.exe
            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.Export3DXML(parameter);
        }

        public void ExportEbomXml()
        {
            TranslateParameter parameter = new TranslateParameter();

            // VIZCoreTrans
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZCoreTrans.exe
            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportEbomXml(parameter);
        }

        public void ExportThumbnail()
        {
            TranslateParameter parameter = new TranslateParameter();

            // VIZCoreTrans
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZCoreTrans.exe
            TranslateManager translate = new TranslateManager(VIZCoreTrans_Path);
            bool result = translate.ExportThumbnail(parameter);
        }
    }
}
