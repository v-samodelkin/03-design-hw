using System.Collections.Generic;

namespace TagCloud
{
    public interface IPointGenerator
    {
        IEnumerable<Point> GetPoints();
    }
}
