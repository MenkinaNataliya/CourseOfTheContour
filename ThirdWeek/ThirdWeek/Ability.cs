using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThirdWeek
{
    public abstract class Ability
    {
        public string name { get; protected set; }
        int cost;
        int damage;

        public bool useOf;

        public abstract int GetDamage();
        public abstract int GetCost();

        public abstract int GetRecoveryTime();
        public int AbilityToUse(Personage opponent)
        {
            opponent.hitpoints -= this.GetDamage();
            useOf = false;

            return GetCost();
        }
        public Ability(string name)
        {
            this.name = name;
            cost = 5;
            
            useOf = true;
            CheckUseOf(null);
        }

        private void CheckUseOf(object obj)
        {
            TimerCallback tm = new TimerCallback(CheckUseOf);
            Timer timer = new Timer(tm, null, 0, 30000);

            if (!useOf)
            {
                TimerCallback tc = new TimerCallback(ChangeUseOf);
                Timer timer1 = new Timer(tc, null, this.GetRecoveryTime(), 0);
            }
        }
        private void ChangeUseOf(object obj)
        {
            this.useOf =true;
            CheckUseOf(null);
        }




}
   
}
