using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dependencies.Repositories.Comman
{
    public class PageList<T>
    {
        public int TotalPage { get; set; }
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public List<T> Items { get; set; }


        public async Task<PageList<T>> GetPageList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();

            List<T> items = source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            TotalPage = (int)Math.Ceiling((double)count/ pageSize);
            TotalCount = count;
            CurrentPage = pageNumber;
            Items = items ?? new List<T> ();

            return this;
        }
    }
}
