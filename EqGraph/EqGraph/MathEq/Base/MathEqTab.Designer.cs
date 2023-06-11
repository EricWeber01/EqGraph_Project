using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace EqGraph.MathEq.Base
{
    partial class MathEqTab
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            EqNameLabel = new Label();
            EqRepresentationLabel = new Label();
            DeleteButton = new Button();

            this.EqNameLabel.Location = new Point(10, 10);
            this.EqNameLabel.Size = new Size(200, 40);
            this.EqNameLabel.Font = new Font(FontFamily.GenericSerif, 20);
            this.EqNameLabel.Text = _eqType.ToString();
            
            this.EqRepresentationLabel.Location = new Point(10, 60);
            this.EqRepresentationLabel.Size = new Size(200, 40);
            this.EqNameLabel.Font = new Font(FontFamily.GenericMonospace, 16);
            this.EqRepresentationLabel.Text = _mathEq.ToString();

            int currentY = 120, YHeight = 20, YGap = 20, XGap = 10, Xsize = 200;
            foreach (var parameter in _mathEq.GetParametersNames())
            {
                var lbl = new Label();
                lbl.Location = new Point(XGap, currentY);
                lbl.Size = new Size(8 * parameter.Length, YHeight);
                lbl.Font = new Font(FontFamily.GenericSerif, 10);
                lbl.Text = parameter;
                this.Controls.Add(lbl);

                var txtBox = new TextBox();
                txtBox.Location = new Point(XGap + lbl.Width + 10, currentY);
                txtBox.Size = new Size(Xsize - txtBox.Location.X, YHeight);
                txtBox.Font = new Font(FontFamily.GenericSerif, 10);
                txtBox.KeyUp += (sender, args) =>
                {
                    if(txtBox.Text.Length == 0) return;
                    if (parameter == "Coefs" || parameter == "PolynomialCoefs")
                    {
                        var tmp = txtBox.Text.Trim().Split(' ');
                        if(tmp.Any(x => !double.TryParse(x, out _))) return;
                        else _mathEq.GetType().GetProperty(parameter).SetValue(_mathEq,
                            tmp.Select(x => Double.Parse(x)).ToList());
                    }
                    else
                    {
                        if(!double.TryParse(txtBox.Text, out _)) return;
                        _mathEq.GetType().GetProperty(parameter).SetValue(_mathEq, Double.Parse(txtBox.Text));
                    }

                    this._refreshCallback();
                    this.EqRepresentationLabel.Text = _mathEq.ToString();
                };
                this.Controls.Add(txtBox);
                
                currentY += YHeight + YGap;
            }

            DeleteButton.Location = new Point(XGap, currentY);
            DeleteButton.Size = new Size(Xsize, YHeight);
            DeleteButton.Text = "DELETE EQ";
            DeleteButton.Click += (sender, args) =>
            {
                this._deleteCallback(this, _mathEq);
                this.Dispose();
            };

            this.Text = _eqType.ToString();
            
            this.Controls.Add(EqNameLabel);
            this.Controls.Add(EqRepresentationLabel);
            this.Controls.Add(DeleteButton);
        }

        #endregion

        private Label EqNameLabel, EqRepresentationLabel;
        private Button DeleteButton;
    }
}