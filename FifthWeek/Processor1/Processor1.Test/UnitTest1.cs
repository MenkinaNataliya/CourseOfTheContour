using System;
using System.ComponentModel.Design;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Processor1;

namespace Processor1.Test
{
    [TestClass]
    public class UnitTest1
    {
        private DataModel data;
        [TestInitialize]
        public void TestInitialize()
        {
            data = new DataModel(4,4);
            data.Put(1, 1, 8);
            data.Put(1, 3, 6);
            data.Put(2, 2, 7);
            data.Put(3, 2, 5);
            data.Put(3, 3, 4);
            data.Put(4, 1, 3);
            data.Put(4, 2, 2);
        }

        [TestMethod]
        public void CorrectPutData()
        {
            data.Put(1,3 ,10);
            Assert.AreEqual(10, data.Get(1, 3));

        }

        [TestMethod]
        public void CorrectInsertRow()
        {
            data.InsertRow(3);
            Assert.AreEqual(0, data.Get(3, 3));
            Assert.AreEqual(4, data.Get(4, 3));
            Assert.AreEqual(7, data.Get(2, 2));
        }

        [TestMethod]
        public void CorrectInsertColumn()
        {
            data.InsertColumn(2);

            Assert.AreEqual(0, data.Get(1, 2));
            Assert.AreEqual(6, data.Get(1, 4));
            Assert.AreEqual(3, data.Get(4, 1));
        }

        [TestMethod]
        public void CorrectInsertColumnAndRow()
        {
            data.InsertColumn(2);
            data.InsertRow(1);
            Assert.AreEqual(0, data.Get(1, 1));
            Assert.AreEqual(0, data.Get(1, 2));
            Assert.AreEqual(8, data.Get(2,1));
            Assert.AreEqual(5, data.Get(4, 3));
        }


    }
}
