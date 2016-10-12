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
            abilities.Add("FireBall", new FireBall());
        }
        public override int GetRegenerationHitPoints()
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
            abilities.Add("Freeze", new Freeze());
        }
        public override int GetRegenerationHitPoints()
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
            abilities.Add("FireBall", new FireBall());
            abilities.Add("ManipulationOfConsciousness", new ManipulationOfConsciousness());

        }
        public override int GetRegenerationHitPoints()
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
            abilities.Add("ManipulationOfConsciousness", new ManipulationOfConsciousness());
        }
        public override int GetRegenerationHitPoints()
        {
            return 7;
        }
        public override int GetRegenerationManna()
        {
            return 17;
        }
    }
}
