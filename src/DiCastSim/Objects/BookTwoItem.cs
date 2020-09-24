using DiCastSim.Core.Objects;

namespace DiCastSim.Objects
{
    class BookTwoItem : BaseItem
    {
        public BookTwoItem()
        {
            effect = new BookTwoEffect();
            Img = Properties.Resources.book2;
        }
    }
}
