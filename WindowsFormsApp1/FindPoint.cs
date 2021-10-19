using System;
using System.Collections;
using System.Collections.Generic;
using ScottPlot;
using ScottPlot.Plottable;

namespace WindowsFormsApp1
{
    public class FindPoint
    {
        private List<ScatterPlot> plots = new List<ScatterPlot>();
        private FormsPlot formsPlot;

        public FindPoint(List<ScatterPlot> newPlots, FormsPlot newFormsPlot)
        {
            plots = newPlots;
            formsPlot = newFormsPlot;
        }

        public ScatterPlot findPointXY()
        {
            double xyRatio = formsPlot.Plot.XAxis.Dims.PxPerUnit / formsPlot.Plot.YAxis.Dims.PxPerUnit;
            List<double> minDistanses = new List<double>();
            
            foreach (var plot in plots)
            {
                minDistanses.Add(distance(plot,xyRatio));
            }

            var minDis = minDistance(minDistanses);
            return plots[minDistanses.IndexOf(minDis)];
        }

        private double distance(ScatterPlot plot, double xyRatio)
        {
            (double mouseCoordX, double mouseCoordY) = formsPlot.GetMouseCoordinates();
            (double pointX, double pointY, int index) = plot.GetPointNearest(mouseCoordX, mouseCoordY, xyRatio);
            if(plot.IsVisible == true) return Math.Sqrt(Math.Pow(pointX-mouseCoordX,2) + Math.Pow(pointY-mouseCoordY,2));
            
            return Double.MaxValue;
        }

        private double minDistance(List<double> distanses)
        {
            double min = Double.MaxValue;
            foreach(var dis in distanses)
            {
                if (dis <= min) min = dis;
            }
            return min;
        }
        
        
    }
}