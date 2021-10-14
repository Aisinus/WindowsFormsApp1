namespace WindowsFormsApp1
{
    public class ImprovedEuler:Grid
    {
        public ImprovedEuler(int N, double x0, double y0, double X) : base(N, x0, y0, X)
        {
            for (int i = 0; i < N; i++)
            {
                if (i == 0)
                {
                    y[i] = y0;
                }
                else
                {
                    y[i] = y[i - 1] + h * ((differentialEquation(x[i], y[i]) +
                                            differentialEquation(x[i] + h,
                                                y[i] + h * differentialEquation(x[i], y[i])))/2);
                }
            }
        }
    }
}