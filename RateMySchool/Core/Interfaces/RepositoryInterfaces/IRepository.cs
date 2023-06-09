using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.RepositoryInterfaces
{
    public interface IRepository<EntityT> where EntityT : IEntity
    {
        public IEnumerable<EntityT> SelectAll();
        public EntityT? SelectOne(Guid id);
        public bool Insert(EntityT entity);
        public bool Update(EntityT entity);
        public bool Delete(Guid id);
    }
}
