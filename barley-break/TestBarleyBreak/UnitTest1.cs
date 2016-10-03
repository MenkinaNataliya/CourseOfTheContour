using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using barley_break;

namespace TestBarleyBreak
{
    [TestClass]
    public class UnitTest1
    {

        Game field;

        [TestInitialize]
        public void TestInitialize()
        {
            int[] tag = { 1, 2, 3, 4, 5, 6, 7, 8,9,10,11,12,13,14,15, 0 };
            field = new Game(tag);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void GoingBeyondBoundsOfarray()
        {
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

            int[] res = field.GetLocation(5);

            Assert.AreEqual(5, field[ res[0], res[1]]);

        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void DisastrousDeterminingElementCoordinates() {

            int[] res = field.GetLocation(19);
        }

        [TestMethod]
        public void SuccessfulMovementOfChips()
        {
            for (int i = 1; i < 16; i++)
            {
                int[] coordinate = field.GetLocation(i);
                int x = coordinate[0];
                int y = coordinate[1];

                int[] coordinateZero = field.GetLocation(0);
                int xZero = coordinateZero[0];
                int yZero = coordinateZero[1];

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

            int[] coordinateZero = field.GetLocation(0);
            int xZero = coordinateZero[0];
            int yZero = coordinateZero[1];

            for(int i=0; i< 16; i++)
            {
                int[] coordinate = field.GetLocation(i);
                int x = coordinate[0];
                int y = coordinate[1];

                if (Math.Abs(x - xZero) != 1 && Math.Abs(y - yZero) != 1)
                {
                    field.Shift(i);
                }
            }

        }

    }
}
