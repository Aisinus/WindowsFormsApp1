using System.Drawing;
using System.Dynamic;
using ScottPlot;
using ScottPlot.Plottable;

namespace WindowsFormsApp1
{
    public class HighlightedPoint
    {
        private ScatterPlot point;
        private int index = -1;

        public HighlightedPoint(FormsPlot plot)
        {
            point = plot.Plot.AddPoint(0, 0);
            point.Color = Color.Red;
            point.MarkerSize = 10;
            point.MarkerShape = ScottPlot.MarkerShape.openCircle;
            point.IsVisible = false;
        }

        public void IsVisible(bool visibility)
        {
            point.IsVisible = visibility;
        }

        public void ChangePoint(double x, double y)
        {
            point.Xs[0] = x;
            point.Ys[0] = y;
        }

        public int GetIndex()
        {
            return index;
        }

        public void SetIndex(int newIndex)
        {
            index = newIndex;
        }
        
    }
}