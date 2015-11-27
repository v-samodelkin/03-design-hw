using Ninject;

namespace TagCloud
{
    class TxtFileReader : IDataReader
    {
        [Inject]
        public Options options { get; set; }

        private string _text;

        private void Load()
        {
            _text = System.IO.File.ReadAllText(options.InputFile);
        }

        public string RawData()
        {
            if (_text == null)
                Load();
            return _text;
        }

        public IData ClearData()
        {
            if (_text == null)
                Load();
            var text = new Text(RawData());
            return text.Statistic(options.PreLoad);
        }
    }
}
