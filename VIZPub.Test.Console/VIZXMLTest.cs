using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub.Test.Console
{
    public class VIZXMLTest
    {
        public VIZXMLTest()
        {
            
        }

        public void Test()
        {
            CreateVIZXML_Case1();
            CreateVIZXML_Case2();
            CreateVIZXML_Case3();
            CreateVIZXML_Case4();
            CreateVIZXML_Case5();
            CreateVIZXML_Case6();
            CreateVIZXML_Case7();
        }

        public void CreateVIZXML_Case1()
        {
            VIZPub.VIZXMLManager vizxml = new VIZXMLManager("Root");

            vizxml.Add(new VIZXMLNode("NODE A"));
            vizxml.Add(new VIZXMLNode("NODE B"));
            vizxml.Add(new VIZXMLNode("NODE C"));

            vizxml.Export("C:\\Temp\\VIZXML_Case1.vizxml");
        }

        public void CreateVIZXML_Case2()
        {
            VIZPub.VIZXMLManager vizxml = new VIZXMLManager("Root");

            VIZXMLNode aNode = new VIZXMLNode("NODE A");
            aNode.Nodes.Add(new VIZXMLNode("NODE A-1"));
            aNode.Nodes.Add(new VIZXMLNode("NODE A-2"));
            aNode.Nodes.Add(new VIZXMLNode("NODE A-3"));

            vizxml.Add(aNode);
            vizxml.Add(new VIZXMLNode("NODE B"));
            vizxml.Add(new VIZXMLNode("NODE C"));

            vizxml.Export("C:\\Temp\\VIZXML_Case2.vizxml");
        }

        public void CreateVIZXML_Case3()
        {
            VIZPub.VIZXMLManager vizxml = new VIZXMLManager("Root");

            VIZXMLNode aNode = new VIZXMLNode("NODE A");
            aNode.Nodes.Add(new VIZXMLNode("NODE A-1", "C:\\Temp\\Model_A.viz"));

            VIZXMLNode bNode = new VIZXMLNode("NODE B");
            bNode.Nodes.Add(new VIZXMLNode("NODE B-1", "C:\\Temp\\Model_B.viz"));

            VIZXMLNode cNode = new VIZXMLNode("NODE C");
            cNode.Nodes.Add(new VIZXMLNode("NODE C-1", "C:\\Temp\\Model_C.viz"));

            VIZXMLNode dNode = new VIZXMLNode("NODE D");
            dNode.Nodes.Add(new VIZXMLNode("NODE D-1", "C:\\Temp\\Model_D.viz"));

            vizxml.Add(aNode);
            vizxml.Add(bNode);
            vizxml.Add(cNode);
            vizxml.Add(dNode);

            vizxml.Export("C:\\Temp\\VIZXML_Case3.vizxml");
        }

        public void CreateVIZXML_Case4()
        {
            VIZPub.VIZXMLManager vizxml = new VIZXMLManager("Root");

            VIZXMLNode aNode = new VIZXMLNode("NODE A");
            aNode.Nodes.Add(new VIZXMLNode("NODE A-1", "C:\\Temp\\Model_A.viz", VIZXMLNodeType.Part));

            VIZXMLNode bNode = new VIZXMLNode("NODE B");
            bNode.Nodes.Add(new VIZXMLNode("NODE B-1", "C:\\Temp\\Model_B.viz", VIZXMLNodeType.Part));

            VIZXMLNode cNode = new VIZXMLNode("NODE C");
            cNode.Nodes.Add(new VIZXMLNode("NODE C-1", "C:\\Temp\\Model_C.viz", VIZXMLNodeType.Part));

            VIZXMLNode dNode = new VIZXMLNode("NODE D");
            dNode.Nodes.Add(new VIZXMLNode("NODE D-1", "C:\\Temp\\Model_D.viz", VIZXMLNodeType.Part));

            vizxml.Add(aNode);
            vizxml.Add(bNode);
            vizxml.Add(cNode);
            vizxml.Add(dNode);

            vizxml.Export("C:\\Temp\\VIZXML_Case4.vizxml");
        }

        public void CreateVIZXML_Case5()
        {
            VIZPub.VIZXMLManager vizxml = new VIZXMLManager("Root");

            VIZXMLNode aNode = new VIZXMLNode("NODE A");
            aNode.Nodes.Add(new VIZXMLNode("NODE A-1", "C:\\Temp\\Model_A.viz", "ROOT\\BLOCK\\NODE_A_1", VIZXMLNodeType.Assembly));

            VIZXMLNode bNode = new VIZXMLNode("NODE B");
            bNode.Nodes.Add(new VIZXMLNode("NODE B-1", "C:\\Temp\\Model_B.viz", "ROOT\\BLOCK\\NODE_A_2", VIZXMLNodeType.Assembly));

            VIZXMLNode cNode = new VIZXMLNode("NODE C");
            cNode.Nodes.Add(new VIZXMLNode("NODE C-1", "C:\\Temp\\Model_C.viz", "ROOT\\BLOCK\\NODE_A_3", VIZXMLNodeType.Assembly));

            VIZXMLNode dNode = new VIZXMLNode("NODE D");
            dNode.Nodes.Add(new VIZXMLNode("NODE D-1", "C:\\Temp\\Model_D.viz", "ROOT\\BLOCK\\NODE_A_4", VIZXMLNodeType.Assembly));

            vizxml.Add(aNode);
            vizxml.Add(bNode);
            vizxml.Add(cNode);
            vizxml.Add(dNode);

            vizxml.Export("C:\\Temp\\VIZXML_Case5.vizxml");
        }

        public void CreateVIZXML_Case6()
        {
            VIZPub.VIZXMLManager vizxml = new VIZXMLManager("Root");

            VIZXMLNode assyA = new VIZXMLNode("NODE A");
            VIZXMLNode partA = new VIZXMLNode("NODE A-1", VIZXMLNodeType.Part);
            VIZXMLNode bodyA = new VIZXMLNode("NODE A-1-1", "C:\\Temp\\Model.viz", 2, VIZXMLNodeType.Body);
            assyA.Nodes.Add(partA);
            partA.Nodes.Add(bodyA);

            VIZXMLNode assyB = new VIZXMLNode("NODE B");
            VIZXMLNode partB = new VIZXMLNode("NODE B-1", VIZXMLNodeType.Part);
            VIZXMLNode bodyB = new VIZXMLNode("NODE B-1-1", "C:\\Temp\\Model.viz", 12, VIZXMLNodeType.Body);
            assyB.Nodes.Add(partB);
            partB.Nodes.Add(bodyB);

            VIZXMLNode assyC = new VIZXMLNode("NODE C");
            VIZXMLNode partC = new VIZXMLNode("NODE C-1", VIZXMLNodeType.Part);
            VIZXMLNode bodyC = new VIZXMLNode("NODE C-1-1", "C:\\Temp\\Model.viz", 20, VIZXMLNodeType.Body);
            assyC.Nodes.Add(partC);
            partC.Nodes.Add(bodyC);


            vizxml.Add(assyA);
            vizxml.Add(assyB);
            vizxml.Add(assyC);

            vizxml.Export("C:\\Temp\\VIZXML_Case6.vizxml");
        }

        public void CreateVIZXML_Case7()
        {
            VIZPub.VIZXMLManager vizxml = new VIZXMLManager("Root");

            VIZXMLNode aNode = new VIZXMLNode("NODE A");
            aNode.Nodes.Add(new VIZXMLNode("NODE A-1", "C:\\Temp\\Model_A.viz", new float[] { 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0 }));

            VIZXMLNode bNode = new VIZXMLNode("NODE B");
            bNode.Nodes.Add(new VIZXMLNode("NODE B-1", "C:\\Temp\\Model_B.viz", new float[] { 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 110 }));

            VIZXMLNode cNode = new VIZXMLNode("NODE C");
            cNode.Nodes.Add(new VIZXMLNode("NODE C-1", "C:\\Temp\\Model_C.viz", new float[] { 1, 0, 0, 0, 0.707106781186548f, -0.707106781186548f, 0, 0.707106781186548f, 0.707106781186548f, 0, 0, 0 }));

            VIZXMLNode dNode = new VIZXMLNode("NODE D");
            dNode.Nodes.Add(new VIZXMLNode("NODE D-1", "C:\\Temp\\Model_D.viz", new float[] { 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0 }));

            vizxml.Add(aNode);
            vizxml.Add(bNode);
            vizxml.Add(cNode);
            vizxml.Add(dNode);

            vizxml.Export("C:\\Temp\\VIZXML_Case7.vizxml");
        }
    }
}
