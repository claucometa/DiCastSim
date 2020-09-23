using DiCastSim.Core;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DiCastSim
{
    public partial class BaseItem : UserControl
    {
        public int Index;
        protected readonly Game game;

        public virtual string Do()
        {
            throw new NotImplementedException();
        }

        public BaseItem()
        {
            InitializeComponent();
            game = IOC.Resolve<Game>();
        }

        public Image _img;
        public Image Img { get => _img; 
            set { _img = value; pictureBox1.Image = _img; } }
    }
}
