using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Processor;
using System.Collections.Generic;

namespace Processor.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestStorageString()
        {
            Storage storage = new Storage();
            List<string> stringList =  storage.CreateObject<List<string>>();
            stringList.Add("Hello");
            stringList.Add("World");

            var stringListEnumerable = storage.GetPairsOfElements<List<string>>().GetEnumerator();
            stringListEnumerable.MoveNext();

            Assert.AreEqual(stringListEnumerable.Current.Value[1], "World");
            Assert.AreEqual(storage.GetObjectByGuid<List<string>>(stringListEnumerable.Current.Key)[0], stringList[0]);

        }

        [TestMethod]
        public void GetTypeOfObjectThatIsNotInDictionary()
        {
            Storage storage = new Storage();

            Assert.AreEqual(storage.GetObjectByGuid<Dictionary<long, int>>(Guid.NewGuid()), null);
        }

    }
}
