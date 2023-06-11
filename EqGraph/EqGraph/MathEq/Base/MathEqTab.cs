using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace EqGraph.MathEq.Base
{
    public partial class MathEqTab : TabPage
    {
        public MathEqTab(EqGraphProvider mathEq, EqType eqType, Action refreshCallback,
            Action<MathEqTab, EqGraphProvider> deleteCallback)
        {
            _mathEq = mathEq;
            _eqType = eqType;
            _refreshCallback = refreshCallback;
            _deleteCallback = deleteCallback;
            
            InitializeComponent();
        }

        private EqGraphProvider _mathEq;
        private EqType _eqType;
        private Action _refreshCallback;
        private Action<MathEqTab, EqGraphProvider> _deleteCallback;
    }
}