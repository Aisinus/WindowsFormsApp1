using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace WindowsFormsApp1
{
    public class MaxError
    {
        private double x;
        private double X1;
        private double y;
        private int Nmin;
        private int Nmax;

        public MaxError(int N, int Nmaximum, double x0, double y0, double X)
        {
            Nmax = Nmaximum;
            Nmin = N;
            x = x0;
            y = y0;
            X1 = X;
        }

        public Grid eulerMaxError()
        {
            List<double> maxErrors = new List<double>();
            for(int i=Nmin;i<=Nmax;i++)
            {
                Exact exact = new Exact(i, x, y, X1);
                Euler euler = new Euler(i, x, y, X1);
                LTEerror error = new LTEerror(exact, euler);
                maxErrors.Add(error.y.Max());
            }


            Grid returnGrid = new Grid(Nmax-Nmin,Nmin,0,Nmax,"euler");
            returnGrid.y = maxErrors.ToArray();
            return returnGrid;
        }

        public Grid eulerImproveMaxError()
        {
            List<double> maxErrors = new List<double>();
            for(int i=Nmin;i<=Nmax;i++)
            {
                Exact exact = new Exact(i, x, y, X1);
                ImprovedEuler improvedEuler = new ImprovedEuler(i, x, y, X1);
                LTEerror error = new LTEerror(exact, improvedEuler);
                maxErrors.Add(error.y.Max());
            }

            Grid returnGrid = new Grid(Nmax-Nmin,Nmin,0,Nmax,"improved euler");
            returnGrid.y = maxErrors.ToArray();
            return returnGrid;
        }
        
        public Grid rungeKuttaMaxError()
        {
            List<double> maxErrors = new List<double>();
            for(int i=Nmin;i<=Nmax;i++)
            {
                Exact exact = new Exact(i, x, y, X1);
                RungeKutta rungeKutta = new RungeKutta(i, x, y, X1);
                LTEerror error = new LTEerror(exact, rungeKutta);
                maxErrors.Add(error.y.Max());
            }

            Grid returnGrid = new Grid(Nmax-Nmin,Nmin,0,Nmax,"runge kutta");
            returnGrid.y = maxErrors.ToArray();
            return returnGrid;
        }
        
    }
}