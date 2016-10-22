﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Processor;
using System.Collections.Generic;
using System.Linq;

namespace Processor.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestStorageString()
        {
            var storage = new Storage();
            var stringList =  storage.CreateObject<List<string>>();
            stringList.Add("Hello");
            stringList.Add("World");

            var stringListEnumerable = storage.GetPairsOfElements<string>();

           
           Assert.AreEqual(stringListEnumerable.First().Value, "Hello");
           Assert.AreEqual(storage.GetObjectByGuid<string>(stringListEnumerable.First().Key), stringList[0]);

        }

        [TestMethod]
        public void GetTypeOfObjectThatIsNotInDictionary()
        {
            var storage = new Storage();

            Assert.AreEqual(storage.GetObjectByGuid<Dictionary<long, int>>(Guid.NewGuid()), null);
        }

    }
}