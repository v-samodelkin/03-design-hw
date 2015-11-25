using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
namespace TagCloud
{
    class Cloud
    {
        public Graphics Graphics { get; private set; }
        public Bitmap Bitmap { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public List<Rectangle> Rectangles { get; private set; }
        public Color BrushColor { get; set; }

        public Color FontColor { get; set; }

        public FontGenerator FontGenerator {get; set;}
        public IPointGenerator Generator { get; set; }

        public IEnumerable<Counter> Statistic { get; private set; }
        public Cloud(IEnumerable<Counter> statistic, Options options, IKernel kernel)
        {
            Generator = kernel.Get<IPointGenerator>();
            FontGenerator = kernel.Get<FontGenerator>();
            Rectangles = new List<Rectangle>();
            Width = options.Width;
            Height = options.Height;
            Bitmap = new Bitmap(Width, Height);
            Graphics = Graphics.FromImage(Bitmap);
            BrushColor = Color.FromName(options.BrushColorName);
            FontColor = Color.FromName(options.FontColorName);

            Graphics.Clear(FontColor);
            Statistic = statistic;


        }

        public void Write(string text, Font font, Pen pen, float x, float y)
        {
            //SizeF stringSize = new SizeF();
            //stringSize = Graphics.MeasureString(text, font);
            //Graphics.DrawRectangle(pen, x, y, stringSize.Width, stringSize.Height);
            Graphics.DrawString(text, font, GetBrush(), x, y);
        }

        public SolidBrush GetBrush()
        {
            return new SolidBrush(BrushColor);
        }

        // метод лучше разбить на кусочки помельче и более читаемые  
        public void GenerateImage() {
            foreach (var word in Statistic)
            {
                var sk = new StandardKernel();
                Font font = FontGenerator.GetFont(word);
                Pen pen = GetPen(word);
                var stringSize = Graphics.MeasureString(word.Value, font);
                foreach (var pnt in Generator.GetPoints())
                {
                    double w2 = stringSize.Width / 2;
                    double h2 = stringSize.Height / 2;
                    var rec = new Rectangle(new Point(pnt.X - w2, pnt.Y - h2), new Point(pnt.X + w2, pnt.Y + h2));
                    double newX = (float)(Width / 2 + pnt.X);
                    double newY = (float)(Height / 2 + pnt.Y);
                    //Graphics.DrawRectangle(new Pen(Color.Red, 1), (float)newX, (float)newY, 2, 2);
                    if (!Rectangles.Any(r => r.IsIntersected(rec)))
                    {
                        var NotInt = Rectangles.Where(r => !r.IsIntersected(rec)).ToList();
                        double nx = Width / 2 + rec.LeftUp.X;
                        double ny = Height / 2 + rec.LeftUp.Y;
                        Write(word.Value, font, pen, (float)nx, (float)ny);
                        Rectangles.Add(rec);
                        break;
                    }
                }
            }
        }

        public Pen GetPen(Counter word)
        {
            return new Pen(Color.Red, 1);
        }

    }
}
