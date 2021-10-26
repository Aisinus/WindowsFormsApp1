using System.Collections.Generic;
using System.Linq;
using ScottPlot;
using ScottPlot.Plottable;

namespace WindowsFormsApp1
{
    public class GraphDraw
    {
        private FormsPlot _formsPlot;
        private List<Grid> _grids = new List<Grid>();
        private List<ScatterPlot> _plots = new List<ScatterPlot>();

        public GraphDraw(FormsPlot newFormsplot, List<Grid> newGrids)
        {
            _formsPlot = newFormsplot;
            _grids = newGrids;


            foreach (var grid in _grids)
            {
                var plottableIndexes =
                    Enumerable
                        .Range(0, grid.y.Length)
                        .Where(i => !double.IsNaN(grid.y[i]))
                        .Where(i => !double.IsInfinity(grid.y[i]));
                double[] plottableXs = plottableIndexes.Select(i => grid.x[i]).ToArray();
                double[] plottableYs = plottableIndexes.Select(i => grid.y[i]).ToArray();
                
                _plots.Add(_formsPlot.Plot.AddScatter(plottableXs, plottableYs, label: grid.name));
            }
        }

        public List<ScatterPlot> returnPlots()
        {
            return _plots;
        }
    }
}