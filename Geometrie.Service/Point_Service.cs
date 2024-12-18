using Geometrie.BLL;
using Geometrie.BLL.Depots;
using Geometrie.DAL;
using Geometrie.DTO;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Geometrie.Service
{
    public class Point_Service : IPoint_Service
    {
        private GeometrieContext? context;
        private IDepot<Point> point_depot;
        private IDepot<Log> log_depot;

        public Point_Service(IDepot<Point> unDepotDePoint, IDepot<Log> unDepotDeLog)
        {
            ArgumentNullException.ThrowIfNull(unDepotDeLog);
            ArgumentNullException.ThrowIfNull(unDepotDePoint);

            point_depot = unDepotDePoint;
            log_depot = unDepotDeLog;
        }
        public Point_Service(GeometrieContext context)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));

            this.context = context;
            point_depot = new Point_Depot(context);
            log_depot = new Log_Depot(context);
        }

        public Point_DTO Add(Point_DTO element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));

            var point_BLL = new Point(element.X, element.Y);
            point_BLL = point_depot.Add(point_BLL);
            element.Id = point_BLL.Id;

            return element;
        }

        public double CalculerDistance(Point_DTO p1, Point_DTO p2, string IP)
        {
            ArgumentNullException.ThrowIfNull(p1, nameof(p1));
            ArgumentNullException.ThrowIfNull(p2, nameof(p2));

            //on ne va pas les chercher en BBD si on a déjà les points
            var p1_bll = new Point(p1.X, p1.Y);
            var p2_bll = new Point(p2.X, p2.Y);

            //on log l'opération avant de quitter
            log_depot.Add(new Log(IP));

            return p1_bll.CalculerDistance(p2_bll);
        }

        public double CalculerDistance(int id1, int id2, string IP)
        {
            var p1 = point_depot.GetById(id1);
            var p2 = point_depot.GetById(id2);

            if (p1 is null || p2 is null)
                throw new ArgumentException("Un des points n'existe pas");

            //on log l'opération avant de quitter
            log_depot.Add(new Log(IP));

            return p1.CalculerDistance(p2);
        }

        public IService<Point_DTO> Delete(Point_DTO element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));
            ArgumentNullException.ThrowIfNull(element.Id, nameof(element.Id));

            return Delete(element.Id.Value);
        }

        public IService<Point_DTO> Delete(int Id)
        {
            point_depot.Delete(Id);

            return this;
        }

        public IEnumerable<Point_DTO> GetAll()
        {
            return point_depot.GetAll().Select(p => new Point_DTO() { Id = p.Id, X = p.X, Y = p.Y });
        }

        public Point_DTO? GetById(int id)
        {
            var point_BLL = point_depot.GetById(id);
            if (point_BLL == null)
                return null;

            return new Point_DTO() { Id = point_BLL.Id, X = point_BLL.X, Y = point_BLL.Y };
        }

        public Point_DTO Update(Point_DTO element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));
            ArgumentNullException.ThrowIfNull(element.Id, nameof(element.Id));

            var point_BLL = new Point(element.Id.Value, element.X, element.Y);
            point_depot.Update(point_BLL);

            return element;
        }
    }
}
