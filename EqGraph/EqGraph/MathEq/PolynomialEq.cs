using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using EqGraph.MathEq.Base;
using MathNet.Numerics;

namespace EqGraph.MathEq
{
    public class PolynomialEq : EqGraphProvider
    {
        public PolynomialEq(List<double> coefs)
        {
            Coefs = coefs;
        }
        
        public override double Evaluate(double x)
        {
            double y_val = 0;
            for (int i = Coefs.Count - 1; i >= 0; i--)
            {
                y_val += Coefs[i]*Math.Pow(x, i);
            }

            return y_val;
        }

        public IEnumerable<double> FindAllZeros()
        {
            Polynomial polynomial = new Polynomial(Coefs);
            
            Complex[] roots = polynomial.Roots();

            for (int i = 0; i < Coefs.Count - 1; i++)
            {
                if(roots[i].Imaginary != 0) continue;
                yield return roots[i].Real;
            }
        }
        
        public override IEnumerable<string> GetParametersNames()
        {
            return new[]
            {
                "Coefs"
            };
        }
        
        public override string ToString()
        {
            string res = "y = ";
            for (int i = Coefs.Count - 1; i >= 0; i--)
            {
                if (i == 0) res += $"{Coefs[i]}";
                else res += $"{Coefs[i]}*x^{i} + ";
            }

            return res;
        }
        
        public List<double> Coefs { get; set; }
    }
}