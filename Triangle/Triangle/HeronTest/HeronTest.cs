using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Triangle;


namespace HeronTest
{
    [TestClass]
    public class HeronTest
    {

        public void TestHerons(Triangles tr, double ExectedResult)
        {
            var result = tr.Heron();

            Assert.AreEqual(ExectedResult, result, 10e-2);
        }

        [TestMethod]
        public void FirstSign()
        {
            Triangles tr1 = new Triangles(3.0, 4.0, 5.0);
            TestHerons(tr1, 6);
        }

        [TestMethod]
        public void TriangeDoesNotExist() {
            Triangles tr = new Triangles(3.0, 5.0, 15.0);
            TestHerons(tr, 0);
        }

        [TestMethod]
        public void SecondtSign()
        {
            Triangles tr = new Triangles(3.0, 4.0, 90);
            TestHerons(tr, 6);
        }

        [TestMethod]
        public void ThirdSign()
        {
            Triangles tr = new Triangles(15.0, 20, 42);
            TestHerons(tr, 29.16);
        }
    }
}
