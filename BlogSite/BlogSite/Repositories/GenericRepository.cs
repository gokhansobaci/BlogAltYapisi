using BlogSite.Data;
using BlogSite.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BlogSite.Repositories
{
    public abstract class GenericRepository<T> where T : BaseEntity
    {
        protected BlogContext _context = BlogContext.Instance;
        protected DbSet<T> _set;
        public GenericRepository()
        {
           
            _set = _context.Set<T>();   
        }

        public void Create(T entity) => _set.Add(entity); 
        public T Read(object key) => _set.Find(key);
        public  IEnumerable<T> Read(Expression<Func<T, bool>> expression = null, string[] includes = null)
        {
            IQueryable<T> data = expression !=null ? _set.Where(expression): _set;
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    data = data.Include(include); 
                }
            }
            return data;  
        }

        public void Update(T entity) => _context.Entry(entity).State = EntityState.Modified;

        public void Delete(T entity) => _set.Remove(entity);

        public void Save() => _context.SaveChanges(); 

        //Ekstras
        //Not : Burada yumuşak silme yaptık bu eylem silinen verinin bizde kalıp müşteride silindi göstermesini sağlar.
        public void SoftDelete(T entity)
        {
            entity.Deleted = true; 
            entity.Active = false;
            Update(entity); 
        }

        public void Toggle(T entity)
        {
            entity.Active = !entity.Active;
            Update(entity);
        }

        public bool Exists(Func<T, bool> func) => _set.Any(func); 
        public int Count(Func<T,bool> func) => _set.Count(func);




    }
}