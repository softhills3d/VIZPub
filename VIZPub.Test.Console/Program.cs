﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub.Test.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // ================================================
            // VIZPub
            // ================================================
            VIZPubTest test_VIZPub = new VIZPubTest();
            //test_VIZPub.Test();

            // ================================================
            // VIZCoreTrans
            // ================================================
            VIZCoreTransTest test_VIZCoreTrans = new VIZCoreTransTest();
            //test_VIZCoreTrans.Test();

            // ================================================
            // VIZXML
            // ================================================
            VIZXMLTest test_VIZXML = new VIZXMLTest();
            test_VIZXML.Test();

            // ================================================
            // ShxBomXmlGen
            // ================================================
            ShxBomXmlGenTest test_ShxBomXmlGen = new ShxBomXmlGenTest();
            //test_ShxBomXmlGen.Test();

            // ================================================
            // VIZPub 2D
            // ================================================
            VIZPub2DTest test_VIZPub2D = new VIZPub2DTest();
            //test_VIZPub2D.Test();

            // ================================================
            // VIZCoreTrans (InterOp)
            // ================================================
            VIZCoreTransIopTest test_VIZCoreTransIop = new VIZCoreTransIopTest();
            //test_VIZCoreTransIop.Test();
        }
    }
}
