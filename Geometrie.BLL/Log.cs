using Geometrie.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometrie.BLL
{
    public class Log
    {
        public int? Id { get; set; }
        public string IP { get; set; }
        public DateTime DateAppel { get; set; }

        public Log(string ip)
        {
            IP = ip;
            DateAppel = DateTime.Now;
        }

        public Log(int? id, string ip, DateTime dateAppel)
            : this(ip)
        {
            Id = id;
            DateAppel = dateAppel;
        }

        public override string ToString() {
            return $"Id: {Id}, IP: {IP}, DateAppel: {DateAppel}";
        }

        internal Log_DAL ToDAL()
        {
            return new DAL.Log_DAL()
            {
                Id = Id,
                IP = IP,
                DateAppel = DateAppel
            };
        }
    }
}
