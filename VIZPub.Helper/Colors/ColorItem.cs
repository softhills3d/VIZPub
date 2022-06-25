using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub
{
    /// <summary>
    /// Color Item Class
    /// </summary>
    public class ColorItem
    {
        /// <summary>
        /// Node Id
        /// </summary>
        public int NodeId { get; set; }

        /// <summary>
        /// Node Color
        /// </summary>
        public System.Drawing.Color NodeColor { get; set; }

        /// <summary>
        /// Construction
        /// </summary>
        public ColorItem()
        {

        }

        /// <summary>
        /// Construction
        /// </summary>
        /// <param name="id">Node Id</param>
        /// <param name="color">Node Color</param>
        public ColorItem(int id, System.Drawing.Color color)
        {
            NodeId = id;
            NodeColor = color;
        }
    }
}
