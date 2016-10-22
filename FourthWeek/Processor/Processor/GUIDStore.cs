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
            var value = new Dictionary<Guid, object>();

            if (dictionaryObjects.TryGetValue(typeof(TType), out value))
            {
                dictionaryObjects[typeof(TType)][Guid.NewGuid()] = new TType();
            }
            else
            {
                dictionaryObjects[typeof(TType)] = new Dictionary<Guid, object>();
            }


            return (TType)dictionaryObjects[typeof (TType)][Guid.NewGuid()];
        }

        public Dictionary<Guid, TType> GetPairsOfElements<TType>()
        {
            var resultDictionary = new Dictionary<Guid, object>();
            if (dictionaryObjects.TryGetValue(typeof(TType), out resultDictionary))
            {
                var returnDictionary = new Dictionary<Guid, TType>();
                foreach (var item in resultDictionary)
                {
                    resultDictionary.Add(item.Key, (TType) item.Value);
                }
                return returnDictionary;
            }
            else   return new Dictionary<Guid, TType>(0);

        }

        public TType GetObjectByGuid<TType>(Guid guid)
        {
            var resultDictionary = new Dictionary<Guid, object>();

            if (dictionaryObjects.TryGetValue(typeof(TType), out resultDictionary))
            {
                object result;
                if (resultDictionary.TryGetValue(guid, out result))
                    return (TType)resultDictionary[guid];
                    
            }
            return default(TType);

        }
    }
}
