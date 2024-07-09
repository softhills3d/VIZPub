using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VIZPubProcessMonitoring
{
    internal class ProcessWorker
    {
        public event ProcessCountChangedEventHandler ProcessCountChanged;

        public string ProcessName { get; set; }
        public int MaxProcessCount { get; set; }
        public int MaxProcessTimeSec { get; set; }
        public int Interval { get; set; }

        public ProcessWorker() 
        {
            Interval = 1000;
        }

        public void Run()
        {
            if (String.IsNullOrEmpty(ProcessName) == true)
                throw new NullReferenceException("Process Name is empty.");

            while(true)
            {
                System.Diagnostics.Process[] process = 
                    System.Diagnostics.Process.GetProcessesByName(ProcessName);

                System.Diagnostics.Debug.WriteLine(string.Format("PROCESS: {0}", process.Length));

                if(ProcessCountChanged != null)
                {
                    ProcessCountChangedEventArgs args =
                        new ProcessCountChangedEventArgs(ProcessName, process.Length);

                    ProcessCountChanged(this, args);
                }

                bool changedCount = ProcessCountProcess(process);

                if (changedCount == true && ProcessCountChanged != null)
                {
                    ProcessCountChangedEventArgs args =
                        new ProcessCountChangedEventArgs(ProcessName, process.Length);

                    ProcessCountChanged(this, args);
                }

                bool changedCountByTime = ProcessTimeProcess();

                if (changedCountByTime == true && ProcessCountChanged != null)
                {
                    ProcessCountChangedEventArgs args =
                        new ProcessCountChangedEventArgs(ProcessName);

                    ProcessCountChanged(this, args);
                }

                System.Threading.Thread.Sleep(Interval);
            }
        }

        private bool ProcessCountProcess(System.Diagnostics.Process[] process)
        {
            int workCount = 0;

            if (MaxProcessCount != 1)
                workCount = MaxProcessCount - 1;
            else
                workCount = MaxProcessCount;

            System.Diagnostics.Debug.WriteLine(string.Format("PROCESS: {0} / {1}", workCount, MaxProcessCount));

            Dictionary<double, System.Diagnostics.Process> processMap
                = new Dictionary<double, System.Diagnostics.Process>();

            if (process.Length >= workCount)
            {
                foreach (System.Diagnostics.Process item in process)
                {
                    TimeSpan ts = DateTime.Now - item.StartTime;

                    if(processMap.ContainsKey(ts.TotalSeconds) == false)
                    {
                        processMap.Add(ts.TotalSeconds, item);
                    }
                }

                double tarketKey = 0;

                foreach (KeyValuePair<double, System.Diagnostics.Process> item in processMap)
                {
                    if (item.Key > tarketKey)
                        tarketKey = item.Key;
                }

                if (tarketKey == 0) return false;

                bool changed = false;
                try
                {
                    System.Diagnostics.Process item = processMap[tarketKey];
                    item.Kill();

                    changed = true;
                }
                catch (Exception)
                {
                    changed = false;
                }

                return changed;
            }
            else
            {
                return false;
            }
        }

        private bool ProcessTimeProcess()
        {
            System.Diagnostics.Process[] process =
                    System.Diagnostics.Process.GetProcessesByName(ProcessName);

            bool changed = false;

            foreach (System.Diagnostics.Process item in process)
            {
                TimeSpan ts = DateTime.Now - item.StartTime;

                if(ts.TotalSeconds > MaxProcessTimeSec)
                {
                    try
                    {
                        item.Kill();

                        changed = true;
                    }
                    catch(Exception)
                    {

                    }
                }
            }

            return changed;
        }
    }
}
