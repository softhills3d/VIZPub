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
    public partial class StructureUI : UserControl
    {
        public Dictionary<int, List<VIZPub.Node>> Relation { get; set; }

        public StructureUI()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "VIZ File (*.viz)|*.viz";
            if (dlg.ShowDialog() != DialogResult.OK) return;

            txtPath.Text = dlg.FileName;

            ExportMetadata(dlg.FileName);
        }

        private void ExportMetadata(string path)
        {
            string output_metadata = string.Format("{0}\\{1}.txt", System.IO.Path.GetDirectoryName(path), System.IO.Path.GetFileNameWithoutExtension(path));

            // Export Metadata
            {
                VIZPub.PublishParameter parameter = new PublishParameter();

                parameter.Add(PublishParameters.INPUT, path);
                parameter.Add(PublishParameters.OUTPUT, output_metadata);

                // VIZPub
                // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
                VIZPub.PublishManager publish = new PublishManager(Configuration.VIZPub_EXE);
                bool result_Metadata = publish.ExportMetadata(parameter);

                if (result_Metadata == false) return;
            }

            // Load Metadata
            {
                VIZPub.MetadataLoader loader = new MetadataLoader();

                List<VIZPub.Node> items = new List<VIZPub.Node>();

                bool result = loader.Load(output_metadata, out items);

                if (result == false) return;

                if (items.Count == 0) return;

                Relation = items[0].Relation;

                ShowStructure(path, items);
            }

            // Export Attribute
            {
                VIZPub.PublishParameter parameter = new PublishParameter();

                parameter.Add(PublishParameters.INPUT, "C:\\Temp\\Model_Attribute.viz");
                parameter.Add(PublishParameters.OUTPUT, "C:\\Temp\\Model_Attribute.txt");

                parameter.Add(PublishParameters.INCLUDE_BODY_ATTRIBUTE, true);                  // [Optional] True or False. Default(False)

                // VIZPub
                // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
                VIZPub.PublishManager publish = new PublishManager(Configuration.VIZPub_EXE);
                bool result_Attribute = publish.ExportAttribute(parameter);

                if (result_Attribute == false) return;
            }
        }

        public void ShowStructure(string path, List<VIZPub.Node> items)
        {
            tvStructure.BeginUpdate();

            tvStructure.Nodes.Clear();

            string name = System.IO.Path.GetFileNameWithoutExtension(path).ToUpper();
            TreeNode root = new TreeNode(name);
            root.ImageIndex = 0;
            root.SelectedImageIndex = 0;

            BindStructure(root, null);

            root.Expand();
            tvStructure.Nodes.Add(root);

            tvStructure.EndUpdate();
        }

        public void BindStructure(TreeNode parentNode, VIZPub.Node item)
        {
            List<VIZPub.Node> children = null;

            if (item == null)
            {
                if (Relation.ContainsKey(-1) == false) return;

                children = Relation[-1];
            }
            else
            {
                if (Relation.ContainsKey(item.ID) == false) return;

                children = Relation[item.ID];
            }

            if (children == null) return;

            for (int i = 0; i < children.Count; i++)
            {
                VIZPub.Node node = children[i];

                string name = node.Name;
                if (String.IsNullOrEmpty(name) == true)
                    name = string.Format("BODY ({0})", node.ID);

                TreeNode tNode = new TreeNode(name);

                switch (node.Kind)
                {
                    case Node.NodeKind.ASSEMBLY:
                        tNode.ImageIndex = 1;
                        tNode.SelectedImageIndex = 1;
                        break;
                    case Node.NodeKind.PART:
                        tNode.ImageIndex = 2;
                        tNode.SelectedImageIndex = 2;
                        break;
                    case Node.NodeKind.BODY:
                        tNode.ImageIndex = 3;
                        tNode.SelectedImageIndex = 3;
                        break;
                    default:
                        break;
                }

                BindStructure(tNode, node);

                parentNode.Nodes.Add(tNode);
            }
        }
    }
}
