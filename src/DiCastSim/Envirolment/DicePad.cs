using DiCastSim.Core;
using DiCastSim.Core.Enums;
using DiCastSim.Core.Models;
using DiCastSim.Core.Services;
using System;
using System.Windows.Forms;

namespace DiCastSim.Envirolment
{
    public partial class DicePad : UserControl
    {
        public DiceInHand Tipo { get; set; }
        public readonly DiceGenerator dc;

        public int? PaintDiceFace()
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

        public DicePad(DiceInHand tipo)
        {
            InitializeComponent();
            Tipo = tipo;
            label1.Text = Tipo.Dice.ToString();
            dc = IOC.Resolve<DiceGenerator>();
            Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Clicked?.Invoke(this, Tipo);
        }

        public void Change(Dice face)
        {
            Tipo.Dice = face;
            label1.Text = Tipo.Dice.ToString();
        }

        public event EventHandler<DiceInHand> Clicked;
    }
}
