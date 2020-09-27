using DiCastSim.Core.Enums;
using System.Collections.Generic;

namespace DiCastSim.Core.Models
{
    public class SkillPlayerCollection : List<SkillPlayer>
    {
        public SkillPlayer this[Skills x]
        {
            get
            {
                return this[(int)x];
            }
        }

        public void Build(HeroType type)
        {
            Clear();

            switch (type)
            {
                case HeroType.Hunter:
                    Add(new SkillPlayer(new Heros.Hunter.S1()) { Active = 1, Level = 1 });
                    Add(new SkillPlayer(new Heros.Hunter.S2()) { Active = 1, Level = 1 });
                    Add(new SkillPlayer(new Heros.Hunter.S3()) { Active = 1, Level = 0 });
                    break;
                case HeroType.Grass:
                    Add(new SkillPlayer(new Heros.Grass.S1()) { Active = 0, Level = 1 });
                    Add(new SkillPlayer(new Heros.Grass.S2()) { Active = 0, Level = 1 });
                    Add(new SkillPlayer(new Heros.Grass.S3()) { Active = 0, Level = 0 });
                    break;
                case HeroType.Fire:
                    Add(new SkillPlayer(new Heros.Fire.S1()) { Active = 0, Level = 1 });
                    Add(new SkillPlayer(new Heros.Fire.S2()) { Active = 0, Level = 1 });
                    Add(new SkillPlayer(new Heros.Fire.S3()) { Active = 0, Level = 0 });
                    break;
            }
        }
    }
}
