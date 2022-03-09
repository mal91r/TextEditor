using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeerGrade4
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void NewPage()
        {
            TabPage newp = new TabPage();

            RichTextBox rtf = new RichTextBox();
            newp.Text = "NewPage";
            newp.Name = "NewPage";
            rtf.Size = new Size(768, 368);
            newp.Controls.Add(rtf);
            tabControl1.TabPages.Add(newp);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                string text = System.IO.File.ReadAllText(filename);
                tabControl1.SelectedTab.Controls[0].Text = text;
                MessageBox.Show("Файл открыт!");
            }
        }
    }
}
