using Infrastructure.Identity.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Core.Services
{
    public interface IUserService
    {
        Task<(MySignInResult result, SignInData? data)> SignIn(string username, string password);
    }
}
