using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EqGraph.MathEq.Base;

namespace EqGraph.MathEq
{
    public class EllipseEq : EqGraphProvider
    {
        public EllipseEq(double a, double b, double h, double k)
        {
            A = Math.Abs(a);
            B = Math.Abs(b);
            H = h;
            K = k;
        }

        public override double Evaluate(double x)
        {
            return B * Math.Sqrt(1 - Math.Pow(x - H, 2) / Math.Pow(A, 2)) + K;
        }

        public override IEnumerable<string> GetParametersNames()
        {
            return new[]
            {
                "A",
                "B",
                "H",
                "K"
            };
        }

        public override List<List<PointF>> GetGraphData(double leftX, double rightX, double h)
        {
            if (H - A > leftX) leftX = H - A;
            if (H + A < rightX) rightX = H + A;
            
            var curves = base.GetGraphData(leftX, rightX, h);
            curves.Add(curves[0].Select(point => new PointF(point.X, (float)(-(point.Y - K) + K))).ToList());
            return curves;
        }
        
        public override PointF GetGraphCenterPoint()
        {
            return new PointF((float)H, (float)K);
        }

        public override string ToString()
        {
            return $"(x - {H})^2/{A}^2 + (y - {K})^2/{B}^2 = 1";
        }
        
        public double A { get; set; }
        public double B { get; set; }
        public double H { get; set; }
        public double K { get; set; }
        
    }
}