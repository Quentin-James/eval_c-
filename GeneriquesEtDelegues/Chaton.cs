using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneriquesEtDelegues
{
    public class Chaton
    {
        public string Nom { get; set; }

        public bool Miaou(string a, string b)
        {
            if(a.Length < b.Length)
            {
                Console.WriteLine("Miaou");
                return true;
            }

            return false;
        }
    }
}
