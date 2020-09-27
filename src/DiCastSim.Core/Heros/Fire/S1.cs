namespace DiCastSim.Core.Heros.Fire
{
    // Ativa skill 3 em ataques normais - queima oponente por 3 rounds 
    public class S1 : BaseSkill, ISkill
    {
        public S1() : base() {}

        public void Do()
        {
            if (skill.Active > 0)
            {
                skill.Active--;
                p2.TakeDamage(per() * p1.Atack);
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