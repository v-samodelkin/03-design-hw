using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;

namespace TagCloud
{
    class TxtFileReader : IDataReader
    {
        [Inject]
        public Options options { get; set; }

        public string RawData()
        {
            return System.IO.File.ReadAllText(options.InputFile);
        }

        public IData ClearData()
        {
            var text = new Text(RawData());
            return text.Statistic(options.PreLoad);
        }
    }
}
