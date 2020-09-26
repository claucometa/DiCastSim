namespace DiCastSim.Core.Castles
{
    public class AtackCastle : Base.BaseCastle
    {
        public override void LandOnBase(Game game)
        {
            base.LandOnBase(game);
            game.Player.Atack += 2;
        }

        public override void GoThroughBase(Game game)
        {

        }
    }
}
