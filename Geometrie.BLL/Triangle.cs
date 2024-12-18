using Geometrie.BLL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometrie.BLL
{
    /// <summary>
    /// représente un triangle dans un repère à 2 dimensions
    /// </summary>
    public class Triangle : Polygone
    {
        /// <summary>
        /// Constructeur de triangle
        /// Notez l'appel au constructeur de la classe de base dont il hérite (Polygone)
        /// </summary>
        /// <param name="a">1er point</param>
        /// <param name="b">2eme point</param>
        /// <param name="c">3eme point</param>
        /// <exception cref="ArgumentException"></exception>
        public Triangle(Point a, Point b, Point c) 
            : base(a, b, c)
        {
            //on vérifie que les points ne sont pas alignés
            //je calcule la taille de tous les côtés
            var cotes = new List<double>()
            {
                a.CalculerDistance(b), b.CalculerDistance(c), c.CalculerDistance(a)
            };
            //je les trie
            cotes.Sort();

            //si le plus grand est égal à la somme des 2 autres
            //je lève une exception spécialisée
            if (cotes[2] <= cotes[0] + cotes[1])
                throw new PolygoneException("Les points sont alignés", this);

        }

        /// <summary>
        /// Calcule l'aire du triangle
        /// Cette méthode est imposée par l'interface IForme
        /// et par le Polygone qui est abstract
        /// </summary>
        /// <returns>l'aire du triangle</returns>
        public override double CalculerAire()
        {
            //Formule de Héron
            double p = CalculerPerimetre() / 2;
            double a = this[0].CalculerDistance(this[1]);
            double b = this[1].CalculerDistance(this[2]);
            double c = this[2].CalculerDistance(this[0]);
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }
}
