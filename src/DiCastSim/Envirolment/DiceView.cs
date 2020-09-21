using DiCastSim.Core;
using DiCastSim.Core.Enums;
using DiCastSim.Core.Services;
using System;
using System.Windows.Forms;

namespace DiCastSim.Envirolment
{
    public partial class DiceView : UserControl
    {
        public Dice Tipo { get; set; }
        public readonly DiceGenerator dc;

        public int? ThrowDice()
        {
            if (Value.HasValue)
                label1.Text = Value.ToString();

            return Value;
        }

        public Dice SpecialDice;

        private int? Value
        {
            get
            {
                SpecialDice = Tipo;
                return dc.EvaluateDice(Tipo);
            }
        }

        public DiceView(Dice tipo)
        {
            InitializeComponent();
            Tipo = tipo;
            label1.Text = Tipo.ToString();
            dc = IOC.Resolve<DiceGenerator>();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Clicked?.Invoke(this, e);
        }

        public event EventHandler Clicked;
    }
}
