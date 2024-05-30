using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public interface IRedisCacheService
    {
        public void Set<T>(string key, T value);
        public IEnumerable<T> Get<T>(string key);
    }
}
