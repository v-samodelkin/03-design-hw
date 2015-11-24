using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagCloud
{
    public class Text
    {
        public readonly string _data;
        public string Data { get { return _data; } }

        public Text(string text)
        {
            _data = text;
        }

        public IEnumerable<Counter> Statistic(Func<String, String> PreLoad)
        {
            var gt = SplitText(PreLoad)
                .GroupBy(s => s)
                .Select(g => new Counter(g.Key, g.Count()))
                .OrderByDescending(c => c.Count);
            return gt;
        }

        public IEnumerable<string> SplitText(Func<String, String> PreLoad)
        {
            return Data.Split().Where(s => !String.IsNullOrEmpty(s)).Select(s => PreLoad(s));
        }

        public override string ToString()
        {
            return Data;
        }
    }
}
