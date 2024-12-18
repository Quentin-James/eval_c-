using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometrie.BLL
{
    public abstract class Polygone : IEnumerable<Point>, IForme
    {
        private ArrayList lesPoints;
            
        //indexeur
        public Point this[int index]
        {
            get
            {
                return (Point)lesPoints[index];
            }
        }


        //public int Count
        //{
        //    get
        //    {
        //        return lesPoints.Count;
        //    }
        //}
        /// <summary>
        /// Nombre de points du polygone
        /// </summary>
        //version abrégée
        public int Count => lesPoints.Count;

        /// <summary>
        /// Contructeur d'un polygone
        /// </summary>
        /// <param name="a">1er point</param>
        /// <param name="b">2eme point</param>
        /// <param name="c">3ème point</param>
        /// <param name="autresPoints">Autres points</param>
        /// <exception cref="ArgumentNullException">si un des 3 points obligatoires est null</exception>
        public Polygone(Point a, Point b, Point c, params Point[]? autresPoints)
        {
            if(a == null || b == null || c == null)
                throw new ArgumentNullException("il manque un des points");
            if(autresPoints!=null && autresPoints.Any(p => p == null))
                throw new ArgumentNullException("un des autres points est null");

            lesPoints = new ArrayList();
            lesPoints.Add(a);
            lesPoints.Add(b);
            lesPoints.Add(c);
            if (autresPoints != null)
                lesPoints.AddRange(autresPoints);

            //lever une exception si au moins 2 points ont les mêmes coordonnées
            for (int i = 0; i < Count - 1; i++)
                for (int j = i + 1; j < Count; j++)
                    if (this[i] == this[j])
                        throw new ArgumentException("2 points ont les mêmes coordonnées");
        }

        public IEnumerator<Point> GetEnumerator()
        {
            foreach (Point p in lesPoints)
            {
                //yield c'est un mot clé qui permet de retourner un élément à la fois
                yield return p;
            }   
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            foreach (Point p in lesPoints)
            {
                sb.Append(p);
                sb.Append(" ");
            }
            sb.Append("]");
            return sb.ToString();
        }

        public double CalculerPerimetre()
        {
            double perimetre = 0;
            for (int i = 0; i < Count - 1; i++)
            {
                Point p1 = this[i];
                Point p2 = this[i + 1];
                perimetre += p1.CalculerDistance(p2);
            }
            perimetre += this[Count - 1].CalculerDistance(this[0]);
            return perimetre;
        }

        public abstract double CalculerAire();
    }
}
