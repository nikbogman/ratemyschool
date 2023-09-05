using Core.Interfaces;
using Core.Entities;
using Core.Interfaces.Repositories;

namespace Tests.MockRepositories
{
    public class MockRepository<EntityT>: IRepository<EntityT> where EntityT : Entity
    {
        protected readonly List<EntityT> _mockData = new();

        public bool Delete(Guid id)
        {
            var entity = _mockData.Find(entity => entity.Id == id);
            if (entity == null) return false;
            _mockData.Remove(entity);
            return !_mockData.Contains(entity);
        }

        public bool Insert(EntityT entity)
        {
            _mockData.Add(entity);
            return _mockData.Contains(entity);
        }

        public IEnumerable<EntityT> SelectAll() => _mockData;

        public EntityT? SelectOne(Guid id) => _mockData.Find(entity => entity.Id == id);

        public bool Update(EntityT entity)
        {
            var old = _mockData.Find(e => e.Id == entity.Id);
            if (old == null) return false;
            int idx = _mockData.IndexOf(old);
            _mockData.Remove(old);
            _mockData.Insert(idx, entity);
            return _mockData.Contains(entity);
        }
    }
}
