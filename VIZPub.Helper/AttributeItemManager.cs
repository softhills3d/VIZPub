using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub
{
    /// <summary>
    /// Attribute Item Manager Class
    /// </summary>
    public class AttributeItemManager
    {
        // ================================================
        // Attribute & Property
        // ================================================


        // ================================================
        // Construction
        // ================================================
        /// <summary>
        /// Construction
        /// </summary>
        public AttributeItemManager()
        {

        }


        // ================================================
        // Method
        // ================================================
        /// <summary>
        /// Export Attribute Metadata
        /// </summary>
        /// <param name="path">Attribute Metadata Path</param>
        /// <param name="items">Attribute Metadata</param>
        /// <returns>Result</returns>
        public bool Export(string path, List<AttributeItem> items)
        {
            if (String.IsNullOrEmpty(path) == true) return false;
            if (items.Count == 0) return false;

            try
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(path, false, Encoding.Default);

                foreach (AttributeItem item in items)
                {
                    sw.WriteLine(item.ToString());
                }

                sw.Close();

                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
