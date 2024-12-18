using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RappelSyntaxe
{
    internal static class Outils
    {
        /// <summary>
        /// une méthode d'extension qui met une majuscule au début de chaque mot
        /// Notez l'utilisation de this devant le premier paramètre
        /// C'est ça qui indique que c'est une méthode d'extension du type string
        /// </summary>
        /// <param name="phrase"></param>
        /// <returns></returns>
        public static string MajusculeAuDebutDesMots(this string phrase)
        {
            var mots = phrase.Split(' ');
            for (int i = 0; i < mots.Length; i++)
            {
                if (mots[i].Length > 0)
                {
                    mots[i] = char.ToUpper(mots[i][0]) + mots[i].Substring(1);
                }
            }
            return string.Join(" ", mots);
        }
    }
}
