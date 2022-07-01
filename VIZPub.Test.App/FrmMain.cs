using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VIZPub.Test.App
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnStructure_Click(object sender, EventArgs e)
        {
            View.StructureUI structure = new View.StructureUI();
            structure.Dock = DockStyle.Fill;

            plContainer.Controls.Clear();
            plContainer.Controls.Add(structure);
        }
    }
}
