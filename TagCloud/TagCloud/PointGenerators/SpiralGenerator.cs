using System;
using System.Collections.Generic;


namespace TagCloud
{
    public class SpiralGenerator : IPointGenerator
    {
        public double B { get; private set; }
        public double A { get; private set; }
        public int Steps { get; private set; }

        public SpiralGenerator(double b = 5, double a = 10, int steps = 100)
        {
            B = b;
            A = a;
            Steps = steps;
        }

        public IEnumerable<Point> GetPoints()
        {
            double currentAngle = 0;
            while (true)
            {
                double currentRadius = (currentAngle + 2 * Math.PI) / (2 * Math.PI);
                double currentX = currentRadius * A * (float)Math.Cos(currentAngle);
                double currentY = currentRadius * B * (float)Math.Sin(currentAngle);
                yield return new Point(currentX, currentY);
                currentAngle += (float) (Math.PI / Steps); 
            }
        }
    }
}
