using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barley_break
{
    public class ImmutableGame: Game,  IGame
    {
        private readonly int[,] field;
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

        public Coordinate[] NewLocation;

        public readonly int[] args;




        public  ImmutableGame(params int[] args)
        {
            if (Math.Sqrt(args.Length) % 1 != 0)
            {
                throw new ArgumentException("Wrong number of arguments");
            }
            else
            {
                sizeField = (int)Math.Sqrt(args.Length);
                field = new int[SizeField, SizeField];
                valuesLocation = new Coordinate[args.Length];
                NewLocation = new Coordinate[args.Length];
                this.args = args;
                int k = 0;
                for (int i = 0; i <SizeField; i++)
                    for (int j = 0; j < SizeField; j++)
                    {
                        field[i, j] = args[k];
                        Coordinate coord = new Coordinate(i, j);
                        valuesLocation[args[k]] = coord;

                        k++;
                    }
            }
        }

        public override int this[int x, int y]
        {
            get
            {
                if (x >= sizeField || y >= sizeField) throw new ArgumentException("Incorrectly sets the index");
                else
                {
                    int i = 0;
                    foreach(var tmp  in NewLocation)
                    {
                        if (tmp!=null && tmp.X == x && tmp.Y == y) return i;
                        i++;
                    }
                    return field[x, y];
                }
               
            }

        }


        public override IGame Shift(int value)
        {
           
            Coordinate coordinateValue = GetLocation(value);
            Coordinate coordinateZero = GetLocation(0);

            
            if (Math.Abs(coordinateValue.X - coordinateZero.X) == 1 && Math.Abs(coordinateValue.Y - coordinateZero.Y) == 0
             || Math.Abs(coordinateValue.X - coordinateZero.X) == 0 && Math.Abs(coordinateValue.Y - coordinateZero.Y) == 1)
            {

                int[] resArg=new int[this.ValuesLocation.Length];


                int i= 0;
                int indexZero=0;
                int indexValue = 0;
                foreach (var tmp in Field) {
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
