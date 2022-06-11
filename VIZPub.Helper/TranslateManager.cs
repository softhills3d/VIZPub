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
        internal bool IExport(TranslateParameter parameter)
        {
            string argument = parameter.ToString();

            // Publish
            ProcessHelper process = new ProcessHelper(VIZCoreTrans_Path);
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
        /// Export VIZ
        /// </summary>
        /// <param name="parameter">Translate Parameter</param>
        /// <returns>Translate Result</returns>
        public bool ExportVIZ(TranslateParameter parameter)
        {
            // Add Mode
            parameter.Add(TranslateParameters.MODE, "viz");

            return IExport(parameter);
        }

        /// <summary>
        /// Export STEP
        /// </summary>
        /// <param name="parameter">Translate Parameter</param>
        /// <returns>Translate Result</returns>
        public bool ExportStep(TranslateParameter parameter)
        {
            // Add Mode
            parameter.Add(TranslateParameters.MODE, "s");

            return IExport(parameter);
        }

        /// <summary>
        /// Export IGES
        /// </summary>
        /// <param name="parameter">Translate Parameter</param>
        /// <returns>Translate Result</returns>
        public bool ExportIges(TranslateParameter parameter)
        {
            // Add Mode
            parameter.Add(TranslateParameters.MODE, "g");

            return IExport(parameter);
        }

        /// <summary>
        /// Export 3DXML
        /// </summary>
        /// <param name="parameter">Translate Parameter</param>
        /// <returns>Translate Result</returns>
        public bool Export3DXML(TranslateParameter parameter)
        {
            // Add Mode
            parameter.Add(TranslateParameters.MODE, "3dxml");

            return IExport(parameter);
        }

        /// <summary>
        /// Export E-BOM XML
        /// </summary>
        /// <param name="parameter">Translate Parameter</param>
        /// <returns>Translate Result</returns>
        public bool ExportEbomXml(TranslateParameter parameter)
        {
            return IExport(parameter);
        }

        /// <summary>
        /// Export Thumbnail
        /// </summary>
        /// <param name="parameter">Translate Parameter</param>
        /// <returns>Translate Result</returns>
        public bool ExportThumbnail(TranslateParameter parameter)
        {
            // Add Mode
            parameter.Add(TranslateParameters.MODE, "i");

            return IExport(parameter);
        }
    }
}
