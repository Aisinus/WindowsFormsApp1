using System.Collections.Generic;
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
                _plots.Add(_formsPlot.Plot.AddScatter(grid.x, grid.y,label:grid.name));
            }
            
        }

        public List<ScatterPlot> returnPlots()
        {
            return _plots;
        }

    }
}