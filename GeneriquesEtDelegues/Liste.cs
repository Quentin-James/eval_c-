using GeneriquesEtDelegues;
using System.Collections;

//je veux pouvoir faire des for et des foreach sur ma liste
internal class Liste<T> : IEnumerable<T>
{
    private readonly ArrayList list;

    public int Count => list.Count;
    public T this[int index] => (T)list[index];
    
    public Liste()
    {
        list = new ArrayList();
    }
    public void Ajouter(T element)
    {
        list.Add(element);
    }

    public IEnumerator<T> GetEnumerator() 
        => list.OfType<T>().GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
        => GetEnumerator();

    public void Trier(DelegueQuiCompareDeuxMachins<T> test)
    {
        if (test == null)
            throw new System.ArgumentNullException(nameof(test));

        //tri par inversion
        //on va convertir les T en int
        //et comparer les int
        for (int i = 0; i < list.Count -1 ; i++)
        {
            for (int j = i + 1; j < list.Count; j++)
            {
                if (test((T)list[i],(T)list[j]))
                {
                    var temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                }
            }
        }
    }
}