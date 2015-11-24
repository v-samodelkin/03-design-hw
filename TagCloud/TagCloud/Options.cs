using CommandLine;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagCloud
{
    public class Options {

        public Options()
        {
            Width = 1000;
            Height = 600;
            MultipleSize = 5;
            PreLoad = s => s;
            Log = true;
            FontFamilyName = FontFamily.GenericSerif.Name;
            BrushColorName = "Black";
            FontColorName = "Azure";
        }

        public string InputFile { get; set; }
        public string FontColorName { get; set; }
        public IPointGenerator Generator{ get; set; }
        public string BrushColorName { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Log { get; set; }
        public int MultipleSize { get; set; }

        public string FontFamilyName { get; set; }

        public Func<String, String> PreLoad { get; set; }

        public void AddToPreLoad(Func<String, String> addToPreLoad)
        {
            var clone = (Func<String,String>)PreLoad.Clone();
            PreLoad = x => addToPreLoad(clone(x));
        }

        public void AddToFontFamilyName(string s)
        {
            if (String.IsNullOrEmpty(FontFamilyName))
                FontFamilyName = s;
            else
                FontFamilyName += " " + s;
        }

      }
   
}
