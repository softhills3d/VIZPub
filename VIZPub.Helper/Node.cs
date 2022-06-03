using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub
{
    /// <summary>
    /// Node Class
    /// </summary>
    public class Node
    {
        /// <summary>
        /// Node Kind
        /// </summary>
        public enum NodeKind
        {
            /// <summary>
            /// ASSEMBLY
            /// </summary>
            ASSEMBLY = 500,

            /// <summary>
            /// PART
            /// </summary>
            PART = 501,

            /// <summary>
            /// BODY
            /// </summary>
            BODY = 507
        }

        // ================================================
        // Attribute & Property
        // ================================================
        /// <summary>
        /// ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Parent ID
        /// </summary>
        public int PARENTID { get; set; }

        /// <summary>
        /// Kind
        /// </summary>
        public NodeKind Kind { get; set; }

        /// <summary>
        /// Bouding Box - Min. X
        /// </summary>
        public float BoundBoxMinX { get; set; }

        /// <summary>
        /// Bouding Box - Min. Y
        /// </summary>
        public float BoundBoxMinY { get; set; }

        /// <summary>
        /// Bouding Box - Min. Z
        /// </summary>
        public float BoundBoxMinZ { get; set; }

        /// <summary>
        /// Bouding Box - Max. X
        /// </summary>
        public float BoundBoxMaxX { get; set; }

        /// <summary>
        /// Bouding Box - Max. Y
        /// </summary>
        public float BoundBoxMaxY { get; set; }

        /// <summary>
        /// Bouding Box - Max. Z
        /// </summary>
        public float BoundBoxMaxZ { get; set; }

        /// <summary>
        /// Depth
        /// </summary>
        public int Depth { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        // ================================================
        // Construction
        // ================================================
        /// <summary>
        /// Construction
        /// </summary>
        public Node()
        {

        }

        internal Node(string raw)
        {
            string[] separatingChars = { "<<,>>" };
            string[] items = raw.Split(separatingChars, StringSplitOptions.None);

            ID = Convert.ToInt32(items[0]);
            PARENTID = Convert.ToInt32(items[1]);
            Kind = (NodeKind)Convert.ToInt32(items[2]);

            BoundBoxMinX = Convert.ToSingle(items[3]);
            BoundBoxMinY = Convert.ToSingle(items[4]);
            BoundBoxMinZ = Convert.ToSingle(items[5]);
            BoundBoxMaxX = Convert.ToSingle(items[6]);
            BoundBoxMaxY = Convert.ToSingle(items[7]);
            BoundBoxMaxZ = Convert.ToSingle(items[8]);

            if (BoundBoxMinX == 340282346638528859811704183484516925440.000000)
            {
                BoundBoxMinX = 0.0f;
            }

            if (BoundBoxMinY == 340282346638528859811704183484516925440.000000)
            {
                BoundBoxMinY = 0.0f;
            }

            if (BoundBoxMinZ == 340282346638528859811704183484516925440.000000)
            {
                BoundBoxMinZ = 0.0f;
            }

            if (BoundBoxMaxX == -340282346638528859811704183484516925440.000000)
            {
                BoundBoxMaxX = 0.0f;
            }

            if (BoundBoxMaxY == -340282346638528859811704183484516925440.000000)
            {
                BoundBoxMaxY = 0.0f;
            }

            if (BoundBoxMaxZ == -340282346638528859811704183484516925440.000000)
            {
                BoundBoxMaxZ = 0.0f;
            }

            Depth = Convert.ToInt32(items[10]);

            if (items.Length == 13)
                Name = items[12];

            /*
            if (String.IsNullOrEmpty(Name) == true)
                Name = "(NONAME)";
            */
        }
    }
}
