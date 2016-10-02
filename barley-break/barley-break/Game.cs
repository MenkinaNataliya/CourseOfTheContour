using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barley_break
{
    public class Game
    {
        private int[,] field;
        private int SizeField;

        public Game(int[] args)
        {
            if (Math.Sqrt(args.Length) % 1 != 0)
            {
                throw new ArgumentException("Wrong number of arguments");
            }
            else
            {
                SizeField = (int)Math.Sqrt(args.Length);
                field = new int[SizeField, SizeField];

                var rnd = new Random(1);

                for (int i = 0; i < SizeField; i++)
                    for (int j = 0; j < SizeField; j++)
                        field[i, j] = AssignmentWithoutRpetition(args);
            }
        }


        private int AssignmentWithoutRpetition(int[] args)
        {

            var rnd = new Random();
            var value = args[rnd.Next(0, args.Length)];


            for (int i = 0; i < 100; i++)
            {
                value = args[rnd.Next(0, args.Length)];
                if (GetLocation(value) == null)
                    return value;

            }
            return 0;
        }

        public int this[int x, int y]
        {
            get
            {
                if (x >= SizeField || y >= SizeField) throw new ArgumentException("Incorrectly sets the index");
                else return field[x, y];
            }
            private set
            {
                if (x >= SizeField || y >= SizeField) throw new ArgumentException("Incorrectly sets the index");
                else field[x, y] = value;
            }
        }


        public int[] GetLocation(int value)
        {

            for (int i = 0; i < SizeField; i++)
                for (int j = 0; j < SizeField; j++)
                {
                    if (field[i, j] == value)
                    {
                        int[] res = { i, j };
                        return res;
                    }
                }
            return null;

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

                field[x, y] = 0;
                field[xZero, yZero] = value;

            }
            else throw new ArgumentException("Zero is not on an adjacent site");


        }
    }
}
