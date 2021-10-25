using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.FSharp.Data.UnitSystems.SI.UnitNames;
using ScottPlot.Plottable;

namespace WindowsFormsApp1
{
    public partial class Plot : Form
    {
        private List<ScatterPlot> secondform_graphs = new List<ScatterPlot>();
        private List<ScatterPlot> firstform_graphs = new List<ScatterPlot>();
        private List<ScatterPlot> thirdform_graphs = new List<ScatterPlot>();

        private HighlightedPoint firstHP;
        private HighlightedPoint secondHP;
        private HighlightedPoint thirdHP;

        void ThirdGraphDraw(int Nmin, int Nmax, double x0, double y0, double X)
        {
            formsPlot3.Plot.Clear();
            formsPlot3.Plot.Title("Max Error");

            thirdHP = new HighlightedPoint(formsPlot3);

            MaxError maxError = new MaxError(Nmin, Nmax, x0, y0, X);
            List<Grid> grids = new List<Grid>();
            grids.AddRange(new List<Grid>
            {
                maxError.eulerMaxError(),
                maxError.eulerImproveMaxError(),
                maxError.rungeKuttaMaxError(),
            });
            GraphDraw graphDraw = new GraphDraw(formsPlot3, grids);
            thirdform_graphs = graphDraw.returnPlots();

            thirdform_graphs.First(g => g.Label == "euler").IsVisible = checkBox2.Checked;
            thirdform_graphs.First(g => g.Label == "improved euler").IsVisible = checkBox3.Checked;
            thirdform_graphs.First(g => g.Label == "runge kutta").IsVisible = checkBox4.Checked;

            formsPlot3.Refresh();
            formsPlot3.Plot.Legend();
        }


        void SecondGraphDraw(Exact exact, Euler euler, ImprovedEuler improvedEuler, RungeKutta rungeKutta)
        {
            formsPlot2.Plot.Clear();
            formsPlot2.Plot.Title("Local Errors");

            secondHP = new HighlightedPoint(formsPlot2);

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

            secondform_graphs.First(g => g.Label == "euler").IsVisible = checkBox2.Checked;
            secondform_graphs.First(g => g.Label == "improved euler").IsVisible = checkBox3.Checked;
            secondform_graphs.First(g => g.Label == "runge kutta").IsVisible = checkBox4.Checked;

            formsPlot2.Refresh();
            formsPlot2.Plot.Legend();
        }


        void FirstGraphDraw(Exact exact, Euler euler, ImprovedEuler improvedEuler, RungeKutta rungeKutta)
        {
            formsPlot1.Plot.Clear();
            formsPlot1.Plot.Title("Values");

            firstHP = new HighlightedPoint(formsPlot1);

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

            firstform_graphs.First(g => g.Label == "exact").IsVisible = checkBox1.Checked;
            firstform_graphs.First(g => g.Label == "euler").IsVisible = checkBox2.Checked;
            firstform_graphs.First(g => g.Label == "improved euler").IsVisible = checkBox3.Checked;
            firstform_graphs.Find(g => g.Label == "runge kutta").IsVisible = checkBox4.Checked;
            
            formsPlot1.Refresh();
            formsPlot1.Plot.Legend();
        }

        public Plot()
        {
            InitializeComponent();
            this.Text = "Computational Practicum Zhylkybay Aisen";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double x0 = x0 = Double.Parse(textBox2.Text);
                double y0 = Double.Parse(textBox3.Text);
                double X = Double.Parse(textBox1.Text);
                int N = Int32.Parse(textN.Text);
                int Nmin = Int32.Parse(textBox5.Text);
                int Nmax = Int32.Parse(textBox4.Text);

                Exact exact = new Exact(N, x0, y0, X);
                Euler euler = new Euler(N, x0, y0, X);
                ImprovedEuler improvedEuler = new ImprovedEuler(N, x0, y0, X);
                RungeKutta rungeKutta = new RungeKutta(N, x0, y0, X);


                ThirdGraphDraw(Nmin,Nmax,x0,y0,X);
                SecondGraphDraw(exact,euler,improvedEuler,rungeKutta);
                FirstGraphDraw(exact,euler,improvedEuler,rungeKutta);
            }
            catch (Exception exception)
            {
                MessageBox.Show($@"Wrong input data: {exception.Message}");
                throw;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            firstform_graphs.First(g => g.Label == "exact").IsVisible = checkBox1.Checked;
            formsPlot1.Refresh();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            firstform_graphs.First(g => g.Label == "euler").IsVisible = checkBox2.Checked;
            secondform_graphs.First(g => g.Label == "euler").IsVisible = checkBox2.Checked;
            thirdform_graphs.First(g => g.Label == "euler").IsVisible = checkBox2.Checked;
            formsPlot1.Refresh();
            formsPlot2.Refresh();
            formsPlot3.Refresh();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            firstform_graphs.First(g => g.Label == "improved euler").IsVisible = checkBox3.Checked;
            secondform_graphs.First(g => g.Label == "improved euler").IsVisible = checkBox3.Checked;
            thirdform_graphs.First(g => g.Label == "improved euler").IsVisible = checkBox3.Checked;
            formsPlot1.Refresh();
            formsPlot2.Refresh();
            formsPlot3.Refresh();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            firstform_graphs.Find(g => g.Label == "runge kutta").IsVisible = checkBox4.Checked;
            secondform_graphs.First(g => g.Label == "runge kutta").IsVisible = checkBox4.Checked;
            thirdform_graphs.First(g => g.Label == "runge kutta").IsVisible = checkBox4.Checked;
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

            firstHP.changePoint(pointX,pointY);
            firstHP.isVisible(true);

            if (firstHP.GetIndex() != pointIndex)
            {
                firstHP.setIndex(pointIndex);
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

            secondHP.changePoint(pointX,pointY);
            secondHP.isVisible(true);

            if (secondHP.GetIndex() != pointIndex)
            {
                secondHP.setIndex(pointIndex);
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

            thirdHP.changePoint(pointX,pointY);
            thirdHP.isVisible(true);

            if (thirdHP.GetIndex() != pointIndex)
            {
                thirdHP.setIndex(pointIndex);
                formsPlot3.Render();
            }

            formsPlot3.Refresh();
            label7.Text = $@"{minPlot.Label} point index {pointIndex} at ({pointX:N2}, {pointY:N2})";
        }
    }
}