using Core.Entities;
using Core.Exceptions;
using Core.Interfaces.RepositoryInterfaces;
using System.Diagnostics;
using Core.Interfaces;

namespace Core.Managers
{
    public class BaseManager<EntityT, ViewModelT>
        where EntityT : BaseEntity
        where ViewModelT : IViewModel
    {
        private readonly IRepository<EntityT> _repository;
        protected virtual IRepository<EntityT> Repository { get => _repository; }


        protected readonly string _entityName = typeof(EntityT).Name;
        public BaseManager(IRepository<EntityT> repository) { _repository = repository; }


        public virtual EntityT CreateOne(ViewModelT viewModel)
        {
            ViewModelT validViewModel = viewModelParser(viewModel);
            EntityT entity = (EntityT)Activator.CreateInstance(typeof(EntityT), validViewModel)!;
            entity.GenerateId();
            if (!_repository.Insert(entity))
            {
                throw new Exception($"Something went wrong while inserting {_entityName}");
            }
            return entity;
        }

        public virtual IEnumerable<EntityT> GetAll()
        {
            return _repository.SelectAll();
        }

        public virtual EntityT GetOneById(Guid id)
        {
            EntityT? entity = _repository.SelectOne(id);
            if (entity == null)
            {
                throw new NotFoundException($"{_entityName} with id:{id} was not found");
            }
            return entity;
        }

        public virtual void DeleteOne(Guid id)
        {
            if (!_repository.Delete(id))
            {
                throw new NotFoundException($"{_entityName} with id:{id} was not found in order to be deleted");
            }
            return;
        }

        public virtual EntityT UpdateOne(Guid id, ViewModelT viewModel)
        {
            ViewModelT validViewModel = viewModelParser(viewModel);
            EntityT entity = (EntityT)Activator.CreateInstance(typeof(EntityT), validViewModel)!;
            entity.SetId(id);
            if (!_repository.Update(entity))
            {
                throw new NotFoundException($"{_entityName} with id:{id} was not found in order to be updated");
            }
            return entity;
        }

        public virtual ViewModelT viewModelParser(ViewModelT viewModel) { return viewModel; }
    }
}
