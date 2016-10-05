using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barley_break
{
    public class ImmutableGame: Game,  InterfaceGame
    {

        private readonly  int[,] field;
        public int[,] Field {
            get { return field; }
        }
        private readonly int sizeField;
        public int SizeField
        {
            get { return sizeField; }
        }

        private readonly Coordinate[] valuesLocation;
        public Coordinate[] ValuesLocation{
            get { return valuesLocation; }    
        }

       

        public ImmutableGame(params int[] args)
        {
            if (Math.Sqrt(args.Length) % 1 != 0)
            {
                throw new ArgumentException("Wrong number of arguments");
            }
            else
            {
                sizeField = (int)Math.Sqrt(args.Length);
                field = new int[sizeField, sizeField];
                valuesLocation = new Coordinate[args.Length];

                int k = 0;
                for (int i = 0; i < sizeField; i++)
                    for (int j = 0; j < sizeField; j++)
                    {
                        field[i, j] = args[k];
                        Coordinate coord = new Coordinate(i, j);
                        valuesLocation[args[k]] = coord;

                        k++;
                    }
            }
        }

        public  ImmutableGame Shift(int value)
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
