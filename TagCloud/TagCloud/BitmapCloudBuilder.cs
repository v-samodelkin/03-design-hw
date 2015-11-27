using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Ninject;
namespace TagCloud
{
    class BitmapCloudBuilder : ICloudBuilder
    {
        public List<Rectangle> Rectangles { get; private set; }
        [Inject]
        public IFontGenerator FontGenerator { get; set; }
        [Inject]
        public IPointGenerator Generator { get; set; }
        [Inject]
        public IData Data { get; set; }
        [Inject]
        public IGraphicModule GraphicModule { get; set; }
        [Inject]
        public ISaveModule SaveModule { get; set; }
        public BitmapCloudBuilder()
        {
            Rectangles = new List<Rectangle>();    
        }

        public SolidBrush GetBrush()
        {
            return new SolidBrush(GraphicModule.BrushColor);
        }

        public void GenerateImage() {
            foreach (var word in Data.Data)
            {
                Font font = FontGenerator.GetFont(word);
                var wordSizes = GraphicModule.Graphics.MeasureString(word.Value, font);
                foreach (var point in Generator.GetPoints())
                {
                    var rec = new Rectangle(point, wordSizes.Width, wordSizes.Height);
                    if (!Rectangles.Any(r => r.IsIntersected(rec)))
                    {
                        WriteOneWord(word.Value, font, GetPen(word), rec);
                        Rectangles.Add(rec);
                        break;
                    }
                }
            }
        }

        public void WriteOneWord(string text, Font font, Pen pen, float x, float y)
        {
            //SizeF stringSize = new SizeF();
            //stringSize = GraphicModule.Graphics.MeasureString(text, font);
            //GraphicModule.Graphics.DrawRectangle(pen, x, y, stringSize.Width, stringSize.Height);
            GraphicModule.Graphics.DrawString(text, font, GetBrush(), x, y);
        }

        public void WriteOneWord(string text, Font font, Pen pen, Rectangle rec)
        {
            float newX = (float)(GraphicModule.Width / 2 + rec.LeftUp.X);
            float newY = (float)(GraphicModule.Height / 2 + rec.LeftUp.Y);
            WriteOneWord(text, font, pen, newX, newY);
        }

        public void Build()
        {
            SaveModule.Save(this);
        }

        public Pen GetPen(Counter word)
        {
            return new Pen(Color.Red, 1);
        }

    }
}
