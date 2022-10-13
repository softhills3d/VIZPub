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

            Export_BackgroundColor();
            Export_SingleColor();
        }

        public void Export()
        {
            // Parameter
            VIZPub.ImageParameter parameter = new VIZPub.ImageParameter();

            parameter.Add(VIZPub.ImageParameters.INPUT, "C:\\Temp\\Drawing.dwg");
            parameter.Add(VIZPub.ImageParameters.OUTPUT, "C:\\Temp\\Drawing.png");

            // Conversion
            VIZPub.ImageManager image = new VIZPub.ImageManager(VIZPub2D_Path);
            bool result = image.Export(parameter);
        }

        

        public void Export_Size()
        {
            // Parameter
            VIZPub.ImageParameter parameter = new VIZPub.ImageParameter();

            parameter.Add(VIZPub.ImageParameters.INPUT, "C:\\Temp\\Drawing.dwg");
            parameter.Add(VIZPub.ImageParameters.OUTPUT, "C:\\Temp\\Drawing_Size.png");

            parameter.Add(VIZPub.ImageParameters.WIDTH, 15360);
            parameter.Add(VIZPub.ImageParameters.HEIGHT, 15360);

            // Conversion
            VIZPub.ImageManager image = new VIZPub.ImageManager(VIZPub2D_Path);
            bool result = image.Export(parameter);
        }

        public void Export_Scale()
        {
            // Parameter
            VIZPub.ImageParameter parameter = new VIZPub.ImageParameter();

            parameter.Add(VIZPub.ImageParameters.INPUT, "C:\\Temp\\Drawing.dwg");
            parameter.Add(VIZPub.ImageParameters.OUTPUT, "C:\\Temp\\Drawing_Scale.png");

            parameter.Add(VIZPub.ImageParameters.SCALE, 4.0f);

            // Conversion
            VIZPub.ImageManager image = new VIZPub.ImageManager(VIZPub2D_Path);
            bool result = image.Export(parameter);
        }

        public void Export_SizeScale()
        {
            // Parameter
            VIZPub.ImageParameter parameter = new VIZPub.ImageParameter();

            parameter.Add(VIZPub.ImageParameters.INPUT, "C:\\Temp\\Drawing.dwg");
            parameter.Add(VIZPub.ImageParameters.OUTPUT, "C:\\Temp\\Drawing_SizeScale.png");

            parameter.Add(VIZPub.ImageParameters.WIDTH, 15360);
            parameter.Add(VIZPub.ImageParameters.HEIGHT, 15360);
            parameter.Add(VIZPub.ImageParameters.SCALE, 1.0f);

            // Conversion
            VIZPub.ImageManager image = new VIZPub.ImageManager(VIZPub2D_Path);
            bool result = image.Export(parameter);
        }

        public void Export_BackgroundColor()
        {
            // Parameter
            VIZPub.ImageParameter parameter = new VIZPub.ImageParameter();

            parameter.Add(VIZPub.ImageParameters.INPUT, "C:\\Temp\\Drawing.dwg");
            parameter.Add(VIZPub.ImageParameters.OUTPUT, "C:\\Temp\\Drawing_BackgroundColor_Black.png");

            parameter.Add(VIZPub.ImageParameters.WIDTH, 15360);
            parameter.Add(VIZPub.ImageParameters.HEIGHT, 15360);
            parameter.Add(VIZPub.ImageParameters.SCALE, 1.0f);

            parameter.Add(VIZPub.ImageParameters.BACKGROUND_COLOR, System.Drawing.Color.Black);
            parameter.Add(VIZPub.ImageParameters.DRAW_TYPE, 1); // 0 (DrawColor), 1 (ObjectColor)

            // Conversion
            VIZPub.ImageManager image = new VIZPub.ImageManager(VIZPub2D_Path);
            bool result = image.Export(parameter);
        }

        public void Export_SingleColor()
        {
            // Parameter
            VIZPub.ImageParameter parameter = new VIZPub.ImageParameter();

            parameter.Add(VIZPub.ImageParameters.INPUT, "C:\\Temp\\Drawing.dwg");
            parameter.Add(VIZPub.ImageParameters.OUTPUT, "C:\\Temp\\Drawing_SingleColor.png");

            parameter.Add(VIZPub.ImageParameters.WIDTH, 15360);
            parameter.Add(VIZPub.ImageParameters.HEIGHT, 15360);
            parameter.Add(VIZPub.ImageParameters.SCALE, 1.0f);

            parameter.Add(VIZPub.ImageParameters.BACKGROUND_COLOR, System.Drawing.Color.White);
            parameter.Add(VIZPub.ImageParameters.DRAW_TYPE, 0); // 0 (DrawColor), 1 (ObjectColor)
            parameter.Add(VIZPub.ImageParameters.DRAW_COLOR, System.Drawing.Color.Black);

            // Conversion
            VIZPub.ImageManager image = new VIZPub.ImageManager(VIZPub2D_Path);
            bool result = image.Export(parameter);
        }
    }
}
