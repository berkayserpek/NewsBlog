using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<UserPerson, UserRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-BR4E36S8;database=NewsDB;user=sa;password=berkay345..;integrated security=true;");
            optionsBuilder.EnableSensitiveDataLogging();
        }
        public DbSet<UserPerson> Users { get; set; }
        public DbSet<New> News { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserPerson>().Property(x => x.Id).IsConcurrencyToken();
        }
    }
}
