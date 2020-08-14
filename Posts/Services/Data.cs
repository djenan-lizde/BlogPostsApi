using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Posts.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Posts.Services
{
    public class Data<T> : IData<T> where T : class, IEntity
    {
        protected readonly PostsDbContext _context;
        protected readonly DbSet<T> _entity;
        protected readonly IMapper _mapper;

        public Data(PostsDbContext context, IMapper mapper)
        {
            _context = context;
            _entity = context.Set<T>();
            _mapper = mapper;
        }

        public List<T> Get()
        {
            return _entity.AsNoTracking().ToList();
        }
        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> predicate)
        {
            return _entity.AsNoTracking().Where(predicate);
        }
        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _entity.FirstOrDefault(predicate);
        }
        public T Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity");
            }

            var x = _entity.Add(entity);
            _context.SaveChanges();
            return x.Entity;
        }
        public T Update(int Id, T entity)
        {
            var e = _entity.Find(Id);

            if (e == null)
                return null;

            _entity.Attach(e);
            _entity.Update(e);
            _mapper.Map(entity, e);

            _context.SaveChanges();
            return _mapper.Map<T>(entity);
        }
        public T Delete(int Id)
        {
            var entity = _entity.Find(Id);

            if (entity == null)
                return null;

            _entity.Remove(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
