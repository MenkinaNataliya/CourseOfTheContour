using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using barley_break;

namespace TestBarleyBreak
{
    [TestClass]
    public class UnitTest1
    {
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void GoingBeyondBoundsOfarray()
        {
            int[] tag = { 1, 2, 3, 4, 5, 6, 7, 8, 0 };
            Game field = new Game(tag);
            field.GetLocation(field[4, 1]);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void IncorrectNumberOfArguments()
        {
            int[] tag = { 1, 2, 3, 4, 5, 6, 7, 8};
            Game field = new Game(tag);
            
        }

        [TestMethod]
        public void SuccessfulDeterminingElementCoordinates() {
            int[] tag = { 1, 2, 3, 4, 5, 6, 7, 8, 0 };
            Game field = new Game(tag);

            int[] res = field.GetLocation(5);

            Assert.AreEqual(5, field[ res[0], res[1]]);

        }


        [TestMethod]
        public void DisastrousDeterminingElementCoordinates() {
            int[] tag = { 1, 2, 3, 4, 5, 6, 7, 8, 0 };
            Game field = new Game(tag);
            int[] res = field.GetLocation(9);
            Assert.AreEqual(null, res);
        }

        [TestMethod]
        public void SuccessfulMovementOfChips()
        {
            int[] tag = { 1, 2, 3, 4, 5, 6, 7, 8, 0 };
            Game field = new Game(tag);

            int[] coordinate;
            int[] coordinateZero ;
            int x;
            int y;
            int xZero;
            int yZero;

            for (int i = 1; i < tag.Length; i++)
            {
                coordinate = field.GetLocation(i);
                x = coordinate[0];
                y = coordinate[1];

                coordinateZero = field.GetLocation(0);
                xZero = coordinateZero[0];
                yZero = coordinateZero[1];

                if (Math.Abs(x - xZero) == 1 && Math.Abs(y - yZero) == 0
                    || Math.Abs(x - xZero) == 0 && Math.Abs(y - yZero) == 1)
                {
                    field.Shift(i);
                    Assert.AreEqual(0, field[x, y]);
                    Assert.AreEqual(i, field[xZero, yZero]);
                }
            }
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void DisastrousMovementOfChips()
        {
            int[] tag = { 1, 2, 3, 4, 5, 6, 7, 8, 0 };
            Game field = new Game(tag);

            int[] coordinate ;
            int[] coordinateZero = field.GetLocation(0);
            int x ;
            int y ;
            int xZero = coordinateZero[0];
            int yZero = coordinateZero[1];

            for(int i=0; i< tag.Length; i++)
            {
                coordinate = field.GetLocation(i);
                x = coordinate[0];
                y = coordinate[1];

                if (Math.Abs(x - xZero) != 1 && Math.Abs(y - yZero) != 1)
                {
                    field.Shift(i);
                }
            }

        }

    }
}
