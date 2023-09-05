using Core.Entities;
using Core.Exceptions;
using Core.Interfaces;
using Core.Interfaces.Repositories;

namespace Core.Managers
{
    public class Manager<EntityT, ViewModelT>
        where EntityT : Entity
        where ViewModelT : IModel
    {
        private readonly IRepository<EntityT> _repository;
        protected virtual IRepository<EntityT> Repository { get => _repository; }


        protected readonly string _entityName = typeof(EntityT).Name;
        public Manager(IRepository<EntityT> repository) { _repository = repository; }


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
                throw new NotFoundException($"{_entityName} with id:{id} was not found and therefore cannot be deleted");
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
                throw new NotFoundException($"{_entityName} with id:{id} was not found and therefore cannot be updated");
            }
            return entity;
        }

        public virtual ViewModelT viewModelParser(ViewModelT viewModel) { return viewModel; }
    }
}
