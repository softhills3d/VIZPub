using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VIZPub.Test.App.View
{
    public partial class ThumbnailUI : UserControl
    {
        public ThumbnailUI()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "VIZ File (*.viz)|*.viz";
            if (dlg.ShowDialog() != DialogResult.OK) return;

            txtPath.Text = dlg.FileName;

            ExportThumbnail(dlg.FileName);
        }

        public void ExportThumbnail(string path)
        {
            string output = string.Format("{0}\\{1}.png", System.IO.Path.GetDirectoryName(path), System.IO.Path.GetFileNameWithoutExtension(path));

            VIZPub.PublishParameter parameter = new PublishParameter();

            parameter.Add(PublishParameters.INPUT, path);
            parameter.Add(PublishParameters.THUMBNAIL_WIDTH, 400);
            parameter.Add(PublishParameters.THUMBNAIL_HEIGHT, 300);
            parameter.Add(PublishParameters.THUMBNAIL_VIEW_DIRECTION, ViewDirection.ISO_PLUS);
            parameter.Add(PublishParameters.THUMBNAIL_IMAGE_FORMAT, ImageFormat.PNG);
            parameter.Add(PublishParameters.THUMBNAIL_IMAGE_NODE_UNIT, NodeUnit.ALL_MODEL);
            parameter.Add(PublishParameters.THUMBNAIL_IMAGE_NAME, NameKind.NONE);
            //parameter.Add(PublishParameters.THUMBNAIL_IMAGE_MATRIX, "");
            parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model.png");

            // VIZPub
            // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
            VIZPub.PublishManager publish = new PublishManager(Configuration.VIZPub_EXE);
            bool result = publish.ExportImage(parameter);

            if (result == false) return;

            pbThumbnail.Image = Image.FromFile(output);
        }
    }
}
