using DiCastSim.Core.Enums;
using DiCastSim.Core.Models;
using System;
using System.Linq;

namespace DiCastSim.Core
{
    public class Game
    {
        public int Turn = -1;
        public int TotalItems => Enum.GetValues(typeof(Drops)).Length;
        public bool Hunting;
        public Player Player => p1.Turns > 0 ? p1 : p2;
        private Player p1, p2;
        public event EventHandler<DiceInHand> DiceAdded;

        public Player GetPlayer(Who who) => who == Who.Player1 ? p1 : p2;

        public Player Opponent => GetPlayer(PlayerTurn == Game.Who.Player1 ? Game.Who.Player2 : Game.Who.Player1);

        public Who PlayerTurn => p1.Turns > 0 ? Who.Player1 : Who.Player2;

        public bool PlayerLandedOnBase => new int[] { 0, 12, 18 }.Contains(Player.LastPosition % 24);

        internal void PerformAtack()
        {
            Opponent.Life -= Player.Atack;
        }

        public void SwitchPlayers()
        {
            if (PlayerTurn == Who.Player1)
            {
                p1.Turns--;
                if (p1.Turns == 0)
                {
                    p2.Turns++;
                    Turn++;
                }
            }
            else if (PlayerTurn == Who.Player2)
            {
                p2.Turns--;
                if (p2.Turns == 0)
                {
                    p1.Turns++;
                    Turn++;
                }
            }
        }

        public enum Who
        {
            Player1,
            Player2
        }

        public void Start(Who who)
        {
            Turn = 1;

            p1 = Player.Build("Player 1", 24 * 100, Base.CastleTypes.Atack);
            p2 = Player.Build("Player 2", 12, Base.CastleTypes.Atack);

            if (who == Who.Player1)
                p1.Turns = 1;
            else
                p2.Turns = 1;
        }

        public void TakeDice(Dice d)
        {
            var dice = Player.Hand.TakeDice(d);
            if (dice != null) DiceAdded?.Invoke(this, dice);
        }

        public void AddDice(bool forceNumber = false)
        {
            var dice = Player.Hand.TakeNextDice(forceNumber);
            if(dice != null) DiceAdded?.Invoke(this, dice);
        }
    }
}
