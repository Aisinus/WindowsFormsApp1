namespace WindowsFormsApp1 {
    public class Euler:Grid {
        public Euler(int N, double x0, double y0, double X) : base(N, x0, y0, X, "euler") {
            for (int i = 0; i < n; i++) {
                if (i == 0) {
                    y[i] = y0;
                }else{
                    y[i] = EulerEquation(x[i-1],y[i-1]);
                }
            }
        }
        private double EulerEquation(double x1, double y1) {
            return y1 + h * DifferentialEquation(x1, y1);
        }
    }
}