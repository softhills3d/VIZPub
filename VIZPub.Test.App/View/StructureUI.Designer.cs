namespace VIZPub.Test.App.View
{
    partial class StructureUI
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StructureUI));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tvStructure = new System.Windows.Forms.TreeView();
            this.imgTree = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tcUDA = new System.Windows.Forms.TabControl();
            this.tpList = new System.Windows.Forms.TabPage();
            this.tpTree = new System.Windows.Forms.TabPage();
            this.tpSelected = new System.Windows.Forms.TabPage();
            this.lvNodes = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvUDA = new System.Windows.Forms.ListView();
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvSelectedUDA = new System.Windows.Forms.ListView();
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tvUDA = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tcUDA.SuspendLayout();
            this.tpList.SuspendLayout();
            this.tpTree.SuspendLayout();
            this.tpSelected.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(834, 494);
            this.splitContainer1.SplitterDistance = 309;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tvStructure);
            this.groupBox2.Location = new System.Drawing.Point(3, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(301, 426);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tree";
            // 
            // tvStructure
            // 
            this.tvStructure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvStructure.ImageIndex = 0;
            this.tvStructure.ImageList = this.imgTree;
            this.tvStructure.Location = new System.Drawing.Point(3, 17);
            this.tvStructure.Name = "tvStructure";
            this.tvStructure.SelectedImageIndex = 0;
            this.tvStructure.Size = new System.Drawing.Size(295, 406);
            this.tvStructure.TabIndex = 0;
            this.tvStructure.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvStructure_AfterSelect);
            // 
            // imgTree
            // 
            this.imgTree.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgTree.ImageStream")));
            this.imgTree.TransparentColor = System.Drawing.Color.Transparent;
            this.imgTree.Images.SetKeyName(0, "MODEL.png");
            this.imgTree.Images.SetKeyName(1, "ASSEMBLY.png");
            this.imgTree.Images.SetKeyName(2, "PART.png");
            this.imgTree.Images.SetKeyName(3, "BODY.png");
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnOpen);
            this.groupBox1.Controls.Add(this.txtPath);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Model (VIZ)";
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Location = new System.Drawing.Point(220, 20);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(15, 20);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(199, 21);
            this.txtPath.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tcUDA);
            this.splitContainer2.Size = new System.Drawing.Size(521, 494);
            this.splitContainer2.SplitterDistance = 268;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lvNodes);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(521, 268);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Nodes";
            // 
            // tcUDA
            // 
            this.tcUDA.Controls.Add(this.tpList);
            this.tcUDA.Controls.Add(this.tpTree);
            this.tcUDA.Controls.Add(this.tpSelected);
            this.tcUDA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcUDA.Location = new System.Drawing.Point(0, 0);
            this.tcUDA.Name = "tcUDA";
            this.tcUDA.SelectedIndex = 0;
            this.tcUDA.Size = new System.Drawing.Size(521, 222);
            this.tcUDA.TabIndex = 0;
            // 
            // tpList
            // 
            this.tpList.Controls.Add(this.lvUDA);
            this.tpList.Location = new System.Drawing.Point(4, 22);
            this.tpList.Name = "tpList";
            this.tpList.Padding = new System.Windows.Forms.Padding(3);
            this.tpList.Size = new System.Drawing.Size(513, 196);
            this.tpList.TabIndex = 0;
            this.tpList.Text = "List";
            this.tpList.UseVisualStyleBackColor = true;
            // 
            // tpTree
            // 
            this.tpTree.Controls.Add(this.tvUDA);
            this.tpTree.Location = new System.Drawing.Point(4, 22);
            this.tpTree.Name = "tpTree";
            this.tpTree.Padding = new System.Windows.Forms.Padding(3);
            this.tpTree.Size = new System.Drawing.Size(513, 196);
            this.tpTree.TabIndex = 1;
            this.tpTree.Text = "Tree";
            this.tpTree.UseVisualStyleBackColor = true;
            // 
            // tpSelected
            // 
            this.tpSelected.Controls.Add(this.lvSelectedUDA);
            this.tpSelected.Location = new System.Drawing.Point(4, 22);
            this.tpSelected.Name = "tpSelected";
            this.tpSelected.Padding = new System.Windows.Forms.Padding(3);
            this.tpSelected.Size = new System.Drawing.Size(513, 196);
            this.tpSelected.TabIndex = 2;
            this.tpSelected.Text = "Selected";
            this.tpSelected.UseVisualStyleBackColor = true;
            // 
            // lvNodes
            // 
            this.lvNodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader5,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader7,
            this.columnHeader6});
            this.lvNodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvNodes.FullRowSelect = true;
            this.lvNodes.GridLines = true;
            this.lvNodes.HideSelection = false;
            this.lvNodes.Location = new System.Drawing.Point(3, 17);
            this.lvNodes.Name = "lvNodes";
            this.lvNodes.Size = new System.Drawing.Size(515, 248);
            this.lvNodes.TabIndex = 0;
            this.lvNodes.UseCompatibleStateImageBehavior = false;
            this.lvNodes.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "PARENT";
            this.columnHeader2.Width = 76;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "NAME";
            this.columnHeader3.Width = 88;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "KIND";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "DEPTH";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "PATH";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "BOUNDBOX";
            this.columnHeader7.Width = 98;
            // 
            // lvUDA
            // 
            this.lvUDA.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.lvUDA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvUDA.FullRowSelect = true;
            this.lvUDA.GridLines = true;
            this.lvUDA.HideSelection = false;
            this.lvUDA.Location = new System.Drawing.Point(3, 3);
            this.lvUDA.Name = "lvUDA";
            this.lvUDA.Size = new System.Drawing.Size(507, 190);
            this.lvUDA.TabIndex = 1;
            this.lvUDA.UseCompatibleStateImageBehavior = false;
            this.lvUDA.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "ID";
            this.columnHeader8.Width = 88;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "KEY";
            this.columnHeader9.Width = 135;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "VALUE";
            this.columnHeader10.Width = 130;
            // 
            // lvSelectedUDA
            // 
            this.lvSelectedUDA.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13});
            this.lvSelectedUDA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSelectedUDA.FullRowSelect = true;
            this.lvSelectedUDA.GridLines = true;
            this.lvSelectedUDA.HideSelection = false;
            this.lvSelectedUDA.Location = new System.Drawing.Point(3, 3);
            this.lvSelectedUDA.Name = "lvSelectedUDA";
            this.lvSelectedUDA.Size = new System.Drawing.Size(507, 190);
            this.lvSelectedUDA.TabIndex = 2;
            this.lvSelectedUDA.UseCompatibleStateImageBehavior = false;
            this.lvSelectedUDA.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "ID";
            this.columnHeader11.Width = 88;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "KEY";
            this.columnHeader12.Width = 135;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "VALUE";
            this.columnHeader13.Width = 130;
            // 
            // tvUDA
            // 
            this.tvUDA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvUDA.Location = new System.Drawing.Point(3, 3);
            this.tvUDA.Name = "tvUDA";
            this.tvUDA.Size = new System.Drawing.Size(507, 190);
            this.tvUDA.TabIndex = 0;
            // 
            // StructureUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "StructureUI";
            this.Size = new System.Drawing.Size(834, 494);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tcUDA.ResumeLayout(false);
            this.tpList.ResumeLayout(false);
            this.tpTree.ResumeLayout(false);
            this.tpSelected.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.TreeView tvStructure;
        private System.Windows.Forms.ImageList imgTree;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabControl tcUDA;
        private System.Windows.Forms.TabPage tpList;
        private System.Windows.Forms.TabPage tpTree;
        private System.Windows.Forms.TabPage tpSelected;
        private System.Windows.Forms.ListView lvNodes;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ListView lvUDA;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ListView lvSelectedUDA;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.TreeView tvUDA;
    }
}
