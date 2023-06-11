using System;
using System.Windows.Forms;

namespace EqGraph
{
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
        }
        
    }
}