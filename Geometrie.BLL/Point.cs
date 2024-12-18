namespace Geometrie.BLL
{
    /// <summary>
    /// Représente un point dans un espace à deux dimensions.
    /// avec des coordonnées X et Y.
    /// </summary>
    public class Point
    {
        /// <summary>
        /// pour stocker l'id du point qui vient de la base de données
        /// </summary>
        public int? Id{ get; set; }

        //un champ privé
        private int x;

        /// <summary>
        /// Abscisse du point
        /// </summary>
        //l'accesseur (propriété) pour aller avec le champ
        public int X
        {
            get { return x; }
            private set { x = value; }
        }

        /// <summary>
        /// Ordonnée du point
        /// </summary>
        //la version automatique de la propriété
        public int Y { get; private set; }

        /// <summary>
        /// Constructeur d'un point
        /// </summary>
        /// <param name="x">abscisse du point</param>
        /// <param name="y">ordonnée du point</param>
        public Point(int x, int y)
        {
            X = x; //le this.X est implicite
            Y = y;
        }

        public Point(int id, int x, int y)
            : this(x, y)
        {
            Id = id;
        }

        /// <summary>
        /// Calcule la distance au carré entre ce point et un autre.
        /// </summary>
        /// <param name="autre">autre point</param>
        /// <returns>la distance au carré</returns>
        public int CalculerDistanceCarre(Point autre)
        {
            //je lève une exception si autre est null
            //if (autre == null)
            //    throw new ArgumentNullException(nameof(autre));
            //on peut aussi l'écrire comme ça
            ArgumentNullException.ThrowIfNull(autre, nameof(autre));

            return Convert.ToInt32(Math.Pow(X - autre.X, 2) + Math.Pow(Y - autre.Y, 2));
        }

        /// <summary>
        /// Calcule la distance entre ce point et un autre (valeur approximative à cause du Sqrt).
        /// </summary>
        /// <param name="autre">Un autre <see cref="Point"/></param>
        /// <returns>la distance</returns>
        public double CalculerDistance(Point autre)
        {
            ArgumentNullException.ThrowIfNull(autre, nameof(autre));

            return Math.Sqrt(CalculerDistanceCarre(autre));
        }

        //public override string ToString()
        //{
        //    return $"({X}, {Y})";
        //}
        //version abrégée
        public override string ToString() => $"({X}, {Y})";

        internal DAL.Point_DAL ToDAL()
        {
            if(Id == null)
                return new DAL.Point_DAL(X, Y);
            else
                return new DAL.Point_DAL(Id.Value, X, Y);
        }

        //on implémente l'opérateur == pour pourvoir comparer 2 points entre eux
        public static bool operator ==(Point p1, Point p2)
        {
            //si deux variables pointent sur le même objet
            if (ReferenceEquals(p1, p2))
                return true;
            //si un des deux objets est null
            if (ReferenceEquals(p1, null) || ReferenceEquals(p2, null))
                return false;
            //si les coordonnées des points sont égales
            return p1.X == p2.X && p1.Y == p2.Y;
        }

        //on implémente l'opérateur != obligatoire si on fait le ==
        public static bool operator !=(Point p1, Point p2) => !(p1 == p2);

    }
}