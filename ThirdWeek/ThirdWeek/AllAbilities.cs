using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdWeek
{
    public class Freeze : Ability
    {
        public Freeze() : base("Freeze") { }
        public override int GetDamage()
        {
            return 20;
        }
        public override int GetCost()
        {
            return 23;
        }
        public override int GetRecoveryTime()
        {
            return 2;
        }

    }

    public class ManipulationOfConsciousness : Ability
    {
        public ManipulationOfConsciousness() : base("ManipulationOfConsciousness") { }
        public override int GetDamage()
        {
            return 10;
        }
        public override int GetCost()
        {
            return 20;
        }
        public override int GetRecoveryTime()
        {
            return 5;
        }
    }

    public class FireBall : Ability
    {
        public FireBall() : base("FireBall") { }
        public override int GetDamage()
        {
            return 15;
        }
        public override int GetCost()
        {
            return 30;
        }
        public override int GetRecoveryTime()
        {
            return 3;
        }

    }
}
