using Domain.Dependencies.Repositories.Comman;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dependencies.Comman
{
    public class Repository<T> : IRepository<T> where T : class 
    {
        private readonly DbSet<T> _DbSet;

        public Repository(DbSet<T> dbSet)
        {
            _DbSet = dbSet;
        }
        public Task<T> Add(T entity)
        {
            if(entity == null) throw new ArgumentNullException(nameof(entity));
            _DbSet.Add(entity);
            return Task.FromResult(entity);
        }

        public async void Delete(int Id)
        {
            var result = await _DbSet.FindAsync(Id);
            if(result != null) { throw  new ArgumentNullException(nameof(result)); }
            _DbSet.Remove(result);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var results = await _DbSet.ToListAsync();
            if(results.Count < 0) { throw new Exception("No record found"); }
            return results;
        }

        public async Task<T> GetById(int Id)
        {
            var result = await _DbSet.FindAsync(Id);
            if (result is null) throw new Exception("No record found");
            return result;
        }

        public Task<T> Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _DbSet.Update(entity);
            return Task.FromResult(entity);
        }
    }
}
