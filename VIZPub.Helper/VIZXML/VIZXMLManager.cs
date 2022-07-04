using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub
{
    /// <summary>
    /// VIZXML Manager Class
    /// </summary>
    public class VIZXMLManager
    {
        // ================================================
        // Attribute & Property
        // ================================================
        /// <summary>
        /// Model Name
        /// </summary>
        public string ModelName { get; set; }
        /// <summary>
        /// Nodes
        /// </summary>
        public List<VIZXMLNode> Nodes { get; set; }

        // ================================================
        // Construction
        // ================================================
        /// <summary>
        /// Construction
        /// </summary>
        /// <param name="name">Model Name</param>
        public VIZXMLManager(string name)
        {
            ModelName = name;
            Nodes = new List<VIZXMLNode>();
        }

        // ================================================
        // Function
        // ================================================

        // ================================================
        // Method
        // ================================================
        /// <summary>
        /// Add Node
        /// </summary>
        /// <param name="node">VIZXML Node</param>
        public void Add(VIZXMLNode node)
        {
            Nodes.Add(node);
        }

        /// <summary>
        /// Export VIZXML
        /// </summary>
        /// <param name="path"></param>
        public void Export(string path)
        {
            if (String.IsNullOrEmpty(ModelName) == true) return;
            if (Nodes.Count == 0) return;

            try
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(path, false, Encoding.UTF8))
                {
                    sw.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                    sw.WriteLine("<VIZXML>");

                    sw.WriteLine(string.Format("<Model Name=\"{0}\" SkipBrokenLinks=\"False\">", ModelName));

                    for (int i = 0; i < Nodes.Count; i++)
                    {
                        string tag = Nodes[i].ToString();
                        if (String.IsNullOrEmpty(tag) == true) continue;
                        
                        sw.Write(tag);
                    }

                    sw.WriteLine("</Model>");
                    sw.Write("</VIZXML>");

                    sw.Close();
                }
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
