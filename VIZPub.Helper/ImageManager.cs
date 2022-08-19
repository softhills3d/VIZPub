using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub
{
    /// <summary>
    /// Image Manager Class
    /// </summary>
    public class ImageManager
    {
        // ================================================
        // Attribute & Property
        // ================================================
        /// <summary>
        /// VIZPub.exe Program Path
        /// </summary>
        internal string VIZPub_Path { get; set; }

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
        /// <param name="vizpub_path">VIZPub 2D Program Path</param>
        public ImageManager(string vizpub_path)
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
        internal bool IExport(ImageParameter parameter)
        {
            // Check Parameter (Necessary)  
            if (parameter.Exist(ImageParameters.INPUT) == false)
                throw new NullReferenceException("INPUT is null.");

            if (parameter.Exist(ImageParameters.OUTPUT) == false)
                throw new NullReferenceException("OUTPUT is null.");

            // Working : Local, Original
            string original_input = (string)parameter.GetValue(ImageParameters.INPUT);
            string original_output = (string)parameter.GetValue(ImageParameters.OUTPUT);

            if (String.IsNullOrEmpty(original_input) == true)
                throw new NullReferenceException("Input File is null.");

            if (String.IsNullOrEmpty(original_output) == true)
                throw new NullReferenceException("Output File is null.");

            if (System.IO.File.Exists(original_input) == false)
                throw new System.IO.FileNotFoundException(string.Format("Input File Not Found.\r\n\r\n{0}", original_input));

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

            if (result == false)
            {
                System.IO.File.Delete(original_output);

                return result;
            }

            return System.IO.File.Exists(original_output);
        }

        /// <summary>
        /// Export Image
        /// </summary>
        /// <param name="parameter">Image Parameter</param>
        /// <returns>Result</returns>
        public bool Export(ImageParameter parameter)
        {
            return IExport(parameter);
        }
    }
}
