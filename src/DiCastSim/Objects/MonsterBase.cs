namespace DiCastSim.Objects
{
    public class MonsterBase : BaseItem
    {
        public override string Do()
        {
            game.Hunting = true;
            game.AddDice(true);
            return null;
        }
    }
}
