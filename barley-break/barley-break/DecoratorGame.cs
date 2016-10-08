using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barley_break
{

    public class Decorator: ImmutableGame
    {
        protected Game ChangedGame;
        protected Game FirstGame;

        public Decorator(ImmutableGame game)
            :base(game)
        {
            ChangedGame = game;
            FirstGame = game;
        }


        public override IGame Shift(int value)
        {
           
            Coordinate coordinateValue = GetLocation(value);
            Coordinate coordinateZero = GetLocation(0);

            if (Math.Abs(coordinateValue.X - coordinateZero.X) == 1 && Math.Abs(coordinateValue.Y - coordinateZero.Y) == 0
             || Math.Abs(coordinateValue.X - coordinateZero.X) == 0 && Math.Abs(coordinateValue.Y - coordinateZero.Y) == 1)
            {
                ChangedGame = (ImmutableGame)ChangedGame.Shift(value);

                return this;
            }
            else throw new ArgumentException("Zero is not on an adjacent site");

        }

        public override Coordinate GetLocation( int value) {
            if (value >= sizeField * sizeField) throw new ArgumentException("Incorrectly sets the value");          
            return ChangedGame.GetLocation(value);
        }

        public override int this[int x, int y]
        {
           get {
                if (x >= sizeField || y >= sizeField) throw new ArgumentException("Incorrectly sets the index");
                return ChangedGame[x, y];
            }

        }

    }

}
