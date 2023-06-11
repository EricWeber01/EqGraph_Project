using System;
using System.Collections.Generic;
using System.Drawing;
using EqGraph.MathEq.Base;

namespace EqGraph.MathEq
{
    public class CosEq : EqGraphProvider
    {
        public CosEq(double a, double b, double h, double k)
        {
            A = a;
            B = b;
            H = h;
            K = k;
        }
        
        public override double Evaluate(double x)
        {
            return A * Math.Cos(B * (x - H)) + K;
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
            return $"y = {A}*cos({B}*(x - {H})) + {K}";
        }

        public double A { get; set; }
        public double B { get; set; }
        public double H { get; set; }
        public double K { get; set; }
    }
}