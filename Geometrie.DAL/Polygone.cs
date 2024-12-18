using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometrie.DAL
{
    public class Polygone
    {
        public int? Id { get; set; }

        public DateTime DateDeCreation { get; set; }
        public DateTime? DateDeModification { get; set; }

        //pour faire la relation 1-n avec Point
        public ICollection<Point_DAL> Points { get; set; }

        /// <summary>
        /// Quand j'ai des ICollection pour les relations
        /// je les initialise dans le constructeur
        /// </summary>
        public Polygone()
        {
            Points = new HashSet<Point_DAL>();
        }
    }
}
