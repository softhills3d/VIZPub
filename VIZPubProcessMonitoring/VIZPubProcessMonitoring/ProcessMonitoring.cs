using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace VIZPubProcessMonitoring
{
    public class ProcessMonitoring
    {
        public event ProcessCountChangedEventHandler ProcessCountChanged;

        public string ProcessName { get; set; }
        public int MaxProcessCount { get; set; }
        public int MaxProcessTimeSec { get; set; }

        private Thread MonitoringThread { get; set; }

        public bool IsRunning 
        { 
            get
            {
                return MonitoringThread == null ? false : true;
            }
        }

        public ProcessMonitoring()
        {
            ProcessName = String.Empty;
            MaxProcessCount = 0;
            MaxProcessTimeSec = 0;

            MonitoringThread = null;
        }

        public void Start()
        {
            if (String.IsNullOrEmpty(ProcessName) == true)
                throw new NullReferenceException("Process Name is empty.");

            if (MaxProcessCount == 0)
                throw new ArgumentOutOfRangeException("MaxProcessCount is 0.");

            if (MaxProcessTimeSec == 0)
                throw new ArgumentOutOfRangeException("MaxProcessTimeSec is 0.");

            if (MonitoringThread != null)
            {
                try
                {
                    MonitoringThread.Abort();
                }
                catch(Exception)
                {

                }
            }

            MonitoringThread = null;


            ProcessWorker worker = new ProcessWorker();
            worker.ProcessName = ProcessName;
            worker.MaxProcessCount = MaxProcessCount;
            worker.MaxProcessTimeSec = MaxProcessTimeSec;
            worker.Interval = 2000;
            worker.ProcessCountChanged += Worker_ProcessCountChanged;


            MonitoringThread = new Thread(worker.Run);
            MonitoringThread.IsBackground = true;
            MonitoringThread.Start();
        }

        private void Worker_ProcessCountChanged(object sender, ProcessCountChangedEventArgs e)
        {
            if (ProcessCountChanged != null)
            {
                ProcessCountChanged(this, e);
            }
        }

        public void Stop()
        {
            if (MonitoringThread == null) return;

            try
            {
                MonitoringThread.Abort();
            }
            catch(Exception)
            {
            }

            MonitoringThread = null;
        }
    }
}
