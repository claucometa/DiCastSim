using DiCastSim.Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace DiCastSim.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void VerificaSeOsNumerosNaoSeRepetem()
        {
            MonsterService x = new MonsterService();
            for (int i = 0; i < 100; i++)
            {
                var result = x.GetDices(5);
                var monsterNumbers = result.Distinct().ToArray();
                Assert.AreEqual(result.Length, monsterNumbers.Length);
            }
        }
    }
}
