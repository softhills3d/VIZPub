using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Publish2DManagerDemo
{
    public partial class FrmMain : Form
    {
        public string VIZPub_2D_Path { get; set; }


        public string VIZWeb2D_URI { get; set; }
        public string VIZWeb2D_IMAGE { get; set; }
        public string VIZWeb2D_NAVIGATION { get; set; }

        public FrmMain()
        {
            InitializeComponent();

            LoadConfiguration();
        }

        private void LoadConfiguration()
        {
            VIZPub_2D_Path = System.Configuration.ConfigurationManager.AppSettings.Get("VIZPub_2D");

            string uri = System.Configuration.ConfigurationManager.AppSettings.Get("VIZWeb2D_URI");
            string model = System.Configuration.ConfigurationManager.AppSettings.Get("VIZWeb2D_IMAGE_PATH");
            string navi = System.Configuration.ConfigurationManager.AppSettings.Get("VIZWeb2D_NAVIGATION_PATH");

            VIZWeb2D_URI = uri;
            txtUri.Text = uri;

            if (String.IsNullOrEmpty(model) == false)
            {
                if (System.IO.Directory.Exists(model) == true)
                {
                    VIZWeb2D_IMAGE = model;
                    txtModel.Text = model;
                }
            }

            if (String.IsNullOrEmpty(navi) == false)
            {
                if (System.IO.Directory.Exists(navi) == true)
                {
                    VIZWeb2D_NAVIGATION = navi;
                    txtNavigation.Text = navi;
                }
            }
        }

        private void btnNavigateTo_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(VIZWeb2D_URI) == true)
            {
                MessageBox.Show("URI is null.", "Publish Manager(Demo)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            System.Diagnostics.Process.Start("chrome.exe", VIZWeb2D_URI);
        }

        private void btnSelectModelPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (String.IsNullOrEmpty(VIZWeb2D_IMAGE) == false)
                dlg.SelectedPath = VIZWeb2D_IMAGE;

            if (dlg.ShowDialog() != DialogResult.OK) return;

            VIZWeb2D_IMAGE = dlg.SelectedPath;
            txtModel.Text = dlg.SelectedPath;
        }

        private void btnSelectNavigationPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (String.IsNullOrEmpty(VIZWeb2D_NAVIGATION) == false)
                dlg.SelectedPath = VIZWeb2D_NAVIGATION;

            if (dlg.ShowDialog() != DialogResult.OK) return;

            VIZWeb2D_NAVIGATION = dlg.SelectedPath;
            txtNavigation.Text = dlg.SelectedPath;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All (*.*) | *.dwg;*.dxf;*.dgn";
            dlg.Multiselect = true;
            if (dlg.ShowDialog() != DialogResult.OK) return;

            PublishImage(dlg.FileNames);
        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() != DialogResult.OK) return;

            string[] files = System.IO.Directory.GetFiles(dlg.SelectedPath, "*.*", System.IO.SearchOption.AllDirectories);

            List<string> items = new List<string>();

            foreach (string file in files)
            {
                string ext = System.IO.Path.GetExtension(file).ToUpper();

                if (ext != ".DWG" && ext != ".DXF" && ext != ".DGN") continue;

                items.Add(file);
            }

            if (items.Count == 0) return;

            PublishImage(items.ToArray());
        }

        private void PublishImage(string[] files)
        {
            this.Cursor = Cursors.WaitCursor;

            foreach (string input in files)
            {
                string name = System.IO.Path.GetFileNameWithoutExtension(input);
                string output_image = string.Format("{0}\\{1}.jpg", VIZWeb2D_IMAGE, name);

                if (rbVIZPub2D.Checked == true)
                {
                    VIZPub.ImageParameter parameter = new VIZPub.ImageParameter();

                    parameter.Add(VIZPub.ImageParameters.INPUT, input);
                    parameter.Add(VIZPub.ImageParameters.OUTPUT, output_image);

                    parameter.Add(VIZPub.ImageParameters.WIDTH, Convert.ToInt32(txtImageWidth.Text));
                    parameter.Add(VIZPub.ImageParameters.HEIGHT, Convert.ToInt32(txtImageHeight.Text));

                    DateTime start = DateTime.Now;

                    // Conversion
                    // Path : Ex) C:\SOFTHILLS\VIZPub2D\VIZPub2D.exe
                    VIZPub.ImageManager image = new VIZPub.ImageManager(VIZPub_2D_Path);
                    bool result = image.Export(parameter);

                    AddHistory(input, (string)parameter.GetValue(VIZPub.ImageParameters.OUTPUT), start, DateTime.Now, result);
                }
            }

            this.Cursor = Cursors.Default;
        }

        private void AddHistory(string input, string image, DateTime start, DateTime finish, bool result)
        {
            TimeSpan ts = finish - start;

            ListViewItem lvi = new ListViewItem(new string[]
                {
                    input
                    , result == true ? "OK" : "NG"
                    , start.ToString("HH:mm:ss")
                    , finish.ToString("HH:mm:ss")
                    , string.Format("{0:D2}:{1:D2}:{2:D2}", Convert.ToInt32(ts.TotalHours), Convert.ToInt32(ts.TotalMinutes), Convert.ToInt32(ts.TotalSeconds))
                    , image
                });

            lvHistory.Items.Add(lvi);
        }

        private void btnClearHistory_Click(object sender, EventArgs e)
        {
            lvHistory.Items.Clear();
        }

        private void btnExportHistory_Click(object sender, EventArgs e)
        {
            if (lvHistory.Items.Count == 0)
            {
                MessageBox.Show("History is null.", "Publish Manager(Demo)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "CSV (*.csv)|*.csv";

            if (dlg.ShowDialog() != DialogResult.OK) return;

            System.IO.StreamWriter sw = new System.IO.StreamWriter(dlg.FileName, true, Encoding.UTF8);

            sw.WriteLine("Name,Status,Start,Finish,Elapsed,VIZ,VIZW");

            for (int i = 0; i < lvHistory.Items.Count; i++)
            {
                ListViewItem lvi = lvHistory.Items[i];

                sw.WriteLine(
                    string.Format("{0},{1},{2},{3},{4},{5},{6}"
                    , lvi.SubItems[0].Text
                    , lvi.SubItems[1].Text
                    , lvi.SubItems[2].Text
                    , lvi.SubItems[3].Text
                    , lvi.SubItems[4].Text
                    , lvi.SubItems[5].Text
                    )
                    );
            }

            sw.Close();
        }

        private void btnExportNavigation_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(VIZWeb2D_NAVIGATION) == true) return;
            if (System.IO.Directory.Exists(VIZWeb2D_NAVIGATION) == false) return;

            if (String.IsNullOrEmpty(VIZWeb2D_IMAGE) == true) return;
            if (System.IO.Directory.Exists(VIZWeb2D_IMAGE) == false) return;

            string path = System.IO.Path.Combine(VIZWeb2D_NAVIGATION, "model.json");

            string[] dirs = System.IO.Directory.GetDirectories(VIZWeb2D_IMAGE, "*.*", System.IO.SearchOption.TopDirectoryOnly);

            if (dirs == null || dirs.Length == 0) return;

            System.IO.StreamWriter sw = new System.IO.StreamWriter(path, false, Encoding.UTF8);

            sw.WriteLine("[");

            sw.WriteLine("{ \"key\": \"1\", \"title\": \"Models\", \"expanded\": true, \"folder\": true, \"children\": [");

            for (int i = 0; i < dirs.Length; i++)
            {
                int id = i + 1;
                string name = new System.IO.DirectoryInfo(dirs[i]).Name;

                if(i < dirs.Length - 1)
                    sw.WriteLine("{ \"key\": \"1_" + id.ToString() + "\", \"title\": \"" + name + "\", \"expanded\": true, \"folder\": true },");
                else
                    sw.WriteLine("{ \"key\": \"1_" + id.ToString() + "\", \"title\": \"" + name + "\", \"expanded\": true, \"folder\": true }");
            }

            sw.WriteLine("]");

            sw.WriteLine("}");

            sw.WriteLine("]");

            sw.Close();
        }
    }
}
