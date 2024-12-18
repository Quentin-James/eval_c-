using RappelSyntaxe;

//commentaire
/* commentaire
 * commentaire
 * commentaire
 */

//déclaration de variable

int a;
//dfslfjd
a = 5;
if (true)
{
    int b = 3;
}


//Inférence de type
var c = "5";
var d = new InvalidCastException();
InvalidCastException e = new();

//type anonyme
var voiture = new { Marque = "Renault", Modele = "Clio" };
Console.WriteLine(voiture.Marque);

//type nullable
//sur les types par valeur c'est obligatoire
//si on veut que la variable soit null
int? f = null;
bool? bb = null;
//sur les types par référence c'est optionnel
//si on veut que la variable soit null
//Ca enlève des warning et c'est une bonne indication
//pendant le codage
string? s = null;

//type dynamique
//on peut changer le type de la variable
//a n'utiliser que si on ne peut pas faire autrement
dynamic g = 5;
g = "5";
g = new InvalidCastException();

//tableau
int[] tab = new int[5];
tab[0] = 5;
//syntaxe rapide d'affectation
int[] tab2 = { 1, 2, 3, 4, 5 };
//tableau multidimensionnel
int[,] tab3 = new int[2, 3];
tab3[0, 0] = 1;
//tableau de tableau
int[][] tab4 = new int[2][];
tab4[0] = new int[3];
tab4[0][0] = 1;
tab4[0][1] = 2;

//Liste
List<int> liste = new List<int>();
liste.Add(5);
//syntaxe rapide d'affectation
List<int> liste2 = new List<int> { 1, 2, 3, 4, 5 };

//Méthode d'extension
//on ajoute une méthode à une classe sans la modifier
var chaine = "une chaine de caractères";
 Console.WriteLine(chaine.MajusculeAuDebutDesMots());

//LINQ
// Language INtegrated Query
//C'est un ensemble de méthodes d'extension sur IEnumerable<T>
//Ca permet de manipuler les listes, tableaux etc...
//de manière plus simple et plus lisible
var listeDEntiers = new List<int>() { 1, 6, 9, 3, -5, -4, 8 };
//on veut les entiers positifs
//var lesPositifs = new List<int>();
//foreach (var item in listeDEntiers)
//{
//    if (item > 0)
//    {
//        lesPositifs.Add(item);
//    }
//}
//var lesPositifs = from i in listeDEntiers
//                  where i > 0
//                  select i;
var lesPositifs = listeDEntiers.Where(i => i > 0).ToList();

var uneAutreListe = new List<int>() { 6, 8, 3, -2, 9, 7 };

//je cherche les éléments communs
var entierCommuns = listeDEntiers.Intersect(uneAutreListe).ToList();