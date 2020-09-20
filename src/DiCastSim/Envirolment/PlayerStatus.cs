using DiCastSim.Core.Models;
using System.Windows.Forms;

namespace DiCastSim
{
    public partial class PlayerStatus : UserControl
    {
        public PlayerStatus()
        {
            InitializeComponent();
        }

        public string _Title;
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                groupBox1.Text = _Title = value; 
            }
        }

        Player p;
        public Player Player
        {
            set
            {
                p = value;
                label4.Text = p.Coins.ToString();
                label5.Text = p.Life.ToString();
                label6.Text = p.Atack.ToString();
                label13.Visible = p.Imprisioned;
                label8.Text = p.Level.ToString();
            }
        }
    }
}
