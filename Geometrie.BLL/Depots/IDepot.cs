using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometrie.BLL.Depots
{
    public interface IDepot<T>
    {
        T? GetById(int id);
        IEnumerable<T> GetAll();
        T Add(T element);
        T Update(T element);
        IDepot<T> Delete(T element);
        IDepot<T> Delete(int Id);
    }
}
