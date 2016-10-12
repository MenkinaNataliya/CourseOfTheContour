using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThirdWeek;

namespace TestGame
{
    [TestClass]
    public class UnitTest1
    {
        Personage demon = new DemonHunter();
        Personage keeper = new KeeperOfGrove();
        Personage priestess = new PriestessOfMoon();
        Personage looking = new LookingInNight();

        [TestMethod]
        public void TwoConsecutiveIdenticalStrikeSpecialFeaturesWilNotWork()
        {
            keeper.UseAbility("Freeze", demon);
            keeper.UseAbility("Freeze", demon);

            Assert.AreEqual(demon.hitpoints, 100 - keeper.abilities["Freeze"].GetDamage());
            

        }

        [TestMethod]
        public void TwoConsecutiveIdenticalStrikeStandartFeaturesWilWork()
        {
            keeper.UseAbility("Hit", demon);
            keeper.UseAbility("Hit", demon);

            Assert.AreEqual(demon.hitpoints, 100 - 2*keeper.abilities["Hit"].GetDamage());

        }

        [TestMethod]
        public void TwoConsecutiveIdenticalStrikeDifferentFeaturesWilWork()
        {
            keeper.UseAbility("Hit", demon);
            keeper.UseAbility("Freeze", demon);

            Assert.AreEqual(demon.hitpoints, 100 -keeper.abilities["Hit"].GetDamage()- keeper.abilities["Freeze"].GetDamage());

        }

    }
}
