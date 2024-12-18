using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneriquesEtDelegues
{
    /// <summary>
    /// Délégué qui compare deux machins et renvoie un booléen
    /// pour coder la comparaison que l'on veut 
    /// </summary>
    /// <typeparam name="TypeDeMachin">Type sur lequel on travaille</typeparam>
    /// <param name="machin1">premier machin à comparer</param>
    /// <param name="machin2">deuxième machin à comparer</param>
    /// <returns>le résultat de la comparaison</returns>
    public delegate bool DelegueQuiCompareDeuxMachins<TypeDeMachin>(TypeDeMachin machin1, TypeDeMachin machin2);
}
