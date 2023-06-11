using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EqGraph.MathEq.Base;
using MathNet.Numerics;

namespace EqGraph.MathEq
{
    public class InvPolynomialEq : EqGraphProvider
    {

        public InvPolynomialEq(List<double> polynomialCoefs, double k, double b)
        {
            _polynomialEq = new PolynomialEq(polynomialCoefs);
            K = k;
            B = b;
        }
        
        public override double Evaluate(double x)
        {
            return K / _polynomialEq.Evaluate(x) + B;
        }

        public override IEnumerable<string> GetParametersNames()
        {
            return new[]
            {
                "PolynomialCoefs",
                "K",
                "B"
            };
        }
        
        public override List<List<PointF>> GetGraphData(double leftX, double rightX, double h)
        {
            var curvePoints = new List<double> { leftX };
            var zeros = new List<double>();
            foreach (var zeroX in _polynomialEq.FindAllZeros())
            {
                if(zeroX < leftX || zeroX > rightX || zeroX.AlmostEqual(curvePoints.Last())) continue;
                curvePoints.Add(zeroX);
                zeros.Add(zeroX);
            }
            curvePoints.Add(rightX);

            List<List<PointF>> data = new();
            for (int i = 0; i < curvePoints.Count-1; i++)
            {
                List<PointF> curveData = new();
                for (double j = curvePoints[i]; j <= curvePoints[i + 1]; j += h)
                {
                    curveData.Add(new PointF((float)j, GetGraphFloat(this.Evaluate(j)) ));
                    if (Math.Abs(curveData.Last().Y) == 10_000)
                    {
                        if (curveData.Count > 1 && j.AlmostEqual(curvePoints[i+1], 5))
                        {
                            curveData[curveData.Count-1] = new PointF(curveData[curveData.Count-1].X,
                                curveData[curveData.Count-2].Y);
                        }
                    
                        if (j.AlmostEqual(curvePoints[i], 5))
                        {
                            curveData[curveData.Count - 1] = new PointF(curveData[curveData.Count - 1].X,
                                (float)this.Evaluate(curveData[curveData.Count-1].X + h)
                            );
                        }
                        
                    }
                }
                data.Add(curveData);
            }

            return data;
        }

        private float GetGraphFloat(double x)
        {
            return (float) Math.Min(10_000, Math.Max(-10_000, x));
        }
        
        public override string ToString()
        {
            return $"y = {K}/({_polynomialEq.ToString().Substring(4)}) + {B}";
        }

        private PolynomialEq _polynomialEq;
        public List<double> PolynomialCoefs
        {
            set => _polynomialEq.Coefs = value;
        }
        
        public double K { get; set; }
        public double B { get; set; }
        
    }
}