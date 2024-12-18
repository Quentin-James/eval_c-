namespace Geometrie.DAL
{
    public class Cercle_DAL
    {
        public int? Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Rayon { get; set; }
        public DateTime DateDeCreation { get; set; }
        public DateTime? DateDeModification { get; set; }

        public Cercle_DAL(double x, double y, double rayon)
        {
            X = x;
            Y = y;
            Rayon = rayon;
        }
    }
}