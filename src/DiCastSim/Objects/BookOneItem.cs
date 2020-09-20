using DiCastSim.Core;

namespace DiCastSim.Objects
{
    class BookOneItem : BaseItem
    {
        public override string Do()
        {
            return $"{game.Player.Name} reading a book";
        }

        public BookOneItem()
        {
            Img = Properties.Resources.book1;
        }
    }
}
