using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Triangle1;

namespace TestTriangle
{
    [TestClass]
    public class UnitTest1
    {

        public void TestHerons(Triangle tr, double ExectedResult)
        {
            var result = tr.CalculationAreaByHeron();

            Assert.AreEqual(ExectedResult, result, 10e-2);
        }

        [TestMethod]
        public void TriangleTestCalculationOnTwoSidesAndAngle()
        {
            Triangle tr = Triangle.TwoSidesAndAngle(a: 14, b: 25, angleC:30);
            TestHerons(tr, 87.50);
           
            Assert.AreEqual(28.53, tr.AngleA, 10e-2);
            Assert.AreEqual(121.47, tr.AngleB, 10e-2);
            Assert.AreEqual(14.66, tr.SideC, 10e-2);

        }

        [TestMethod]
        public void TriangleTestCalculationOnSideAndTwoAngles()
        {
            Triangle tr = Triangle.SideAndTwoAngles(a: 12, angleB: 25, angleC: 15);
            TestHerons(tr,12.25);
            
            Assert.AreEqual(140, tr.AngleA, 10e-2);
            Assert.AreEqual(4.83, tr.SideC, 10e-2);
            Assert.AreEqual(7.89, tr.SideB, 10e-2);

        }

        [TestMethod]
        public void TriangleTestCalculationOnThreeSides()
        {
            Triangle tr = Triangle.ThreeSides(3, 5, 6);
            TestHerons(tr, 7.48);

            Assert.AreEqual(29.93, tr.AngleA, 10e-2);
            Assert.AreEqual(56.25, tr.AngleB, 10e-2);
            Assert.AreEqual(93.82, tr.AngleC, 10e-2);

        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void Exceprion_FailTest_TriangleDoesNotExist()
        {
            Triangle tr = Triangle.ThreeSides(3,5,15);
        }


        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TriangleDoesNotExistBecauseNegativeSideA()
        {
            Triangle tr = Triangle.ThreeSides(-15, 5, 15);
        }


        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TriangleDoesNotExistBecauseNegativeAngle()
        {
            Triangle tr = Triangle.TwoSidesAndAngle(a: 4, b: 5, angleC: -15);
        }


        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void FunctionalTestTriangleDoesNotExistOrNegativeSide()
        {
            var rnd = new Random(1);
            for (int i = 0; i < 100; i++)
            {
                var a = rnd.NextDouble() * 10-20;
                var b = rnd.NextDouble() * 10-20;
                var c = rnd.NextDouble() * 10-20;

                Triangle tr = Triangle.ThreeSides(a: a, b: b, c: c);
            }
        }

    }
}