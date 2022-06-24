using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub
{
    /// <summary>
    /// Bound Box Item Class
    /// </summary>
    public class BoundBoxItem
    {
        /// <summary>
        /// Min. X
        /// </summary>
        public int MinX { get; set; }
        /// <summary>
        /// Min. Y
        /// </summary>
        public int MinY { get; set; }
        /// <summary>
        /// Min. Z
        /// </summary>
        public int MinZ { get; set; }
        /// <summary>
        /// Max. X
        /// </summary>
        public int MaxX { get; set; }
        /// <summary>
        /// Max. Y
        /// </summary>
        public int MaxY { get; set; }
        /// <summary>
        /// Max. Z
        /// </summary>
        public int MaxZ { get; set; }

        /// <summary>
        /// Keep Structure
        /// </summary>
        public bool KeepStructure { get; set; }

        /// <summary>
        /// Output VIZ Path
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Construction
        /// </summary>
        public BoundBoxItem()
        {

        }

        /// <summary>
        /// Construction
        /// </summary>
        /// <param name="path">Output VIZ Path</param>
        /// <param name="keepStructure">Keep Structure</param>
        /// <param name="vals">Values</param>
        public BoundBoxItem(string path, bool keepStructure, int[] vals)
        {
            Path = path;
            KeepStructure = keepStructure;

            MinX = Math.Min(vals[0], vals[3]);
            MinY = Math.Min(vals[1], vals[4]);
            MinZ = Math.Min(vals[2], vals[5]);

            MaxX = Math.Max(vals[0], vals[3]);
            MaxY = Math.Max(vals[1], vals[4]);
            MaxZ = Math.Max(vals[2], vals[5]);
        }

        /// <summary>
        /// Construction
        /// </summary>
        /// <param name="path">Output VIZ Path</param>
        /// <param name="keepStructure">Keep Structure</param>
        /// <param name="vals">Values</param>
        public BoundBoxItem(string path, bool keepStructure, List<int> vals)
        {
            Path = path;
            KeepStructure = keepStructure;

            MinX = Math.Min(vals[0], vals[3]);
            MinY = Math.Min(vals[1], vals[4]);
            MinZ = Math.Min(vals[2], vals[5]);

            MaxX = Math.Max(vals[0], vals[3]);
            MaxY = Math.Max(vals[1], vals[4]);
            MaxZ = Math.Max(vals[2], vals[5]);
        }
    }
}
