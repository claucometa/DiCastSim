namespace DiCastSim.Core.Heros.FireHero
{
    // Ativa skill 1 colocando chamas em 4/5/6 quadrados a frente do oponente
    public class S3 : BaseSkill, ISkill
    {
        public void Do()
        {
            if (skill.Active > 0)
                if ((p2.Position - p2.LastPosition) < (skill.Level + 3))
                {
                    skill.Active--;
                    p2.TakeDamage(p1.Atack * per() * -1);
                }

            double per()
            {
                if (skill.Level == 2) return .6;
                if (skill.Level == 3) return .8;
                return .4;
            }
        }
    }
}