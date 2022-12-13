using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub
{
    /// <summary>
    /// Node Class
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Node Kind
        /// </summary>
        public enum NodeKind
        {
            /// <summary>
            /// ASSEMBLY
            /// </summary>
            ASSEMBLY = 500,

            /// <summary>
            /// PART
            /// </summary>
            PART = 501,

            /// <summary>
            /// BODY
            /// </summary>
            BODY = 507
        }

        // ================================================
        // Attribute & Property
        // ================================================
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Parent ID
        /// </summary>
        public int PARENTID { get; set; }

        /// <summary>
        /// Kind
        /// </summary>
        public NodeKind Kind { get; set; }

        /// <summary>
        /// Bouding Box - Min. X
        /// </summary>
        public float BoundBoxMinX { get; set; }

        /// <summary>
        /// Bouding Box - Min. Y
        /// </summary>
        public float BoundBoxMinY { get; set; }

        /// <summary>
        /// Bouding Box - Min. Z
        /// </summary>
        public float BoundBoxMinZ { get; set; }

        /// <summary>
        /// Bouding Box - Max. X
        /// </summary>
        public float BoundBoxMaxX { get; set; }

        /// <summary>
        /// Bouding Box - Max. Y
        /// </summary>
        public float BoundBoxMaxY { get; set; }

        /// <summary>
        /// Bouding Box - Max. Z
        /// </summary>
        public float BoundBoxMaxZ { get; set; }

        /// <summary>
        /// Depth
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Node Cache : ID -> Node Object
        /// </summary>
        public Dictionary<int, Node> NodeCache { get; set; }

        /// <summary>
        /// Node Relation : PID -> Children Object
        /// </summary>
        public Dictionary<int, List<Node>> Relation { get; set; }

        /// <summary>
        /// Node Path
        /// </summary>
        public string NodePath
        {
            get
            {
                if (NodeCache.ContainsKey(PARENTID) == false) return String.Empty;

                Node parent = NodeCache[PARENTID];
                return string.Format("{0}\\{1}", parent.NodePath, Name);
            }
        }

        // ================================================
        // Construction
        // ================================================
        /// <summary>
        /// Construction
        /// </summary>
        public Node()
        {

        }

        internal Node(string raw, Dictionary<int, Node> cache, Dictionary<int, List<Node>> relation)
        {
            NodeCache = cache;
            Relation = relation;

            string[] separatingChars = { "<<,>>" };
            string[] items = raw.Split(separatingChars, StringSplitOptions.None);

            ID = Convert.ToInt32(items[0]);
            PARENTID = Convert.ToInt32(items[1]);
            Kind = (NodeKind)Convert.ToInt32(items[2]);

            if (NodeCache.ContainsKey(ID) == false)
                NodeCache.Add(ID, this);

            if (Relation.ContainsKey(PARENTID) == false)
            {
                Relation.Add(PARENTID, new List<Node>(){ this });
            }
            else
            {
                Relation[PARENTID].Add(this);
            }

            BoundBoxMinX = Convert.ToSingle(items[3]);
            BoundBoxMinY = Convert.ToSingle(items[4]);
            BoundBoxMinZ = Convert.ToSingle(items[5]);
            BoundBoxMaxX = Convert.ToSingle(items[6]);
            BoundBoxMaxY = Convert.ToSingle(items[7]);
            BoundBoxMaxZ = Convert.ToSingle(items[8]);

            if (BoundBoxMinX == 340282346638528859811704183484516925440.000000)
            {
                BoundBoxMinX = 0.0f;
            }

            if (BoundBoxMinY == 340282346638528859811704183484516925440.000000)
            {
                BoundBoxMinY = 0.0f;
            }

            if (BoundBoxMinZ == 340282346638528859811704183484516925440.000000)
            {
                BoundBoxMinZ = 0.0f;
            }

            if (BoundBoxMaxX == -340282346638528859811704183484516925440.000000)
            {
                BoundBoxMaxX = 0.0f;
            }

            if (BoundBoxMaxY == -340282346638528859811704183484516925440.000000)
            {
                BoundBoxMaxY = 0.0f;
            }

            if (BoundBoxMaxZ == -340282346638528859811704183484516925440.000000)
            {
                BoundBoxMaxZ = 0.0f;
            }

            Depth = Convert.ToInt32(items[10]);

            if (items.Length == 13)
                Name = items[12];

            /*
            if (String.IsNullOrEmpty(Name) == true)
                Name = "(NONAME)";
            */
        }


        // ================================================
        // Function
        // ================================================
        internal string GetDepthString()
        {
            string str = String.Empty;

            for (int i = 0; i < Depth; i++)
            {
                str += "\t";
            }

            return str;
        }

        internal VIZXMLNodeType GetVIZXMLNodeKind()
        {
            VIZXMLNodeType kind = VIZXMLNodeType.Assembly;

            switch (Kind)
            {
                case NodeKind.ASSEMBLY:
                    kind = VIZXMLNodeType.Assembly;
                    break;
                case NodeKind.PART:
                    kind = VIZXMLNodeType.Part;
                    break;
                case NodeKind.BODY:
                    kind = VIZXMLNodeType.Body;
                    break;
                default:
                    break;
            }


            return kind;
        }


        // ================================================
        // Method
        // ================================================
        /// <summary>
        /// Get VIZXML Node String
        /// </summary>
        /// <param name="leafKind">Leaf Node Kind</param>
        /// <param name="modelPath">Base Model Path</param>
        /// <returns>VIZXML Node String</returns>
        public string GetVIZXMLNodeString(NodeKind leafKind, string modelPath)
        {
            StringBuilder sb = new StringBuilder();

            if (leafKind == NodeKind.PART && Kind == NodeKind.BODY) return String.Empty;

            // Has Children
            if (Relation.ContainsKey(ID) == true)
            {
                if (Kind == leafKind)
                {
                    sb.Append(string.Format("{0}<Node Name=\"{1}\" Type=\"{2}\" HideAndLock=\"False\" ExtLinkFile=\"{3}\\{4}.viz\" />", GetDepthString(), Name, GetVIZXMLNodeKind(), modelPath, ID));
                }
                else
                {
                    sb.AppendLine(string.Format("{0}<Node Name=\"{1}\" Type=\"{2}\">", GetDepthString(), Name, GetVIZXMLNodeKind()));

                    List<Node> children = Relation[ID];

                    for (int i = 0; i < children.Count; i++)
                    {
                        Node child = children[i];

                        string childNode = child.GetVIZXMLNodeString(leafKind, modelPath);

                        if (String.IsNullOrEmpty(childNode) == false)
                            sb.AppendLine(childNode);
                    }

                    sb.Append(string.Format("{0}</Node>", GetDepthString()));
                }
            }
            else // Leaf Node
            {
                if (leafKind == NodeKind.PART && Kind == NodeKind.PART)
                {
                    sb.Append(string.Format("{0}<Node Name=\"{1}\" Type=\"{2}\" HideAndLock=\"False\" ExtLinkFile=\"{3}\\{4}.viz\" />", GetDepthString(), Name, GetVIZXMLNodeKind(), modelPath, ID));
                }
                else if(leafKind == NodeKind.BODY && Kind == NodeKind.BODY)
                {
                    sb.Append(string.Format("{0}<Node Name=\"{1}\" Type=\"{2}\" HideAndLock=\"False\" ExtLinkFile=\"{3}\\{4}.viz\" />", GetDepthString(), Name, GetVIZXMLNodeKind(), modelPath, ID));
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Get Node String Format
        /// </summary>
        /// <returns>Node String</returns>
        public string GetString()
        {
            return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}"
                , ID
                , PARENTID
                , (int)Kind
                , BoundBoxMinX
                , BoundBoxMinY
                , BoundBoxMinZ
                , BoundBoxMaxX
                , BoundBoxMaxY
                , BoundBoxMaxZ
                , Depth
                , Name
                , NodePath
                );
        }
    }
}
