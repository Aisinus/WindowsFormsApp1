using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Plot : Form
    {
        public Plot()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double x0 = Double.Parse(textBox2.Text);
                double y0 = Double.Parse(textBox3.Text);
                double X = Double.Parse(textBox1.Text);
                int N = Int32.Parse(textN.Text);

                Exact exact = new Exact(N, x0, y0, X);
                Euler euler = new Euler(N, x0, y0, X);
                ImprovedEuler improvedEuler = new ImprovedEuler(N, x0, y0, X);
                
                chart1.Series[0].Points.DataBindXY(exact.x,exact.y);
                chart1.Series[1].Points.DataBindXY(euler.x,euler.y);
                chart1.Series[2].Points.DataBindXY(improvedEuler.x,improvedEuler.y);

                chart1.ChartAreas[0].AxisX.Minimum = x0;
                chart1.ChartAreas[0].AxisX.Maximum = X;

                chart1.Series[0].IsValueShownAsLabel = true;
                chart1.Series[1].IsValueShownAsLabel = true;
                chart1.Series[2].IsValueShownAsLabel = true;

                formsPlot1.Plot.AddScatter(exact.x, exact.y);
                formsPlot1.Refresh();
            }
            catch (Exception exception)
            {
                MessageBox.Show($@"Wrong input data: {exception.Message}");
                throw;
            }
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series[0].Enabled = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series[1].Enabled = checkBox2.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series[2].Enabled = checkBox3.Checked;
        }
    }
}