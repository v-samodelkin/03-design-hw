using System.Drawing;

namespace TagCloud
{
    class DefaultGraphicModule : IGraphicModule
    {
        public Graphics Graphics { get; set; }
        public Bitmap Bitmap { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Color BrushColor { get; set; }
        public Color FontColor { get; set; }
        public DefaultGraphicModule(Options options)
        {
            Width = options.Width;
            Height = options.Height;
            Bitmap = new Bitmap(Width, Height);
            Graphics = Graphics.FromImage(Bitmap);
            BrushColor = Color.FromName(options.BrushColorName);
            FontColor = Color.FromName(options.FontColorName);
            Graphics.Clear(FontColor);
        }

    }
}
