using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub
{
    public class PublishManager
    {
        // ================================================
        // Attribute & Property
        // ================================================
        /// <summary>
        /// VIZPub.exe Program Path
        /// </summary>
        internal string VIZPub_Path { get; set; }

        /// <summary>
        /// Working Location
        /// </summary>
        public WorkingLocation PublishWorkingLocation { get; set; }

        /// <summary>
        /// Local Working Base Path
        /// </summary>
        public string LocalBasePath { get; set; }

        /// <summary>
        /// Local Working Input Path
        /// </summary>
        public string LocalInputPath { get; set; }

        /// <summary>
        /// Local Working Output Path
        /// </summary>
        public string LocalOutputPath { get; set; }

        /// <summary>
        /// Local Working Intermediate Path
        /// </summary>
        public string LocalIntermediatePath { get; set; }



        // ================================================
        // Construction
        // ================================================
        public PublishManager(string vizpub_path)
        {
            VIZPub_Path = vizpub_path;

            if (String.IsNullOrEmpty(VIZPub_Path) == true)
                throw new NullReferenceException("VIZPub Path is null.");

            if (System.IO.File.Exists(VIZPub_Path) == false)
                throw new System.IO.FileNotFoundException(string.Format("File Not Found.\r\n{0}", VIZPub_Path));

            LocalBasePath = "C:\\Temp";

            PublishWorkingLocation = WorkingLocation.ORIGINAL_PATH;
        }

        // ================================================
        // Function
        // ================================================



        // ================================================
        // Method :: Publish
        // ================================================
        public bool ExportVIZ(PublishParameter parameter)
        {
            return false;
        }

        public bool ExportVIZM(PublishParameter parameter)
        {
            return false;
        }

        public bool ExportVIZW(PublishParameter parameter)
        {
            return false;
        }

        // ================================================
        // Method :: Merge VIZ
        // ================================================
        public bool MergeVIZ(PublishParameter parameter)
        {
            // METADATA

            // MERGE RULE FILE (?)

            return false;
        }


        // ================================================
        // Method :: Metadata
        // ================================================
        public bool ExportMetadata(PublishParameter parameter)
        {
            return false;
        }


        // ================================================
        // Method :: Attribute
        // ================================================
        public bool ImportAttribute(PublishParameter parameter)
        {
            return false;
        }

        public bool ExportAttribute(PublishParameter parameter)
        {
            return false;
        }

        public bool ClearAttribute(PublishParameter parameter)
        {
            return false;
        }

        // ================================================
        // Method :: Image (Thumbnail)
        // ================================================
        public bool ExportImage(PublishParameter parameter)
        {
            return false;
        }

        // ================================================
        // Method :: Color
        // ================================================
        public bool ChangeColor(PublishParameter parameter)
        {
            return false;
        }
    }
}
