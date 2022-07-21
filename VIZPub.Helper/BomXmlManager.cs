using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub
{
    /// <summary>
    /// Bom Xml Generate Manager Class
    /// </summary>
    public class BomXmlManager
    {
        // ================================================
        // Attribute & Property
        // ================================================
        /// <summary>
        /// ShxBomXmlGen.exe Program Path
        /// </summary>
        internal string ShxBomXmlGen_Path { get; set; }

        /// <summary>
        /// Publish Log Received
        /// </summary>
        public event DataEventHandler PublishLogReceived;


        // ================================================
        // Construction
        // ================================================
        /// <summary>
        /// Construction
        /// </summary>
        /// <param name="shxbomxmlgen_path">ShxBomXmlGen.exe Program Path</param>
        public BomXmlManager(string shxbomxmlgen_path)
        {
            ShxBomXmlGen_Path = shxbomxmlgen_path;
        }

        // ================================================
        // Event
        // ================================================
        private void Process_DataReceived(object sender, DataEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.Message);
            Console.WriteLine(e.Message);

            if (PublishLogReceived == null) return;

            DataEventArgs args = new DataEventArgs();
            args.process = e.process;
            args.Message = e.Message;

            PublishLogReceived(this, args);
        }

        private void Process_ErrorReceived(object sender, DataEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.Message);
            Console.WriteLine(e.Message);

            if (PublishLogReceived == null) return;

            DataEventArgs args = new DataEventArgs();
            args.process = e.process;
            args.Message = e.Message;

            PublishLogReceived(this, args);
        }


        // ================================================
        // Method :: Publish
        // ================================================
        internal bool IExport(BomXmlParameter parameter)
        {
            string argument = parameter.ToString();

            // Publish
            ProcessHelper process = new ProcessHelper(ShxBomXmlGen_Path);
            process.DataReceived += Process_DataReceived;
            process.ErrorReceived += Process_ErrorReceived;

            bool result = process.Execute(
                    argument    /* Argument */
                    , true      /* Redirect Standard Output */
                    , true      /* Redirect Standard Error */
                    , true      /* Create No Window */
                    , false     /* Use Shell Execute */
                    );

            return result;
        }

        /// <summary>
        /// Export XML
        /// </summary>
        /// <param name="parameter">Bom Xml Parameter</param>
        /// <returns>Generate Result</returns>
        public bool ExportXML(BomXmlParameter parameter)
        {
            // Add Mode
            parameter.Add(BomXmlParameters.MODE, "xml");

            return IExport(parameter);
        }

        /// <summary>
        /// Export E-BOM XML
        /// </summary>
        /// <param name="parameter">Bom Xml Parameter</param>
        /// <returns>Generate Result</returns>
        public bool ExportEbomXml(BomXmlParameter parameter)
        {
            // Add Mode
            parameter.Add(BomXmlParameters.MODE, "r");

            return IExport(parameter);
        }

        /// <summary>
        /// Export Thumbnail
        /// </summary>
        /// <param name="parameter">Bom Xml Parameter</param>
        /// <returns>Generate Result</returns>
        public bool ExportThumbnail(BomXmlParameter parameter)
        {
            // Add Mode
            parameter.Add(BomXmlParameters.MODE, "i");

            return IExport(parameter);
        }

        /// <summary>
        /// Get Check CAD Type
        /// </summary>
        /// <param name="parameter">Bom Xml Parameter</param>
        /// <returns>Generate Result</returns>
        public bool GetCADType(BomXmlParameter parameter)
        {
            // Add Mode
            parameter.Add(BomXmlParameters.MODE, "t");

            return IExport(parameter);
        }

    }
}
