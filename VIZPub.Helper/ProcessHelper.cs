using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPub
{
    /// <summary>
    /// Data Event Handler
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void DataEventHandler(object sender, DataEventArgs e);


    internal class ProcessHelper
    {
        // ================================================
        // Attribute & Property
        // ================================================
        /// <summary>
        /// VIZPub Program Path
        /// </summary>
        internal string VIZPub_Path { get; set; }



        /// <summary>
        /// Process Log : Information
        /// </summary>
        public StringBuilder ProcessLog { get; set; }

        /// <summary>
        /// Process Log : Error
        /// </summary>
        public StringBuilder ProcessError { get; set; }

        /// <summary>
        /// Process Elapsed Time
        /// </summary>
        public TimeSpan ElapsedTime { get; set; }


        // ================================================
        // Event
        // ================================================
        /// <summary>
        /// Data Received Event Handler
        /// </summary>
        public event DataEventHandler DataReceived;

        /// <summary>
        /// Error Data Received Event Handler
        /// </summary>
        public event DataEventHandler ErrorReceived;


        // ================================================
        // Construction
        // ================================================
        public ProcessHelper(string vizpub_path)
        {
            VIZPub_Path = vizpub_path;

            ProcessLog = new StringBuilder();
            ProcessError = new StringBuilder();
        }


        // ================================================
        // Function
        // ================================================
        internal void SetElapsedTime(DateTime StartTime)
        {
            ElapsedTime = DateTime.Now - StartTime;
        }


        // ================================================
        // Method
        // ================================================
        public bool Execute(string argument, bool useOutput, bool useError, bool createNoWindow = true, bool useShellExecute = false)
        {
            DateTime dtStart = DateTime.Now;

            System.Diagnostics.ProcessStartInfo processInfo = new System.Diagnostics.ProcessStartInfo(VIZPub_Path);
            processInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(VIZPub_Path);
            processInfo.Arguments = string.Format(" {0}", argument);

            if (useOutput == true && createNoWindow == true)
                processInfo.RedirectStandardOutput = true;

            if (useError == true && createNoWindow == true)
                processInfo.RedirectStandardError = true;

            processInfo.UseShellExecute = useShellExecute;
            processInfo.ErrorDialog = false;
            processInfo.CreateNoWindow = createNoWindow;


            System.Diagnostics.Process processVIZPub = new System.Diagnostics.Process();

            processVIZPub.StartInfo = processInfo;
            processVIZPub.OutputDataReceived += ProcessVIZPub_OutputDataReceived;
            processVIZPub.ErrorDataReceived += ProcessVIZPub_ErrorDataReceived;

            try
            {
                processVIZPub.Start();

                if (useOutput == true && createNoWindow == true)
                    processVIZPub.BeginOutputReadLine();

                if (useError == true && createNoWindow == true)
                    processVIZPub.BeginErrorReadLine();

                do
                {
                    if (processVIZPub.HasExited == false)
                    {
                        processVIZPub.Refresh();
                    }
                }
                while (processVIZPub.WaitForExit(1000) == false);

                processVIZPub.WaitForExit();
                processVIZPub.Close();

                SetElapsedTime(dtStart);

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                SetElapsedTime(dtStart);

                return false;
            }
        }

        private void ProcessVIZPub_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            if (String.IsNullOrEmpty(e.Data) == true) return;

            ProcessLog.AppendLine(e.Data.ToString());

            if (sender == null) return;
            if (DataReceived == null) return;

            DataEventArgs args = new DataEventArgs();
            args.process = (System.Diagnostics.Process)sender;
            args.Message = e.Data.ToString();

            DataReceived(this, args);
        }

        private void ProcessVIZPub_ErrorDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            if (String.IsNullOrEmpty(e.Data) == true) return;

            ProcessLog.AppendLine(e.Data.ToString());

            if (sender == null) return;
            if (ErrorReceived == null) return;

            DataEventArgs args = new DataEventArgs();
            args.process = (System.Diagnostics.Process)sender;
            args.Message = e.Data.ToString();

            ErrorReceived(this, args);
        }
    }

    /// <summary>
    /// Data Event Args.
    /// </summary>
    public class DataEventArgs : EventArgs
    {
        /// <summary>
        /// Current Process
        /// </summary>
        public System.Diagnostics.Process process { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        public string Message { get; set; }
    }
}
