namespace DiCastSim.Core.Objects
{
    public class MonsterEffect : ItemEffect
    {
        public override string Do()
        {
            game.Hunting = true;
            game.AddDice(true);
            return null;
        }
    }

}