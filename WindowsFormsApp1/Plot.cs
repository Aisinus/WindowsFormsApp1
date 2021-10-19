using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ScottPlot.Plottable;

namespace WindowsFormsApp1
{
    public partial class Plot : Form
    {
        private  ScottPlot.Plottable.ScatterPlot exactGraph;
        private  ScottPlot.Plottable.ScatterPlot eulerGraph;
        private ScottPlot.Plottable.ScatterPlot improvedEulerGraph;
        private  ScottPlot.Plottable.ScatterPlot rungeGraph;
        private ScottPlot.Plottable.ScatterPlot HighlightedPoint;
        private int LastHighlightedIndex = -1;
        
        double distancetomouse(ScottPlot.Plottable.ScatterPlot graph ,double pointX,double pointY)
        {
            (double mouseCoordX, double mouseCoordY) = formsPlot1.GetMouseCoordinates();
            if(graph.IsVisible == true) return Math.Sqrt(Math.Pow(pointX-mouseCoordX,2) + Math.Pow(pointY-mouseCoordY,2));
            
            return Double.MaxValue;
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
            improvedEulerGraph = formsPlot1.Plot.AddScatter(improvedEuler.x, improvedEuler.y, label: "improve Euler");
            rungeGraph = formsPlot1.Plot.AddScatter(rungeKutta.x, rungeKutta.y, label: "runge kutta");
            

            exactGraph.IsVisible = checkBox1.Checked;
            eulerGraph.IsVisible = checkBox2.Checked;
            improvedEulerGraph.IsVisible = checkBox3.Checked;
            rungeGraph.IsVisible = checkBox4.Checked;
                
                
            formsPlot1.Plot.SetAxisLimits(x0,X,exact.y[N-1],y0);
            formsPlot1.Refresh();
            formsPlot1.Plot.Legend();
        }
        public Plot()
        {
            InitializeComponent();
            firstGraphDraw();
            
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
            improvedEulerGraph.IsVisible = checkBox3.Checked;
            formsPlot1.Refresh();
        }
        
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            rungeGraph.IsVisible = checkBox4.Checked;
            formsPlot1.Refresh();
        }

        private void formsPlot1_MouseMove(object sender, MouseEventArgs e)
        {
            List<ScatterPlot> plots = new List<ScatterPlot>();
            ScatterPlot[] _plots =
            {
                exactGraph,
                eulerGraph,
                improvedEulerGraph,
                rungeGraph
            };
            
            plots.AddRange(_plots);
            FindPoint points = new FindPoint(plots, formsPlot1);

            ScatterPlot minPlot = points.findPointXY();
            
            (double mouseCoordX, double mouseCoordY) = formsPlot1.GetMouseCoordinates();
            double xyRatio = formsPlot1.Plot.XAxis.Dims.PxPerUnit / formsPlot1.Plot.YAxis.Dims.PxPerUnit;
            (double pointX, double pointY, int pointIndex) = minPlot.GetPointNearest(mouseCoordX, mouseCoordY, xyRatio);

            HighlightedPoint.Xs[0] = pointX;
            HighlightedPoint.Ys[0] = pointY;
            
            HighlightedPoint.IsVisible = true;

            
            if (LastHighlightedIndex != pointIndex)
            {
                LastHighlightedIndex = pointIndex;
                formsPlot1.Render();
            }
            formsPlot1.Refresh();

            
            label5.Text = $@"{minPlot.Label} point index {pointIndex} at ({pointX:N2}, {pointY:N2})";
        }



    }
}