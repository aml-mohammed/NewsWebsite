using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public class DataContext:IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions<DataContext>options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
           
            builder.Entity<News>()
                 .HasOne(i => i.Author)
                 .WithMany()
                 .HasForeignKey(i => i.AuthorId);
            base.OnModelCreating(builder);
        }

        public DbSet<News> News { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
