using DiCastSim.Core.Enums;
using DiCastSim.Objects;
using System;
using System.Collections.Generic;

namespace DiCastSim
{
    class LinkItem : Dictionary<Items, Type>
    {
        public LinkItem()
        {
           Add(Items.Nothing, typeof(NothingItem));
           Add(Items.Castle, typeof(CastleItem));
           Add(Items.Portal, typeof(PortalItem));
           Add(Items.Sword, typeof(SwordItem));
           Add(Items.Bag, typeof(BagItem));
           Add(Items.BookOne, typeof(BookOneItem));
           Add(Items.BookTwo, typeof(BookTwoItem));
           Add(Items.Apple, typeof(AppleItem));
           Add(Items.Bread, typeof(BreadItem));
           Add(Items.Monster1, typeof(MonsterOneItem));
           Add(Items.Monster2, typeof(MonsterTwoItem));
           Add(Items.Monster3, typeof(MonsterThreeItem));
           Add(Items.SpikeOne, typeof(SpikeOneItem));
           Add(Items.SpikeTwo, typeof(SpikeTwoItem));
           Add(Items.Store, typeof(StoreItem));
           Add(Items.Coin, typeof(CoinItem));
        }
    }
}