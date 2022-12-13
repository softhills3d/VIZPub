using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub
{
    /// <summary>
    /// Metadata Reader Class
    /// </summary>
    public class MetadataLoader
    {
        // ================================================
        // Attribute & Property
        // ================================================
        internal string Path { get; set; }


        // ================================================
        // Construction
        // ================================================
        /// <summary>
        /// Construction
        /// </summary>
        public MetadataLoader()
        {
        }


        // ================================================
        // Method
        // ================================================
        /// <summary>
        /// Load Metadata
        /// </summary>
        /// <param name="path">Metadata File Path</param>
        /// <param name="items">Node Items</param>
        /// <param name="deleteMetadata">Delete Metadata After Loading</param>
        /// <returns>Result</returns>
        public bool Load(string path, out List<Node> items, bool deleteMetadata = false)
        {
            Path = path;
            items = new List<Node>();

            if (String.IsNullOrEmpty(Path) == true) return false;
            if (System.IO.File.Exists(Path) == false) return false;

            Dictionary<int, Node> nodeCache = new Dictionary<int, Node>();
            Dictionary<int, List<Node>> nodeRelation = new Dictionary<int, List<Node>>();

            bool result = false;

            try
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(Path, Encoding.UTF8);

                while (sr.EndOfStream == false)
                {
                    string item = sr.ReadLine();
                    if (String.IsNullOrEmpty(item) == true) continue;

                    Node node = new Node(item, nodeCache, nodeRelation);
                    items.Add(node);
                }

                sr.Close();

                result = true;
            }
            catch(Exception)
            {
                result = false;
            }

            if (deleteMetadata == true)
                System.IO.File.Delete(path);

            return result;
        }
    }
}
