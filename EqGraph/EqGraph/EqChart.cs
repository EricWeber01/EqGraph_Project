using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EqGraph
{
    public class EqChart : PictureBox
    {
        public EqChart(int width, int height, double scale)
        {
            this.Width = width;
            this.Height = height;
            this.Scale = scale;

            this.AxisPen = new Pen(Color.Black, 4);
            this.AxisFont = new Font(FontFamily.GenericMonospace, 16);

            this.DataPen = new Pen(Color.Firebrick);

            this._originPoint = new Point(width/2, height/2);
            
            this.Build();
        }
        
        private void Build()
        {
            Bitmap bmp = new Bitmap(this.Width, this.Height);
            this.Image = bmp;
            this._graphics = Graphics.FromImage(bmp);
        }
        
        public void Draw()
        {
            this._graphics.Clear(Color.Transparent);
            
            DrawAxes();
            DrawData();
        }

        private void DrawAxes()
        {
            this._graphics.DrawLine( this.AxisPen, 
                new PointF(_originPoint.X, 0), 
                new PointF(_originPoint.X, this.Height));
                        
            this._graphics.DrawString((-Scale).ToString(), 
                AxisFont, new SolidBrush(AxisPen.Color), 
                new PointF(0, _originPoint.Y));
            this._graphics.DrawString(Scale.ToString(), 
                AxisFont, new SolidBrush(AxisPen.Color), 
                new PointF(this.Width-this._graphics.MeasureString(Scale.ToString(), AxisFont).Width, _originPoint.Y));
            
            this._graphics.DrawLine( this.AxisPen, 
                new PointF(0, _originPoint.Y), 
                new PointF(this.Width, _originPoint.Y));
            
            this._graphics.DrawString(Scale.ToString(), 
                AxisFont, new SolidBrush(AxisPen.Color), 
                new PointF(_originPoint.X, 0));
            this._graphics.DrawString((-Scale).ToString(), 
                AxisFont, new SolidBrush(AxisPen.Color), 
                new PointF(_originPoint.X, this.Height-this._graphics.MeasureString(Scale.ToString(), AxisFont).Height));
        }
        
        private void DrawData()
        {
            if(_values.Count == 0) return;

            _graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            foreach (var normalPoints in _normalizedValues)
            {
                if (normalPoints.Count == 0) continue;
                if (normalPoints.Count == 1) 
                    _graphics.FillEllipse(new SolidBrush(DataPen.Color), 
                        new Rectangle(Point.Subtract(new Point((int)normalPoints[0].X, (int)normalPoints[0].Y), new Size(3, 3)),
                            new Size(6, 6)));
                else _graphics.DrawLines(DataPen, normalPoints.ToArray());
            }
        }

        private void NormalizeData(List<List<PointF>> newValues)
        {
            foreach (var points in newValues)
            {
                _normalizedValues.Add(new List<PointF>());
                foreach (var point in points)
                {
                    _normalizedValues.Last().Add(
                        new PointF(
                            (float)(_originPoint.X + (point.X / Scale) * (this.Width / 2.0 )),
                                (float)(_originPoint.Y - (point.Y / Scale) * (this.Height / 2.0 ))
                            ));
                    
                }
            }
        }
        

        private PointF _originPoint;
        public PointF OriginPoint
        {
            get => _originPoint;
            set => _originPoint = value;
        }

        public double Scale { get; set; }
        public Pen AxisPen { get; set; }
        public Font AxisFont { get; set; }
        public Pen DataPen { get; set; }

        private List<List<PointF>> _values = new();

        public void ClearGraph()
        {
            _values.Clear();
            _normalizedValues.Clear();
        }

        public void AddCurve(List<PointF> curvePoints)
        {
            _values.Add(curvePoints);
            NormalizeData(new List<List<PointF>>{curvePoints});
        }
        
        public void AddCurves(List<List<PointF>> curves)
        {
            _values.AddRange(curves);
            NormalizeData(curves);
        }
        
        private Graphics _graphics;
        private List<List<PointF>> _normalizedValues = new();
        
    }
}