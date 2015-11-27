using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagCloud
{
    public class Statistic : IData
    {
        public IEnumerable<Counter> Data { get; private set; }
        public Statistic(IEnumerable<Counter> data)
        {
            Data = data;
        }
    }
}
