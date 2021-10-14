using System;

namespace WindowsFormsApp1
{
    public class Exact:Grid
    {
        public Exact(int N, double x0, double y0, double X) : base(N, x0,y0, X)
        {
            double c = Math.Pow((1 / Math.E), y0 / x0) - x0;
            
            for (int i = 0; i < N; i++)
            {
                if (i == 0)
                {
                    y[i] = y0;
                    
                }
                else
                {
                    y[i] = -x[i] * Math.Log(c + x[i], Math.E);
                }
            }
        }
    }
}