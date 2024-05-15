using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Core.Model
{
    public enum MySignInResult
    {
        Failed,
        Success,
        LockedOut,
        NotAllowed
    }
}
