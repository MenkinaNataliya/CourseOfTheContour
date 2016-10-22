using System;
using System.Collections;
using System.Collections.Generic;



namespace Processor
{
    public class Storage
    {
        private readonly Dictionary<Type, Dictionary<Guid, object>> dictionaryObjects=new Dictionary<Type, Dictionary<Guid, object>>();

        public TType CreateObject<TType>() 
        where TType : new()     
        { 
            if (!dictionaryObjects.ContainsKey(typeof(TType)))
            {
                
                dictionaryObjects[typeof(TType)] = new Dictionary<Guid, object>();
            }
                

            return (TType)(dictionaryObjects[typeof (TType)][Guid.NewGuid()] = new TType());
        }

        public List<KeyValuePair<Guid, TType>> GetPairsOfElements<TType>()
        {

            if (!dictionaryObjects.ContainsKey(typeof(TType))) return new List<KeyValuePair<Guid, TType>>(0);

            List<KeyValuePair<Guid, TType>> guidObjectPairs = new List<KeyValuePair<Guid, TType>>();
            foreach (var dictionary in dictionaryObjects[typeof(TType)])
            {

                guidObjectPairs.Add(new KeyValuePair<Guid, TType>(dictionary.Key, (TType)dictionary.Value));
            }
                
            return guidObjectPairs;

        }

        public TType GetObjectByGuid<TType>(Guid guid)
        {
            if (!dictionaryObjects.ContainsKey(typeof(TType))) return default(TType);
            else
            {
                Dictionary<Guid, object> resultDictionary = dictionaryObjects[typeof(TType)];

                if (resultDictionary.ContainsKey(guid)) return (TType)resultDictionary[guid];
                else return default(TType);
            }
        }
    }
}
