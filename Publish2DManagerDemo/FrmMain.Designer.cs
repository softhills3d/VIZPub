namespace Publish2DManagerDemo
{
    partial class FrmMain
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.btnExportNavigation = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnNavigateTo = new System.Windows.Forms.Button();
            this.btnSelectNavigationPath = new System.Windows.Forms.Button();
            this.btnSelectModelPath = new System.Windows.Forms.Button();
            this.txtNavigation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.txtUri = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtImageHeight = new System.Windows.Forms.TextBox();
            this.txtImageWidth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rbVIZPub2D = new System.Windows.Forms.RadioButton();
            this.btnExportHistory = new System.Windows.Forms.Button();
            this.btnClearHistory = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lvHistory = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnSelectPath);
            this.splitContainer1.Panel1.Controls.Add(this.btnExportNavigation);
            this.splitContainer1.Panel1.Controls.Add(this.btnOpen);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnExportHistory);
            this.splitContainer1.Panel2.Controls.Add(this.btnClearHistory);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(1014, 498);
            this.splitContainer1.SplitterDistance = 430;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Location = new System.Drawing.Point(108, 255);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(90, 23);
            this.btnSelectPath.TabIndex = 7;
            this.btnSelectPath.Text = "Select Path";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // btnExportNavigation
            // 
            this.btnExportNavigation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportNavigation.Location = new System.Drawing.Point(346, 255);
            this.btnExportNavigation.Name = "btnExportNavigation";
            this.btnExportNavigation.Size = new System.Drawing.Size(75, 23);
            this.btnExportNavigation.TabIndex = 6;
            this.btnExportNavigation.Text = "Export";
            this.btnExportNavigation.UseVisualStyleBackColor = true;
            this.btnExportNavigation.Click += new System.EventHandler(this.btnExportNavigation_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(12, 255);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(90, 23);
            this.btnOpen.TabIndex = 5;
            this.btnOpen.Text = "Open Files";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnNavigateTo);
            this.groupBox2.Controls.Add(this.btnSelectNavigationPath);
            this.groupBox2.Controls.Add(this.btnSelectModelPath);
            this.groupBox2.Controls.Add(this.txtNavigation);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtModel);
            this.groupBox2.Controls.Add(this.txtUri);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(409, 126);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "VIZWeb2D Path";
            // 
            // btnNavigateTo
            // 
            this.btnNavigateTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNavigateTo.Location = new System.Drawing.Point(327, 20);
            this.btnNavigateTo.Name = "btnNavigateTo";
            this.btnNavigateTo.Size = new System.Drawing.Size(75, 23);
            this.btnNavigateTo.TabIndex = 8;
            this.btnNavigateTo.Text = "Navigate";
            this.btnNavigateTo.UseVisualStyleBackColor = true;
            this.btnNavigateTo.Click += new System.EventHandler(this.btnNavigateTo_Click);
            // 
            // btnSelectNavigationPath
            // 
            this.btnSelectNavigationPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectNavigationPath.Location = new System.Drawing.Point(327, 87);
            this.btnSelectNavigationPath.Name = "btnSelectNavigationPath";
            this.btnSelectNavigationPath.Size = new System.Drawing.Size(75, 23);
            this.btnSelectNavigationPath.TabIndex = 7;
            this.btnSelectNavigationPath.Text = "Select";
            this.btnSelectNavigationPath.UseVisualStyleBackColor = true;
            this.btnSelectNavigationPath.Click += new System.EventHandler(this.btnSelectNavigationPath_Click);
            // 
            // btnSelectModelPath
            // 
            this.btnSelectModelPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectModelPath.Location = new System.Drawing.Point(328, 54);
            this.btnSelectModelPath.Name = "btnSelectModelPath";
            this.btnSelectModelPath.Size = new System.Drawing.Size(75, 23);
            this.btnSelectModelPath.TabIndex = 6;
            this.btnSelectModelPath.Text = "Select";
            this.btnSelectModelPath.UseVisualStyleBackColor = true;
            this.btnSelectModelPath.Click += new System.EventHandler(this.btnSelectModelPath_Click);
            // 
            // txtNavigation
            // 
            this.txtNavigation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNavigation.Location = new System.Drawing.Point(63, 87);
            this.txtNavigation.Name = "txtNavigation";
            this.txtNavigation.ReadOnly = true;
            this.txtNavigation.Size = new System.Drawing.Size(258, 21);
            this.txtNavigation.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Navi.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Image";
            // 
            // txtModel
            // 
            this.txtModel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtModel.Location = new System.Drawing.Point(63, 54);
            this.txtModel.Name = "txtModel";
            this.txtModel.ReadOnly = true;
            this.txtModel.Size = new System.Drawing.Size(258, 21);
            this.txtModel.TabIndex = 2;
            // 
            // txtUri
            // 
            this.txtUri.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUri.Location = new System.Drawing.Point(63, 20);
            this.txtUri.Name = "txtUri";
            this.txtUri.Size = new System.Drawing.Size(258, 21);
            this.txtUri.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Uri";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtImageHeight);
            this.groupBox1.Controls.Add(this.txtImageWidth);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.rbVIZPub2D);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(409, 105);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "VIZPub";
            // 
            // txtImageHeight
            // 
            this.txtImageHeight.Location = new System.Drawing.Point(96, 68);
            this.txtImageHeight.Name = "txtImageHeight";
            this.txtImageHeight.Size = new System.Drawing.Size(100, 21);
            this.txtImageHeight.TabIndex = 4;
            this.txtImageHeight.Text = "15360";
            // 
            // txtImageWidth
            // 
            this.txtImageWidth.Location = new System.Drawing.Point(96, 43);
            this.txtImageWidth.Name = "txtImageWidth";
            this.txtImageWidth.Size = new System.Drawing.Size(100, 21);
            this.txtImageWidth.TabIndex = 3;
            this.txtImageWidth.Text = "15360";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "Height";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "Width";
            // 
            // rbVIZPub2D
            // 
            this.rbVIZPub2D.AutoSize = true;
            this.rbVIZPub2D.Checked = true;
            this.rbVIZPub2D.Location = new System.Drawing.Point(19, 20);
            this.rbVIZPub2D.Name = "rbVIZPub2D";
            this.rbVIZPub2D.Size = new System.Drawing.Size(82, 16);
            this.rbVIZPub2D.TabIndex = 0;
            this.rbVIZPub2D.TabStop = true;
            this.rbVIZPub2D.Text = "VIZPub 2D";
            this.rbVIZPub2D.UseVisualStyleBackColor = true;
            // 
            // btnExportHistory
            // 
            this.btnExportHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportHistory.Location = new System.Drawing.Point(412, 12);
            this.btnExportHistory.Name = "btnExportHistory";
            this.btnExportHistory.Size = new System.Drawing.Size(75, 23);
            this.btnExportHistory.TabIndex = 2;
            this.btnExportHistory.Text = "Export";
            this.btnExportHistory.UseVisualStyleBackColor = true;
            this.btnExportHistory.Click += new System.EventHandler(this.btnExportHistory_Click);
            // 
            // btnClearHistory
            // 
            this.btnClearHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearHistory.Location = new System.Drawing.Point(493, 12);
            this.btnClearHistory.Name = "btnClearHistory";
            this.btnClearHistory.Size = new System.Drawing.Size(75, 23);
            this.btnClearHistory.TabIndex = 1;
            this.btnClearHistory.Text = "Clear";
            this.btnClearHistory.UseVisualStyleBackColor = true;
            this.btnClearHistory.Click += new System.EventHandler(this.btnClearHistory_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lvHistory);
            this.groupBox3.Location = new System.Drawing.Point(9, 41);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(559, 445);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "History";
            // 
            // lvHistory
            // 
            this.lvHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader7,
            this.columnHeader5});
            this.lvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvHistory.FullRowSelect = true;
            this.lvHistory.GridLines = true;
            this.lvHistory.HideSelection = false;
            this.lvHistory.Location = new System.Drawing.Point(3, 17);
            this.lvHistory.Name = "lvHistory";
            this.lvHistory.Size = new System.Drawing.Size(553, 425);
            this.lvHistory.TabIndex = 0;
            this.lvHistory.UseCompatibleStateImageBehavior = false;
            this.lvHistory.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Status";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Start";
            this.columnHeader3.Width = 96;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Finish";
            this.columnHeader4.Width = 87;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Elapsed";
            this.columnHeader7.Width = 83;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Output";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 498);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Publish Manager (Demo)";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbVIZPub2D;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSelectNavigationPath;
        private System.Windows.Forms.Button btnSelectModelPath;
        private System.Windows.Forms.TextBox txtNavigation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.TextBox txtUri;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNavigateTo;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lvHistory;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnClearHistory;
        private System.Windows.Forms.Button btnExportHistory;
        private System.Windows.Forms.Button btnExportNavigation;
        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.TextBox txtImageHeight;
        private System.Windows.Forms.TextBox txtImageWidth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}

