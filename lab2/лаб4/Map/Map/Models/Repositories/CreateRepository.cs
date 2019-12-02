using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Map.Models.Repositories;
using Map.Models;

namespace Map.Models.Repositories
{
    public abstract class CreateRepository<T> : IRepository<T>
    {
        protected MainContext _context;

        public CreateRepository(MainContext context)
        {
            _context = context;
        }

        public abstract void Add(T entity);

        public abstract void Delete(T entity);

        public abstract void Edit(T entity);

        public abstract T GetById(int id);

        public abstract List<T> List();

        public abstract List<T> List(Expression<Func<T, bool>> predicate);
    }
}
