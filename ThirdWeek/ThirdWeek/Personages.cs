using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdWeek
{
    public class DemonHunter : Personage
    {
        public DemonHunter() : base("DemonHunter")
        {
            Abilities.Add("FireBall", new FireBall());
        }
        public override int GetRegenerationHitpoints()
        {
            return 15;
        }
        public override int GetRegenerationManna()
        {
            return 25;
        }
    }

    public class KeeperOfGrove : Personage
    {
        public KeeperOfGrove() : base("KeeperOfGrove")
        {
            Abilities.Add("Freeze", new Freeze());
        }
        public override int GetRegenerationHitpoints()
        {
            return 11;
        }
        public override int GetRegenerationManna()
        {
            return 20;
        }
    }
    public class PriestessOfMoon : Personage
    {
        public PriestessOfMoon() : base("PriestessOfMoon")
        {
            Abilities.Add("FireBall", new FireBall());
            Abilities.Add("ManipulationOfConsciousness", new ManipulationOfConsciousness());

        }
        public override int GetRegenerationHitpoints()
        {
            return 5;
        }
        public override int GetRegenerationManna()
        {
            return 7;
        }
    }
    public class LookingInNight : Personage
    {
        public LookingInNight() : base("LookingInNight")
        {
            Abilities.Add("ManipulationOfConsciousness", new ManipulationOfConsciousness());
        }
        public override int GetRegenerationHitpoints()
        {
            return 7;
        }
        public override int GetRegenerationManna()
        {
            return 17;
        }
    }
}
