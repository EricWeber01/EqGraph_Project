using System;
using System.Collections.Generic;
using EqGraph.MathEq.Base;

namespace EqGraph.MathEq
{
    public class ExpEq : EqGraphProvider
    {
        public ExpEq(double a, double b, double c, double d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        public override double Evaluate(double x)
        {
            return A * Math.Pow(B, C * x) + D;
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

        public override string ToString()
        {
            return $"{A}*{B}^({C}*x) + {D}";
        }
        
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double D { get; set; }

        
    }
}