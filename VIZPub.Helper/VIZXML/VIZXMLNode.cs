using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub
{
    /// <summary>
    /// VIZXML Node Class
    /// </summary>
    public class VIZXMLNode
    {
        // ================================================
        // Attribute & Property
        // ================================================
        /// <summary>
        /// Node Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Node Kind
        /// </summary>
        internal VIZXMLNodeKind Kind { get; set; }

        /// <summary>
        /// VIZ File Path
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// VIZ File Node Path
        /// </summary>
        public string NodePath { get; set; }

        /// <summary>
        /// Node Type - Assembly / Part
        /// </summary>
        public VIZXMLNodeType TypeNode { get; set; }

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
        /// <param name="name">Node Name</param>
        public VIZXMLNode(string name)
        {
            Name = name;

            Kind = VIZXMLNodeKind.Node;
            TypeNode = VIZXMLNodeType.Assembly;

            Nodes = new List<VIZXMLNode>();
        }

        /// <summary>
        /// Construction
        /// </summary>
        /// <param name="name">Node Name</param>
        /// <param name="path">VIZ File Path</param>
        public VIZXMLNode(string name, string path)
        {
            Name = name;
            Path = path;

            Kind = VIZXMLNodeKind.LinkFile;
            TypeNode = VIZXMLNodeType.Assembly;

            Nodes = new List<VIZXMLNode>();
        }

        /// <summary>
        /// Construction
        /// </summary>
        /// <param name="name">Node Name</param>
        /// <param name="path">VIZ File Path</param>
        /// <param name="node">Node Path</param>
        public VIZXMLNode(string name, string path, string node)
        {
            Name = name;
            Path = path;
            NodePath = node;

            Kind = VIZXMLNodeKind.LinkNode;
            TypeNode = VIZXMLNodeType.Assembly;

            Nodes = new List<VIZXMLNode>();
        }

        /// <summary>
        /// Construction
        /// </summary>
        /// <param name="name">Node Name</param>
        /// <param name="path">VIZ File Path</param>
        /// <param name="node">Node Path</param>
        /// <param name="type">Type Node</param>
        public VIZXMLNode(string name, string path, string node, VIZXMLNodeType type)
        {
            Name = name;
            Path = path;
            NodePath = node;

            Kind = VIZXMLNodeKind.LinkNode;
            TypeNode = type;

            Nodes = new List<VIZXMLNode>();
        }

        // ================================================
        // Function
        // ================================================



        // ================================================
        // Method
        // ================================================
        /// <summary>
        /// To VIZXML String
        /// </summary>
        /// <returns>VIZXML String</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if(Kind == VIZXMLNodeKind.Node)
            {
                if (Nodes.Count == 0)
                {
                    sb.AppendLine(string.Format("<Node Name=\"{0}\" />", Name));
                }
                else
                {
                    sb.AppendLine(string.Format("<Node Name=\"{0}\">", Name));

                    for (int i = 0; i < Nodes.Count; i++)
                    {
                        sb.AppendLine(Nodes[i].ToString());
                    }

                    sb.AppendLine("</Node>");
                }
            }
            else if(Kind == VIZXMLNodeKind.LinkFile)
            {
                sb.AppendLine(string.Format("<Node Name=\"{0}\" ExtLinkFile=\"{1}\" HideAndLock=\"False\" Type=\"Assembly\" />", Name, Path));
            }
            else if(Kind == VIZXMLNodeKind.LinkNode)
            {
                sb.AppendLine(string.Format("<Node Name=\"{0}\" ExtLinkNode=\"{1}:{2}\" HideAndLock=\"False\" Type=\"{3}\" />", Name, Path, NodePath, TypeNode == VIZXMLNodeType.Assembly ? "Assembly" : "Part"));
            }

            return sb.ToString();
        }
    }
}
