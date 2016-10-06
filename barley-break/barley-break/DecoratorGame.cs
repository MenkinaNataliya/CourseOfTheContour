using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barley_break
{
     public abstract class DecoratorGame : ImmutableGame
    {
        protected Game game;

        public DecoratorGame(int[] args, ImmutableGame game) : base(args)
        {
            this.game = game;
        }
    }

    public class Decorator: DecoratorGame {

        public Decorator(ImmutableGame game)
            :base(game.args, game)
        { }


        public override IGame Shift(int value)
        {
            Console.WriteLine("decorator");
            Coordinate coordinateValue = GetLocation(value);
            Coordinate coordinateZero = GetLocation(0);

            if (Math.Abs(coordinateValue.X - coordinateZero.X) == 1 && Math.Abs(coordinateValue.Y - coordinateZero.Y) == 0
             || Math.Abs(coordinateValue.X - coordinateZero.X) == 0 && Math.Abs(coordinateValue.Y - coordinateZero.Y) == 1)
            {
                NewLocation[value] = coordinateZero;
                NewLocation[0] = coordinateValue;

                return this;
            }
            else throw new ArgumentException("Zero is not on an adjacent site");

        }

        public override Coordinate GetLocation( int value) {

            Console.WriteLine("decorator");
            if (value >= SizeField * SizeField) throw new ArgumentException("Incorrectly sets the value");

            if (NewLocation[value] == null) return ValuesLocation[value];
            else return NewLocation[value];
        }

        public override int this[int x, int y]
        {
            get
            {
                if (x >= SizeField || y >= SizeField) throw new ArgumentException("Incorrectly sets the index");
                else {
                    Console.WriteLine("decorator");
                    for (int i = 0; i < NewLocation.Length; i++)
                        if (NewLocation[i].X == x && NewLocation[i].Y == y) return i;

                    throw new ArgumentException("Incorrectly sets the index");
                }
            }

        }

    }

}
