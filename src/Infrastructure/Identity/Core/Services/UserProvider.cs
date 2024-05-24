using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Core.Services
{
    public class UserProvider : IUserProvider
    {
        private readonly IHttpContextAccessor _context;
        public UserProvider(IHttpContextAccessor context) 
        {
            this._context = context;
        }

        public string GetUserId()
        {
           var userId =this._context.HttpContext.User.Claims.FirstOrDefault(i => i.Type == "sub")?.Value;
            return userId;
        }
    }
}
