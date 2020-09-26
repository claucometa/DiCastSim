namespace DiCastSim.Core.Castles
{
    public class FireCastle : Base.BaseCastle
    {
        public override void LandOnBase(Game game)
        {
            base.LandOnBase(game);
            game.PerformAtack();
        }

        public override void GoThroughBase(Game game)
        {

        }
    }
}
