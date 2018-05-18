namespace GenericDictionary
{
    public class GenericDictionaryItem<TKey, TValue>
    {
        private readonly TKey _key;
        private readonly TValue _value;

        public GenericDictionaryItem(TKey key, TValue value)
        {
            _key = key;
            _value = value;
        }

        public TKey GetKey()
        {
            return _key;
        }

        public TValue GetValue()
        {
            return _value;
        }

    }
}
