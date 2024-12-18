namespace Geometrie.DAL
{
    public class Point_DAL
    {
        public int? Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public DateTime DateDeCreation { get; set; }
        public DateTime? DateDeModification { get; set; }

        public Polygone? Polygone { get; set; }

        public Point_DAL(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point_DAL(int id, int x, int y)
            :this(x,y)
        {
            Id = id;
        }
    }
}
