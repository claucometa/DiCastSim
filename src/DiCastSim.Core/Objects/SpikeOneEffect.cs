namespace DiCastSim.Core.Objects
{
    public class SpikeOneEffect : ItemEffect
    {
        public override string Do()
        {
            game.Player.AddLife(-3);

            return $"{game.Player.Name} trap I";
        }
    }
}