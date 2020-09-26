using DiCastSim.Core.Base;
using DiCastSim.Core.Castles;
using System;
using System.Collections.Generic;

namespace DiCastSim.Core
{
    public class CastleFabric : Dictionary<CastleTypes, Type>
    {
        public CastleFabric()
        {
            Add(CastleTypes.Atack, typeof(AtackCastle));
            Add(CastleTypes.Fire, typeof(FireCastle));
            Add(CastleTypes.Health, typeof(HealthCastle));
            Add(CastleTypes.Gold, typeof(GoldCastle));
        }

        internal IBaseCastle Build(CastleTypes castleType)
        {
            return (IBaseCastle)Activator.CreateInstance(this[castleType]);
        }
    }
}