using DiCastSim.Core.Models;
using System.Windows.Forms;

namespace DiCastSim
{
    public partial class PlayerSprit : UserControl
    {
        public Player Player;
        public FlowLayoutPanel _deck;
        public FlowLayoutPanel Deck {
            set
            {
                _deck = value;
                _deck.Controls.Clear();
            }
            get => _deck;
        }

        public PlayerSprit(Player player)
        {
            InitializeComponent();
            this.Height = this.Width = 64;
            Player = player;
        }
    }
}
