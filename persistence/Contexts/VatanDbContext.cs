using domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace persistence.Contexts
{
    public class VatanDbContext : IdentityDbContext<User>
    {
        public VatanDbContext(DbContextOptions<VatanDbContext> options):base(options)
        {
          //  Database.EnsureCreated();
        }
      //  public DbSet<User> User { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<Post> Posts { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Category>().HasOne(x=>x.Parent).WithMany(x => x.SubCategories)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Post>().HasOne(b => b.Banner).WithOne(p => p.Post).HasForeignKey<Banner>(p => p.PostId);
        }
    }
}
