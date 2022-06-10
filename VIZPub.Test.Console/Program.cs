using System;
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
            test_VIZPub.Test();

            // ================================================
            // VIZCoreTrans
            // ================================================
            VIZCoreTransTest test_VIZCoreTrans = new VIZCoreTransTest();
            test_VIZCoreTrans.Test();

            // ================================================
            // VIZXML
            // ================================================
            VIZXMLTest test_VIZXML = new VIZXMLTest();
            test_VIZXML.Test();
        }
    }
}
