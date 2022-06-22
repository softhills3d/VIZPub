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
        internal bool IExport(PublishParameter parameter, bool output_dir = false)
        {
            // Check Parameter (Necessary)  
            if (parameter.Exist(PublishParameters.INPUT) == false)
                throw new NullReferenceException("INPUT is null.");

            if (parameter.Exist(PublishParameters.OUTPUT) == false)
                throw new NullReferenceException("OUTPUT is null.");

            // Working : Local, Original
            string original_input = (string)parameter.GetValue(PublishParameters.INPUT);
            string original_output = (string)parameter.GetValue(PublishParameters.OUTPUT);

            if(output_dir == true)
            {
                if (String.IsNullOrEmpty(original_output) == false && System.IO.Directory.Exists(original_output) == false)
                    System.IO.Directory.CreateDirectory(original_output);
            }

            if (String.IsNullOrEmpty(original_input) == true)
                throw new NullReferenceException("Input Path is null.");

            if (String.IsNullOrEmpty(original_output) == true)
                throw new NullReferenceException("Output Path is null.");

            if (System.IO.File.Exists(original_input) == false)
                throw new System.IO.FileNotFoundException(string.Format("Input File Not Found.\r\n\r\n{0}", original_input));

            string local_input = String.Empty;
            string local_output = String.Empty;

            if (output_dir == false) // File
            {
                local_input = GetLocalPath(LocalPaths.Input, original_input);
                local_output = GetLocalPath(LocalPaths.Output, original_output);

                // Update Path
                parameter.SetValue(PublishParameters.INPUT, local_input);
                parameter.SetValue(PublishParameters.OUTPUT, local_output);
            }
            else
            {
                if (System.IO.Directory.Exists(original_output) == false)
                    System.IO.Directory.CreateDirectory(original_output);
            }
            
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

            if (output_dir == false)
            {
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
            else
            {
                try
                {
                    string[] files = System.IO.Directory.GetFiles(original_output, "*.*", System.IO.SearchOption.TopDirectoryOnly);
                    if (files != null && files.Length > 0) return true;
                    else return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
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

        /// <summary>
        /// Export FBX
        /// </summary>
        /// <param name="parameter">Publish Parameter</param>
        /// <returns>Publish Result</returns>
        public bool ExportFBX(PublishParameter parameter)
        {
            // Add Mode
            parameter.Add(PublishParameters.MODE, 200);

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
            // Add Mode
            parameter.Add(PublishParameters.MODE, 3);

            bool result = IExport(parameter);

            if(result == true)
            {
                string path = (string)parameter.GetValue(PublishParameters.INPUT);
                System.IO.File.Delete(path);
            }

            return result;
        }

        /// <summary>
        /// Merge VIZM File or Node
        /// </summary>
        /// <param name="parameter">Publish Parameter</param>
        /// <returns>Publish Result</returns>
        public bool MergeVIZM(PublishParameter parameter)
        {
            // Add Mode
            parameter.Add(PublishParameters.MODE, 4);

            bool result = IExport(parameter);

            if (result == true)
            {
                string path = (string)parameter.GetValue(PublishParameters.INPUT);
                System.IO.File.Delete(path);
            }

            return result;
        }

        /// <summary>
        /// Merge VIZW File or Node
        /// </summary>
        /// <param name="parameter">Publish Parameter</param>
        /// <returns>Publish Result</returns>
        public bool MergeVIZW(PublishParameter parameter)
        {
            // Add Mode
            parameter.Add(PublishParameters.MODE, 5);

            bool result = IExport(parameter);

            if (result == true)
            {
                string path = (string)parameter.GetValue(PublishParameters.INPUT);
                System.IO.File.Delete(path);
            }

            return result;
        }

        /// <summary>
        /// Merge Leaf Assembly To Part
        /// </summary>
        /// <param name="parameter">Publish Parameter</param>
        /// <returns>Publish Result</returns>
        public bool MergeLeafAssemblyToPart(PublishParameter parameter)
        {
            // Add Mode
            parameter.Add(PublishParameters.MODE, 12);

            return IExport(parameter);
        }

        /// <summary>
        /// Merge By Rule XML File
        /// </summary>
        /// <param name="parameter">Publish Parameter</param>
        /// <returns>Publish Result</returns>
        public bool MergeByRuleXMLFile(PublishParameter parameter)
        {
            // Add Mode
            parameter.Add(PublishParameters.MODE, 13);

            return IExport(parameter);
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
            // Add Mode
            parameter.Add(PublishParameters.MODE, 2);

            return IExport(parameter);
        }

        /// <summary>
        /// Export Model BoundBox
        /// </summary>
        /// <param name="parameter">Publish Parameter</param>
        /// <returns>Publish Result</returns>
        public bool ExportModelBoundBox(PublishParameter parameter)
        {
            // Add Mode
            parameter.Add(PublishParameters.MODE, 21);

            return IExport(parameter);
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
            // Add Mode
            parameter.Add(PublishParameters.MODE, 9);

            bool result = IExport(parameter);

            if(result == true)
            {
                string path = (string)parameter.GetValue(PublishParameters.ATTRIBUTE_FILE);
                System.IO.File.Delete(path);
            }

            return result;
        }

        /// <summary>
        /// Export Attribute
        /// </summary>
        /// <param name="parameter">Publish Parameter</param>
        /// <returns>Publish Result</returns>
        public bool ExportAttribute(PublishParameter parameter)
        {
            // Add Mode
            parameter.Add(PublishParameters.MODE, 8);

            return IExport(parameter);
        }

        /// <summary>
        /// Clear Attribute
        /// </summary>
        /// <param name="parameter">Publish Parameter</param>
        /// <returns>Publish Result</returns>
        public bool ClearAttribute(PublishParameter parameter)
        {
            // Add Mode
            parameter.Add(PublishParameters.MODE, 10);

            return IExport(parameter);
        }

        // ================================================
        // Method :: Node
        // ================================================
        /// <summary>
        /// Export Node
        /// </summary>
        /// <param name="parameter">Publish Parameter</param>
        /// <returns>Publish Result</returns>
        public bool ExportNode(PublishParameter parameter)
        {
            // Add Mode
            parameter.Add(PublishParameters.MODE, 14);

            return IExport(parameter, true);
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
            // Add Mode
            parameter.Add(PublishParameters.MODE, 6);

            NodeUnit unit = (NodeUnit)parameter.GetValue(PublishParameters.THUMBNAIL_IMAGE_NODE_UNIT);
            if(unit == NodeUnit.NODE_UNIT)
            {
                return IExport(parameter, true);
            }
            else
            {
                return IExport(parameter, false);
            }
        }

        // ================================================
        // Method :: Simplify
        // ================================================
        /// <summary>
        /// Simplify Model
        /// </summary>
        /// <param name="parameter">Publish Parameter</param>
        /// <returns>Publish Result</returns>
        public bool Simplify(PublishParameter parameter)
        {
            // Add Mode
            parameter.Add(PublishParameters.MODE, 17);

            return IExport(parameter, false);
        }

        // ================================================
        // Method :: VIZWide3D
        // ================================================
        /// <summary>
        /// Export VIZWide3D
        /// </summary>
        /// <param name="parameter">Publish Parameter</param>
        /// <returns>Publish Result</returns>
        public bool ExportVIZWide3D(PublishParameter parameter)
        {
            // Add Mode
            parameter.Add(PublishParameters.MODE, 18);

            string input = (string)parameter.GetValue(PublishParameters.INPUT);
            string name = System.IO.Path.GetFileNameWithoutExtension(input);

            string output_dir = (string)parameter.GetValue(PublishParameters.OUTPUT);
            string output_viz = string.Format("{0}\\{1}.viz", output_dir, name);
            string output_vizw = string.Format("{0}\\{1}.vizw", output_dir, name);

            parameter.Add(PublishParameters.OUTPUT_VIZW, output_vizw);
            parameter.Add(PublishParameters.OUTPUT_FILE_FORMAT, OutputFileFormat.VIZW_LOD);

            parameter.SetValue(PublishParameters.OUTPUT, output_viz);

            return IExport(parameter);
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
            // Add Mode
            parameter.Add(PublishParameters.MODE, 60);

            return IExport(parameter);
        }


        // ================================================
        // Method :: NWD / HMF
        // ================================================
        /// <summary>
        /// Export HMF
        /// </summary>
        /// <param name="parameter">Publish Parameter</param>
        /// <returns>Publish Result</returns>
        public bool ExportHMF(PublishParameter parameter)
        {
            // Add Mode
            parameter.Add(PublishParameters.MODE, 19);

            return IExport(parameter);
        }


        // ================================================
        // Method :: SPACE
        // ================================================
        /// <summary>
        /// Export Model In Bounding Box
        /// </summary>
        /// <param name="parameter">Publish Parameter</param>
        /// <returns>Publish Result</returns>
        public bool ExportZone(PublishParameter parameter)
        {
            // Add Mode
            parameter.Add(PublishParameters.MODE, 20);

            return IExport(parameter);
        }
    }
}
