using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using eTicaret.Domain.Entities;
using eTicaret.Domain.ValueObjects;

namespace eTicaret.Infrastructure.Persistence.Context
{
    public class eTicaretDbContext : DbContext
    {
        public eTicaretDbContext(DbContextOptions<eTicaretDbContext> option) : base(option)
        {            
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.HasIndex(u => u.Email).IsUnique();
                entity.OwnsOne(a => a.Address, address =>
                {
                    address.Property(a => a.Title).HasColumnName("HomeAddress_Title").IsRequired();
                    address.Property(a => a.City).HasColumnName("HomeAddress_City").IsRequired();
                    address.Property(a => a.FullAddress).HasColumnName("HomeAddress_FullAddress").IsRequired();                    
                    address.Property(a => a.District).HasColumnName("HomeAddress_District").IsRequired();
                    address.Property(a => a.ZipCode).HasColumnName("HomeAddress_ZipCode").IsRequired();
                });
            });
        }
    }
}
