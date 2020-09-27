namespace DiCastSim.Core.Heros.Fire
{
    // Ativa skill 2 em quadrados adjacente ao oponente
    public class S2 : BaseSkill, ISkill
    {
        public string Trigger()
        {
            if(p1.Position == p2.Position - 1 || p1.Position == p2.Position + 1)
            {
                p2.TakeDamage(per() * p1.Atack);
                return "Skill triggered";
            }

            double per()
            {
                if (skill.Level == 1) return .3;
                if (skill.Level == 2) return .4;
                if (skill.Level == 3) return .5;
                return 0;
            }

            return null;
        }
    }
}