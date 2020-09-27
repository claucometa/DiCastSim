namespace DiCastSim.Core.Heros.Fire
{
    // Ativa skill 3 em ataques normais - queima oponente por 3 rounds 
    public class S1 : BaseSkill, ISkill
    {
        public S1() : base() {}

        public string Trigger()
        {
            if (skill.Active > 0)
            {
                skill.Active--;
                p2.TakeDamage(per() * p1.Atack);
                return "Skill Triggered";
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