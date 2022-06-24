using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub
{
    /// <summary>
    /// Bound Box Manager Class
    /// </summary>
    public class BoundBoxManager
    {
        /// <summary>
        /// Construction
        /// </summary>
        public BoundBoxManager()
        {

        }

        /// <summary>
        /// Export
        /// </summary>
        /// <param name="path">Path</param>
        /// <param name="items">Bound Box</param>
        public void Export(string path, List<BoundBoxItem> items)
        {
            if (String.IsNullOrEmpty(path) == true) return;
            if (System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(path)) == false)
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path));

            try
            {
                using (System.IO.StreamWriter sw = new System.IO.StreamWriter(path, false, Encoding.UTF8))
                {
                    sw.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
                    sw.WriteLine("<Spaces>");

                    foreach (BoundBoxItem item in items)
                    {
                        sw.WriteLine(string.Format("\t<Box KeepStructure=\"{0}\" Path=\"{1}\">", item.KeepStructure == true ? 1 : 0, item.Path));

                        sw.WriteLine(string.Format("\t\t<Minimum X=\"{0}\" Y=\"{1}\" Z=\"{2}\" />", item.MinX, item.MinY, item.MinZ));
                        sw.WriteLine(string.Format("\t\t<Maximum X=\"{0}\" Y=\"{1}\" Z=\"{2}\" />", item.MaxX, item.MaxY, item.MaxZ));

                        sw.WriteLine("\t</Box>");
                    }

                    sw.WriteLine("</Spaces>");

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
