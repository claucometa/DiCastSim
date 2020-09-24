using DiCastSim.Core.Objects;

namespace DiCastSim.Objects
{
    class BookOneItem : BaseItem
    {        
        public BookOneItem()
        {
            effect = new BookOneEffect();
            Img = Properties.Resources.book1;
        }
    }
}
