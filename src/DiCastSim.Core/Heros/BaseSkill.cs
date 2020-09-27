using DiCastSim.Core.Enums;
using DiCastSim.Core.Models;

namespace DiCastSim.Core.Heros
{    
    public class BaseSkill
    {
        protected Game game;
        protected Player p1 => game.Player;
        protected Player p2 => game.Opponent;
        protected SkillPlayer skill => p1.Skill[Skills.Three];

        public BaseSkill()
        {
            this.game = IOC.Resolve<Game>();
        }
    }
}