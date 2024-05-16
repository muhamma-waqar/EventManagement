using Domain.Entities;
using Infrastructure.Identity.Core.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class EventDbContext : IdentityDbContext
    {
        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventUser> EventUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            string ADMIN_ID = "02174cf0–9412–4cfe - afbf - 59f706d72cf6";
            string USER_ID = Guid.NewGuid().ToString();

            base.OnModelCreating(builder);

            builder.Entity<Event>().ToTable("Events")
                .HasOne<EventUser>()
                .WithMany(i => i.Events)
                .HasForeignKey(i => i.UserId);

            builder.Entity<IdentityRole>().HasData(new List<IdentityRole> { new IdentityRole { Id = ADMIN_ID, Name = "Admin", ConcurrencyStamp = ADMIN_ID, NormalizedName = "ADMIN" }, new IdentityRole { Id = USER_ID, Name = "User", ConcurrencyStamp = USER_ID, NormalizedName = "USER" } });

            var appUsers = new List<EventUser> {
                new EventUser
                {
                    Id = ADMIN_ID,
                    Email = "waqar.netdev@gmail.com",
                    EmailConfirmed = true,
                    UserName = "waqar.netdev@gmail.com",
                    NormalizedUserName = "WAQAR.NETDEV@GMAIL.COM",
                    AccessFailedCount = 0,
                    ConcurrencyStamp = ADMIN_ID,
                    LockoutEnabled = true,
                    NormalizedEmail = "WAQAR.NETDEV@GMAIL.COM",
                    PhoneNumber = "021345",
                    SecurityStamp = ADMIN_ID,
                    PhoneNumberConfirmed = true,
                },
                new EventUser
                {
                    Id = USER_ID,
                    Email = "waqar@gmail.com",
                    EmailConfirmed = true,
                    UserName = "waqar@gmail.com",
                    NormalizedUserName = "WAQAR@GMAIL.COM",
                    AccessFailedCount=0,
                    ConcurrencyStamp = ADMIN_ID,
                    LockoutEnabled = true,
                    NormalizedEmail = "WAQAR@GMAIL.COM",
                    PhoneNumber = "021345",
                    SecurityStamp = ADMIN_ID,
                    PhoneNumberConfirmed = true,
                }
            };

            PasswordHasher<EventUser> ph = new PasswordHasher<EventUser>();
            foreach(var user in appUsers)
            {
                if(user.Id == USER_ID)
                {
                    user.PasswordHash = ph.HashPassword(user, "User123");
                }
                if(user.Id == ADMIN_ID)
                {
                    user.PasswordHash = ph.HashPassword(user, "Admin123");
                }
            }

            builder.Entity<EventUser>().HasData(appUsers);

            builder.Entity<IdentityUserRole<string>>().HasData(new List<IdentityUserRole<string>> { new IdentityUserRole<string> { RoleId = ADMIN_ID, UserId = ADMIN_ID }, new IdentityUserRole<string> { RoleId = USER_ID, UserId = USER_ID } });
        }
    }
}
