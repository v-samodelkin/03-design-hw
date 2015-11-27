using System;
using System.Collections.Generic;
using System.Linq;

namespace TagCloud
{
    public class Text
    {
        private readonly string _data;
        public string Data { get { return _data; } }

        public Text(string text)
        {
            _data = text;
        }

        public Statistic Statistic(Func<String, String> preLoad)
        {
            var gt = SplitText(preLoad)
                .GroupBy(s => s)
                .Select(g => new Counter(g.Key, g.Count()))
                .OrderByDescending(c => c.Count);
            return new Statistic(gt);
        }

        public IEnumerable<string> SplitText(Func<String, String> preLoad)
        {
            return Data.Split().Where(s => !String.IsNullOrEmpty(s)).Select(s => preLoad(s));
        }

        public override string ToString()
        {
            return Data;
        }
    }
}
