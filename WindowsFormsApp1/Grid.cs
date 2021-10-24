using System;

namespace WindowsFormsApp1
{
    public class Grid
    {
        public double[] x;
        public double[] y;
        public int n;
        public double h;
        public string name;
        public Grid(int N, double x0,double y0, double X, string newname)
        {
            n = N+1;
            h = (X - x0) / N;
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

        public double differentialEquation(double x, double y)
        {
            return ((y/x)-x*Math.Pow(Math.E,(y/x)));
        }
        
    }
}