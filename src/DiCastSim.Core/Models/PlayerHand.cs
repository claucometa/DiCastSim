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

        public DiceInHand TakeDice(Dice diceFace)
        {
            var dice = new DiceInHand(Count, diceFace);
            
            Add(dice);

            return dice;
        }

        /// <summary>
        /// Retorna qualquer dado, numérico ou especial
        /// Se o jogador só tiver dados especiais, obrigatoriamente retorna um númerico
        /// </summary>
        /// <returns></returns>
        public DiceInHand TakeNextDice(bool forceNumber = false)
        {
            if (Count == 5) return null;

            var diceFace = forceNumber ? NumbericDice : AddAnyDice;

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

        public void ValidateForHunting()
        {
            foreach (var item in this)
            {
                item.Enabled = item.IsNumber;
            }
        }

        public void Validate()
        {
            foreach (var item in this)
            {
                if (item.IsNumber)
                {
                    item.Enabled = true;
                }
                else if (item.Dice == Dice.Home && player.InitialPosition % 24 == 0 && player.Position % 24 != 0)
                {
                    item.Enabled = true;
                }
                else if (item.Dice == Dice.Home && player.InitialPosition == 12 && player.Position != 12)
                {
                    item.Enabled = true;
                }
                else if (player.Imprisioned)
                {
                    if (item.Dice != Dice.Stunt && item.Dice != Dice.Swap && item.Dice != Dice.Atack)
                        item.Enabled = true;
                }
                else if (item.Dice == Dice.Shuffle || item.Dice == Dice.Stunt)
                {
                    item.Enabled = true;
                };
            }
        }

        public void Shuffle()
        {
            foreach (var item in this)
            {
                var x = dc.Get(player);
                item.Dice = x;
            }
        }
    }
}
