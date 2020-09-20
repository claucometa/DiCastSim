
using DiCastSim.Core;

namespace DiCastSim.Objects
{
    class BookTwoItem : BaseItem
    {
        public override string Do()
        {
            return $"{game.Player.Name} reading a book";
        }

        public BookTwoItem()
        {
            Img = Properties.Resources.book2;
        }
    }
}
