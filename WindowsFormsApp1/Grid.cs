using System;
using System.Diagnostics.CodeAnalysis;


namespace WindowsFormsApp1
{
    public class Grid
    {
        public double[] x;
        public double[] y;
        public int n;
        protected double h;
        public string name;

        [SuppressMessage("ReSharper.DPA", "DPA0003: Excessive memory allocations in LOH", MessageId = "type: System.Double[]")]
        public Grid(int N, double x0, double y0, double X, string newname)
        {
            n = N + 1;
            h =  (X - x0) / N;
            x = new double[n];
            y = new double[n];
            name = newname;
            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    x[i] = x0;
                }
                else
                {
                    x[i] = x[i - 1] + h;
                }
            }
        }

        protected static double DifferentialEquation(double x1, double y1)
        {

            return ((y1 / x1) - x1 * Math.Pow(Math.E, (y1 / x1)));
        }
    }
}