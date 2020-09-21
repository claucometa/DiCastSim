using DiCastSim.Core.Enums;
using DiCastSim.Core.Models;
using System;
using System.Linq;

namespace DiCastSim.Core
{
    public class Game
    {
        public int TotalItems => Enum.GetValues(typeof(Items)).Length;
        public bool Hunting;
        public Player Player => p1.Turns > 0 ? p1 : p2;
        private Player p1, p2;
        public event EventHandler<Dice> DiceAdded;

        public Player GetPlayer(Who who) => who == Who.Player1 ? p1 : p2;

        public Who PlayerTurn => p1.Turns > 0 ? Who.Player1 : Who.Player2;

        public void SwitchPlayers()
        {
            if (PlayerTurn == Who.Player1)
            {
                p1.Turns--;
                if (p1.Turns == 0) p2.Turns++;
            }
            else if (PlayerTurn == Who.Player2)
            {
                p2.Turns--;
                if (p2.Turns == 0) p1.Turns++;
            }
        }

        public enum Who
        {
            Player1,
            Player2
        }

        public void Start(Who who)
        {
            p1 = Player.Build("Player 1", 24 * 100);
            p2 = Player.Build("Player 2", 12);

            if (who == Who.Player1)
                p1.Turns = 1;
            else
                p2.Turns = 1;
        }

        public void AddDice(bool forceNumber = false)
        {
            if (forceNumber)
                Player.Hand.GetNumberDice();
            else
                Player.Hand.GetNextDice();

            DiceAdded?.Invoke(this, Player.Hand.Last());
        }
    }
}
