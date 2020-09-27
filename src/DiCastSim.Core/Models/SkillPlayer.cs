using DiCastSim.Core.Heros;

namespace DiCastSim.Core.Models
{
    public class SkillPlayer
    {
        private readonly ISkill fire;

        public SkillPlayer(ISkill fire)
        {
            this.fire = fire;
        }

        public string Trigger()
        {
            return fire.Trigger();
        }

        public int Level { get; set; }
        public int Active { get; set; }
    }
}
