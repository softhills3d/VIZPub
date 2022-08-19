using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub.Test.Console
{
    public class VIZPub2DTest
    {
        public string VIZPub2D_Path { get; set; }

        public VIZPub2DTest()
        {
            VIZPub2D_Path = "D:\\SH_GitHub\\VIZPub\\VIZPub2D\\VIZPub2D.exe";
        }

        public void Test()
        {
            Export();
        }

        public void Export()
        {
            // Parameter
            ImageParameter parameter = new ImageParameter();

            parameter.Add(ImageParameters.INPUT, "C:\\Temp\\Drawing.dxf");
            parameter.Add(ImageParameters.OUTPUT, "C:\\Temp\\Drawing.jpg");
            parameter.Add(ImageParameters.LOG, false);

            // Conversion
            ImageManager image = new ImageManager(VIZPub2D_Path);
            bool result = image.Export(parameter);
        }
    }
}
