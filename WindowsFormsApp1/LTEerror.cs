using System;

namespace WindowsFormsApp1
{
    public class LTEerror:Grid
    
    {
        public LTEerror(Grid first, Grid second) : base(first.n-1,first.x[0],0,first.x[first.n-1],second.name)
        {
            for (int i = 0; i < n; i++)
            {
                y[i] = Math.Abs(first.y[i] - second.y[i]);
            }
            
        }
    }
}