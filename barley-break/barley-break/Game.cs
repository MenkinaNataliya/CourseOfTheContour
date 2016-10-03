using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barley_break
{

    class Coordinate {
        public int x { get; set; }
        public int y { get; set; }

        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public class Game
    {
        private int[,] Field;
        private int SizeField;
        private Coordinate[] ChipLayout;

        public Game(int[] args)
        {
            if (Math.Sqrt(args.Length) % 1 != 0)
            {
                throw new ArgumentException("Wrong number of arguments");
            }
            else
            {
                SizeField = (int)Math.Sqrt(args.Length);
                Field = new int[SizeField, SizeField];
                ChipLayout = new Coordinate[args.Length];

                var rnd = new Random(1);

                int k = 0;
                for (int i = 0; i < SizeField; i++)
                    for (int j = 0; j < SizeField; j++)
                    {
                        Field[i, j] = args[k];
                        Coordinate coord = new Coordinate(i, j);
                        ChipLayout[args[k]] = coord;

                        k++;
                    }
            }
        }

        public int this[int x, int y]
        {
            get
            {
                if (x >= SizeField || y >= SizeField) throw new ArgumentException("Incorrectly sets the index");
                else return Field[x, y];
            }
            private set
            {
                if (x >= SizeField || y >= SizeField) throw new ArgumentException("Incorrectly sets the index");
                else Field[x, y] = value;
            }
        }


        public int[] GetLocation(int value)
        {
            if (value >= SizeField* SizeField) throw new ArgumentException("Incorrectly sets the value"); 
            int[] result = new int[2];
            result[0] = ChipLayout[value].x;
            result[1] = ChipLayout[value].y;
            return result;
        }

        public void Shift(int value)
        {
            int[] coordinate = GetLocation(value);
            int[] coordinateZero = GetLocation(0);
            int x = coordinate[0];
            int y = coordinate[1];
            int xZero = coordinateZero[0];
            int yZero = coordinateZero[1];

            if (Math.Abs(x - xZero) == 1 && Math.Abs(y - yZero) == 0
             || Math.Abs(x - xZero) == 0 && Math.Abs(y - yZero) == 1)
            {

                Field[x, y] = 0;
                Field[xZero, yZero] = value;

            }
            else throw new ArgumentException("Zero is not on an adjacent site");


        }
    }
}