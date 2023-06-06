﻿using Core.Entities;
using Core.Exceptions;
using Core.Interfaces;
using System.Diagnostics;

namespace Core.Managers
{
    public class BaseManager<EntityT, ViewModelT> 
        where EntityT : BaseEntity 
        where ViewModelT : IViewModel
    {
        private readonly IRepository<EntityT> _repository;
        protected virtual IRepository<EntityT> getRepository() { return _repository; }


        protected readonly string _entityName = typeof(EntityT).Name;
        public BaseManager(IRepository<EntityT> repository) { _repository = repository; }
        

        public virtual EntityT CreateOne(ViewModelT viewModel)
        {
            try
            {
                ViewModelT validViewModel = viewModelParser(viewModel);
                EntityT entity = (EntityT)Activator.CreateInstance(typeof(EntityT), validViewModel)!;
                entity.GenerateId();
                if (!_repository.Insert(entity))
                {
                    throw new Exception("");
                }
                return entity;
            }
            catch (DataAccessException ex)
            {
                Debug.WriteLine(ex.Message);
                throw new InternalServerException(ex);
            }
            catch (Exception) { throw; }
        }

        public virtual IEnumerable<EntityT> GetAll()
        {
            try
            {
                return _repository.SelectAll();
            }
            catch (DataAccessException ex)
            {
                Debug.WriteLine(ex.Message);
                throw new InternalServerException(ex);
            }
            catch (Exception) { throw; }
        }

        public virtual EntityT GetOneById(Guid id)
        {
            try
            {
                EntityT? entity = _repository.SelectOne(id);
                if (entity == null)
                {
                    throw new NotFoundException();
                }
                return entity;
            }
            catch (DataAccessException ex)
            {
                Debug.WriteLine(ex.Message);
                throw new InternalServerException(ex);
            }
            catch (Exception) { throw; }
        }

        public virtual void DeleteOne(Guid id)
        {
            try
            {
                if (!_repository.Delete(id))
                {
                    throw new NotFoundException();
                }
                return;
            }
            catch (DataAccessException ex)
            {
                Debug.WriteLine(ex.Message);
                throw new InternalServerException(ex);
            }
            catch (Exception) { throw; }
        }

        public virtual EntityT UpdateOne(Guid id, ViewModelT viewModel)
        {
            try
            {
                ViewModelT validViewModel = viewModelParser(viewModel);
                EntityT entity = (EntityT)Activator.CreateInstance(typeof(EntityT), validViewModel)!;
                entity.SetId(id);
                if (!_repository.Update(entity))
                {
                    throw new NotFoundException();
                }
                return entity;
            }
            catch (DataAccessException ex)
            {
                Debug.WriteLine(ex.Message);
                throw new InternalServerException(ex);
            }
            catch (Exception) { throw; }
        }

        protected virtual ViewModelT viewModelParser(ViewModelT viewModel) { return viewModel; }
    }
}
