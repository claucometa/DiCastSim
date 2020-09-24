using DiCastSim.Core;
using DiCastSim.Core.Objects;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DiCastSim
{
    public partial class BaseItem : UserControl
    {
        public int Index;
        protected readonly Game game;
        protected ItemEffect effect;

        public string Do()
        {
            return effect.Do();
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
