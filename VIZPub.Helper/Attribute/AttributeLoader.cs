using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub
{
    /// <summary>
    /// Attribute Reader Class
    /// </summary>
    public class AttributeLoader
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
        public AttributeLoader()
        {
        }

        // ================================================
        // Method
        // ================================================
        /// <summary>
        /// Load Attribute
        /// </summary>
        /// <param name="path">Attribute File Path</param>
        /// <param name="attribute">Attribute Data</param>
        /// <returns>Result</returns>
        public bool Load(string path, out Dictionary<int, List<AttributeItem>> attribute)
        {
            attribute = new Dictionary<int, List<AttributeItem>>();

            Path = path;

            if (String.IsNullOrEmpty(path) == true) return false;
            if (System.IO.File.Exists(path) == false) return false;

            try
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(Path, Encoding.Default);

                while (sr.EndOfStream == false)
                {
                    string item = sr.ReadLine();
                    if (String.IsNullOrEmpty(item) == true) continue;

                    AttributeItem attributeItem = new AttributeItem(item);
                    if (attributeItem.HasValue() == false) continue;

                    if (attribute.ContainsKey(attributeItem.NodeID) == false)
                    {
                        attribute.Add(attributeItem.NodeID, new List<AttributeItem>() { attributeItem });
                    }
                    else
                    {
                        List<AttributeItem> items = attribute[attributeItem.NodeID];
                        items.Add(attributeItem);
                        attribute[attributeItem.NodeID] = items;
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
