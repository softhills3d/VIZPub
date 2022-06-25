using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub
{
    /// <summary>
    /// Color Manager
    /// </summary>
    public class ColorManager
    {
        /// <summary>
        /// Construction
        /// </summary>
        public ColorManager()
        {

        }

        /// <summary>
        /// Export
        /// </summary>
        /// <param name="path">Path</param>
        /// <param name="items">Color Items</param>
        /// <returns></returns>
        public void Export(string path, List<ColorItem> items)
        {
            if (String.IsNullOrEmpty(path) == true) return;
            if (System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(path)) == false)
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path));

            try
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(path, false, Encoding.UTF8))
                {
                    sw.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                    sw.WriteLine("<Colors>");

                    foreach (ColorItem item in items)
                    {
                        sw.WriteLine(string.Format("\t<Color NodeId=\"{0}\" R=\"{1}\" G=\"{2}\" B=\"{3}\" A=\"{4}\" />", item.NodeId, item.NodeColor.R, item.NodeColor.G, item.NodeColor.B, item.NodeColor.A));
                    }

                    sw.WriteLine("</Colors>");

                    sw.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
