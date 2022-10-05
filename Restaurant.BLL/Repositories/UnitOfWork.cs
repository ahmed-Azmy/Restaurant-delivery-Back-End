using Restaurant.BLL.Interfaces;
using Restaurant.DAL.Contexts;
using Restaurant.DAL.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RestaurantDeliveryContext restaurantContext;
        private Hashtable _repository;

        public UnitOfWork(RestaurantDeliveryContext RestaurantContext)
        {
            restaurantContext = RestaurantContext;
        }
        public async Task<int> Complete()
        {
            return await restaurantContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            restaurantContext.Dispose();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repository == null)
                _repository = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repository.ContainsKey(type))
            {
                var repository = new GenericRepository<TEntity>(restaurantContext);
                _repository.Add(type, repository);
            }

            return (IGenericRepository<TEntity>)_repository[type];
        }
    }
}
