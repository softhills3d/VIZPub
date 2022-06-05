using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub
{
    /// <summary>
    /// Merge Item Manager Class
    /// </summary>
    public class MergeItemManager
    {
        // ================================================
        // Attribute & Property
        // ================================================
        internal Dictionary<string, MergeItem> Items { get; set; }

        // ================================================
        // Construction
        // ================================================
        /// <summary>
        /// Construction
        /// </summary>
        public MergeItemManager()
        {
            Items = new Dictionary<string, MergeItem>();
        }


        // ================================================
        // Method
        // ================================================
        /// <summary>
        /// Add Item
        /// </summary>
        /// <param name="item">Merge Item</param>
        public void Add(MergeItem item)
        {
            if (Items.ContainsKey(item.Path) == false)
            {
                Items.Add(item.Path, item);
            }
            else
            {
                MergeItem val = Items[item.Path];

                if (String.IsNullOrEmpty(item.NodeNameTag) == false)
                    val.NodeNameTag = item.NodeNameTag;

                if (item.NodeId.Count > 0)
                    val.AddNodeID(item.NodeId.Values.ToList());
            }
        }

        /// <summary>
        /// Export Metadata
        /// </summary>
        /// <param name="path">Metadata File Path</param>
        /// <returns>Result</returns>
        public bool Export(string path)
        {
            if (String.IsNullOrEmpty(path) == true) return false;
            if (Items.Count == 0) return false;

            System.IO.StreamWriter sw = new System.IO.StreamWriter(path, false, Encoding.Default);

            sw.WriteLine(Items.Count);  // Total Count

            foreach (KeyValuePair<string, MergeItem> item in Items)
            {
                sw.WriteLine(item.Key); // File Path

                if (String.IsNullOrEmpty(item.Value.NodeNameTag) == false)
                    sw.WriteLine(string.Format("({0})", item.Value.NodeNameTag));
                else
                    sw.WriteLine("NONE");

                if (item.Value.NodeId.Count == 0)
                {
                    sw.WriteLine("-1");
                }
                else
                {
                    sw.WriteLine(item.Value.NodeId.Count.ToString());

                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < item.Value.NodeId.Count; i++)
                    {
                        if (i != 0)
                        {
                            sb.Append(",");
                        }

                        sb.Append(item.Value.NodeId[i].ToString());
                    }

                    // Part List : ","
                    sw.WriteLine(sb.ToString());
                }
            }

            sw.Close();

            return true;
        }
    }
}
