using System;
using System.Collections.Generic;
using System.Drawing;
using EqGraph.MathEq.Base;

namespace EqGraph.MathEq
{
    public class SinEq : EqGraphProvider
    {
        public SinEq(double a, double b, double h, double k)
        {
            A = a;
            B = b;
            H = h;
            K = k;
        }
        
        public override double Evaluate(double x)
        {
            return A * Math.Sin(B * (x - H)) + K;
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

        public override string ToString()
        {
            return $"y = {A}sin({B}(x - {H})) + {K}";
        }

        public double A { get; set; }
        public double B { get; set; }
        public double H { get; set; }
        public double K { get; set; }
    }
}