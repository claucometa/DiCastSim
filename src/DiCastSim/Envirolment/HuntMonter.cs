using Autofac;
using DiCastSim.Core;
using DiCastSim.Core.Services;
using DiCastSim.Envirolment;
using System.Windows.Forms;

namespace DiCastSim
{
    public partial class HuntMonter : UserControl
    {
        readonly MonsterService ms;

        public HuntMonter()
        {
            InitializeComponent();
            ms = IOC.Resolve<MonsterService>();
        }

        public void SetDices(int total)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var item in ms.GetMonterDices(total))
            {
                flowLayoutPanel1.Controls.Add(new DiceView(item));
            }
        }
    }
}
