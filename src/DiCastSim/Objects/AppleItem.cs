namespace DiCastSim.Objects
{
    class AppleItem : BaseItem
    {        
        public override string Do()
        {
            game.Player.Life += 8;

            return $"{game.Player.Name} eating an apple";
        }

        public AppleItem()
        {
            Img = Properties.Resources.apple;            
        }
    }
}
