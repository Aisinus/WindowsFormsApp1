using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
           // throw new System.NotImplementedException();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
           // throw new System.NotImplementedException();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
           // throw new System.NotImplementedException();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.containerControl1.Controls.Clear();
            Plot plotform = new Plot() {Dock = DockStyle.Fill, TopLevel = false, TopMost = true};
            plotform.FormBorderStyle = FormBorderStyle.None;
            this.containerControl1.Controls.Add(plotform);
            plotform.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.containerControl1.Controls.Clear();
            MaxError errorform = new MaxError() {Dock = DockStyle.Fill, TopLevel = false, TopMost = true};
            errorform.FormBorderStyle = FormBorderStyle.None;
            this.containerControl1.Controls.Add(errorform);
            errorform.Show();
        }
    }
}