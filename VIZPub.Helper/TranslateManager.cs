using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub
{
    /// <summary>
    /// Translate Manager Class
    /// </summary>
    public class TranslateManager
    {
        // ================================================
        // Attribute & Property
        // ================================================
        /// <summary>
        /// VIZCoreTrans.exe Program Path
        /// </summary>
        internal string VIZCoreTrans_Path { get; set; }

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
        /// <param name="vizcoretrans_path">VIZCoreTrans.exe Program Path</param>
        public TranslateManager(string vizcoretrans_path)
        {
            VIZCoreTrans_Path = vizcoretrans_path;
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
        /// <summary>
        /// Export VIZ
        /// </summary>
        /// <param name="parameter">Translate Parameter</param>
        /// <returns>Translate Result</returns>
        public bool ExportVIZ(TranslateParameter parameter)
        {
            return false;
        }

        /// <summary>
        /// Export STEP
        /// </summary>
        /// <param name="parameter">Translate Parameter</param>
        /// <returns>Translate Result</returns>
        public bool ExportStep(TranslateParameter parameter)
        {
            return false;
        }

        /// <summary>
        /// Export IGES
        /// </summary>
        /// <param name="parameter">Translate Parameter</param>
        /// <returns>Translate Result</returns>
        public bool ExportIges(TranslateParameter parameter)
        {
            return false;
        }

        /// <summary>
        /// Export 3DXML
        /// </summary>
        /// <param name="parameter">Translate Parameter</param>
        /// <returns>Translate Result</returns>
        public bool Export3DXML(TranslateParameter parameter)
        {
            return false;
        }

        /// <summary>
        /// Export E-BOM XML
        /// </summary>
        /// <param name="parameter">Translate Parameter</param>
        /// <returns>Translate Result</returns>
        public bool ExportEbomXml(TranslateParameter parameter)
        {
            return false;
        }

        /// <summary>
        /// Export Thumbnail
        /// </summary>
        /// <param name="parameter">Translate Parameter</param>
        /// <returns>Translate Result</returns>
        public bool ExportThumbnail(TranslateParameter parameter)
        {
            return false;
        }
    }
}
