﻿using Microsoft.EntityFrameworkCore;
using Restaurant.BLL.Interfaces;
using Restaurant.BLL.Specifications;
using Restaurant.DAL.Contexts;
using Restaurant.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly RestaurantDeliveryContext context;

        public GenericRepository(RestaurantDeliveryContext context)
        {
            this.context = context;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
          => await context.Set<T>().ToListAsync();

        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec)
            => await ApplySpecifications(spec).ToListAsync();


        public async Task<T> GetAsync(int Id)
          => await context.Set<T>().FindAsync(Id);

        public async Task<int> GetCountAsync(ISpecification<T> spec)
        => await ApplySpecifications(spec).CountAsync();

        public async Task<T> GetEntityWithSpecAsync(ISpecification<T> spec)
          => await ApplySpecifications(spec).FirstOrDefaultAsync();

        public async Task Add(T entity)
        => await context.Set<T>().AddAsync(entity);
        public void Update(T entity)
        => context.Set<T>().Update(entity);
        public void Delete(T entity)
        => context.Set<T>().Remove(entity);

        private IQueryable<T> ApplySpecifications(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(context.Set<T>(), spec);
        }
    }
}
