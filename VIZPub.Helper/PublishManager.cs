using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub
{
    /// <summary>
    /// Publish Manager Class
    /// </summary>
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
        /// <param name="vizpub_path">VIZPub Program Path</param>
        public PublishManager(string vizpub_path)
        {
            VIZPub_Path = vizpub_path;

            InitEnvironment();
        }

        // ================================================
        // Function
        // ================================================
        internal void InitEnvironment()
        {
            if (String.IsNullOrEmpty(VIZPub_Path) == true)
                throw new NullReferenceException("VIZPub Program Path is null.");

            if (System.IO.File.Exists(VIZPub_Path) == false)
                throw new System.IO.FileNotFoundException(string.Format("File Not Found.\r\n{0}", VIZPub_Path));

            LocalBasePath = string.Format("{0}\\Working", System.IO.Path.GetDirectoryName(VIZPub_Path));
            LocalInputPath = System.IO.Path.Combine(LocalBasePath, "Input");
            LocalOutputPath = System.IO.Path.Combine(LocalBasePath, "Output");
            LocalIntermediatePath = System.IO.Path.Combine(LocalBasePath, "Intermediate");

            if (System.IO.Directory.Exists(LocalBasePath) == false)
                System.IO.Directory.CreateDirectory(LocalBasePath);

            if (System.IO.Directory.Exists(LocalInputPath) == false)
                System.IO.Directory.CreateDirectory(LocalInputPath);

            if (System.IO.Directory.Exists(LocalOutputPath) == false)
                System.IO.Directory.CreateDirectory(LocalOutputPath);

            if (System.IO.Directory.Exists(LocalIntermediatePath) == false)
                System.IO.Directory.CreateDirectory(LocalIntermediatePath);
        }

        internal string GetLocalPath(LocalPaths kind, string path)
        {
            if (String.IsNullOrEmpty(path) == true)
                throw new NullReferenceException("Path is null.");

            string name = System.IO.Path.GetFileName(path);
            string result = String.Empty;

            switch (kind)
            {
                case LocalPaths.Input:
                    result = System.IO.Path.Combine(LocalInputPath, name);
                    break;
                case LocalPaths.Intermediate:
                    result = System.IO.Path.Combine(LocalIntermediatePath, name);
                    break;
                case LocalPaths.Output:
                    result = System.IO.Path.Combine(LocalOutputPath, name);
                    break;
                default:
                    break;
            }

            if (System.IO.File.Exists(result) == true)
                System.IO.File.Delete(result);

            if(kind == LocalPaths.Input)
            {
                System.IO.File.Copy(path, result);
            }
            else if(kind == LocalPaths.Output)
            {
                if (System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(path)) == false)
                    System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(path));
            }

            return result;
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
        internal bool IExport(PublishParameter parameter)
        {
            // Check Parameter (Necessary)  
            if (parameter.Exist(PublishParameters.INPUT) == false)
                throw new NullReferenceException("INPUT is null.");

            if (parameter.Exist(PublishParameters.OUTPUT) == false)
                throw new NullReferenceException("OUTPUT is null.");

            // Working : Local, Original
            string original_input = (string)parameter.GetValue(PublishParameters.INPUT);
            string original_output = (string)parameter.GetValue(PublishParameters.OUTPUT);

            if (String.IsNullOrEmpty(original_input) == true)
                throw new NullReferenceException("Input Path is null.");

            if (String.IsNullOrEmpty(original_output) == true)
                throw new NullReferenceException("Output Path is null.");

            if (System.IO.File.Exists(original_input) == false)
                throw new System.IO.FileNotFoundException(string.Format("Input File Not Found.\r\n\r\n{0}", original_input));

            string local_input = GetLocalPath(LocalPaths.Input, original_input);
            string local_output = GetLocalPath(LocalPaths.Output, original_output);

            // Update Path
            parameter.SetValue(PublishParameters.INPUT, local_input);
            parameter.SetValue(PublishParameters.OUTPUT, local_output);

            string argument = parameter.ToString();

            // Publish
            ProcessHelper process = new ProcessHelper(VIZPub_Path);
            process.DataReceived += Process_DataReceived;
            process.ErrorReceived += Process_ErrorReceived;

            bool result = process.Execute(
                    argument    /* Argument */
                    , true      /* Redirect Standard Output */
                    , true      /* Redirect Standard Error */
                    , true      /* Create No Window */
                    , false     /* Use Shell Execute */
                    );

            System.IO.File.Delete(local_input);

            if (result == false)
            {
                System.IO.File.Delete(local_output);

                return result;
            }

            try
            {
                if (System.IO.File.Exists(local_output) == true)
                {
                    System.IO.File.Delete(original_output);
                    System.IO.File.Move(local_output, original_output);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Export VIZ
        /// </summary>
        /// <param name="parameter">Publish Parameter</param>
        /// <returns>Publish Result</returns>
        public bool ExportVIZ(PublishParameter parameter)
        {
            // Add Mode
            parameter.Add(PublishParameters.MODE, 0);

            return IExport(parameter);
        }

        
        /// <summary>
        /// Export VIZM (VIZWing)
        /// </summary>
        /// <param name="parameter">Publish Parameter</param>
        /// <returns>Publish Result</returns>
        public bool ExportVIZM(PublishParameter parameter)
        {
            // Add Mode
            parameter.Add(PublishParameters.MODE, 1);
            parameter.Add(PublishParameters.OUTPUT_VIZM, GetLocalPath(LocalPaths.Output, (string)parameter.GetValue(PublishParameters.OUTPUT)));

            return IExport(parameter);
        }

        /// <summary>
        /// Export VIZW (VIZWeb)
        /// </summary>
        /// <param name="parameter">Publish Parameter</param>
        /// <returns>Publish Result</returns>
        public bool ExportVIZW(PublishParameter parameter)
        {
            // Add Mode
            parameter.Add(PublishParameters.MODE, 7);
            parameter.Add(PublishParameters.OUTPUT_VIZW, GetLocalPath(LocalPaths.Output, (string)parameter.GetValue(PublishParameters.OUTPUT)));

            return IExport(parameter);
        }

        // ================================================
        // Method :: Merge VIZ
        // ================================================
        /// <summary>
        /// Merge VIZ File or Node
        /// </summary>
        /// <param name="parameter">Publish Parameter</param>
        /// <returns>Publish Result</returns>
        public bool MergeVIZ(PublishParameter parameter)
        {
            // METADATA

            // MERGE RULE FILE (?)

            return false;
        }


        // ================================================
        // Method :: Metadata
        // ================================================
        /// <summary>
        /// Export Metadata
        /// </summary>
        /// <param name="parameter">Publish Parameter</param>
        /// <returns>Publish Result</returns>
        public bool ExportMetadata(PublishParameter parameter)
        {
            return false;
        }


        // ================================================
        // Method :: Attribute
        // ================================================
        /// <summary>
        /// Import Attribute
        /// </summary>
        /// <param name="parameter">Publish Parameter</param>
        /// <returns>Publish Result</returns>
        public bool ImportAttribute(PublishParameter parameter)
        {
            return false;
        }

        /// <summary>
        /// Export Attribute
        /// </summary>
        /// <param name="parameter">Publish Parameter</param>
        /// <returns>Publish Result</returns>
        public bool ExportAttribute(PublishParameter parameter)
        {
            return false;
        }

        /// <summary>
        /// Clear Attribute
        /// </summary>
        /// <param name="parameter">Publish Parameter</param>
        /// <returns>Publish Result</returns>
        public bool ClearAttribute(PublishParameter parameter)
        {
            return false;
        }

        // ================================================
        // Method :: Image (Thumbnail)
        // ================================================
        /// <summary>
        /// Export Image
        /// </summary>
        /// <param name="parameter">Publish Parameter</param>
        /// <returns>Publish Result</returns>
        public bool ExportImage(PublishParameter parameter)
        {
            return false;
        }

        // ================================================
        // Method :: Color
        // ================================================
        /// <summary>
        /// Change Model Color
        /// </summary>
        /// <param name="parameter">Publish Parameter</param>
        /// <returns>Publish Result</returns>
        public bool ChangeColor(PublishParameter parameter)
        {
            return false;
        }
    }
}
