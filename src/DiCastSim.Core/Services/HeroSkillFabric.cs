using System.Collections.Generic;

namespace DiCastSim.Core.Models
{
    internal class HeroSkillFabric
    {
        internal SkillPlayer[] Build(Enums.HeroType type)
        {
            var x = new List<SkillPlayer>();

            switch (type)
            {
                case Enums.HeroType.Hunter:
                    x.Add(new SkillPlayer() { Active = 1, Level = 1 });
                    x.Add(new SkillPlayer() { Active = 1, Level = 1 });
                    x.Add(new SkillPlayer() { Active = 1, Level = 0 });
                    break;
                case Enums.HeroType.Grass:
                    x.Add(new SkillPlayer() { Active = 0, Level = 1 });
                    x.Add(new SkillPlayer() { Active = 0, Level = 1 });
                    x.Add(new SkillPlayer() { Active = 0, Level = 0 });
                    break;
                case Enums.HeroType.Fire:
                    x.Add(new SkillPlayer() { Active = 0, Level = 1 });
                    x.Add(new SkillPlayer() { Active = 0, Level = 1 });
                    x.Add(new SkillPlayer() { Active = 0, Level = 0 });
                    break;
            }

            return x.ToArray();
        }
    }
}