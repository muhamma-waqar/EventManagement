using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Core.Services
{
    public interface IUserProvider
    {
        string GetUserId();
    }
}
