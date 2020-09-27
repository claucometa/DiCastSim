namespace DiCastSim.Core.Heros.FireHero
{
    // Ativa skill 2 em quadrados adjacente ao oponente
    public class S2 : BaseSkill, ISkill
    {
        public void Do()
        {
            if(p1.Position == p2.Position - 1 || p1.Position == p2.Position + 1)
                p2.TakeDamage(per() * p1.Atack);

            double per()
            {
                if (skill.Level == 2) return .6;
                if (skill.Level == 3) return .8;
                return .4;
            }
        }
    }
}