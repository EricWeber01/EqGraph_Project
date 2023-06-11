using System;
using System.Collections.Generic;
using System.Drawing;
using EqGraph.MathEq.Base;

namespace EqGraph.MathEq
{
    public class LogEq : EqGraphProvider
    {
        public LogEq(double a, double b, double c, double d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }
        
        public override IEnumerable<string> GetParametersNames()
        {
            return new[]
            {
                "A",
                "B",
                "C",
                "D"
            };
        }

        public override List<List<PointF>> GetGraphData(double leftX, double rightX, double h)
        {
            if (leftX <= 0) leftX = 1e-100;
            if (leftX > rightX) rightX = leftX;
            return base.GetGraphData(leftX, rightX, h);
        }
        
        public override PointF GetGraphCenterPoint()
        {
            return new PointF(1, (float)D);
        }

        public override double Evaluate(double x)
        {
            return A * Math.Log(C * x, B) + D;
        }
        
        public override string ToString()
        {
            return $"y = {A}*log_{B}({C}*x) + {D}";
        }

        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double D { get; set; }

    }
}