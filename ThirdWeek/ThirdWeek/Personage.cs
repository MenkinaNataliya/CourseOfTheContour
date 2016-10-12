using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThirdWeek
{
    public abstract class Personage
    {
        private string name { get; set; }
        public  int hitpoints;
        public int manna;
        public Dictionary<string, Ability> abilities = new Dictionary<string, Ability>(); 

        public abstract int GetRegenerationHitPoints();
        public abstract int GetRegenerationManna();

        public Personage(string name) {
            this.name = name;

            hitpoints = 100;
            manna = 100;

            abilities.Add("Jump",new Jump());
            abilities.Add("Hit",new Hit());

            CheckHitPoints(null);
            CheckManna(null);
        }

      

        public void UseAbility(String name, Personage opponent)
        {
            if (this.manna >= abilities[name].GetCost() && abilities[name].useOf)
            {
                this.manna -= abilities[name].AbilityToUse(opponent);
            }

        }

        private void CheckManna(object obj)
        {
            TimerCallback tm = new TimerCallback(CheckManna);
            Timer timer = new Timer(tm, null, 0, 30000);

            if (hitpoints < 100)
            {
                TimerCallback tc = new TimerCallback(MannaIncrease);
                Timer timer1 = new Timer(tc, null, this.GetRegenerationManna(), 0);
            }
        }
        private void MannaIncrease(object obj)
        {
            this.manna++;
            CheckManna(null);
        }

        private void CheckHitPoints(object obj)
        {
            TimerCallback tm = new TimerCallback(CheckHitPoints);
            Timer timer = new Timer(tm, null, 0, 30000);

            if (hitpoints <= 0)
            {
                Console.WriteLine("Personage " + this.name + "is died");
                timer.Dispose();

            }
            else
                if (hitpoints < 100)
            {
                TimerCallback tc = new TimerCallback(HealthIncrease);
                Timer timer1 = new Timer(tc, null, this.GetRegenerationHitPoints(), 0);
            }
        }

        private void HealthIncrease(object obj)
        {
            this.hitpoints++;
            CheckHitPoints(null);
        }
    }

   
    
}
