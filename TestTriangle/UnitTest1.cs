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
            var result = tr.PaymentAreaByHeron();
           

            Assert.AreEqual(ExectedResult, result, 10e-2);
        }

        public void TestTriangleDoesNot(Triangle tr, double ExectedAngleA, double ExectedAngleB=0, double ExectedAngleC=0, double ExectedA =0, double ExectedB= 0, double ExectedC= 0)
        {
            

            Assert.AreEqual(ExectedAngleA, tr.getAngleA(), 10e-2);
            Assert.AreEqual(ExectedAngleB, tr.getAngleB(), 10e-2);
            Assert.AreEqual(ExectedAngleC, tr.getAngleC(), 10e-2);
            Assert.AreEqual(ExectedA, tr.getA(), 10e-2);
            Assert.AreEqual(ExectedB, tr.getB(), 10e-2);
            Assert.AreEqual(ExectedC, tr.getC(), 10e-2);
        }


        [TestMethod]
        public void TriangleTestCalculationOnTwoSidesAndAngle()
        {
            Triangle tr = new Triangle(a: 14, b: 25, angleC:30);
            TestHerons(tr, 87.50);
           
            Assert.AreEqual(28.53, tr.getAngleA(), 10e-2);
            Assert.AreEqual(121.47, tr.getAngleB(), 10e-2);
            Assert.AreEqual(14.66, tr.getC(), 10e-2);

        }

        [TestMethod]
        public void TriangleTestCalculationOnSideAndTwoAngles()
        {
            Triangle tr = new Triangle(a: 12, angleB: 25, angleC: 15);
            TestHerons(tr,12.25);
            
            Assert.AreEqual(140, tr.getAngleA(), 10e-2);
            Assert.AreEqual(4.83, tr.getC(), 10e-2);
            Assert.AreEqual(7.89, tr.getB(), 10e-2);

        }

        [TestMethod]
        public void TriangleTestCalculationOnThreeSides()
        {
            Triangle tr = new Triangle(a: 3, b: 5, c: 6);
            TestHerons(tr, 7.48);

            Assert.AreEqual(29.93, tr.getAngleA(), 10e-2);
            Assert.AreEqual(56.25, tr.getAngleB(), 10e-2);
            Assert.AreEqual(93.82, tr.getAngleC(), 10e-2);

        }


        [TestMethod]
        public void TriangleDoesNot()
        {
            Triangle tr = new Triangle(a: 3, b: 5, c: 15);

            TestHerons(tr, 0);
            TestTriangle(tr, 0,0,0,0,0,0);

        }

        [TestMethod]
        public void NegativeSideA()
        {
            Triangle tr = new Triangle(a: 0, b: 5, c: 15);

            TestHerons(tr, 0);
            TestTriangleDoesNot(tr, 0, 0, 0, 0, 0, 0);
        }


        [TestMethod]
        public void NegativeSide()
        {
            Triangle tr = new Triangle(a: -3, b: 5, c: 15);

            TestHerons(tr, 0);
            TestTriangleDoesNot(tr, 0, 0, 0, 0, 0, 0);
        }

        [TestMethod]
        public void NegativeAngle()
        {
            Triangle tr = new Triangle(a: -3, b: 5, angleC: -15);

            TestHerons(tr, 0);
            TestTriangleDoesNot(tr, 0, 0, 0, 0, 0, 0);
        }


        [TestMethod]
        public void FunctionalTestTriangleDoesNot()
        {
            var rnd = new Random(1);
            for (int i = 0; i < 100; i++)
            {
                var a = rnd.NextDouble() * 10-20;
                var b = rnd.NextDouble() * 10-20;
                var c = rnd.NextDouble() * 10-20;

                Triangle tr = new Triangle(a: a, b: b, c: c);
                if(!(Math.Abs(a) > Math.Abs(b - c) && a < b + c &&
                                Math.Abs(b) > Math.Abs(a - c) && b < a + c &&
                                Math.Abs(c) > Math.Abs(b - a) && c < b + a))
                {
                    TestHerons(tr, 0);
                    TestTriangleDoesNot(tr, 0, 0, 0, 0, 0, 0);
                }
            }
        }


    }
}
