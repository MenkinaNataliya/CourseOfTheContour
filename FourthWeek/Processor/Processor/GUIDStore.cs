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
        public readonly Dictionary<Type, IDictionary> DictionaryObjects = new Dictionary<Type, IDictionary>();

        public Type CreateObject<Type>()
            where Type: new()
        {
            if (!DictionaryObjects.ContainsKey(typeof(Type)))
                DictionaryObjects[typeof(Type)] = new Dictionary<Guid, Type>();

            return (Type) (DictionaryObjects[typeof(Type)][Guid.NewGuid()] = new Type());

        }

        public IEnumerable<KeyValuePair<Guid, Type>> GetPairsOfElements<Type>() {
          

            if (DictionaryObjects.ContainsKey(typeof(Type)))
                return ((Dictionary<Guid, Type>)DictionaryObjects[typeof(Type)]).AsEnumerable();

            return new KeyValuePair<Guid, Type>[0];

        }

        public Type GetObjectByGuid<Type>(Guid guid) {
            if (!DictionaryObjects.ContainsKey(typeof(Type))) return default(Type);
            else
            {
                Dictionary<Guid, Type> resultDictionary = (Dictionary<Guid, Type>)DictionaryObjects[typeof(Type)];

                if (resultDictionary.ContainsKey(guid)) return resultDictionary[guid];
                else return default(Type);
            }
        }
    }
}
