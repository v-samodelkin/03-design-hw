using System;
using System.Collections.Generic;


namespace TagCloud
{
    public class FastSpiralGenerator : IPointGenerator
    {
        public double B { get; private set; }
        public double A { get; private set; }
        public double СircumferenceDelta { get; private set; }
        private double CurrentAngle { get; set; }


        public FastSpiralGenerator(double b = 5, double a = 10, double сircumferenceDelta = 5)
        {
            B = b;
            A = a;
            СircumferenceDelta = сircumferenceDelta;
            CurrentAngle = 0;
        }
        public IEnumerable<Point> GetPoints()
        {
            while (true)
            {
                double currentRadius = (CurrentAngle + 2 * Math.PI) / (2 * Math.PI);
                double currentX = currentRadius * A * (float)Math.Cos(CurrentAngle);
                double currentY = currentRadius * B * (float)Math.Sin(CurrentAngle);
                yield return new Point(currentX, currentY);
                double circumference = Math.PI * 2 * currentRadius;
                double circlePartDelta = СircumferenceDelta / circumference;
                CurrentAngle += circlePartDelta * Math.PI * 2;
            }
        }
    }
}
