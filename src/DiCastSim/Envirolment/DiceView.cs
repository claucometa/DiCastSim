using DiCastSim.Core;
using DiCastSim.Core.Models;
using DiCastSim.Core.Services;
using System;
using System.Windows.Forms;

namespace DiCastSim.Envirolment
{
    public partial class DiceView : UserControl
    {
        public DiceInHand Tipo { get; set; }
        public readonly DiceGenerator dc;

        public int? ThrowDice()
        {
            if (Value.HasValue)
                label1.Text = Value.ToString();

            return Value;
        }

        public DiceInHand SpecialDice;

        private int? Value
        {
            get
            {
                SpecialDice = Tipo;
                return dc.EvaluateDice(Tipo.Dice);
            }
        }

        public DiceView(DiceInHand tipo)
        {
            InitializeComponent();
            Tipo = tipo;
            label1.Text = Tipo.Dice.ToString();
            dc = IOC.Resolve<DiceGenerator>();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Clicked?.Invoke(this, Tipo);
        }

        public event EventHandler<DiceInHand> Clicked;
    }
}
