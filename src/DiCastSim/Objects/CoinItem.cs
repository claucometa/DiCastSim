namespace DiCastSim.Objects
{
    class CoinItem : BaseItem
    {
        public override string Do()
        {
            game.Player.Coins += 12;

            return $"{game.Player.Name} got money";
        }

        public CoinItem()
        {
            Img = Properties.Resources.coin;
        }
    }
}
