using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barley_break
{
    public class ImmutableGame: Game,  IGame
    {

        public  ImmutableGame(params int[] args):base(args)
        {
        }

        public ImmutableGame(ImmutableGame immutableGame) : base(immutableGame)
        {
        }


        public override IGame Shift(int value)
        {
           
            Coordinate coordinateValue = GetLocation(value);
            Coordinate coordinateZero = GetLocation(0);

            
            if (Math.Abs(coordinateValue.X - coordinateZero.X) == 1 && Math.Abs(coordinateValue.Y - coordinateZero.Y) == 0
             || Math.Abs(coordinateValue.X - coordinateZero.X) == 0 && Math.Abs(coordinateValue.Y - coordinateZero.Y) == 1)
            {

                int[] resArg=new int[this.valuesLocation.Length];


                int i= 0;
                int indexZero=0;
                int indexValue = 0;
                foreach (var tmp in field) {
                    resArg[i] = tmp;
                    if (tmp == 0) indexZero = i;
                    if (tmp == value) indexValue = i;
                    i++;
                }
   
                resArg[indexValue] = 0;
                resArg[indexZero] = value;

               ImmutableGame resultGame = new ImmutableGame(resArg);

                return resultGame;
            }
            else throw new ArgumentException("Zero is not on an adjacent site");
        }
    }

}
