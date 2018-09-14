using Library.DAL.Filters;
using Library.DAL.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;

namespace Library.DAL.EFGenericRepository
{
    [ExceptionLogger]
    public class EFGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        protected DbSet<TEntity> _dbSet;

        public EFGenericRepository(DbContext context)
        {
            _context = context;
        }

        [ExceptionLogger]
        public TEntity FindById(int id)
        {
            try
            {
                return entities.Find(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [ExceptionLogger]
        public void Create(TEntity item)
        {
            try
            {
                entities.Add(item);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [ExceptionLogger]
        public void Update(TEntity item)
        {
            try
            {
                _context.Entry(item).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [ExceptionLogger]
        public void Remove(TEntity item)
        {
            try
            {
                entities.Remove(item);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual IQueryable<TEntity> Table
        {
            get
            {
                return entities;
            }
        }

        protected IDbSet<TEntity> entities
        {
            get
            {
                if (_dbSet == null)
                {
                    _dbSet = _context.Set<TEntity>();
                }
                return _dbSet;
            }
        }
    }


}
