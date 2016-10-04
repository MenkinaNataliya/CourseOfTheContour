﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barley_break
{

    public class Game
    {
        private int[,] field;
        private int sizeField;
        private Coordinate[] valuesLocation;

        public Game(int[] args)
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

        public int this[int x, int y]
        {
            get
            {
                if (x >= sizeField || y >= sizeField) throw new ArgumentException("Incorrectly sets the index");
                else return field[x, y];
            }
            private set
            {
                if (x >= sizeField || y >= sizeField) throw new ArgumentException("Incorrectly sets the index");
                else field[x, y] = value;
            }
        }


        public Coordinate GetLocation(int value)
        {
            if (value >= sizeField* sizeField) throw new ArgumentException("Incorrectly sets the value"); 

            return valuesLocation[value];
        }

        public void Shift(int value)
        {
            Coordinate coordinateValue = GetLocation(value);
            Coordinate coordinateZero = GetLocation(0);
            

            if (Math.Abs(coordinateValue.X - coordinateZero.X) == 1 && Math.Abs(coordinateValue.Y - coordinateZero.Y) == 0
             || Math.Abs(coordinateValue.X - coordinateZero.X) == 0 && Math.Abs(coordinateValue.Y - coordinateZero.Y) == 1)
            {

                field[coordinateValue.X, coordinateValue.Y] = 0;
                field[coordinateZero.X, coordinateZero.Y] = value;

                valuesLocation[0] = coordinateValue;
                valuesLocation[value] = coordinateZero;

            }
            else throw new ArgumentException("Zero is not on an adjacent site");


        }
    }

}