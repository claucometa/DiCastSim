using DiCastSim.Core;
using DiCastSim.Core.Enums;
using DiCastSim.Core.Services;
using DiCastSim.Envirolment;
using System.Windows.Forms;

namespace DiCastSim
{
    public partial class HuntMonter : UserControl
    {        
        public HuntMonter()
        {
            InitializeComponent();            
        }

        public int[] Dices
        {
            set
            {
                flowLayoutPanel1.Controls.Clear();
                foreach (var item in value)
                {
                    flowLayoutPanel1.Controls.Add(new DiceView((Dice)item));
                }
            }
        }
    }
}
