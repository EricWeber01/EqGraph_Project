using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using EqGraph.MathEq;
using EqGraph.MathEq.Base;

namespace EqGraph
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            this.EqListBox.DataSource = Enum.GetValues(typeof(EqType));

            this.EqChart = new EqChart(500, 500, _scale);
            this.EqChart.Location = new Point(0, 0);
            this.Controls.Add(this.EqChart);

            DrawChart();
        }

        private void DrawChart()
        {
            this.EqChart.ClearGraph();

            foreach (var provider in _eqGraphProviders)
            {
                this.EqChart.AddCurves(provider.GetGraphData(-_scale, _scale, _chartH));
            }

            this.EqChart.Draw();
            this.EqChart.Refresh();
        }

        private void ScaleDownButton_Click(object sender, EventArgs e)
        {
            _scale = Math.Min(MAX_SCALE, _scale + _scaleH);
            this.EqChart.Scale = _scale;
            DrawChart();
        }

        private void ScaleUpButton_Click(object sender, EventArgs e)
        {
            _scale = Math.Max(MIN_SCALE, _scale - _scaleH);
            this.EqChart.Scale = _scale;
            DrawChart();
        }

        private void AddEqButton_Click(object sender, EventArgs e)
        {
            EqGraphProvider newEq = (EqType)EqListBox.SelectedItem switch
            {
                EqType.Polynomial => new PolynomialEq(new List<double>{0, 1}),
                EqType.InversePolynomial => new InvPolynomialEq(new List<double>{0, 1}, 1, 0),
                EqType.Logarithmic => new LogEq(1, 10, 1, 0),
                EqType.Exponential => new ExpEq(1, Math.E, 1, 0),
                EqType.Ellipse => new EllipseEq(1, 1, 0, 0),
                EqType.Sin => new SinEq(1, 1, 0, 0),
                EqType.Cos => new CosEq(1, 1, 0, 0),
                _ => throw new Exception("This equation isn't known")
            };
            
            this.EqTabs.TabPages.Add(new MathEqTab(newEq, (EqType)EqListBox.SelectedItem, DrawChart, DeleteEqTab));
            _eqGraphProviders.Add(newEq);
            
            DrawChart();
        }

        private void DeleteEqTab(MathEqTab mathEqTab, EqGraphProvider mathEq)
        {
            this.EqTabs.TabPages.Remove(mathEqTab);
            _eqGraphProviders.Remove(mathEq);
            
            DrawChart();
        }

        private double _scale = 5;
        private double _scaleH = 1;
        const double MIN_SCALE = 1, MAX_SCALE = 100;
        private EqChart EqChart;
        private double _chartH = 0.001;
        private List<EqGraphProvider> _eqGraphProviders = new()
        {
            // new LogEq(1, 10, 1, 0),
            // new InvPolynomialEq(new List<double>{1, 0, 0, 0, -1}, 1, 1),
            // new EllipseEq(0.5, 2, 5, 0)
        };
        
    }
    
 
}