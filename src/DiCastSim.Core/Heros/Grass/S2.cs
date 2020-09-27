namespace DiCastSim.Core.Heros.Grass
{
    // Ativa - oponente tem movimentação limitada em 3/4/5 blocos
    // sempre reduz dados do monstro por 3/4/5
    // quando a s2 ativa a s1 tem que ser desativada
    public class S2 : BaseSkill, ISkill
    {
        public S2() : base() { }

        public string Trigger()
        {
            return null;
        }
    }
}