using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometrie.DTO
{
    public interface IPoint_Service : IService<Point_DTO>
    {
        double CalculerDistance(Point_DTO p1, Point_DTO p2, string IP);
        double CalculerDistance(int id1, int id2, string IP);
    }
}
