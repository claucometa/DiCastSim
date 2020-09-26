namespace DiCastSim.Core.Castles
{
    public class HealthCastle : Base.BaseCastle
    {
        public override void LandOnBase(Game game)
        {
            base.LandOnBase(game);
            game.Player.AddLife(6);
        }

        public override void GoThroughBase(Game game)
        {
            game.Player.AddLife(2);
        }
    }
}
