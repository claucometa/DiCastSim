using System.Drawing;
using System.Windows.Forms;

namespace DiCastSim
{
    public partial class Board : UserControl
    {
        public Block GetSquare(int i) => (Block)Controls[i % 24];

        public Board()
        {
            InitializeComponent();

            for (int x = 0; x < 6; x++)
            {
                var b = new Block();
                b.Location = new Point(x + x * b.Width, 0);
                this.Controls.Add(b);
            }

            for (int x = 0; x < 6; x++)
            {
                var b = new Block();
                b.Location = new Point(6 * b.Width + 6, x + x * b.Height);
                this.Controls.Add(b);
            }

            for (int x = 6; x > 0; x--)
            {
                var b = new Block();
                b.Location = new Point(x + x * b.Width, 6 * b.Height + 6);
                this.Controls.Add(b);
            }

            for (int x = 6; x > 0; x--)
            {
                var b = new Block();
                b.Location = new Point(0, x + x * b.Height);
                this.Controls.Add(b);
            }
        }
    }
}
