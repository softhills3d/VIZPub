using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VIZPubProcessMonitoringApp
{
    public partial class FrmMain : Form
    {
        private VIZPubProcessMonitoring.ProcessMonitoring Monitoring { get; set; }

        public FrmMain()
        {
            InitializeComponent();

            Monitoring = new VIZPubProcessMonitoring.ProcessMonitoring();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Monitoring.ProcessName = txtName.Text;
            Monitoring.MaxProcessCount = Convert.ToInt32(txtMaxCount.Value);
            Monitoring.MaxProcessTimeSec = Convert.ToInt32(txtMaxTime.Value) * 60;
            Monitoring.ProcessCountChanged += Monitoring_ProcessCountChanged;

            Monitoring.Start();

            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }

        private void Monitoring_ProcessCountChanged(object sender, VIZPubProcessMonitoring.ProcessCountChangedEventArgs e)
        {
            if(lbCount.InvokeRequired)
            {
                Action update = () =>
                {
                    UpdateCount(e.ProcessCount);
                };

                lbCount.BeginInvoke(update);
            }
            else
            {
                UpdateCount(e.ProcessCount);
            }
        }

        private void UpdateCount(int count)
        {
            lbCount.Text = count.ToString();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;

            if (Monitoring.IsRunning == false) return;

            Monitoring.Stop();
        }
    }
}
