using GeneriquesEtDelegues;
using System.Linq;

var liste = new Liste<int>();
liste.Ajouter(5);
liste.Ajouter(8);
liste.Ajouter(3);
liste.Ajouter(1);
liste.Ajouter(9);
liste.Ajouter(4);

foreach (var element in liste)
{
    Console.WriteLine(element);
}
//for
for (int i = 0; i < liste.Count; i++)
{
    Console.WriteLine(liste[i]);
}

//tri
Console.WriteLine("tri");
liste.Trier((i, j) => i % 3 == 0 && j % 3 != 0);

Console.WriteLine("après tri");
foreach (var element in liste)
{
    Console.WriteLine(element);
}

//une liste de string
var listeString = new Liste<string>();
listeString.Ajouter("totodsqlk");
listeString.Ajouter("titiqsùdùsmqdlù");
listeString.Ajouter("tataqsmdmqsdmksqmdqskm");
foreach (var element in listeString)
{
    Console.WriteLine(element);
}
//tri
//listeString.Trier(delegate (string a, string b) { return a.Length < b.Length; });
listeString.Trier((a, b) => a.Length < b.Length);

foreach (var item in listeString)
{
    Console.WriteLine(item);
}
