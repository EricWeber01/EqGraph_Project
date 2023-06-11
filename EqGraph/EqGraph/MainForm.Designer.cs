using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using EqGraph.MathEq;

namespace EqGraph
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            
            this.SuspendLayout();

            this.ScaleDownButton = new Button();
            this.ScaleUpButton = new Button();
            this.EqListBox = new ComboBox();
            this.AddEqButton = new Button();
            this.EqTabs = new TabControl();
            
            this.ScaleDownButton.Location = new Point(520, 20);
            this.ScaleDownButton.Size = new Size(100, 40);
            this.ScaleDownButton.Text = "-Zoom";
            this.ScaleDownButton.Click += ScaleDownButton_Click;
            
            this.ScaleUpButton.Location = new Point(640, 20);
            this.ScaleUpButton.Size = new Size(100, 40);
            this.ScaleUpButton.Text = "+Zoom";
            this.ScaleUpButton.Click += ScaleUpButton_Click;

            this.EqListBox.Location = new Point(520, 80);
            this.EqListBox.Size = new Size(180, 40);
            this.EqListBox.Font = new Font(FontFamily.GenericMonospace, 20);
            
            this.AddEqButton.Location = new Point(700, 80);
            this.AddEqButton.Size = new Size(40, 40);
            this.AddEqButton.Text = "+";
            this.AddEqButton.Click += AddEqButton_Click;
            
            this.EqTabs.Location = new Point(520, 140);
            this.EqTabs.Size = new Size(220, 340);
            
            this.Size = new System.Drawing.Size(760,530);
            this.Text =  "Eq Chart";
            
            this.Controls.Add(ScaleDownButton);
            this.Controls.Add(ScaleUpButton);
            this.Controls.Add(EqListBox);
            this.Controls.Add(AddEqButton);
            this.Controls.Add(EqTabs);
            this.ResumeLayout(false);

        }

        #endregion

        private Button ScaleDownButton;
        private Button ScaleUpButton;
        private ComboBox EqListBox;
        private Button AddEqButton;
        private TabControl EqTabs;
    }
}