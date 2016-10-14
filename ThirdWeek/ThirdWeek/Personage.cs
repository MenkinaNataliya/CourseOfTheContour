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
        public  int Hitpoints;
        public int Manna;
        public int Speed;
        public Dictionary<string, Ability> Abilities = new Dictionary<string, Ability>();
        public List<Effect> Effects = new List<Effect>();

        public abstract int GetRegenerationHitpoints();
        public abstract int GetRegenerationManna();

        public Personage(string name) {
            this.name = name;

            Hitpoints = 100;
            Manna = 100;
            Speed = 10;

            Abilities.Add("Jump",new Jump());
            Abilities.Add("Hit",new Hit());

            CheckHitpoints(null);
            CheckManna(null);
        }

      

        public void UseAbility(String name, Personage opponent)
        {
            if (this.Manna >= Abilities[name].GetCost() && Abilities[name].UseOf)
            {
                this.Manna -= Abilities[name].AbilityToUse(opponent);
            }

        }

        private void CheckManna(object obj)
        {
            TimerCallback tm = new TimerCallback(CheckManna);
            Timer timer = new Timer(tm, null, 0, 30000);

            if (Hitpoints < 100)
            {
                TimerCallback tc = new TimerCallback(MannaIncrease);
                Timer timer1 = new Timer(tc, null, this.GetRegenerationManna(), 0);
            }
        }
        private void MannaIncrease(object obj)
        {
            this.Manna++;
            CheckManna(null);
        }

        private void CheckHitpoints(object obj)
        {
            TimerCallback tm = new TimerCallback(CheckHitpoints);
            Timer timer = new Timer(tm, null, 0, 30000);

            if (Hitpoints <= 0)
            {
                Console.WriteLine("Personage " + this.name + "is died");
                timer.Dispose();

            }
            else
                if (Hitpoints < 100)
            {
                TimerCallback tc = new TimerCallback(HealthIncrease);
                Timer timer1 = new Timer(tc, null, this.GetRegenerationHitpoints(), 0);
            }
        }

        private void HealthIncrease(object obj)
        {
            this.Hitpoints++;
            CheckHitpoints(null);
        }


    }

   
    
}
