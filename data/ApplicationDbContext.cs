using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi.models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace webapi.data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Portifolio> Portifolios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Portifolio>(x => x.HasKey(p => new { p.AppUserId, p.Id_Stock }));

            modelBuilder.Entity<Portifolio>()
                        .HasOne(s => s.AppUser)
                        .WithMany(i => i.Portifolios)
                        .HasForeignKey(s => s.AppUserId);

            modelBuilder.Entity<Portifolio>()
                        .HasOne(s => s.Stock)
                        .WithMany(i => i.Portifolios)
                        .HasForeignKey(s => s.Id_Stock);

            base.OnModelCreating(modelBuilder);

            /* Creating Basic roles */
            List<IdentityRole> roles = new List<IdentityRole>{
                new IdentityRole{
                    Id = "1",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole{
                    Id = "2",
                    Name = "User",
                    NormalizedName = "USER"
                }
            };

            modelBuilder.Entity<IdentityRole>().HasData(roles);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Stock)
                .WithMany(s => s.Comments)
                .HasForeignKey(c => c.Id_Stock)
                .HasConstraintName("FK_Comment_Stock")
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Stock>()
                .HasOne(s => s.Industry)
                .WithMany(i => i.Stocks)
                .HasForeignKey(s => s.Id_Industry)
                .HasConstraintName("FK_Stock_Industry")
                .OnDelete(DeleteBehavior.Restrict);

/*             modelBuilder.Entity<Comment>()
                        .HasOne(c => c.AppUser)
                        .WithOne(s => s.Comments)
                        .HasForeignKey(c => c.AppUserId)
                        .HasConstraintName("FK_Comment_User"); */
        }

    }
}