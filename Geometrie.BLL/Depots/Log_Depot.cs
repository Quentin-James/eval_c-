using Geometrie.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometrie.BLL.Depots
{
    public class Log_Depot : IDepot<Log>
    {
        //un contexte pour accéder à la base de données
        private GeometrieContext context;

        public Log_Depot(GeometrieContext context)
        {
            this.context = context;
        }

        public Log Add(Log element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));

            var log_DAL = element.ToDAL();
            context.Add(log_DAL);
            context.SaveChanges();//déclenche l'insert
            //on récupère l'id généré par la base de données
            element.Id = log_DAL.Id;
            return element;
        }

        public IDepot<Log> Delete(Log element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));
            ArgumentNullException.ThrowIfNull(element.Id, nameof(element.Id));

            return Delete(element.Id.Value);
        }

        public IDepot<Log> Delete(int Id)
        {
            var log_DAL = context.Logs.Find(Id);
            if (log_DAL == null)
                throw new ArgumentException("Le log n'existe pas en base de données", nameof(Id));

            context.Logs.Remove(log_DAL);
            context.SaveChanges();
            return this;
        }

        public IEnumerable<Log> GetAll()
        {
            //avec du LINQ on transforme une IEnumerable<DAL.Log> en IEnumerable<BLL.Log>
            return context.Logs.Select(p => new Log(p.Id, p.IP, p.DateAppel));
        }

        public Log? GetById(int id)
        {
            var log_DAL = context.Logs.Find(id);
            if (log_DAL == null)
                return null;

            return new Log(log_DAL.Id, log_DAL.IP, log_DAL.DateAppel);
        }

        public Log Update(Log element)
        {
            ArgumentNullException.ThrowIfNull(element, nameof(element));
            ArgumentNullException.ThrowIfNull(element.Id, nameof(element.Id));

            var log_DAL = context.Logs.Find(element.Id);
            if (log_DAL == null)
                throw new ArgumentException("Le log n'existe pas en base de données", nameof(element.Id));

            log_DAL.IP = element.IP;
            log_DAL.DateAppel = element.DateAppel;
            context.SaveChanges();
            return element;
        }
    }
}
