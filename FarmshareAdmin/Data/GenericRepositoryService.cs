using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

using mdl = FarmshareAdmin.Models;

/*
 *  This class provides generic methods for use by any entity in the ACF_SharedEntities dbset.
 */


namespace FarmshareAdmin.Data
{
    public class GenericRepositoryService<TEntity> where TEntity : class
    {

        internal mdl.ACF_FarmshareContext _context;
        internal DbSet<TEntity> dbSet;

        public GenericRepositoryService(mdl.ACF_FarmshareContext context)
        {
            _context = context;
            dbSet = _context.Set<TEntity>();
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

    }
}