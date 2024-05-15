using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dependencies.Repositories.Comman
{
    public interface IRepository<T> where T : class
    {
        Task<T> Add(T entity);
        void Delete(int Id);
        Task<T> Update(T entity);
        Task<IEnumerable<T>> GetAll();
        Task DeleteAll();
        Task<IEnumerable<T>> GetById();
    }
}
