using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometrie.BLL.Exceptions
{
    public class PolygoneException : Exception
    {
        public IEnumerable<Point> Points { get; private set; }

        public PolygoneException(string message, IEnumerable<Point> desPoints)
            : base(message)
        {
            Points = desPoints;
        }
    }
}
