﻿using PhamaMicroCrm.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PhamaMicroCrm.Data.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Add(TEntity entity);

        Task<TEntity> GetById(Guid id);

        Task<List<TEntity>> GetAll();

        Task Update(TEntity entity);

        Task Remove(Guid id);

        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate);

        Task<int> SaveChanges();
    }
}
