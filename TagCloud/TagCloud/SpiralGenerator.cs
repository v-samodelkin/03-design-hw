using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            double angleStep = (float)(Math.PI / Steps);
            double alpha = 0;
            double x, y;
            double fPi = (float)Math.PI;
            double r;
            while (true)
            {
                r = (alpha) / (2 * fPi);
                x = r * A * (float)Math.Cos(alpha);
                y = r * B * (float)Math.Sin(alpha);
                yield return new Point(x, y);
                alpha += angleStep;
            }
        }
    }
}
