using System.Collections.Generic;
using System.Drawing;

namespace EqGraph.MathEq.Base
{
    public abstract class EqGraphProvider : IMathEq
    {
        public virtual List<List<PointF>> GetGraphData(double leftX, double rightX, double h)
        {
            var curve = new List<PointF>();
            for (double i = leftX; i <= rightX; i += h)
            {  
                curve.Add(new PointF((float)i, (float)this.Evaluate(i)));
            }

            return new List<List<PointF>>
            {
                curve
            };
        }

        public virtual PointF GetGraphCenterPoint()
        {
            return new PointF(0, (float)this.Evaluate(0));
        }
        
        public abstract double Evaluate(double x);
        public abstract IEnumerable<string> GetParametersNames();
    }
}