using DiCastSim.Core.Enums;
using DiCastSim.Core.Services;
using System.Collections.Generic;
using System.Linq;

namespace DiCastSim.Core.Models
{
    public class PlayerHand : List<DiceInHand>
    {
        readonly DiceGenerator dc;
        readonly Player player;

        public PlayerHand(Player player)
        {
            this.player = player;
            dc = IOC.Resolve<DiceGenerator>();

            Add(new DiceInHand(Count, dc.Get(player)));
            Add(new DiceInHand(Count, dc.Get(player)));
        }

        public enum DiceType
        {
            NumberOnly,
            Any,
        }

        /// <summary>
        /// Retorna qualquer dado, numérico ou especial
        /// Se o jogador só tiver dados especiais, obrigatoriamente retorna um númerico
        /// </summary>
        /// <returns></returns>
        public DiceInHand TakeNextDice(DiceType type)
        {
            if (Count == 5) return null;

            var diceFace = type == DiceType.NumberOnly ?
                NumbericDice : AddAnyDice;

            var dice = new DiceInHand(Count, diceFace);

            Add(dice);

            return dice;
        }

        private Dice NumbericDice => dc.Get(player, true);

        private Dice AddAnyDice
        {
            get
            {
                var anyNumber = this.Any(t =>
                    (t.Dice >= Dice.One && t.Dice <= Dice.High) ||
                    (t.Dice == Dice.MinusOne || t.Dice == Dice.MinusRandom));

                return dc.Get(player, !anyNumber);
            }
        }
    }
}
