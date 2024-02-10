
using AdaFood.Domain.Models;
using AdaFood.Infra.Interfaces;

namespace AdaFood.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        internal List<T> _entities = new();
        private int _nextId = 1;

        public bool Add(T entityToAdd)
        {
            if (!_entities.Any(existingEntity => existingEntity.GetType().GetProperties()
                .Where(prop => prop.Name != "Id")
                .All(prop => object.Equals(prop.GetValue(existingEntity), prop.GetValue(entityToAdd)))))
            {
                entityToAdd.Id = _nextId++;
                _entities.Add(entityToAdd);
                return true;
            }

            throw new Exception($"{nameof(T)} with same properties already exists.");
        }

        public T Get(int id)
        {
            return _entities.FirstOrDefault(t => t.Id == id);
        }

        public bool Update(T entity)
        { 
            if (_entities.FirstOrDefault(e => e.Id == entity.Id) is T existingEntity)
            {
                typeof(T)
                    .GetProperties()
                    .Where(prop => prop.Name != "Id")
                    .ToList()
                    .ForEach(prop => prop.SetValue(existingEntity, prop.GetValue(entity)));
                return true;
            }

            throw new Exception($"{nameof(T)} not found. Update didn't happen.");
        }

        public bool Delete(int id)
        {
            if (_entities.FirstOrDefault(existingEntity => existingEntity.Id == id) is T entityToRemove)
            {
                _entities.Remove(entityToRemove);
                return true;
            }

            throw new Exception($"{nameof(T)} not found. Deletion didn't happen.");
        }

        public IEnumerable<T> GetAll()
        {
            return _entities;
        }
    }
}
