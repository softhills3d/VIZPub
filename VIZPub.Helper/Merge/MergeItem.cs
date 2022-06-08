using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub
{
    /// <summary>
    /// Merge Item Class
    /// </summary>
    public class MergeItem
    {
        // ================================================
        // Attribute & Property
        // ================================================
        /// <summary>
        /// Path
        /// </summary>
        public string Path { get; set; }

        internal Dictionary<int, int> NodeId { get; set; }

        /// <summary>
        /// Node Name Tag
        /// </summary>
        public string NodeNameTag { get; set; }


        // ================================================
        // Construction
        // ================================================
        /// <summary>
        /// Construction
        /// </summary>
        public MergeItem()
        {
            NodeId = new Dictionary<int, int>();
        }

        /// <summary>
        /// Construction
        /// </summary>
        /// <param name="path">Path</param>
        public MergeItem(string path)
        {
            NodeId = new Dictionary<int, int>();

            Path = path;
        }

        /// <summary>
        /// Construction
        /// </summary>
        /// <param name="path">Path</param>
        /// <param name="tag">Node Name Tag</param>
        public MergeItem(string path, string tag)
        {
            NodeId = new Dictionary<int, int>();

            Path = path;
            NodeNameTag = tag;
        }

        /// <summary>
        /// Construction
        /// </summary>
        /// <param name="path">Path</param>
        /// <param name="id">Node ID</param>
        public MergeItem(string path, int[] id)
        {
            Path = path;

            NodeId = new Dictionary<int, int>();

            if (id != null && id.Length > 0)
            {
                foreach (int item in id)
                {
                    if (NodeId.ContainsKey(item) == false)
                        NodeId.Add(item, item);
                }
            }
        }

        /// <summary>
        /// Construction
        /// </summary>
        /// <param name="path">Path</param>
        /// <param name="id">Node ID</param>
        /// <param name="tag">Node Name Tag</param>
        public MergeItem(string path, int[] id, string tag)
        {
            Path = path;

            NodeNameTag = tag;

            NodeId = new Dictionary<int, int>();

            if (id != null && id.Length > 0)
            {
                foreach (int item in id)
                {
                    if (NodeId.ContainsKey(item) == false)
                        NodeId.Add(item, item);
                }
            }
        }


        // ================================================
        // Method
        // ================================================
        /// <summary>
        /// Add Node ID
        /// </summary>
        /// <param name="id">ID</param>
        public void AddNodeID(List<int> id)
        {
            foreach (int item in id)
            {
                if (NodeId.ContainsKey(item) == false)
                    NodeId.Add(item, item);
            }
        }
    }
}
