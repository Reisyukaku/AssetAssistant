using SmartPoint.AssetAssistant;
using System;
using System.Windows.Forms;

namespace Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openBinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            outBox.Text = string.Empty;
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != DialogResult.OK) return;
            var manifest = AssetBundleDownloadManifest.Load(ofd.FileName);
            outBox.AppendText("Total size: " + manifest.totalSize + Environment.NewLine);
            foreach (var m in manifest.records) {
                outBox.AppendText("AssetBundleName: " + m.assetBundleName + Environment.NewLine);
                //outBox.AppendText(m.assetPaths + Environment.NewLine);
                outBox.AppendText("Dependencies: " + Environment.NewLine);
                foreach (var dep in m.allDependencies) {
                    outBox.AppendText(dep + Environment.NewLine);
                }
                
                outBox.AppendText(Environment.NewLine);
            }
        }
    }
}
