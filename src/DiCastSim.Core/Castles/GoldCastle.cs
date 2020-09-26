namespace DiCastSim.Core.Castles
{
    public class GoldCastle : Base.BaseCastle
    {
        public override void LandOnBase(Game game)
        {
            base.LandOnBase(game);
            game.Player.Coins += 20;
        }

        public override void GoThroughBase(Game game)
        {

        }
    }
}
