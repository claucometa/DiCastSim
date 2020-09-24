namespace DiCastSim.Core.Objects
{
    public class StoreEffect : ItemEffect
    {
        public override string Do()
        {
            return $"{game.Player.Name} visited the store";
        }
    }
}