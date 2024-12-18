using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometrie.BLL
{
    public class Cercle : IForme
    {
        public Point Centre { get; private set; }
        public double Rayon { get; private set; }

        public Cercle(Point centre, double rayon)
        {
            Centre = centre;
            Rayon = rayon;
        }

        public double CalculerPerimetre() => 2 * Math.PI * Rayon;

        public double CalculerAire() => Math.PI * Math.Pow(Rayon, 2);
    }
}
