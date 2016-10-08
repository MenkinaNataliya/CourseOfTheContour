using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barley_break
{
    public interface IGame
    {
        Coordinate GetLocation(int value);  
        IGame Shift(int value);

        int this[int x, int y] { get; set; }

    }
}
