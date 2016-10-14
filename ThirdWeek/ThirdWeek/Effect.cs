using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdWeek
{
    public class Effect
    {
        public string Name;
        public  int TimeOfAction;

        public Effect(string name)
        {
            this.Name = name;
            TimeOfAction = 5;
        }
        public virtual void ReceiveDamagevoid(Personage pers) {

        }
       
    }


    public class Stupor : Effect {
        public Stupor() : base("Stupor") {
            this.TimeOfAction = 7;
        }

        public override void ReceiveDamagevoid(Personage pers) {
            pers.Speed = 0;
        }
    }
}
