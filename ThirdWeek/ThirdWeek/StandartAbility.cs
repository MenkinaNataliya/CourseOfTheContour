using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdWeek
{
    public abstract class StandartAbility : Ability
    {

        public StandartAbility(string name) : base(name) { }
        public override int GetCost()
        {
            return 0;
        }
        public override int GetDamage()
        {
            return 0;
        }
        public override int GetRecoveryTime()
        {
            return 0;
        }
    }

    public class Hit : StandartAbility
    {
        public Hit() : base("Hit") {}
        public override int GetDamage()
        {
            return 5;
        }

    }

    public class Jump : StandartAbility
    {
        public Jump() : base("Jump") { }

    }
}
