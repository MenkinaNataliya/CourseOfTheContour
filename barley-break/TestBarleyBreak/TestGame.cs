using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using barley_break;

using System.Linq;
using System.Reflection;



namespace TestBarleyBreak
{
    
    [TestClass]
    public class TestGame
    {

        Game field;
        protected virtual Game CreateGame(int[] args)
        {
            return new Game(args);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            int[] tag = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 0 };
            field = CreateGame(tag);
        }


        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void GoingBeyondBoundsOfarray()
        {

            int value = field[4, 1];
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void IncorrectNumberOfArguments()
        {
            int[] tag = { 1, 2, 3, 4, 5, 6, 7, 8 };
            Game field = new Game(tag);
        }


        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void DisastrousDeterminingElementCoordinates()
        {
            Coordinate coord = field.GetLocation(19);
        }

        [TestMethod]
        public void SuccessfulMovementOfChips()
        {
            for (int i = 1; i < 16; i++)
            {
                Coordinate coordValue = field.GetLocation(i);

                Coordinate coordZero = field.GetLocation(0);

                if (Math.Abs(coordValue.X - coordZero.X) == 1 && Math.Abs(coordValue.Y - coordZero.Y) == 0
                    || Math.Abs(coordValue.X - coordZero.X) == 0 && Math.Abs(coordValue.X - coordZero.Y) == 1)
                {
                    field = (Game)field.Shift(i);
                    Assert.AreEqual(0, field[coordValue.X, coordValue.Y]);
                    Assert.AreEqual(i, field[coordZero.X, coordZero.Y]);
                }
            }
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void DisastrousMovementOfChips()
        {
            for (int i = 0; i < 16; i++)
            {
                Coordinate coordValue = field.GetLocation(i);
                Coordinate coordZero = field.GetLocation(0);

                if (Math.Abs(coordValue.X - coordZero.X) != 1 && Math.Abs(coordValue.Y - coordZero.Y) != 1)
                    field.Shift(i);
            }
        }


        [TestMethod]
        public void Not_GetLocationBreakAfterShift()
        {
            for (int i = 1; i < 16; i++)
            {
                Coordinate coordValue = field.GetLocation(i);
                Coordinate coordZero = field.GetLocation(0);

                if (Math.Abs(coordValue.X - coordZero.X) == 1 && Math.Abs(coordValue.Y - coordZero.Y) == 0
                    || Math.Abs(coordValue.X - coordZero.X) == 0 && Math.Abs(coordValue.X - coordZero.Y) == 1)
                {
                    field.Shift(i);
                    field.Shift(i);
                    Assert.AreEqual(i, field[coordValue.X, coordValue.Y]);
                    Assert.AreEqual(0, field[coordZero.X, coordZero.Y]);
                }
            }
        }
    }

    [TestClass]
   public  class ImmutableTest : TestGame
    {
        
        protected override Game CreateGame(int[] args)
        {
            return new ImmutableGame(args);
        }

        [TestMethod]
        public void CompareGamesAndImmutableGame()
        {
            int[] args= { 1, 2, 3, 4, 5, 6, 7, 8, 0 };
            Game game = CreateGame(args);
            int number = 8;
            Game newGame = (Game)game.Shift(number);
            Assert.AreEqual(game[2, 1], 8);
            Assert.AreEqual(game[2, 2], 0);
            Assert.AreNotEqual(newGame[2, 1], 8);
            Assert.AreNotEqual(newGame[2, 2], 0);
            Assert.AreEqual(newGame[2, 1], 0);
            Assert.AreEqual(newGame[2, 2], 8);
            Assert.AreNotEqual(game, newGame);
        }

    }
}
