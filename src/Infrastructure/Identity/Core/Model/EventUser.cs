using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity.Core.Model
{
    public class EventUser : IdentityUser
    {
        public virtual ICollection<Event> Events { get; set; }
    }
}
