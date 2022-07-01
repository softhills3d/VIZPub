namespace VIZPub.Test.App
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.plContainer = new System.Windows.Forms.Panel();
            this.btnStructure = new System.Windows.Forms.ToolStripButton();
            this.toolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbar
            // 
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnStructure});
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(940, 25);
            this.toolbar.TabIndex = 0;
            this.toolbar.Text = "toolStrip1";
            // 
            // plContainer
            // 
            this.plContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plContainer.Location = new System.Drawing.Point(0, 25);
            this.plContainer.Name = "plContainer";
            this.plContainer.Size = new System.Drawing.Size(940, 498);
            this.plContainer.TabIndex = 1;
            // 
            // btnStructure
            // 
            this.btnStructure.Image = ((System.Drawing.Image)(resources.GetObject("btnStructure.Image")));
            this.btnStructure.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStructure.Name = "btnStructure";
            this.btnStructure.Size = new System.Drawing.Size(76, 22);
            this.btnStructure.Text = "Structure";
            this.btnStructure.Click += new System.EventHandler(this.btnStructure_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 523);
            this.Controls.Add(this.plContainer);
            this.Controls.Add(this.toolbar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VIZPub.Test.App";
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.Panel plContainer;
        private System.Windows.Forms.ToolStripButton btnStructure;
    }
}

