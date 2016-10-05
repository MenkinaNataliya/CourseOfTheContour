using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barley_break
{
    interface InterfaceGame
    {
        Coordinate GetLocation(int value);
        Game Shift(int value);

        int this[int x, int y] { get; set; }


    }
}
