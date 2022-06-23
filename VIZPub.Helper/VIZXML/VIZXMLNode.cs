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
        /// VIZ Node ID
        /// </summary>
        public string NodeId { get; set; }

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
        /// <param name="type">Type Node</param>
        public VIZXMLNode(string name, string path, VIZXMLNodeType type)
        {
            Name = name;
            Path = path;

            Kind = VIZXMLNodeKind.LinkFile;
            TypeNode = type;

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

        /// <summary>
        /// Construction
        /// </summary>
        /// <param name="name">Node Name</param>
        /// <param name="path">VIZ File Path</param>
        /// <param name="id">Node Id</param>
        /// <param name="type">Type Node</param>
        public VIZXMLNode(string name, string path, int id, VIZXMLNodeType type)
        {
            Name = name;
            Path = path;
            NodeId = id.ToString();

            Kind = VIZXMLNodeKind.LinkId;
            TypeNode = type;

            Nodes = new List<VIZXMLNode>();
        }

        // ================================================
        // Function
        // ================================================
        internal string GetDepthString(int depth)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < depth; i++)
            {
                sb.Append("\t");
            }

            return sb.ToString();
        }


        // ================================================
        // Method
        // ================================================
        /// <summary>
        /// To VIZXML String
        /// </summary>
        /// <param name="depth">Depth</param>
        /// <returns>VIZXML String</returns>
        public string ToString(int depth = 1)
        {
            StringBuilder sb = new StringBuilder();

            string depthString = GetDepthString(depth);

            switch (Kind)
            {
                case VIZXMLNodeKind.Node:
                    {
                        if (Nodes.Count == 0)
                        {
                            sb.AppendLine(string.Format("{0}<Node Name=\"{1}\" />", depthString, Name));
                        }
                        else
                        {
                            sb.AppendLine(string.Format("{0}<Node Name=\"{1}\">", depthString, Name));

                            for (int i = 0; i < Nodes.Count; i++)
                            {
                                sb.Append(Nodes[i].ToString(++depth));
                            }

                            sb.AppendLine(string.Format("{0}</Node>", depthString));
                        }
                    }
                    break;
                case VIZXMLNodeKind.LinkFile:
                    {
                        sb.AppendLine(string.Format("{0}<Node Name=\"{1}\" ExtLinkFile=\"{2}\" HideAndLock=\"False\" Type=\"{3}\" />", depthString, Name, Path, TypeNode.ToString()));
                    }
                    break;
                case VIZXMLNodeKind.LinkNode:
                    {
                        sb.AppendLine(string.Format("{0}<Node Name=\"{1}\" ExtLinkNode=\"{2}:{3}\" HideAndLock=\"False\" Type=\"{4}\" />", depthString, Name, Path, NodePath, TypeNode.ToString()));
                    }
                    break;
                case VIZXMLNodeKind.LinkId:
                    {
                        sb.AppendLine(string.Format("{0}<Node Name=\"{1}\" ExtLinkId=\"{2}:{3}\" HideAndLock=\"False\" Type=\"{4}\" />", depthString, Name, Path, NodeId, TypeNode.ToString()));
                    }
                    break;
                default:
                    break;
            }

            return sb.ToString();
        }
    }
}
