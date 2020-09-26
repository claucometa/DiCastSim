using DiCastSim.Core.Enums;
using DiCastSim.Core.Services;

namespace DiCastSim.Core.Base
{
    public class BaseCastle : IBaseCastle
    {
        protected readonly Randomizer rand;

        public BaseCastle()
        {
            rand = IOC.Resolve<Randomizer>();
        }

        public virtual void LandOnBase(Game game)
        {
            game.Player.LevelUp();
            var addSpecialCard = new Dice[] { Dice.LockEven, Dice.LockOdd, Dice.DrawTwoDices, Dice.Swap, Dice.Quick_SmallPotion };
            var randomIndex = rand.Get(0, addSpecialCard.Length);
            game.TakeDice(addSpecialCard[randomIndex]);
        }

        public virtual void GoThroughBase(Game game)
        {
            game.Player.LevelUp();
        }
    }
}
