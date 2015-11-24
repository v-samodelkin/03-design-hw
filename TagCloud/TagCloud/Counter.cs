using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagCloud
{
    public class Counter
    {
        private string _value;
        private int _count;
        public string Value { get { return _value; } }
        public int Count { get { return _count; } }
        public Counter(string value, int count)
        {
            _value = value;
            _count = count;
        }
    }
}
