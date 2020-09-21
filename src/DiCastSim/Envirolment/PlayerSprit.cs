using System.Windows.Forms;

namespace DiCastSim
{
    public partial class PlayerSprit : UserControl
    {
        public FlowLayoutPanel _deck;
        public FlowLayoutPanel Deck {
            set
            {
                _deck = value;
                _deck.Controls.Clear();
            }
            get => _deck;
        }

        public PlayerSprit()
        {
            InitializeComponent();
            this.Height = this.Width = 64;
        }
    }
}
