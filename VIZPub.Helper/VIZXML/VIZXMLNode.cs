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

        /// <summary>
        /// Matrix
        /// </summary>
        public float[] Matrix { get; set; }


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
        /// <param name="type">Type Node</param>
        public VIZXMLNode(string name, VIZXMLNodeType type)
        {
            Name = name;

            Kind = VIZXMLNodeKind.Node;
            TypeNode = type;

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
        /// <param name="matrix">Matrix</param>
        public VIZXMLNode(string name, string path, float[] matrix)
        {
            Name = name;
            Path = path;

            Kind = VIZXMLNodeKind.LinkFile;
            TypeNode = VIZXMLNodeType.Assembly;

            Nodes = new List<VIZXMLNode>();

            Matrix = matrix;
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
        /// <param name="type">Type Node</param>
        /// <param name="matrix">Matrix</param>
        public VIZXMLNode(string name, string path, VIZXMLNodeType type, float[] matrix)
        {
            Name = name;
            Path = path;

            Kind = VIZXMLNodeKind.LinkFile;
            TypeNode = type;

            Nodes = new List<VIZXMLNode>();

            Matrix = matrix;
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
        /// <param name="matrix">Matrix</param>
        public VIZXMLNode(string name, string path, string node, float[] matrix)
        {
            Name = name;
            Path = path;
            NodePath = node;

            Kind = VIZXMLNodeKind.LinkNode;
            TypeNode = VIZXMLNodeType.Assembly;

            Nodes = new List<VIZXMLNode>();

            Matrix = matrix;
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
        /// <param name="node">Node Path</param>
        /// <param name="type">Type Node</param>
        /// <param name="matrix">Matrix</param>
        public VIZXMLNode(string name, string path, string node, VIZXMLNodeType type, float[] matrix)
        {
            Name = name;
            Path = path;
            NodePath = node;

            Kind = VIZXMLNodeKind.LinkNode;
            TypeNode = type;

            Nodes = new List<VIZXMLNode>();

            Matrix = matrix;
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

        /// <summary>
        /// Construction
        /// </summary>
        /// <param name="name">Node Name</param>
        /// <param name="path">VIZ File Path</param>
        /// <param name="id">Node Id</param>
        /// <param name="type">Type Node</param>
        /// <param name="matrix">Matrix</param>
        public VIZXMLNode(string name, string path, int id, VIZXMLNodeType type, float[] matrix)
        {
            Name = name;
            Path = path;
            NodeId = id.ToString();

            Kind = VIZXMLNodeKind.LinkId;
            TypeNode = type;

            Nodes = new List<VIZXMLNode>();

            Matrix = matrix;
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

        internal string GetMatrixString()
        {
            if (Matrix == null || Matrix.Length == 0) return String.Empty;

            return string.Format("V1=\"{0}\" V2=\"{1}\" V3=\"{2}\" V4=\"{3}\" V5=\"{4}\" V6=\"{5}\" V7=\"{6}\" V8=\"{7}\" V9=\"{8}\" T1=\"{9}\" T2=\"{10}\" T3=\"{11}\""
                , Matrix[0]
                , Matrix[1]
                , Matrix[2]
                , Matrix[3]
                , Matrix[4]
                , Matrix[5]
                , Matrix[6]
                , Matrix[7]
                , Matrix[8]
                , Matrix[9]     /* TRANSLATION X */
                , Matrix[10]    /* TRANSLATION Y */
                , Matrix[11]    /* TRANSLATION Z */
                );
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
            string matrixString = GetMatrixString();

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
                            sb.AppendLine(string.Format("{0}<Node Name=\"{1}\" Type=\"{2}\" >", depthString, Name, TypeNode.ToString()));

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
                        sb.AppendLine(string.Format("{0}<Node Name=\"{1}\" ExtLinkFile=\"{2}\" HideAndLock=\"False\" Type=\"{3}\" {4} />", depthString, Name, Path, TypeNode.ToString(), matrixString)); // Assembly or Part
                    }
                    break;
                case VIZXMLNodeKind.LinkNode:
                    {
                        sb.AppendLine(string.Format("{0}<Node Name=\"{1}\" ExtLinkNode=\"{2}:{3}\" HideAndLock=\"False\" Type=\"{4}\" {5} />", depthString, Name, Path, NodePath, TypeNode.ToString(), matrixString));
                    }
                    break;
                case VIZXMLNodeKind.LinkId:
                    {
                        sb.AppendLine(string.Format("{0}<Node Name=\"{1}\" ExtLinkId=\"{2}:{3}\" HideAndLock=\"False\" Type=\"{4}\" {5} />", depthString, Name, Path, NodeId, TypeNode.ToString(), matrixString));
                    }
                    break;
                default:
                    break;
            }

            return sb.ToString();
        }
    }
}
