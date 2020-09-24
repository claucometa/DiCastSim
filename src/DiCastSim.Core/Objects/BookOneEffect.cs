namespace DiCastSim.Core.Objects
{
    public class BookOneEffect : ItemEffect
    {
        public override string Do()
        {
            return $"{game.Player.Name} reading a book";
        }
    }
}