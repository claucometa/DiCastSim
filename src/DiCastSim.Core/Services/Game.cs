using DiCastSim.Core.Enums;
using DiCastSim.Core.Models;
using System;

namespace DiCastSim.Core
{
    public class Game
    {
        public int TotalItems => Enum.GetValues(typeof(Items)).Length;
        public bool Hunting;
        public Player Player => p1.Turns > 0 ? p1 : p2;
        private readonly Player p1;
        private readonly Player p2;

        public Game()
        {
            var fabric = new PlayerFabric();
            p1 = fabric.Build("Player 1", 24 * 100);
            p2 = fabric.Build("Player 2", 12);
        }

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
            p1.Turns = p2.Turns = 0;

            if (who == Who.Player1)
            {
                p1.Turns = 2;
                p1.Position = p1.InitialPosition;
                p1.LastPosition = -1;
            }
            else
            {
                p2.Turns = 2;
                p2.Position = p2.InitialPosition;
                p2.LastPosition = -1;
            }
        }
    }
}
