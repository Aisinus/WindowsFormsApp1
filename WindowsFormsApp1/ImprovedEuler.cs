namespace WindowsFormsApp1
{
    public class ImprovedEuler:Grid
    {
        public ImprovedEuler(int N, double x0, double y0, double X) : base(N, x0, y0, X,"improved euler")
        {
            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    y[i] = y0;
                }
                else
                {
                    y[i] = y[i - 1] + (h/2) * ((DifferentialEquation(x[i-1], y[i-1]) +
                                            DifferentialEquation(x[i-1] + h,
                                                y[i-1] + h * DifferentialEquation(x[i-1], y[i-1]))));
                }
                
            }
        }
    }
}