using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPubProcessMonitoring
{
    public delegate void ProcessCountChangedEventHandler(object sender, ProcessCountChangedEventArgs e);

    public class ProcessCountChangedEventArgs : EventArgs
    {
        public string ProcessName { get; set; }
        public int ProcessCount { get; set; }

        public ProcessCountChangedEventArgs(string processName)
        {
            ProcessName = processName;
            ProcessCount =
                System.Diagnostics.Process.GetProcessesByName(processName).Length;
        }

        public ProcessCountChangedEventArgs(string processName, int processCount) : this(processName)
        {
            ProcessName = processName;
            ProcessCount = processCount;
        }   
    }
}
