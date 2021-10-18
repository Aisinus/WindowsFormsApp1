namespace WindowsFormsApp1
{
    public class Euler:Grid
    {

        double eulerEquation(double x, double y)
        {
            return y + h * differentialEquation(x, y);
        }
        
        public Euler(int N, double x0, double y0, double X) : base(N, x0, y0, X)
        {
            for (int i = 0; i < N; i++)
            {
                if (i == 0)
                {
                    y[i] = y0;
                }
                else
                {
                    y[i] = eulerEquation(x[i-1],y[i-1]);
                }
            }
        }
    }
}