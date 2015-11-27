using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TagCloud
{
    public class StableSpiralGenerator : IPointGenerator
    {
        public double B { get; private set; }
        public double A { get; private set; }
        public double Delta { get; private set; }

        public StableSpiralGenerator(double b = 5, double a = 10, double delta = 5)
        {
            B = b;
            A = a;
            Delta = delta;
        }

        // Этот метод тоже надо было сделать более читаемым
        public IEnumerable<Point> GetPoints()
        {
            double alpha = 0;
            double x, y;
            double r;
            int cnt = 0;
            while (true)
            {
                cnt++;
                r = (alpha + 2 * Math.PI) / (2 * Math.PI);
                x = r * A * (float)Math.Cos(alpha);
                y = r * B * (float)Math.Sin(alpha);
                yield return new Point(x, y);
                double len = Math.PI * 2 * r;
                double part = Delta / len;
                alpha += part * Math.PI * 2;
            }
        }
    }
}
