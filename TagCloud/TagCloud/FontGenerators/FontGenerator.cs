using System;
using System.Drawing;

namespace TagCloud
{
    public class FontGenerator : IFontGenerator
    {
        public FontFamily FontFamily { get; set; }
        public bool Log { get; private set; }
        public int MultipleSize { get; private set; }
        public FontGenerator(FontFamily fontFamily, bool log = false, int multipleSize = 3)
        {
            FontFamily = fontFamily;
            MultipleSize = multipleSize;
            Log = log;
        }
        public Font GetFont(Counter word)
        {
            var cnt = word.Count;
            var lgcnt = Math.Log(cnt, 2) + 1;
            return new Font(FontFamily, (int)(Math.Round(GetCount(word) * MultipleSize)));
        }

        public double GetCount(Counter word)
        {
            return (Log ? Math.Log(word.Count, 2) + 1 : word.Count);
        }
    }
}
