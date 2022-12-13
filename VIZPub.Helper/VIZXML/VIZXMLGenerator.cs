using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub
{
    /// <summary>
    /// VIZXML Generator
    /// </summary>
    public class VIZXMLGenerator
    {
        // ================================================
        // Attribute & Property
        // ================================================
        /// <summary>
        /// Metadata File Path
        /// </summary>
        public string MetadataPath { get; set; }

        /// <summary>
        /// Model File Path (Files : PartId.viz or BodyId.viz)
        /// </summary>
        public string ModelPath { get; set; }

        /// <summary>
        /// VIZXML Model Link Unit
        /// </summary>
        public VIZPub.Node.NodeKind ModelLinkUnit { get; set; }


        // ================================================
        // Construction
        // ================================================
        /// <summary>
        /// Construction
        /// </summary>
        public VIZXMLGenerator()
        {

        }

        /// <summary>
        /// Construction
        /// </summary>
        /// <param name="metadata">Metadata File Path</param>
        /// <param name="model">Model File Path (Files : PartId.viz or BodyId.viz)</param>
        /// <param name="linkUnit">VIZXML Model Link Unit</param>
        public VIZXMLGenerator(string metadata, string model, VIZPub.Node.NodeKind linkUnit = Node.NodeKind.PART)
        {
            MetadataPath = metadata;
            ModelPath = model;
            ModelLinkUnit = linkUnit;
        }


        // ================================================
        // Function
        // ================================================

        // ================================================
        // Method
        // ================================================
        /// <summary>
        /// Generate VIZXML
        /// </summary>
        /// <param name="path">Output VIZXML Path</param>
        /// <param name="deleteMetadata">Delete Metadata After Loading</param>
        /// <returns>Result</returns>
        public bool GenerateVIZXML(string path, bool deleteMetadata = false)
        {
            MetadataLoader loader = new MetadataLoader();
            List<Node> nodes = new List<Node>();
            bool result_load = loader.Load(MetadataPath, out nodes, deleteMetadata);

            if (result_load == false) return false;

            Node root = null;
            foreach (Node item in nodes)
            {
                if (item.PARENTID != -1) continue;
                root = item;
                break;
            }

            System.IO.StreamWriter sw = new System.IO.StreamWriter(path, false, Encoding.UTF8);

            sw.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            sw.WriteLine("<VIZXML>");

            sw.WriteLine(string.Format("<Model Name=\"{0}\" SkipBrokenLinks=\"False\">", root.Name));

            if (root.Relation.ContainsKey(root.ID) == true)
            {
                List<Node> children = root.Relation[root.ID];

                for (int i = 0; i < children.Count; i++)
                {
                    Node child = children[i];

                    string nodeStr = child.GetVIZXMLNodeString(ModelLinkUnit, ModelPath);

                    if (String.IsNullOrEmpty(nodeStr) == false)
                        sw.WriteLine(nodeStr);
                }
            }

            sw.WriteLine("</Model>");

            sw.WriteLine("</VIZXML>");

            sw.Close();

            return System.IO.File.Exists(path);
        }
    }
}
