using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometrie.BLL
{
    public class Quadrilatère : Polygone
    {
        public Quadrilatère(Point a, Point b, Point c, Point d)
            : base(a, b, c, d)
        {
        }

        public override double CalculerAire()
        {
            //je le coupe en 2 triangles
            var t1 = new Triangle(this[0], this[1], this[2]);
            var t2 = new Triangle(this[0], this[2], this[3]);
            return t1.CalculerAire() + t2.CalculerAire();
        }
    }
}
