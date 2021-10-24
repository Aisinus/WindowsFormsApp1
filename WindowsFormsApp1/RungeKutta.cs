namespace WindowsFormsApp1
{
    public class RungeKutta:Grid
    {
        public RungeKutta(int N, double x0, double y0, double X) : base(N, x0, y0, X, "runge kutta")
        {
            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    y[i] = y0;
                }
                else
                {
                    var k1 = differentialEquation(x[i - 1], y[i - 1]);
                    var k2 = differentialEquation(x[i-1]+h/2,y[i-1]+(h*k1)/2);
                    var k3 = differentialEquation(x[i-1]+h/2,y[i-1]+(h*k2)/2);
                    var k4 = differentialEquation(x[i-1]+h,y[i-1]+h*k3);
                    y[i] = y[i - 1] + h * (k1 / 6 + k2 / 3 + k3 / 3 + k4 / 6);
                }
            }
        }
    }
}