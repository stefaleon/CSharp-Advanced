using System.Collections.Generic;

namespace GenericDictionary
{
    public class GenericDictionary<TKey, TValue>
    {
        IList<GenericDictionaryItem<TKey, TValue>> _items = new List<GenericDictionaryItem<TKey, TValue>>();
        public void AddItem(TKey key, TValue value)
        {
            // throw exception when key already exists
            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i].GetKey().Equals(key))
                    throw new System.Exception("This key already exists!");
            }

            _items.Add(new GenericDictionaryItem<TKey, TValue>(key, value));
        }

        //public TValue GetTheValueForKey(TKey key)
        //{
        //    for (int i = 0; i < _items.Count; i++)
        //    {
        //        if (_items[i].GetKey().Equals(key))
        //            return _items[i].GetValue();
        //    }

        //    return default(TValue);
        //}


        public TValue GetTheValueForKey(TKey key)
        // read from the end of the list to the beginning
        {
            for (int i = _items.Count - 1; i >= 0; i--)
            {
                if (_items[i].GetKey().Equals(key))
                    return _items[i].GetValue();
            }

            return default(TValue);
        }

        public TKey FindTheFirstKeyWithValue(TValue value)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i].GetValue().Equals(value))
                    return _items[i].GetKey();
            }

            return default(TKey);
        }
    }
}
