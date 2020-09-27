namespace DiCastSim.Core.Heros.Fire
{
    // Ativa skill 1 colocando chamas em 4/5/6 quadrados a frente do oponente
    public class S3 : BaseSkill, ISkill
    {
        public string Trigger()
        {
            if (skill.Active > 0)
                if ((p2.Position - p2.LastPosition) < (skill.Level + 3))
                {
                    skill.Active--;
                    p2.TakeDamage(p1.Atack * per());
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