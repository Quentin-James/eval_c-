using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Geometrie.DAL
{
    public class Log_DAL
    {
        public int? Id { get; set; }

        //la longueur d'une IP V6
        [StringLength(39)]
        public string IP { get; set; }
        public DateTime DateAppel { get; set; }
    }
}
