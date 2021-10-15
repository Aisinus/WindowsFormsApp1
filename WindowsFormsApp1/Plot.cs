using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Plot : Form
    {
        private ScottPlot.Plottable.ScatterPlot MyScatterPlot;
        private readonly ScottPlot.Plottable.ScatterPlot HighlightedPoint;
        private int LastHighlightedIndex = -1;
        public Plot()
        {
            InitializeComponent();
            
            
            HighlightedPoint = formsPlot1.Plot.AddPoint(0, 0);
            HighlightedPoint.Color = Color.Red;
            HighlightedPoint.MarkerSize = 10;
            HighlightedPoint.MarkerShape = ScottPlot.MarkerShape.openCircle;
            HighlightedPoint.IsVisible = false;
            
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

                MyScatterPlot = formsPlot1.Plot.AddScatter(exact.x, exact.y);
                formsPlot1.Plot.SetAxisLimits(x0,X,exact.y[N-1],y0);
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

        private void formsPlot1_MouseMove(object sender, MouseEventArgs e)
        {
            (double mouseCoordX, double mouseCoordY) = formsPlot1.GetMouseCoordinates();
            double xyRatio = formsPlot1.Plot.XAxis.Dims.PxPerUnit / formsPlot1.Plot.YAxis.Dims.PxPerUnit;
            (double pointX, double pointY, int pointIndex) = MyScatterPlot.GetPointNearest(mouseCoordX, mouseCoordY, xyRatio);

            // place the highlight over the point of interest
            HighlightedPoint.Xs[0] = pointX;
            HighlightedPoint.Ys[0] = pointY;
            HighlightedPoint.IsVisible = true;

            // render if the highlighted point chnaged
            if (LastHighlightedIndex != pointIndex)
            {
                LastHighlightedIndex = pointIndex;
                formsPlot1.Render();
            }

            // update the GUI to describe the highlighted point
            label5.Text = $"Point index {pointIndex} at ({pointX:N2}, {pointY:N2})";
        }
    }
}