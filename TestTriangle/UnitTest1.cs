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
            var result = tr.Heron();

            Assert.AreEqual(ExectedResult, result, 10e-2);
        }

        public void TestTriangle(Triangle tr, double ExectedAngleA, double ExectedAngleB=0, double ExectedAngleC=0, double ExectedA =0, double ExectedB= 0, double ExectedC= 0)
        {

            Assert.AreEqual(ExectedAngleA, tr.angleA, 10e-2);
            Assert.AreEqual(ExectedAngleB, tr.angleB, 10e-2);
            Assert.AreEqual(ExectedAngleC, tr.angleC, 10e-2);
            Assert.AreEqual(ExectedA, tr.a, 10e-2);
            Assert.AreEqual(ExectedB, tr.b, 10e-2);
            Assert.AreEqual(ExectedC, tr.c, 10e-2);
        }


        [TestMethod]
        public void TestMethod1()
        {
            Triangle tr = new Triangle(a: 14, b: 25, angleC:30);
            TestHerons(tr, 87.50);
           
            Assert.AreEqual(28.53, tr.angleA, 10e-2);
            Assert.AreEqual(121.47, tr.angleB, 10e-2);
            Assert.AreEqual(14.66, tr.c, 10e-2);

        }
        [TestMethod]
        public void TestMethod2()
        {
            Triangle tr = new Triangle(a: 3, b: 5, angleC: 15);
            TestHerons(tr, 1.94);
            
            Assert.AreEqual(20.27, tr.angleA, 10e-2);
            Assert.AreEqual(144.73, tr.angleB, 10e-2);
            Assert.AreEqual(2.24, tr.c, 10e-2);

        }
        [TestMethod]
        public void TestMethod3()
        {
            Triangle tr = new Triangle(a: 12, angleB: 25, angleC: 15);
            TestHerons(tr,12.25);
            
            Assert.AreEqual(140, tr.angleA, 10e-2);
            Assert.AreEqual(4.83, tr.c, 10e-2);
            Assert.AreEqual(7.89, tr.b, 10e-2);

        }

        [TestMethod]
        public void TestMethod4()
        {
            Triangle tr = new Triangle(a: 3, b: 5, c: 6);
            TestHerons(tr, 7.48);

            Assert.AreEqual(29.93, tr.angleA, 10e-2);
            Assert.AreEqual(56.25, tr.angleB, 10e-2);
            Assert.AreEqual(93.82, tr.angleC, 10e-2);

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
            TestTriangle(tr, 0, 0, 0, 0, 0, 0);
        }


        [TestMethod]
        public void NegativeSide()
        {
            Triangle tr = new Triangle(a: -3, b: 5, c: 15);

            TestHerons(tr, 0);
            TestTriangle(tr, 0, 0, 0, 0, 0, 0);
        }

        [TestMethod]
        public void NegativeAngle()
        {
            Triangle tr = new Triangle(a: -3, b: 5, angleC: -15);

            TestHerons(tr, 0);
            TestTriangle(tr, 0, 0, 0, 0, 0, 0);
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
                    TestTriangle(tr, 0, 0, 0, 0, 0, 0);
                }
            }
        }


    }
}
