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

        public Dictionary<int, List<VIZPub.AttributeItem>> UDA { get; set; }

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
            string output_metadata = string.Format("{0}\\{1}_Metadata.txt", System.IO.Path.GetDirectoryName(path), System.IO.Path.GetFileNameWithoutExtension(path));
            string output_attribute = string.Format("{0}\\{1}_Attribute.txt", System.IO.Path.GetDirectoryName(path), System.IO.Path.GetFileNameWithoutExtension(path));

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

                ShowNodes(items);
            }

            // Export Attribute
            {
                VIZPub.PublishParameter parameter = new PublishParameter();

                parameter.Add(PublishParameters.INPUT, path);
                parameter.Add(PublishParameters.OUTPUT, output_attribute);

                parameter.Add(PublishParameters.INCLUDE_BODY_ATTRIBUTE, true);                  // [Optional] True or False. Default(False)

                // VIZPub
                // Path : Ex) C:\SOFTHILLS\VIZPub\VIZPub.exe
                VIZPub.PublishManager publish = new PublishManager(Configuration.VIZPub_EXE);
                bool result_Attribute = publish.ExportAttribute(parameter);

                if (result_Attribute == false) return;

                VIZPub.AttributeLoader loader = new AttributeLoader();
                Dictionary<int, List<VIZPub.AttributeItem>> uda = new Dictionary<int, List<AttributeItem>>();
                loader.Load(output_attribute, out uda);
                UDA = uda;

                ShowUDA(uda);
                ShowUDATree(loader);
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

                //if (node.Kind == Node.NodeKind.BODY) continue;

                string name = node.Name;
                if (String.IsNullOrEmpty(name) == true)
                    name = string.Format("BODY ({0})", node.ID);

                TreeNode tNode = new TreeNode(name);
                tNode.Tag = node;

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

        public void ShowNodes (List<VIZPub.Node> items)
        {
            lvNodes.BeginUpdate();

            lvNodes.Items.Clear();

            for (int i = 0; i < items.Count; i++)
            {
                VIZPub.Node node = items[i];

                //if (node.Kind == Node.NodeKind.BODY) continue;

                string name = node.Name;
                if (String.IsNullOrEmpty(name) == true)
                    name = string.Format("BODY ({0})", node.ID);

                ListViewItem lvi = new ListViewItem(
                    new string[] 
                    {
                        node.ID.ToString()
                        , node.PARENTID.ToString()
                        , node.Depth.ToString()
                        , name
                        , node.Kind.ToString()
                        , string.Format("{0}, {1}, {2}, {3}, {4}, {5}"
                            , Convert.ToInt32(node.BoundBoxMinX)
                            , Convert.ToInt32(node.BoundBoxMinY)
                            , Convert.ToInt32(node.BoundBoxMinZ)
                            , Convert.ToInt32(node.BoundBoxMaxX)
                            , Convert.ToInt32(node.BoundBoxMaxY)
                            , Convert.ToInt32(node.BoundBoxMaxZ)
                        )
                        , node.NodePath
                    }
                    );
                lvNodes.Items.Add(lvi);
            }

            lvNodes.EndUpdate();
        }

        public void ShowUDA(Dictionary<int, List<VIZPub.AttributeItem>> uda)
        {
            lvUDA.BeginUpdate();
            lvUDA.Items.Clear();

            foreach (KeyValuePair<int, List<VIZPub.AttributeItem>> item in uda)
            {
                foreach (VIZPub.AttributeItem vals in item.Value)
                {
                    ListViewItem lvi = new ListViewItem(new string[] { item.Key.ToString(), vals.Key, vals.Value });
                    lvUDA.Items.Add(lvi);
                }
            }

            lvUDA.EndUpdate();
        }

        public void ShowUDATree(VIZPub.AttributeLoader loader)
        {
            tvUDA.BeginUpdate();

            tvUDA.Nodes.Clear();

            TreeNode root = new TreeNode("UDA");
            tvUDA.Nodes.Add(root);

            List<string> keys = loader.GetKeys();
            foreach (string key in keys)
            {
                TreeNode node = new TreeNode(key);
                root.Nodes.Add(node);

                List<string> valuse = loader.GetValues(key);
                foreach (string value in valuse)
                {
                    TreeNode vNode = new TreeNode(value);
                    node.Nodes.Add(vNode);
                }
            }

            root.Expand();

            tvUDA.EndUpdate();
        }

        private void tvStructure_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            if (node == null) return;

            VIZPub.Node vNode = (VIZPub.Node)node.Tag;
            if (vNode == null) return;

            if (UDA == null) return;
            if (UDA.ContainsKey(vNode.ID) == false) return;

            List<VIZPub.AttributeItem> items = UDA[vNode.ID];
            lvSelectedUDA.BeginUpdate();
            lvSelectedUDA.Items.Clear();
            foreach (VIZPub.AttributeItem item in items)
            {
                ListViewItem lvi = new ListViewItem(new string[] { item.NodeID.ToString(), item.Key, item.Value });
                lvSelectedUDA.Items.Add(lvi);
            }
            lvSelectedUDA.EndUpdate();
        }
    }
}
