using DiCastSim.Core.Enums;
using DiCastSim.Objects;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DiCastSim
{
    class Inventario : Dictionary<Drops, Type>
    {       
        public UserControl CreateItem(Drops item) =>
            (UserControl)Activator.CreateInstance(this[item]);

        public Inventario()
        {
           Add(Drops.Nothing, typeof(NothingItem));
           Add(Drops.Castle, typeof(CastleItem));
           Add(Drops.Portal, typeof(PortalItem));
           Add(Drops.Sword, typeof(SwordItem));
           Add(Drops.Bag, typeof(BagItem));
           Add(Drops.BookOne, typeof(BookOneItem));
           Add(Drops.BookTwo, typeof(BookTwoItem));
           Add(Drops.Apple, typeof(AppleItem));
           Add(Drops.Bread, typeof(BreadItem));
           Add(Drops.Monster1, typeof(MonsterOneItem));
           Add(Drops.Monster2, typeof(MonsterTwoItem));
           Add(Drops.Monster3, typeof(MonsterThreeItem));
           Add(Drops.SpikeOne, typeof(SpikeOneItem));
           Add(Drops.SpikeTwo, typeof(SpikeTwoItem));
           Add(Drops.Store, typeof(StoreItem));
           Add(Drops.Coin, typeof(CoinItem));
        }
    }
}