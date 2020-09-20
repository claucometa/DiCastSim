using System.Windows.Forms;

namespace DiCastSim
{
    public partial class PlayerSprit : UserControl
    {
        public FlowLayoutPanel deck;

        public PlayerSprit()
        {
            InitializeComponent();
            this.Height = this.Width = 64;
        }
    }
}
