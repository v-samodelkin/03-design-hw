namespace TagCloud
{
    public class Counter
    {
        private readonly string _value;
        private readonly int _count;
        public string Value { get { return _value; } }
        public int Count { get { return _count; } }

        public Counter(string value, int count)
        {
            _value = value;
            _count = count;
        }
    }
}
