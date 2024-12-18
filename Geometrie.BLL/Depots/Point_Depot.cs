using Geometrie.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Geometrie.BLL.Depots
{
    public class Point_Depot : IDepot<Point>
    {
        // Un contexte pour accéder à la base de données
        private readonly GeometrieContext context;

        public Point_Depot(GeometrieContext context)
        {
            this.context = context;
        }

        public Point Add(Point element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));

            var point_DAL = element.ToDAL();
            point_DAL.DateDeCreation = DateTime.Now;
            context.Points.Add(point_DAL);
            context.SaveChanges(); // Déclenche l'insert
            // On récupère l'id généré par la base de données
            element.Id = point_DAL.Id;

            return element;
        }

        public IDepot<Point> Delete(Point element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));
            ArgumentNullException.ThrowIfNull(element.Id, nameof(element.Id));

            return Delete(element.Id.Value);
        }

        public IDepot<Point> Delete(int Id)
        {
            var point_DAL = context.Points.Find(Id);
            if (point_DAL == null)
                throw new ArgumentException("Le point n'existe pas en base de données", nameof(Id));

            context.Points.Remove(point_DAL);
            context.SaveChanges();
            return this;
        }

        public IEnumerable<Point> GetAll()
        {
            // Avec du LINQ on transforme une IEnumerable<DAL.Point> en IEnumerable<BLL.Point>
            return context.Points.Select(p => new Point(p.Id.Value, p.X, p.Y));
        }

        public Point? GetById(int id)
        {
            // Le select
            var point_DAL = context.Points.Find(id);
            // On vérifie si on a trouvé le point
            if (point_DAL == null)
                return null;

            return new Point(id, point_DAL.X, point_DAL.Y);
        }

        public Point Update(Point element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));
            ArgumentNullException.ThrowIfNull(element.Id, nameof(element.Id));

            var point_DAL = context.Points.Find(element.Id);
            if (point_DAL == null)
                throw new ArgumentException("Le point n'existe pas en base de données", nameof(element));

            point_DAL.X = element.X;
            point_DAL.Y = element.Y;
            point_DAL.DateDeModification = DateTime.Now;
            context.Update(point_DAL);
            context.SaveChanges();

            return element;
        }
    }
}