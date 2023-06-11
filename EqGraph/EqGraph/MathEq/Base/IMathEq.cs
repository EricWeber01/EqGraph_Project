using System.Collections.Generic;

namespace EqGraph.MathEq.Base
{
    public enum EqType
    {
        Polynomial,
        InversePolynomial,
        Logarithmic,
        Exponential,
        Ellipse,
        Sin,
        Cos
    }
    
    public interface IMathEq
    {
        public double Evaluate(double x);

        public IEnumerable<string> GetParametersNames();
    }
}