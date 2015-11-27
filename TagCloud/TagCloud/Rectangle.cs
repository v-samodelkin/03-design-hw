using System;

namespace TagCloud
{
    public class Rectangle
    {
        public Point LeftUp { get; private set; }
        public Point RightDown { get; private set; }
        public Rectangle(Point a, Point b)
        {
            InitByPoints(a, b);
        }


        public Rectangle(Point center, double width, double height)
        {
            double w2 = width/2;
            double h2 = height/2;
            InitByPoints(new Point(center.X - w2, center.Y - h2), new Point(center.X + w2, center.Y + h2));
        }

        private void InitByPoints(Point a, Point b)
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
