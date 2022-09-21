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
        /// Export XML
        /// </summary>
        /// <param name="parameter">Translate Parameter</param>
        /// <returns>Translate Result</returns>
        public bool ExportXML(TranslateParameter parameter)
        {
            // Add Mode
            parameter.Add(TranslateParameters.MODE, "xml");

            return IExport(parameter);
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
            // Add Mode
            parameter.Add(TranslateParameters.MODE, "xml");

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

        /// <summary>
        /// Export Parasolid
        /// </summary>
        /// <param name="parameter">Translate Parameter</param>
        /// <returns>Translate Result</returns>
        public bool ExportPS(TranslateParameter parameter)
        {
            // Add Mode
            parameter.Add(TranslateParameters.MODE, "ps");

            return IExport(parameter);
        }

        /// <summary>
        /// Export PDF
        /// </summary>
        /// <param name="parameter">Translate Parameter</param>
        /// <returns>Translate Result</returns>
        public bool ExportPDF(TranslateParameter parameter)
        {
            // Add Mode
            parameter.Add(TranslateParameters.MODE, "pdf");

            return IExport(parameter);
        }

        /// <summary>
        /// Export JT
        /// </summary>
        /// <param name="parameter">Translate Parameter</param>
        /// <returns>Translate Result</returns>
        public bool ExportJT(TranslateParameter parameter)
        {
            // Add Mode
            parameter.Add(TranslateParameters.MODE, "jt");

            return IExport(parameter);
        }

        /// <summary>
        /// Export Universal3D
        /// </summary>
        /// <param name="parameter">Translate Parameter</param>
        /// <returns>Translate Result</returns>
        public bool ExportU3D(TranslateParameter parameter)
        {
            // Add Mode
            parameter.Add(TranslateParameters.MODE, "u3d");

            return IExport(parameter);
        }

        /// <summary>
        /// Export VRML
        /// </summary>
        /// <param name="parameter">Translate Parameter</param>
        /// <returns>Translate Result</returns>
        public bool ExportVRML(TranslateParameter parameter)
        {
            // Add Mode
            parameter.Add(TranslateParameters.MODE, "vrml");

            return IExport(parameter);
        }

        /// <summary>
        /// Export STL
        /// </summary>
        /// <param name="parameter">Translate Parameter</param>
        /// <returns>Translate Result</returns>
        public bool ExportSTL(TranslateParameter parameter)
        {
            // Add Mode
            parameter.Add(TranslateParameters.MODE, "stl");

            return IExport(parameter);
        }

        /// <summary>
        /// Export ACIS
        /// </summary>
        /// <param name="parameter">Translate Parameter</param>
        /// <returns>Translate Result</returns>
        public bool ExportACIS(TranslateParameter parameter)
        {
            // Add Mode
            parameter.Add(TranslateParameters.MODE, "acis");

            return IExport(parameter);
        }

        /// <summary>
        /// Export CGR
        /// </summary>
        /// <param name="parameter">Translate Parameter</param>
        /// <returns>Translate Result</returns>
        public bool ExportCGR(TranslateParameter parameter)
        {
            // Add Mode
            parameter.Add(TranslateParameters.MODE, "cgr");

            return IExport(parameter);
        }

        /// <summary>
        /// Export 3MF
        /// </summary>
        /// <param name="parameter">Translate Parameter</param>
        /// <returns>Translate Result</returns>
        public bool Export3MF(TranslateParameter parameter)
        {
            // Add Mode
            parameter.Add(TranslateParameters.MODE, "3mf");

            return IExport(parameter);
        }

        /// <summary>
        /// Export FBX
        /// </summary>
        /// <param name="parameter">Translate Parameter</param>
        /// <returns>Translate Result</returns>
        public bool ExportFBX(TranslateParameter parameter)
        {
            // Add Mode
            parameter.Add(TranslateParameters.MODE, "fbx");

            return IExport(parameter);
        }

        /// <summary>
        /// Export GLTF
        /// </summary>
        /// <param name="parameter">Translate Parameter</param>
        /// <returns>Translate Result</returns>
        public bool ExportGLTF(TranslateParameter parameter)
        {
            // Add Mode
            parameter.Add(TranslateParameters.MODE, "gltf");

            return IExport(parameter);
        }

        /// <summary>
        /// Export OBJ
        /// </summary>
        /// <param name="parameter">Translate Parameter</param>
        /// <returns>Translate Result</returns>
        public bool ExportOBJ(TranslateParameter parameter)
        {
            // Add Mode
            parameter.Add(TranslateParameters.MODE, "obj");

            return IExport(parameter);
        }

        /// <summary>
        /// Export VIZM
        /// </summary>
        /// <param name="parameter">Translate Parameter</param>
        /// <returns>Translate Result</returns>
        public bool ExportVIZM(TranslateParameter parameter)
        {
            // Add Mode
            parameter.Add(TranslateParameters.MODE, "vizm");

            return IExport(parameter);
        }

        /// <summary>
        /// Export VIZW
        /// </summary>
        /// <param name="parameter">Translate Parameter</param>
        /// <returns>Translate Result</returns>
        public bool ExportVIZW(TranslateParameter parameter)
        {
            // Add Mode
            parameter.Add(TranslateParameters.MODE, "vw3d");

            bool result = IExport(parameter);

            if (parameter.Exist(TranslateParameters.OUTPUT_VIZW_PATH) == false) return result;

            string output_vizw = (string)parameter.GetValue(TranslateParameters.OUTPUT_VIZW_PATH);
            if (String.IsNullOrEmpty(output_vizw) == true) return result;

            string output_path = System.IO.Path.GetDirectoryName(output_vizw);
            if (System.IO.Directory.Exists(output_path) == false) return result;

            string output_path_file1 = System.IO.Path.Combine(output_path, "BoundInfo.txt");
            string output_path_file2 = System.IO.Path.Combine(output_path, "BoundInfo4JavaScript.txt");

            System.IO.File.Delete(output_path_file1);
            System.IO.File.Delete(output_path_file2);

            return result;
        }
    }
}
