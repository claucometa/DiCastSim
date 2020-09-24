namespace DiCastSim.Core.Objects
{
    public class MonsterTwoEffect : MonsterEffect
    {
        public override string Do()
        {
            base.Do();
            game.Player.Life -= 3;
            return $"{game.Player.Name} Monster level II";
        }
    }
}