using System;

namespace WindowsFormsApp1
{
    public class Grid
    {
        public double[] x;
        public double[] y;
        public int N;
        public double h;

        public Grid(int N, double x0,double y0, double X)
        {
            h = (X - x0) / N;
            x = new double[N];
            y = new double[N];

            for (int i = 0; i < N; i++)
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