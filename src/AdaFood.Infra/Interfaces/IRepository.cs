
using AdaFood.Domain.Models;

namespace AdaFood.Infra.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(int id);
        IEnumerable<T> GetAll();
        T Get(int id);
    }
}
