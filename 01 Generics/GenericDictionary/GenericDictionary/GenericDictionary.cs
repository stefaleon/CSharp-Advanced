using System.Collections.Generic;

namespace GenericDictionary
{
    public class GenericDictionary<TKey, TValue>
    {
        IList<GenericDictionaryItem<TKey, TValue>> _items = new List<GenericDictionaryItem<TKey, TValue>>();
        public void AddItem(TKey key, TValue value)
        {
            _items.Add(new GenericDictionaryItem<TKey, TValue>(key, value));
        }

        public TValue GetTheValueForKey(TKey key)
        { 
            for (int i = 0; i < _items.Count; i++)
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
