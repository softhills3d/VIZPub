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

        internal Dictionary<string, string> IKeys { get; set; }
        internal Dictionary<string, Dictionary<string, List<AttributeItem>>> IValue { get; set; }

        


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

            IKeys = new Dictionary<string, string>();
            IValue = new Dictionary<string, Dictionary<string, List<AttributeItem>>>();

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

                    // Keys
                    if (IKeys.ContainsKey(attributeItem.Key) == false)
                        IKeys.Add(attributeItem.Key, attributeItem.Key);

                    // Values
                    if (IValue.ContainsKey(attributeItem.Key) == false)
                    {
                        Dictionary<string, List<AttributeItem>> iVals = new Dictionary<string, List<AttributeItem>>();
                        iVals.Add(attributeItem.Value, new List<AttributeItem>() { attributeItem });

                        IValue.Add(attributeItem.Key, iVals);
                    }
                    else
                    {
                        Dictionary<string, List<AttributeItem>> iVals = IValue[attributeItem.Key];

                        if (iVals.ContainsKey(attributeItem.Value) == false)
                        {
                            iVals.Add(attributeItem.Value, new List<AttributeItem>() { attributeItem });
                            IValue[attributeItem.Key] = iVals;
                        }
                        else
                        {
                            List<AttributeItem> iItem = iVals[attributeItem.Value];
                            iItem.Add(attributeItem);
                            iVals[attributeItem.Value] = iItem;
                        }
                    }
                }

                sr.Close();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Get UDA Keys
        /// </summary>
        /// <returns>Keys</returns>
        public List<string> GetKeys()
        {
            return IKeys.Keys.ToList();
        }

        /// <summary>
        /// Get UDA Values
        /// </summary>
        /// <param name="key">UDA Key</param>
        /// <returns>Values</returns>
        public List<string> GetValues(string key)
        {
            if (IValue.ContainsKey(key) == true)
                return IValue[key].Keys.ToList();
            else
                return new List<string>();
        }

        /// <summary>
        /// Get Value Items
        /// </summary>
        /// <param name="key">UDA Key</param>
        /// <param name="value">UDA Value</param>
        /// <returns>Attribute Items</returns>
        public List<AttributeItem> GetValueItems(string key, string value)
        {
            if (IValue.ContainsKey(key) == false) return new List<AttributeItem>();
            Dictionary<string, List<AttributeItem>> values = IValue[key];

            if (values.ContainsKey(value) == false) return new List<AttributeItem>();

            return values[value];
        }
    }
}
