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
            Export_Size();
            Export_Scale();
            Export_SizeScale();
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

        public void Export_Size()
        {
            // Parameter
            ImageParameter parameter = new ImageParameter();

            parameter.Add(ImageParameters.INPUT, "C:\\Temp\\Drawing.dxf");
            parameter.Add(ImageParameters.OUTPUT, "C:\\Temp\\Drawing_Size.jpg");
            parameter.Add(ImageParameters.LOG, false);

            parameter.Add(ImageParameters.WIDTH, 1024);
            parameter.Add(ImageParameters.HEIGHT, 768);

            // Conversion
            ImageManager image = new ImageManager(VIZPub2D_Path);
            bool result = image.Export(parameter);
        }

        public void Export_Scale()
        {
            // Parameter
            ImageParameter parameter = new ImageParameter();

            parameter.Add(ImageParameters.INPUT, "C:\\Temp\\Drawing.dxf");
            parameter.Add(ImageParameters.OUTPUT, "C:\\Temp\\Drawing_Scale.jpg");
            parameter.Add(ImageParameters.LOG, false);

            parameter.Add(ImageParameters.SCALE, 2.0f);

            // Conversion
            ImageManager image = new ImageManager(VIZPub2D_Path);
            bool result = image.Export(parameter);
        }

        public void Export_SizeScale()
        {
            // Parameter
            ImageParameter parameter = new ImageParameter();

            parameter.Add(ImageParameters.INPUT, "C:\\Temp\\Drawing.dxf");
            parameter.Add(ImageParameters.OUTPUT, "C:\\Temp\\Drawing_SizeScale.jpg");
            parameter.Add(ImageParameters.LOG, false);

            parameter.Add(ImageParameters.WIDTH, 1024);
            parameter.Add(ImageParameters.HEIGHT, 768);
            parameter.Add(ImageParameters.SCALE, 2.0f);

            // Conversion
            ImageManager image = new ImageManager(VIZPub2D_Path);
            bool result = image.Export(parameter);
        }
    }
}
