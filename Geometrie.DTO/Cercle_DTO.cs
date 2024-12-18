using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometrie.DTO
{
    public class Cercle_DTO
    {
        public int? Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public double Rayon { get; set; }
        public DateTime DateDeCreation { get; set; }
        public DateTime? DateDeModification { get; set; }
    }
}