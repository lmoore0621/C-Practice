using Books.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;

namespace Books.Models.Data
{
    public class DataSource : DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Configure(modelBuilder.Entity<Book>());
        }

        public void Configure(EntityTypeConfiguration<Book> entity)
        {
            entity.ToTable("Books");
            entity.HasKey(b => b.Id);
            entity.Property(b => b.AuthorFirstName).HasMaxLength(50).IsRequired();
            entity.Property(b => b.AuthorLastName).HasMaxLength(50).IsRequired();
            entity.Property(b => b.Copyright).HasColumnType("int");
        }
    }
}