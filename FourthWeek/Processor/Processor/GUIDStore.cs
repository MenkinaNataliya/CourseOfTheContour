using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Processor
{
    public class Storage
    {
        private readonly Dictionary<Type, Dictionary<Guid, Type>> dictionaryObjects=new Dictionary<Type, Dictionary<Guid, Type>>();



        public Type CreateObject<Type>()
            where Type: new()
        {
            if (!dictionaryObjects.ContainsKey(typeof(Type)))
                dictionaryObjects[typeof(Type)] = new Dictionary<Guid,Type>();

            return (dictionaryObjects[typeof(Type)][Guid.NewGuid()] = new Type());

        }

        public Dictionary<Guid, Type> GetPairsOfElements<Type>() {


            if (dictionaryObjects.ContainsKey(typeof(Type)))
                return dictionaryObjects[typeof(Type)];

            return new Dictionary<Guid, Type>(0);

        }

        public Type GetObjectByGuid<Type>(Guid guid) {
            if (!dictionaryObjects.ContainsKey(typeof(Type))) return default(Type);
            else
            {
                Dictionary<Guid, Type> resultDictionary = dictionaryObjects[typeof(Type)];

                if (resultDictionary.ContainsKey(guid)) return resultDictionary[guid];
                else return default(Type);
            }
        }
    }
}
