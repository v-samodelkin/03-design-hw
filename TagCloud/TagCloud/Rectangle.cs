using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagCloud
{
    public class Rectangle
    {
        public Point LeftUp { get; private set; }
        public Point RightDown { get; private set; }
        public Rectangle(Point a, Point b)
        {
            LeftUp = new Point(Math.Min(a.X, b.X), Math.Min(a.Y, b.Y));
            RightDown = new Point(Math.Max(a.X, b.X), Math.Max(a.Y, b.Y));
        }

        public Point Centre()
        {
            return new Point((LeftUp.X + RightDown.X) / 2, (LeftUp.Y + RightDown.Y) / 2);
        }

        public bool IsIntersected(Rectangle rec)
        {
            return !(LeftUp.X > rec.RightDown.X || LeftUp.Y > rec.RightDown.Y
                 || RightDown.X < rec.LeftUp.X || RightDown.Y < rec.LeftUp.Y);
        }
    }
}
