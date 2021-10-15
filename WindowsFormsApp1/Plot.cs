using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Plot : Form
    {
        private  ScottPlot.Plottable.ScatterPlot exactGraph;
        private  ScottPlot.Plottable.ScatterPlot eulerGraph;
        private ScottPlot.Plottable.ScatterPlot impreulerGraph;
        private  ScottPlot.Plottable.ScatterPlot rungeGraph;
        private ScottPlot.Plottable.ScatterPlot HighlightedPoint;
        private int LastHighlightedIndex = -1;
        
        double distancetomouse(double pointX,double pointY)
        {
            (double mouseCoordX, double mouseCoordY) = formsPlot1.GetMouseCoordinates();
            return Math.Sqrt(Math.Pow(pointX-mouseCoordX,2) + Math.Pow(pointY-mouseCoordY,2));
        }

        void firstGraphDraw()
        {
            formsPlot1.Plot.Clear();
                
            HighlightedPoint = formsPlot1.Plot.AddPoint(0, 0);
            HighlightedPoint.Color = Color.Red;
            HighlightedPoint.MarkerSize = 10;
            HighlightedPoint.MarkerShape = ScottPlot.MarkerShape.openCircle;
            HighlightedPoint.IsVisible = false;
            
            double x0 = Double.Parse(textBox2.Text);
            double y0 = Double.Parse(textBox3.Text);
            double X = Double.Parse(textBox1.Text);
            int N = Int32.Parse(textN.Text);

            Exact exact = new Exact(N, x0, y0, X);
            Euler euler = new Euler(N, x0, y0, X);
            ImprovedEuler improvedEuler = new ImprovedEuler(N, x0, y0, X);
            RungeKutta rungeKutta = new RungeKutta(N, x0, y0, X);
                

            exactGraph = formsPlot1.Plot.AddScatter(exact.x, exact.y, label:"exact");
            eulerGraph = formsPlot1.Plot.AddScatter(euler.x, euler.y, label:"euler");
            impreulerGraph = formsPlot1.Plot.AddScatter(improvedEuler.x, improvedEuler.y, label: "improve Euler");
            rungeGraph = formsPlot1.Plot.AddScatter(rungeKutta.x, rungeKutta.y, label: "runge kutta");

            exactGraph.IsVisible = checkBox1.Checked;
            eulerGraph.IsVisible = checkBox2.Checked;
            impreulerGraph.IsVisible = checkBox3.Checked;
            rungeGraph.IsVisible = checkBox4.Checked;
                
                
            formsPlot1.Plot.SetAxisLimits(x0,X,exact.y[N-1],y0);
            formsPlot1.Refresh();
            formsPlot1.Plot.Legend();
        }
        public Plot()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                firstGraphDraw();
            }
            catch (Exception exception)
            {
                MessageBox.Show($@"Wrong input data: {exception.Message}");
                throw;
            }
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            exactGraph.IsVisible = checkBox1.Checked;
            formsPlot1.Refresh();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            eulerGraph.IsVisible = checkBox2.Checked;
            formsPlot1.Refresh();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            impreulerGraph.IsVisible = checkBox3.Checked;
            formsPlot1.Refresh();
        }
        
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            rungeGraph.IsVisible = checkBox4.Checked;
            formsPlot1.Refresh();
        }

        private void formsPlot1_MouseMove(object sender, MouseEventArgs e)
        {
            (double mouseCoordX, double mouseCoordY) = formsPlot1.GetMouseCoordinates();
            double xyRatio = formsPlot1.Plot.XAxis.Dims.PxPerUnit / formsPlot1.Plot.YAxis.Dims.PxPerUnit;
            (double pointXexact, double pointYexact, int pointIndexexact) = exactGraph.GetPointNearest(mouseCoordX, mouseCoordY, xyRatio);
            (double pointXeuler, double pointYeuler, int pointIndexeuler) = eulerGraph.GetPointNearest(mouseCoordX, mouseCoordY, xyRatio);
            (double pointXimprove, double pointYimprove, int pointIndeximprove) = impreulerGraph.GetPointNearest(mouseCoordX, mouseCoordY, xyRatio);
            (double pointXrunge, double pointYrunge, int pointIndexrunge) = rungeGraph.GetPointNearest(mouseCoordX, mouseCoordY, xyRatio);
            
            var distanceExact = distancetomouse(pointXexact, pointYexact);
            var distanceEuler = distancetomouse(pointXeuler, pointYeuler);
            var distanceImprove = distancetomouse(pointXimprove, pointYimprove);
            var distanceRunge = distancetomouse(pointXrunge, pointYrunge);

            var minDistance = Math.Min(distanceExact, distanceEuler);
            minDistance = Math.Min(minDistance, distanceImprove);
            minDistance = Math.Min(minDistance, distanceRunge);

            if (minDistance == distanceExact)
            {
                HighlightedPoint.Xs[0] = pointXexact;
                HighlightedPoint.Ys[0] = pointYexact;
                HighlightedPoint.IsVisible = true;

                // render if the highlighted point chnaged
                if (LastHighlightedIndex != pointIndexexact)
                {
                    LastHighlightedIndex = pointIndexexact;
                    formsPlot1.Render();
                }
                formsPlot1.Refresh();

                // update the GUI to describe the highlighted point
                label5.Text = $@"Exact point index {pointIndexexact} at ({pointXexact:N2}, {pointYexact:N2})";
            }else if (minDistance==distanceEuler)
            {
                HighlightedPoint.Xs[0] = pointXeuler;
                HighlightedPoint.Ys[0] = pointYeuler;
                HighlightedPoint.IsVisible = true;

                // render if the highlighted point chnaged
                if (LastHighlightedIndex != pointIndexeuler)
                {
                    LastHighlightedIndex = pointIndexeuler;
                    formsPlot1.Render();
                }
                formsPlot1.Refresh();

                // update the GUI to describe the highlighted point
                label5.Text = $@"Euler point index {pointIndexeuler} at ({pointXeuler:N2}, {pointYeuler:N2})";
            }else if (minDistance == distanceImprove)
            {
                HighlightedPoint.Xs[0] = pointXimprove;
                HighlightedPoint.Ys[0] = pointYimprove;
                HighlightedPoint.IsVisible = true;

                // render if the highlighted point chnaged
                if (LastHighlightedIndex != pointIndeximprove)
                {
                    LastHighlightedIndex = pointIndeximprove;
                    formsPlot1.Render();
                }
                formsPlot1.Refresh();

                // update the GUI to describe the highlighted point
                label5.Text = $@"Euler improve point index {pointIndeximprove} at ({pointXimprove:N2}, {pointYimprove:N2})";
            }else if (minDistance == distanceRunge)
            {
                HighlightedPoint.Xs[0] = pointXrunge;
                HighlightedPoint.Ys[0] = pointYrunge;
                HighlightedPoint.IsVisible = true;

                // render if the highlighted point chnaged
                if (LastHighlightedIndex != pointIndexrunge)
                {
                    LastHighlightedIndex = pointIndexrunge;
                    formsPlot1.Render();
                }
                formsPlot1.Refresh();

                // update the GUI to describe the highlighted point
                label5.Text = $@"Runge Kutta point index {pointIndexrunge} at ({pointXrunge:N2}, {pointYrunge:N2})";
            }

            // place the highlight over the point of interest
            
        }



    }
}