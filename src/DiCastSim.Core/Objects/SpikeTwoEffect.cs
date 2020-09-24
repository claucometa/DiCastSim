namespace DiCastSim.Core.Objects
{
    public class SpikeTwoEffect : ItemEffect
    {
        public override string Do()
        {
            game.Player.AddLife(-6);

            return $"{game.Player.Name} trap II";
        }
    }
}