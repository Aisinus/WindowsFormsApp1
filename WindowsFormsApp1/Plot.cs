using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ScottPlot.Plottable;

namespace WindowsFormsApp1
{
    public partial class Plot : Form
    {
        private double x0;
        private double y0;
        private double X;
        private int N;
        private int Nmin;
        private int Nmax;

        private Exact exact;
        private Euler euler;
        private ImprovedEuler improvedEuler;
        private RungeKutta rungeKutta;

        private ScottPlot.Plottable.ScatterPlot exactGraph;
        private ScottPlot.Plottable.ScatterPlot eulerGraph;
        private ScottPlot.Plottable.ScatterPlot improvedEulerGraph;
        private ScottPlot.Plottable.ScatterPlot rungeGraph;
        private ScottPlot.Plottable.ScatterPlot eulerErrorGraph;
        private ScottPlot.Plottable.ScatterPlot improvedEulerErrorGraph;
        private ScottPlot.Plottable.ScatterPlot rungeErrorGraph;
        private ScottPlot.Plottable.ScatterPlot eulerMaxErrorGraph;
        private ScottPlot.Plottable.ScatterPlot improvedEulerMaxErrorGraph;
        private ScottPlot.Plottable.ScatterPlot rungeMaxErrorGraph;
        
        private List<ScatterPlot> secondform_graphs = new List<ScatterPlot>();
        private List<ScatterPlot> firstform_graphs = new List<ScatterPlot>();
        private List<ScatterPlot> thirdform_graphs = new List<ScatterPlot>();

        private ScottPlot.Plottable.ScatterPlot HighlightedPointFirstGraph;
        private int LastHighlightedIndexFirstGraph = -1;

        private ScottPlot.Plottable.ScatterPlot HighlightedPointSecondGraph;
        private int LastHighlightedIndexSecondGraph = -1;

        private ScottPlot.Plottable.ScatterPlot HighlightedPointThirdGraph;
        private int LastHighlightedIndexThirdGraph = -1;

        void ThirdGraphDraw()
        {
            formsPlot3.Plot.Clear();
            formsPlot3.Plot.Title("Max Error");
            
            HighlightedPointThirdGraph = formsPlot3.Plot.AddPoint(0, 0);
            HighlightedPointThirdGraph.Color = Color.Red;
            HighlightedPointThirdGraph.MarkerSize = 10;
            HighlightedPointThirdGraph.MarkerShape = ScottPlot.MarkerShape.openCircle;
            HighlightedPointThirdGraph.IsVisible = false;

            MaxError maxError = new MaxError(Nmin, Nmax, x0, y0, X);
            List<Grid> grids = new List<Grid>();
            grids.AddRange(new List<Grid>{
                maxError.eulerMaxError(),
                maxError.eulerImproveMaxError(),
                maxError.rungeKuttaMaxError(),
            });
            GraphDraw graphDraw = new GraphDraw(formsPlot3, grids);
            thirdform_graphs = graphDraw.returnPlots();
            
            eulerMaxErrorGraph = thirdform_graphs.First(g => g.Label == "euler");
            improvedEulerMaxErrorGraph = thirdform_graphs.First(g => g.Label == "improved euler");
            rungeMaxErrorGraph = thirdform_graphs.First(g => g.Label == "runge kutta");
            
            eulerMaxErrorGraph.IsVisible = checkBox2.Checked;
            improvedEulerMaxErrorGraph.IsVisible = checkBox3.Checked;
            rungeMaxErrorGraph.IsVisible = checkBox4.Checked;
            
            
            formsPlot3.Refresh();
            formsPlot3.Plot.Legend();
        }
        
        
        void SecondGraphDraw()
        {
            formsPlot2.Plot.Clear();
            formsPlot2.Plot.Title("Local Errors");

            HighlightedPointSecondGraph = formsPlot2.Plot.AddPoint(0, 0);
            HighlightedPointSecondGraph.Color = Color.Red;
            HighlightedPointSecondGraph.MarkerSize = 10;
            HighlightedPointSecondGraph.MarkerShape = ScottPlot.MarkerShape.openCircle;
            HighlightedPointSecondGraph.IsVisible = false;

            LTEerror eulerError = new LTEerror(exact, euler);
            LTEerror eulerimproveError = new LTEerror(exact, improvedEuler);
            LTEerror rungeError = new LTEerror(exact, rungeKutta);
            List<Grid> grids = new List<Grid>();
            grids.AddRange(new List<Grid>
            {
                eulerError,
                eulerimproveError,
                rungeError,
            });
            GraphDraw graphDraw = new GraphDraw(formsPlot2, grids);
            secondform_graphs = graphDraw.returnPlots();

            eulerErrorGraph = secondform_graphs.First(g => g.Label == "euler");
            improvedEulerErrorGraph = secondform_graphs.First(g => g.Label == "improved euler");
            rungeErrorGraph = secondform_graphs.First(g => g.Label == "runge kutta");
            
            eulerErrorGraph.IsVisible = checkBox2.Checked;
            improvedEulerErrorGraph.IsVisible = checkBox3.Checked;
            rungeErrorGraph.IsVisible = checkBox4.Checked;
            
            
            formsPlot2.Refresh();
            formsPlot2.Plot.Legend();
        }


        void FirstGraphDraw()
        {
            formsPlot1.Plot.Clear();
            formsPlot1.Plot.Title("Values");
            HighlightedPointFirstGraph = formsPlot1.Plot.AddPoint(0, 0);
            HighlightedPointFirstGraph.Color = Color.Red;
            HighlightedPointFirstGraph.MarkerSize = 10;
            HighlightedPointFirstGraph.MarkerShape = ScottPlot.MarkerShape.openCircle;
            HighlightedPointFirstGraph.IsVisible = false;

            List<Grid> listofGrids = new List<Grid>();
            listofGrids.AddRange(new List<Grid>
            {
                exact,
                euler,
                improvedEuler,
                rungeKutta,
            });

            GraphDraw graphDraw = new GraphDraw(formsPlot1, listofGrids);

            firstform_graphs = graphDraw.returnPlots();

            exactGraph = firstform_graphs.First(g => g.Label == "exact");
            eulerGraph = firstform_graphs.First(g => g.Label == "euler");
            improvedEulerGraph = firstform_graphs.First(g => g.Label == "improved euler");
            rungeGraph = firstform_graphs.Find(g => g.Label == "runge kutta");

            exactGraph.IsVisible = checkBox1.Checked;
            eulerGraph.IsVisible = checkBox2.Checked;
            improvedEulerGraph.IsVisible = checkBox3.Checked;
            rungeGraph.IsVisible = checkBox4.Checked;

            formsPlot1.Plot.SetAxisLimits(x0, X, exactGraph.Ys[N - 1], y0);
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
                x0 = Double.Parse(textBox2.Text);
                y0 = Double.Parse(textBox3.Text);
                X = Double.Parse(textBox1.Text);
                N = Int32.Parse(textN.Text);
                Nmin = Int32.Parse(textBox5.Text);
                Nmax = Int32.Parse(textBox4.Text);

                exact = new Exact(N, x0, y0, X);
                euler = new Euler(N, x0, y0, X);
                improvedEuler = new ImprovedEuler(N, x0, y0, X);
                rungeKutta = new RungeKutta(N, x0, y0, X);

                ThirdGraphDraw();
                SecondGraphDraw();
                FirstGraphDraw();
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
            eulerErrorGraph.IsVisible = checkBox2.Checked;
            eulerMaxErrorGraph.IsVisible = checkBox2.Checked;
            formsPlot1.Refresh();
            formsPlot2.Refresh();
            formsPlot3.Refresh();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            improvedEulerGraph.IsVisible = checkBox3.Checked;
            improvedEulerErrorGraph.IsVisible = checkBox3.Checked;
            improvedEulerMaxErrorGraph.IsVisible = checkBox3.Checked;
            formsPlot1.Refresh();
            formsPlot2.Refresh();
            formsPlot3.Refresh();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            rungeGraph.IsVisible = checkBox4.Checked;
            rungeErrorGraph.IsVisible = checkBox4.Checked;
            rungeMaxErrorGraph.IsVisible = checkBox4.Checked;
            formsPlot1.Refresh();
            formsPlot2.Refresh();
            formsPlot3.Refresh();
        }

        private void formsPlot1_MouseMove(object sender, MouseEventArgs e)
        {
            FindPoint points = new FindPoint(firstform_graphs, formsPlot1);
            ScatterPlot minPlot = points.findPointXY();
            (double mouseCoordX, double mouseCoordY) = formsPlot1.GetMouseCoordinates();
            double xyRatio = formsPlot1.Plot.XAxis.Dims.PxPerUnit / formsPlot1.Plot.YAxis.Dims.PxPerUnit;
            (double pointX, double pointY, int pointIndex) = minPlot.GetPointNearest(mouseCoordX, mouseCoordY, xyRatio);

            HighlightedPointFirstGraph.Xs[0] = pointX;
            HighlightedPointFirstGraph.Ys[0] = pointY;

            HighlightedPointFirstGraph.IsVisible = true;

            if (LastHighlightedIndexFirstGraph != pointIndex)
            {
                LastHighlightedIndexFirstGraph = pointIndex;
                formsPlot1.Render();
            }

            formsPlot1.Refresh();
            label5.Text = $@"{minPlot.Label} point index {pointIndex} at ({pointX:N2}, {pointY:N2})";
        }


        private void formsPlot2_MouseMove(object sender, MouseEventArgs e)
        {
            FindPoint points = new FindPoint(secondform_graphs, formsPlot2);

            ScatterPlot minPlot = points.findPointXY();

            (double mouseCoordX, double mouseCoordY) = formsPlot2.GetMouseCoordinates();
            double xyRatio = formsPlot2.Plot.XAxis.Dims.PxPerUnit / formsPlot2.Plot.YAxis.Dims.PxPerUnit;
            (double pointX, double pointY, int pointIndex) = minPlot.GetPointNearest(mouseCoordX, mouseCoordY, xyRatio);

            HighlightedPointSecondGraph.Xs[0] = pointX;
            HighlightedPointSecondGraph.Ys[0] = pointY;

            HighlightedPointSecondGraph.IsVisible = true;

            if (LastHighlightedIndexSecondGraph != pointIndex)
            {
                LastHighlightedIndexSecondGraph = pointIndex;
                formsPlot2.Render();
            }

            formsPlot2.Refresh();


            label6.Text = $@"{minPlot.Label} point index {pointIndex} at ({pointX:N2}, {pointY:N2})";
        }

        private void Plot_Load(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void formsPlot3_MouseMove(object sender, MouseEventArgs e)
        {
            FindPoint points = new FindPoint(thirdform_graphs, formsPlot3);

            ScatterPlot minPlot = points.findPointXY();

            (double mouseCoordX, double mouseCoordY) = formsPlot3.GetMouseCoordinates();
            double xyRatio = formsPlot3.Plot.XAxis.Dims.PxPerUnit / formsPlot3.Plot.YAxis.Dims.PxPerUnit;
            (double pointX, double pointY, int pointIndex) = minPlot.GetPointNearest(mouseCoordX, mouseCoordY, xyRatio);

            HighlightedPointThirdGraph.Xs[0] = pointX;
            HighlightedPointThirdGraph.Ys[0] = pointY;

            HighlightedPointThirdGraph.IsVisible = true;

            if (LastHighlightedIndexThirdGraph != pointIndex)
            {
                LastHighlightedIndexThirdGraph = pointIndex;
                formsPlot3.Render();
            }

            formsPlot3.Refresh();
            label7.Text = $@"{minPlot.Label} point index {pointIndex} at ({pointX:N2}, {pointY:N2})";
        }
    }
}