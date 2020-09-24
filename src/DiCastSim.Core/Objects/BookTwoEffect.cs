namespace DiCastSim.Core.Objects
{
    public class BookTwoEffect : ItemEffect
    {
        public override string Do()
        {
            return $"{game.Player.Name} reading a book";
        }
    }
}