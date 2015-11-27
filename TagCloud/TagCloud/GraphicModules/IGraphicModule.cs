using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagCloud
{
    interface IGraphicModule
    {
        Graphics Graphics { get; set; }
        Bitmap Bitmap { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        Color BrushColor { get; set; }
        Color FontColor { get; set; }
    }
}
