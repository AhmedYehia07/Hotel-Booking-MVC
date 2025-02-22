﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        public Task<List<T>> GetAllAsync(Expression<Func<T,bool>>? filter = null,string? IncludeProperties = null);
        public Task<T> GetAsync(Expression<Func<T,bool>>? filter = null,string? IncludeProperties = null);
        public Task CreateAsync(T entity);
        public Task CreateRangeAsync(List<T> entity);
        public Task RemoveAsync(T entity);
    }
}
