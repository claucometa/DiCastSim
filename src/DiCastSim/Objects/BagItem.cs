﻿using DiCastSim.Core.Objects;

namespace DiCastSim.Objects
{
    class BagItem : BaseItem
    {        
        public BagItem()
        {
            effect = new BagEffect();
            Img = Properties.Resources.bag;
        }
    }    
}
