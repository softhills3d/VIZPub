using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Publish3DManagerDemo
{
    public partial class FrmMain : Form
    {
        public string VIZPub_Manager_Path { get; set; }
        public string VIZPub_Mechanical_Path { get; set; }
        public string VIZPub_BOM_Path { get; set; }
        public string VIZPub_2D_Path { get; set; }


        public string VIZWide3D_URI { get; set; }
        public string VIZWide3D_MODEL { get; set; }
        public string VIZWide3D_NAVIGATION { get; set; }

        public FrmMain()
        {
            InitializeComponent();

            LoadConfiguration();
        }

        private void LoadConfiguration()
        {
            VIZPub_Manager_Path = System.Configuration.ConfigurationManager.AppSettings.Get("VIZPub_Manager");
            VIZPub_Mechanical_Path = System.Configuration.ConfigurationManager.AppSettings.Get("VIZPub_Mechanical");
            VIZPub_BOM_Path = System.Configuration.ConfigurationManager.AppSettings.Get("VIZPub_BOM");
            VIZPub_2D_Path = System.Configuration.ConfigurationManager.AppSettings.Get("VIZPub_2D");


            string uri = System.Configuration.ConfigurationManager.AppSettings.Get("VIZWide3D_URI");
            string model = System.Configuration.ConfigurationManager.AppSettings.Get("VIZWide3D_VIZW_PATH");
            string navi = System.Configuration.ConfigurationManager.AppSettings.Get("VIZWide3D_NAVIGATION_PATH");

            VIZWide3D_URI = uri;
            txtUri.Text = uri;

            if (String.IsNullOrEmpty(model) == false)
            {
                if (System.IO.Directory.Exists(model) == true)
                {
                    VIZWide3D_MODEL = model;
                    txtModel.Text = model;
                }
            }

            if (String.IsNullOrEmpty(navi) == false)
            {
                if (System.IO.Directory.Exists(navi) == true)
                {
                    VIZWide3D_NAVIGATION = navi;
                    txtNavigation.Text = navi;
                }
            }
        }

        private void btnNavigateTo_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(VIZWide3D_URI) == true)
            {
                MessageBox.Show("URI is null.", "Publish Manager(Demo)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            System.Diagnostics.Process.Start("chrome.exe", VIZWide3D_URI);
        }

        private void btnSelectModelPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (String.IsNullOrEmpty(VIZWide3D_MODEL) == false)
                dlg.SelectedPath = VIZWide3D_MODEL;

            if (dlg.ShowDialog() != DialogResult.OK) return;

            VIZWide3D_MODEL = dlg.SelectedPath;
            txtModel.Text = dlg.SelectedPath;
        }

        private void btnSelectNavigationPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (String.IsNullOrEmpty(VIZWide3D_NAVIGATION) == false)
                dlg.SelectedPath = VIZWide3D_NAVIGATION;

            if (dlg.ShowDialog() != DialogResult.OK) return;

            VIZWide3D_NAVIGATION = dlg.SelectedPath;
            txtNavigation.Text = dlg.SelectedPath;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All (*.*) | *.*";
            if (dlg.ShowDialog() != DialogResult.OK) return;

            string input = dlg.FileName;

            PublishVIZW(input);
        }

        private void PublishVIZW(string input)
        {
            string name = System.IO.Path.GetFileNameWithoutExtension(input);
            string output_viz = string.Format("{0}\\{1}.viz", VIZWide3D_MODEL, name);
            string output_vizw_path = string.Format("{0}\\{1}", VIZWide3D_MODEL, name);
            string output_vizw = string.Format("{0}\\{1}.vizw", output_vizw_path, name);

            if (System.IO.Directory.Exists(output_vizw_path) == false)
            {
                System.IO.Directory.CreateDirectory(output_vizw_path);
            }
            else
            {
                string[] files = System.IO.Directory.GetFiles(output_vizw_path);
                foreach (string file in files)
                {
                    System.IO.File.Delete(file);
                }
            }

            this.Cursor = Cursors.WaitCursor;

            if (rbVIZPubManager.Checked == true)
            {
                VIZPub.PublishParameter parameter = new VIZPub.PublishParameter();

                parameter.Add(VIZPub.PublishParameters.INPUT, input);
                parameter.Add(VIZPub.PublishParameters.OUTPUT, output_vizw_path);

                parameter.Add(VIZPub.PublishParameters.GENERATE_EDGE, true);                                    // [Optional] True or False. Default(True)
                parameter.Add(VIZPub.PublishParameters.GENERATE_THUMBNAIL, true);                               // [Optional] True or False. Default(True)

                parameter.Add(VIZPub.PublishParameters.CYLINDER_SIDE_COUNT_NORMAL, 12);                         // [Optional] 6 ~ 36. Default(12)
                parameter.Add(VIZPub.PublishParameters.CYLINDER_SIDE_COUNT_SMALL, 6);                           // [Optional] 6 ~ 36. Default(6)

                parameter.Add(VIZPub.PublishParameters.REMOVE_NODENAME_SLASH, false);                           // [Optional] True or False. Default(False)

                parameter.Add(VIZPub.PublishParameters.VERSION, 303);                                           // [Optional] 303 or 304. Default(303)

                parameter.Add(VIZPub.PublishParameters.NODE_MERGE_OPTIONS, VIZPub.NodeMergeOptions.AS_IS);      // [Optional] As-Is. Default(As-Is) 

                parameter.Add(VIZPub.PublishParameters.LOG, VIZPub.LogKind.INFORMATION);                        // [Optional] Default(None)

                parameter.Add(VIZPub.PublishParameters.COMPRESS_VIZW, true);                                    // [Optional] Default(False)

                DateTime start = DateTime.Now;

                // VIZPub
                // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
                VIZPub.PublishManager publish = new VIZPub.PublishManager(VIZPub_Manager_Path);
                bool result = publish.ExportVIZWide3D(parameter);

                AddHistory(input, "", output_vizw_path, start, DateTime.Now, result);
            }
            else if (rbVIZPubMechanical.Checked == true)
            {
                VIZPub.TranslateParameter parameter = new VIZPub.TranslateParameter();

                parameter.Add(VIZPub.TranslateParameters.INPUT, input);                       // INPUT FILE 경로(절대경로)
                parameter.Add(VIZPub.TranslateParameters.OUTPUT, output_viz);                      // OUTPUT FILE 경로(절대경로)
                parameter.Add(VIZPub.TranslateParameters.LOG, VIZPub.TranslateLog.OUTPUT_ALWAYS);                   // 결과 XML 생성 여부

                //parameter.Add(VIZPub.TranslateParameters.CAD2CAD, "C:\\Temp");                                    // CAD to CAD XML 경로

                parameter.Add(VIZPub.TranslateParameters.MASS_PROPERTY, false);                                     // [Optional] True or False. Default(False), Mass Property 사용 여부
                parameter.Add(VIZPub.TranslateParameters.TESSELLATION_QUALITY, VIZPub.TesselationQuality.Normal);   // [Optional] Default(Normal), Tessellation 품질

                parameter.Add(VIZPub.TranslateParameters.OUTPUT_VIZW_PATH, output_vizw);   // [Optional] VIZW 추출 경로

                //parameter.Add(VIZPub.TranslateParameters.OUTPUT_THUMBNAIL, false);                                  // [Optional] Default(False), 썸네일 EXPORT 여부
                //parameter.Add(VIZPub.TranslateParameters.OUTPUT_THUMBNAIL_PATH, "C:\\Temp\\sample");           // [Optional] Thumbnail 추출 경로
                //parameter.Add(VIZPub.TranslateParameters.THUMBNAIL_IMAGE_WIDTH, 400);                          // [Optional] Default(400), Thumbnail Image 너비값
                //parameter.Add(VIZPub.TranslateParameters.THUMBNAIL_IMAGE_HEIGHT, 300);                         // [Optional] Default(300), Thumbnail Image 높이값
                //parameter.Add(VIZPub.TranslateParameters.THUMBNAIL_DEFAULT_VIEW, 0);                           // [Optional] Default(0), Thumbnail defualt

                parameter.Add(VIZPub.TranslateParameters.VIZ_VERSION, VIZPub.VIZVersion.V302);                   // [Optional] Default(302), VIZ FILE 버전
                parameter.Add(VIZPub.TranslateParameters.SPLIT_COUNT, 1);                                        // [Optional] Default(1), VIZW 파일분할 개수

                parameter.Add(VIZPub.TranslateParameters.HEALING, false);                                       // [Optional] Default(False), Healing 여부
                parameter.Add(VIZPub.TranslateParameters.FREE_POINT, false);                                    // [Optional] Default(False), Free Point 변환 여부
                parameter.Add(VIZPub.TranslateParameters.FREE_CURVE, false);                                    // [Optional] Default(False), Free Curve 변환 여부
                parameter.Add(VIZPub.TranslateParameters.HIDDEN_ENTITY, false);                                 // [Optional] Default(False), Hidden Entity 변환 여부
                parameter.Add(VIZPub.TranslateParameters.SUPRESSED_ENTITY, false);                              // [Optional] Default(False), Supressed Entity 변환 여부

                parameter.Add(VIZPub.TranslateParameters.REFERENCE_NAME, false);                                // [Optional] Default(False), Hoops Reference Name 사용 여부 
                parameter.Add(VIZPub.TranslateParameters.ASSEMBLY_ONLY, false);                                 // [Optional] Default(False), Assembly만 변환할 것인지 여부 
                parameter.Add(VIZPub.TranslateParameters.BODY_TO_PART, false);                                  // [Optional] Default(False), Body를 Part로 변환할 것인지 여부
                parameter.Add(VIZPub.TranslateParameters.FREE_SURFACE, false);                                  // [Optional] Default(False), Free Surface 변환 여부 
                parameter.Add(VIZPub.TranslateParameters.VISIBLE_LAYER_ONLY, false);                            // [Optional] Default(False), Visible Layer만 변환할 것인지 여부 

                parameter.Add(VIZPub.TranslateParameters.COMPRESSION, true);                                    // [Optional] Compress VIZW

                DateTime start = DateTime.Now;

                VIZPub.TranslateManager translate = new VIZPub.TranslateManager(VIZPub_Mechanical_Path);
                bool result = translate.ExportVIZW(parameter);

                AddHistory(input, output_viz, output_vizw_path, start, DateTime.Now, result);

                ClearTempVIZ(VIZWide3D_MODEL);
            }
            else if (rbVIZPubBOM.Checked == true)
            {

            }

            this.Cursor = Cursors.Default;
        }

        private void AddHistory(string input, string viz, string vizw, DateTime start, DateTime finish, bool result)
        {
            TimeSpan ts = finish - start;

            ListViewItem lvi = new ListViewItem(new string[]
                {
                    input
                    , result == true ? "OK" : "NG"
                    , start.ToString("HH:mm:ss")
                    , finish.ToString("HH:mm:ss")
                    , string.Format("{0:D2}:{1:D2}:{2:D2}", Convert.ToInt32(ts.TotalHours), Convert.ToInt32(ts.TotalMinutes), Convert.ToInt32(ts.TotalSeconds))
                    , viz
                    , vizw
                });

            lvHistory.Items.Add(lvi);
        }

        private void ClearTempVIZ(string path)
        {
            if (String.IsNullOrEmpty(path) == true) return;
            if (System.IO.Directory.Exists(path) == false) return;

            string[] files = System.IO.Directory.GetFiles(path, "*_wm_*.viz", System.IO.SearchOption.TopDirectoryOnly);

            foreach (string file in files)
            {
                System.IO.File.Delete(file);
            }
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
                    , lvi.SubItems[6].Text
                    )
                    );
            }

            sw.Close();
        }

        private void btnExportNavigation_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(VIZWide3D_NAVIGATION) == true) return;
            if (System.IO.Directory.Exists(VIZWide3D_NAVIGATION) == false) return;

            if (String.IsNullOrEmpty(VIZWide3D_MODEL) == true) return;
            if (System.IO.Directory.Exists(VIZWide3D_MODEL) == false) return;

            string path = System.IO.Path.Combine(VIZWide3D_NAVIGATION, "model.json");

            string[] dirs = System.IO.Directory.GetDirectories(VIZWide3D_MODEL, "*.*", System.IO.SearchOption.TopDirectoryOnly);

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
