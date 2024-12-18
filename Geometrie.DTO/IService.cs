using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometrie.DTO
{
    public interface IService<T>
    {
        T? GetById(int id);
        IEnumerable<T> GetAll();
        T Add(T element);
        T Update(T element);
        IService<T> Delete(T element);
        IService<T> Delete(int Id);
    }
}
