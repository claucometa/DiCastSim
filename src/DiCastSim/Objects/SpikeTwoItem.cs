using DiCastSim.Core;

namespace DiCastSim.Objects
{
    class SpikeTwoItem : BaseItem
    {
        public override string Do()
        {
            game.Player.Life -= 6;

            return $"{game.Player.Name} trap II";
        }

        public SpikeTwoItem()
        {
            Img = Properties.Resources.trap2;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SpikeTwoItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "SpikeTwoItem";
            this.ResumeLayout(false);

        }
    }
}
