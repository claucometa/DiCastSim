using DiCastSim.Core;

namespace DiCastSim.Objects
{
    class MonsterTwoItem : BaseItem
    {
        public override string Do()
        {
            game.Player.Life -= 3;

            return $"{game.Player.Name} Monster level II";
        }

        public MonsterTwoItem()
        {
            Img = Properties.Resources.monsterTwo;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MonsterTwoItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "MonsterTwoItem";
            this.ResumeLayout(false);

        }
    }
}
