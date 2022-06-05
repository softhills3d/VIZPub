using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub
{
    /// <summary>
    /// Attribute Item Class
    /// </summary>
    public class AttributeItem
    {
        // ================================================
        // Attribute & Property
        // ================================================
        /// <summary>
        /// NODE ID
        /// </summary>
        public int NodeID { get; set; }

        /// <summary>
        /// Attribute Key (Name)
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Attribute Value
        /// </summary>
        public string Value { get; set; }


        // ================================================
        // Construction
        // ================================================
        /// <summary>
        /// Construction
        /// </summary>
        public AttributeItem()
        {

        }

        /// <summary>
        /// Construction
        /// </summary>
        /// <param name="raw">Raw String</param>
        public AttributeItem(string raw)
        {
            string[] separatingChars = { "<<,>>" };
            string[] items = raw.Split(separatingChars, StringSplitOptions.None);

            NodeID = Convert.ToInt32(items[0]);
            Key = items[1];
            Value = items[2];
        }

        /// <summary>
        /// Construction
        /// </summary>
        /// <param name="nodeId">Node ID</param>
        /// <param name="key">Attribute Key</param>
        /// <param name="value">Attribute Value</param>
        public AttributeItem(int nodeId, string key, string value)
        {
            NodeID = nodeId;
            Key = key;
            Value = value;
        }

        // ================================================
        // Method
        // ================================================
        /// <summary>
        /// To String
        /// </summary>
        /// <returns>String</returns>
        public override string ToString()
        {
            return String.Format("{0}<<,>>{1}<<,>>{2}", NodeID, Key, Value);
        }
    }
}
